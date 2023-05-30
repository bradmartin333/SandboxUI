using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace SEYRProcessingDocs
{
    internal class Feature
    {
        public enum NullDetectionTypes
        {
            None,
            Include_Empty,
            Include_Filled,
            Include_Both,
        }

        public float NullFilterPercentage { get; set; } = 0.1f;
        public NullDetectionTypes NullDetection { get; set; } = NullDetectionTypes.None;

        public float Threshold { get; set; } = 0.75f;

        public Color Chroma { get; set; }
        public float RedChroma => Chroma.R / 255f;
        public float GreenChroma => Chroma.G / 255f;
        public float BlueChroma => Chroma.B / 255f;
    }

    internal class Program
    {
        public static float Scaling { get; set; } = 0.35f;

        static void Main(string[] args)
        {
            Feature feature = new Feature { Chroma = Color.FromArgb(255, 0, 255) };

            Bitmap bmp = new Bitmap("raw.png");
            Size rawSize = bmp.Size;

            ResizeAndRotate(ref bmp);
            bmp.Save("resized.png");

            GetChromaFilter(bmp, feature).Save("chroma.png");

            (byte[] vals, int empty, int filled, float score) = GetPixelData(ref bmp, feature);
            bmp.Save("out.png");

            string compression = Compress(vals);
            byte[] data = Decompress(compression);
            Rectangle rect = new Rectangle(0, 0, (int)(Scaling * rawSize.Width), (int)(Scaling * rawSize.Height));
            rect = new Rectangle(rect.X, rect.Y, rect.Width + (rect.Width * 3 % 4), rect.Height);
            Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            int idx = 0;
            for (int j = 0; j < rect.Height; j++)
            {
                for (int i = 0; i < rect.Width; i++)
                {
                    if (idx >= data.Length) break; // Hack for protection against corrupted files
                    byte val = data[idx];
                    bitmap.SetPixel(i, j, Color.FromArgb(val, val, val));
                    idx++;
                }
            }
            bitmap.Save("compressed.png");

            int filterVal = (int)(feature.NullFilterPercentage * (bmp.Width * bmp.Height));
            if (filled < filterVal || empty < filterVal)
            {
                switch (feature.NullDetection)
                {
                    case Feature.NullDetectionTypes.None:
                        Console.WriteLine($"Score is -10f");
                        break;
                    case Feature.NullDetectionTypes.Include_Empty:
                        if (empty < filterVal) Console.WriteLine($"Score is 0f");
                        else Console.WriteLine($"Score is -10f");
                        break;
                    case Feature.NullDetectionTypes.Include_Filled:
                        if (filled < filterVal) Console.WriteLine($"Score is 0f");
                        else Console.WriteLine($"Score is -10f");
                        break;
                    case Feature.NullDetectionTypes.Include_Both:
                        Console.WriteLine($"Score is 0f");
                        break;
                    default:
                        Console.WriteLine($"Score is -10f");
                        break;
                }
            }
            else
                Console.WriteLine($"Score is {score}");
            Console.ReadKey();
        }

        private static string Compress(byte[] data)
        {
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Fastest))
                dstream.Write(data, 0, data.Length);
            return Convert.ToBase64String(output.ToArray());
        }

        public static byte[] Decompress(string compressed)
        {
            byte[] data = Convert.FromBase64String(compressed);
            MemoryStream input = new MemoryStream(data);
            MemoryStream output = new MemoryStream();
            using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
            {
                dstream.CopyTo(output);
            }
            return output.ToArray();
        }

        private static Bitmap GetChromaFilter(Bitmap bmpIn, Feature f)
        {
            Bitmap bmp = (Bitmap)bmpIn.Clone();
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color c = bmp.GetPixel(i, j);
                    Color c2 = Color.FromArgb((int)(c.R * f.RedChroma), (int)(c.G * f.GreenChroma), (int)(c.B * f.BlueChroma));
                    bmp.SetPixel(i, j, c2);
                }
            }
            return bmp;
        }

        private static (byte[], int, int, float) GetPixelData(ref Bitmap bmp, Feature f)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int bytes = Math.Abs(bmpData.Width * 3) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);

            float t = f.Threshold * 255f;
            List<byte> rvals = new List<byte>();
            List<byte> gvals = new List<byte>();
            List<byte> bvals = new List<byte>();
            int empty = 0;
            int filled = 0;

            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                byte r = (byte)(f.RedChroma * rgbValues[counter + 2]);
                byte g = (byte)(f.GreenChroma * rgbValues[counter + 1]);
                byte b = (byte)(f.BlueChroma * rgbValues[counter]);
                bool rt = r > t;
                bool gt = g > t;
                bool bt = b > t;
                rgbValues[counter + 2] = rt ? byte.MaxValue : byte.MinValue;
                rgbValues[counter + 1] = gt ? byte.MaxValue : byte.MinValue;
                rgbValues[counter] = bt ? byte.MaxValue : byte.MinValue;
                rvals.Add(r);
                gvals.Add(g);
                bvals.Add(b);
                if (!rt & !gt & !bt) filled++;
                else empty++;
            }

            Marshal.Copy(rgbValues, 0, bmpData.Scan0, bytes);
            bmp.UnlockBits(bmpData);

            float re = CalculateShannonEntropy(rvals.ToArray(), bmp.Size);
            float ge = CalculateShannonEntropy(gvals.ToArray(), bmp.Size);
            float be = CalculateShannonEntropy(bvals.ToArray(), bmp.Size);
            float score = (float)Math.Sqrt(re * re + ge * ge + be * be);
            score = score > 0 ? (float)Math.Round(score + (empty / 2), 3) : 0;

            return (rvals.ToArray(), empty, filled, score);
        }

        private static float CalculateShannonEntropy(byte[] data, Size size)
        {
            float entropy = 0; // Calculate Shannon entropy
            foreach (var g in data.GroupBy(i => i)) // Turn list into an array of counts
            {
                double val = g.Count() / (double)(size.Width * size.Height);
                entropy -= (float)(val * Math.Log(val, 2));
            }
            return entropy;
        }

        private static void ResizeAndRotate(ref Bitmap bmp)
        {
            Bitmap resize = new Bitmap((int)(Scaling * bmp.Width), (int)(Scaling * bmp.Height), PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(resize))
                g.DrawImage(bmp, 0, 0, resize.Width, resize.Height);
            bmp = RotateImage(resize);
        }

        private static Bitmap RotateImage(Bitmap img, float rotationAngle = 0f)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            //turn the Bitmap into a Graphics object
            Graphics g = Graphics.FromImage(bmp);
            //now we set the rotation point to the center of our image
            g.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            //now rotate the image
            g.RotateTransform(rotationAngle);
            g.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //now draw our new image onto the graphics object
            g.DrawImage(img, new Point(0, 0));
            //dispose of our Graphics object
            g.Dispose();
            //return the image
            return bmp;
        }
    }
}
