using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace FocusStack
{
    internal class Program
    {
        private const string _ImgDir = @"C:\Users\bmartin\Downloads\Other\AM Focus Stacking\Small";
        private const int _DilateBallSize = 31; // Size in pixels of how much the image stack is smoothed
        private const int _LowContrast = 0; // Value to try and reduce picking up noise as edges (0 = off)
        private const int _OSize = 11; // Size in pixels to search for edges (Size of gauss and laplace kernels)
        private const int _BlurSize = 11; // Size of blur in pixels (0 = off, try to match OSize)
        private const int _XMult = 1; // Direction multiplier for X dir
        private const int _YMult = 0; // Direction multiplier for Y dir

        static void Main(string[] args)
        {
            Bitmap[] imgs = LoadImages();
            MatchBrightness(ref  imgs);
            Directory.CreateDirectory("test");
            for (int i = 0; i < imgs.Length; i++)
                imgs[i].Save(Path.Combine("test", $"{i}.png"), ImageFormat.Png);
        }

        private static Bitmap[] LoadImages()
        {
            string[] files = Directory.GetFiles(_ImgDir);
            Bitmap[] images = new Bitmap[files.Length];
            for (int i = 0; i < files.Length; i++)
                images[i] = new Bitmap(files[i]);
            return images;
        }

        private static void MatchBrightness(ref Bitmap[] bitmaps)
        {
            int rb = 0;
            int gb = 0;
            int bb = 0;
            MeasureBrightness(ref bitmaps[0], ref rb, ref gb, ref bb);
            for (int i = 1; i < bitmaps.Length; i++)
            {
                int rb2 = 0;
                int gb2 = 0;
                int bb2 = 0;
                MeasureBrightness(ref bitmaps[i], ref rb2, ref gb2, ref bb2);
                rb2 -= rb;
                gb2 -= gb;
                bb2 -= bb;
                MeasureBrightness(ref bitmaps[i], ref rb2, ref gb2, ref bb2, true);
            }    
        }

        private static void MeasureBrightness(ref Bitmap bmp, ref int rb, ref int gb, ref int bb, bool adjust = false)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int bytes = Math.Abs(bmpData.Width * 3) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(bmpData.Scan0, rgbValues, 0, bytes);

            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {
                byte r = rgbValues[counter + 2];
                byte g = rgbValues[counter + 1];
                byte b = rgbValues[counter];
                if (adjust)
                {
                    rgbValues[counter + 2] -= (byte)rb;
                    rgbValues[counter + 1] -= (byte)gb;
                    rgbValues[counter] -= (byte)bb;
                }
                else
                {
                    rb += r;
                    gb += g;
                    bb += b;
                }
            }

            Marshal.Copy(rgbValues, 0, bmpData.Scan0, bytes);
            bmp.UnlockBits(bmpData);

            int size = rect.Width * rect.Height;
            rb /= size;
            gb /= size;
            bb /= size;
        }
    }
}
