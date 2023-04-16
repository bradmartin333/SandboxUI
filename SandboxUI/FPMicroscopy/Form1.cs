using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Numerics;
using FPMicroscopy.Properties;
using System.Diagnostics;
using System.Linq;

namespace FPMicroscopy
{
    public partial class Form1 : Form
    {
        public int FFTSize = 100;

        public Form1()
        {
            InitializeComponent();
            Bitmap[] imgs = LoadImages();
            // Apply FFT to first image
            Bitmap padded = PadSquareImage(imgs[0]);
            Complex[][] fft = Forward(padded);
            foreach (Bitmap img in imgs.Skip(1))
            {
                padded = PadSquareImage(img);
                Complex[][] thisFFT = Forward(padded);
                for (int i = 0; i < FFTSize; i++)
                    for (int j = 0; j < FFTSize; j++)
                    {
                        Complex initial = fft[i][j];
                        Complex thisComplex = thisFFT[i][j];
                        fft[i][j] = initial + thisComplex;
                    }
            }
            pictureBox1.Image = Inverse(fft);
        }

        private Bitmap[] LoadImages()
        {
            return new Bitmap[]
            {
                Resources.linearblur0deg,
                Resources.linearblur30deg,
                Resources.linearblur60deg,
                Resources.linearblur90deg,
                Resources.linearblur120deg,
                Resources.linearblur150deg,
                Resources.linearblur180deg,
                Resources.linearblur210deg,
                Resources.linearblur240deg,
                Resources.linearblur270deg,
                Resources.linearblur300deg,
                Resources.linearblur330deg,
            };
        }

        public Bitmap PadSquareImage(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;
            int n = 0;
            while (FFTSize <= Math.Max(w, h))
            {
                FFTSize = (int)Math.Pow(2, n);
                if (FFTSize == Math.Max(w, h)) break;
                n++;
            }
            double horizontalPadding = FFTSize - w;
            double verticalPadding = FFTSize - h;
            int leftPadding = (int)Math.Floor(horizontalPadding / 2);
            int topPadding = (int)Math.Floor(verticalPadding / 2);

            BitmapData imageData = image.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = imageData.Stride * imageData.Height;
            byte[] buffer = new byte[bytes];
            Marshal.Copy(imageData.Scan0, buffer, 0, bytes);
            image.UnlockBits(imageData);
            Bitmap paddedImage = new Bitmap(FFTSize, FFTSize);
            BitmapData paddedData = paddedImage.LockBits(new Rectangle(0, 0, FFTSize, FFTSize), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            int paddedBytes = paddedData.Stride * paddedData.Height;
            byte[] result = new byte[paddedBytes];

            for (int i = 3; i < paddedBytes; i += 4)
                result[i] = 255;

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int imagePosition = y * imageData.Stride + x * 4;
                    int paddingPosition = y * paddedData.Stride + x * 4;
                    for (int i = 0; i < 3; i++)
                        result[paddedData.Stride * topPadding + 4 * leftPadding + paddingPosition + i] = buffer[imagePosition + i];
                }
            }

            Marshal.Copy(result, 0, paddedData.Scan0, paddedBytes);
            paddedImage.UnlockBits(paddedData);
            return paddedImage;
        }

        public Complex[][] ToComplex(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData inputData = image.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int bytes = inputData.Stride * inputData.Height;
            byte[] buffer = new byte[bytes];
            Marshal.Copy(inputData.Scan0, buffer, 0, bytes);
            image.UnlockBits(inputData);

            Complex[][] result = new Complex[w][];
            int pixelPosition;
            for (int x = 0; x < w; x++)
            {
                result[x] = new Complex[h];
                for (int y = 0; y < h; y++)
                {
                    pixelPosition = y * inputData.Stride + x * 4 + 1;
                    result[x][y] = new Complex(buffer[pixelPosition], 0);
                }
            }

            return result;
        }

        public Complex[][] Forward(Bitmap image)
        {
            Complex[][] p = new Complex[FFTSize][];
            Complex[][] f = new Complex[FFTSize][];
            Complex[][] t = new Complex[FFTSize][];

            Complex[][] complexImage = ToComplex(image);
            for (int l = 0; l < FFTSize; l++)
                p[l] = Forward(complexImage[l]);
            for (int l = 0; l < FFTSize; l++)
            {
                t[l] = new Complex[FFTSize];
                for (int k = 0; k < FFTSize; k++)
                    t[l][k] = p[k][l];
                f[l] = Forward(t[l]);
            }

            return f;
        }

        public Complex[] Forward(Complex[] input, bool phaseShift = true)
        {
            Complex[] result = new Complex[input.Length];
            float omega = (float)(-2.0 * Math.PI / input.Length);

            if (input.Length == 1)
            {
                result[0] = input[0];
                if (result[0].Magnitude == double.NaN)
                    return new[] { new Complex(0, 0) };
                return result;
            }

            var evenInput = new Complex[input.Length / 2];
            var oddInput = new Complex[input.Length / 2];

            for (int i = 0; i < input.Length / 2; i++)
            {
                evenInput[i] = input[2 * i];
                oddInput[i] = input[2 * i + 1];
            }

            var even = Forward(evenInput, phaseShift);
            var odd = Forward(oddInput, phaseShift);

            for (int k = 0; k < input.Length / 2; k++)
            {
                int phase = phaseShift ? k - input.Length / 2 : k;
                odd[k] *= Complex.FromPolarCoordinates(1, omega * phase);
            }

            for (int k = 0; k < input.Length / 2; k++)
            {
                result[k] = even[k] + odd[k];
                result[k + input.Length / 2] = even[k] - odd[k];
            }

            return result;
        }

        public Bitmap Inverse(Complex[][] frequencies)
        {
            var p = new Complex[FFTSize][];
            var f = new Complex[FFTSize][];
            var t = new Complex[FFTSize][];

            Bitmap image = new Bitmap(FFTSize, FFTSize);
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, FFTSize, FFTSize), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            int bytes = imageData.Stride * imageData.Height;
            byte[] result = new byte[bytes];

            for (int i = 0; i < FFTSize; i++)
                p[i] = Inverse(frequencies[i]);

            for (int i = 0; i < FFTSize; i++)
            {
                t[i] = new Complex[FFTSize];
                for (int j = 0; j < FFTSize; j++)
                    t[i][j] = p[j][i] / (FFTSize * FFTSize);
                f[i] = Inverse(t[i]);
            }

            double max = 0;

            for (int y = 0; y < FFTSize; y++)
            {
                for (int x = 0; x < FFTSize; x++)
                {
                    double mag = f[x][y].Magnitude;
                    if (mag > max) max = mag;
                }
            }

            for (int y = 0; y < FFTSize; y++)
            {
                for (int x = 0; x < FFTSize; x++)
                {
                    int pixel_position = y * imageData.Stride + x * 4;
                    for (int i = 0; i < 3; i++)
                    {
                        double mag = f[x][y].Magnitude;
                        result[pixel_position + i] = (byte)(mag / max * 255);
                    }
                    result[pixel_position + 3] = 255;
                }
            }

            Marshal.Copy(result, 0, imageData.Scan0, bytes);
            image.UnlockBits(imageData);
            return image;
        }

        public Complex[] Inverse(Complex[] input)
        {
            for (int i = 0; i < input.Length; i++)
                input[i] = Complex.Conjugate(input[i]);
            Complex[] transform = Forward(input, false);
            for (int i = 0; i < input.Length; i++)
                transform[i] = Complex.Conjugate(transform[i]);
            return transform;
        }
    }
}
