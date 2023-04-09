using FPMicroscopy.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Numerics;
using System.Xml.Linq;
using System.Xml;

namespace FPMicroscopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Rectangle rect = new Rectangle(0, 0, 100, 100);
            Bitmap FTbmp = PerformFT(LoadImages(), rect);
            pictureBox1.Image = FTbmp;
            Bitmap FTbmp2 = PerformFT(LoadImages2(), rect);
            pictureBox2.Image = FTbmp;
            Bitmap FTbmpDiff = new Bitmap(rect.Width, rect.Height);
            bool isDifferent = false;
            for (int i = 0; i < rect.Width; i++)
            {
                for (int j = 0; j < rect.Height; j++)
                {
                    byte rDiff = (byte)Math.Abs(FTbmp.GetPixel(i, j).R - FTbmp2.GetPixel(i, j).R);
                    byte gDiff = (byte)Math.Abs(FTbmp.GetPixel(i, j).G - FTbmp2.GetPixel(i, j).G);
                    byte bDiff = (byte)Math.Abs(FTbmp.GetPixel(i, j).B - FTbmp2.GetPixel(i, j).B);
                    isDifferent = rDiff > 0 || gDiff > 0 || bDiff > 0;
                    FTbmpDiff.SetPixel(i, j, Color.FromArgb(rDiff, gDiff, bDiff));
                }
            }
            pictureBox3.Image = FTbmpDiff;
            pictureBox4.BackColor = isDifferent ? Color.Red : Color.Green;
        }

        private Bitmap[] LoadImages()
        {
            //return new Bitmap[]
            //{
            //    Resources.linearblur0deg,
            //    Resources.linearblur30deg,
            //    Resources.linearblur60deg,
            //    Resources.linearblur90deg,
            //    Resources.linearblur120deg,
            //    Resources.linearblur150deg,
            //    Resources.linearblur180deg,
            //    Resources.linearblur210deg,
            //    Resources.linearblur240deg,
            //    Resources.linearblur270deg,
            //    Resources.linearblur300deg,
            //    Resources.linearblur330deg,
            //};

            Bitmap a = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(a))
            {
                g.Clear(Color.White);
                g.DrawString("A", DefaultFont, Brushes.Black, new Point(5, 5));
            }
            return new Bitmap[] { a };
        }

        private Bitmap[] LoadImages2()
        {
            //return new Bitmap[]
            //{
            //    Resources.linearblur0deg,
            //    Resources.linearblur30deg,
            //    Resources.linearblur60deg,
            //    Resources.linearblur90deg,
            //    Resources.linearblur120deg,
            //    Resources.linearblur150deg,
            //    Resources.linearblur180deg,
            //    Resources.linearblur210deg,
            //    Resources.linearblur240deg,
            //    Resources.linearblur270deg,
            //    Resources.linearblur300deg,
            //    Resources.linearblur330deg,
            //};

            Bitmap a = new Bitmap(100, 100);
            using (Graphics g = Graphics.FromImage(a))
            {
                g.Clear(Color.White);
                g.DrawString("A", DefaultFont, Brushes.Black, new Point(15, 15));
            }
            return new Bitmap[] { a };
        }

        private Bitmap PerformFT(Bitmap[] imgs, Rectangle rect)
        {
            double[,] r = new double[rect.Height, rect.Width];
            double[,] g = new double[rect.Height, rect.Width];
            double[,] b = new double[rect.Height, rect.Width];
            for (int img = 0; img < imgs.Length; img++)
            {
                Bitmap src = imgs[img];
                BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                byte[] srcBuf = new byte[srcData.Stride * srcData.Height];
                Marshal.Copy(srcData.Scan0, srcBuf, 0, srcBuf.Length);
                src.UnlockBits(srcData);
                for (int j = 0; j < srcBuf.Length; j += 4)
                {
                    // Get x and y coordinates of the pixel
                    int x = (j / 4) % rect.Width;
                    int y = (j / 4) / rect.Width;
                    r[y, x] += srcBuf[j + 2];
                    g[y, x] += srcBuf[j + 1];
                    b[y, x] += srcBuf[j + 0];
                }
            }
           
            double[,] fft_r = FT2D(r, rect);
            double[,] fft_g = FT2D(g, rect);
            double[,] fft_b = FT2D(b, rect);

            byte[] fft = new byte[rect.Width * rect.Height * 4];
            for (int i = 0; i < rect.Width; i++)
                for (int j = 0; j < rect.Height; j++)
                {
                    fft[(j * rect.Width + i) * 4 + 0] = (byte)fft_b[j, i];
                    fft[(j * rect.Width + i) * 4 + 1] = (byte)fft_g[j, i];
                    fft[(j * rect.Width + i) * 4 + 2] = (byte)fft_r[j, i];
                    fft[(j * rect.Width + i) * 4 + 3] = 255;
                }

            Bitmap dst = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            BitmapData dstData = dst.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(fft, 0, dstData.Scan0, fft.Length);
            dst.UnlockBits(dstData);
            return dst;
        }

        private double[,] FT2D(double[,] P, Rectangle rect)
        {
            int n = P.Length;
            if (n == 1) return P;
            double[,] FTreal = new double[rect.Height, rect.Width];
            double[,] FTimaginary = new double[rect.Height, rect.Width];
            double[,] FTamplitude = new double[rect.Height, rect.Width];
            for (int xOut = 0; xOut < rect.Width; xOut++)
                for (int yOut = 0; yOut < rect.Height; yOut++)
                    for (int xSrc = 0; xSrc < rect.Width; xSrc++)
                        for (int ySrc = 0; ySrc < rect.Height; ySrc++)
                        {
                            FTreal[yOut, xOut] += P[ySrc, xSrc] * Math.Cos(2 * Math.PI * ((1.0 * xOut * xSrc / rect.Width) + (1.0 * yOut * ySrc / rect.Height))) / Math.Sqrt(rect.Width * rect.Height);
                            FTimaginary[yOut, xOut] += P[ySrc, xSrc] * Math.Sin(2 * Math.PI * ((1.0 * xOut * xSrc / rect.Width) + (1.0 * yOut * ySrc / rect.Height))) / Math.Sqrt(rect.Width * rect.Height);
                            FTamplitude[yOut, xOut] += Math.Sqrt(Math.Pow(FTreal[yOut, xOut], 2) + Math.Pow(FTimaginary[yOut, xOut], 2));
                        }
            return NormalizeFT(FTamplitude, rect);
        }

        private double[,] NormalizeFT(double[,] FT, Rectangle rect)
        {
            double max = 0;
            for (int i = 0; i < rect.Width; i++)
                for (int j = 0; j < rect.Height; j++)
                {
                    FT[j, i] = Math.Log(FT[j, i]);
                    if (FT[j, i] == double.NaN) FT[j, i] = 0;
                    else if (FT[j, i] > max) max = FT[j, i];
                }
            for (int i = 0; i < rect.Width; i++)
                for (int j = 0; j < rect.Height; j++)
                    FT[j, i] = FT[j, i] / max * 255;
            return FT;
        }
    }
}
