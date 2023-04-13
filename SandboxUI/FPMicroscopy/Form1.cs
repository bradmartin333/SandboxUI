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
                Complex[][] fft_multiply = Forward(padded);
                for (int i = 0; i < FFTSize; i++)
                    for (int j = 0; j < FFTSize; j++)
                    {
                        Complex initial = fft[i][j];
                        Complex complex = fft_multiply[i][j];
                        fft[i][j] = initial + complex;
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

        public Complex[][] ToComplex(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;

            BitmapData input_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            int bytes = input_data.Stride * input_data.Height;

            byte[] buffer = new byte[bytes];
            Complex[][] result = new Complex[w][];

            Marshal.Copy(input_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(input_data);

            int pixel_position;

            for (int x = 0; x < w; x++)
            {
                result[x] = new Complex[h];
                for (int y = 0; y < h; y++)
                {
                    pixel_position = y * input_data.Stride + x * 4;
                    result[x][y] = new Complex(buffer[pixel_position], 0);
                }
            }

            return result;
        }

        public Complex[] Forward(Complex[] input, bool phaseShift = true)
        {
            Complex[] result = new Complex[input.Length];
            float omega = (float)(-2.0 * Math.PI / input.Length);

            if (input.Length == 1)
            {
                result[0] = input[0];

                if (result[0].Magnitude == double.NaN)
                {
                    return new[] { new Complex(0, 0) };
                }
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
                int phase;

                if (phaseShift)
                {
                    phase = k - FFTSize / 2;
                }
                else
                {
                    phase = k;
                }
                odd[k] *= Complex.FromPolarCoordinates(1, omega * phase);
            }

            for (int k = 0; k < input.Length / 2; k++)
            {
                result[k] = even[k] + odd[k];
                result[k + input.Length / 2] = even[k] - odd[k];
            }

            return result;
        }

        public Complex[][] Forward(Bitmap image)
        {
            var p = new Complex[FFTSize][];
            var f = new Complex[FFTSize][];
            var t = new Complex[FFTSize][];

            var complexImage = ToComplex(image);

            for (int l = 0; l < FFTSize; l++)
            {
                p[l] = Forward(complexImage[l]);
            }

            for (int l = 0; l < FFTSize; l++)
            {
                t[l] = new Complex[FFTSize];
                for (int k = 0; k < FFTSize; k++)
                {
                    t[l][k] = p[k][l];
                }
                f[l] = Forward(t[l]);
            }

            // Only keep the horizontal and vertical frequencies
            for (int l = 0; l < FFTSize; l++)
            {
                for (int k = 0; k < FFTSize; k++)
                {
                    if (Math.Abs(l - FFTSize / 2) < FFTSize / 10 || Math.Abs(k - FFTSize / 2) < FFTSize / 10)
                    {
                        f[l][k] = new Complex(0, 0);
                    }
                }
            }

            return f;
        }

        public Bitmap PadSquareImage(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;
            int n = 0;
            while (FFTSize <= Math.Max(w, h))
            {
                FFTSize = (int)Math.Pow(2, n);
                if (FFTSize == Math.Max(w, h))
                {
                    break;
                }
                n++;
            }
            double horizontal_padding = FFTSize - w;
            double vertical_padding = FFTSize - h;
            int left_padding = (int)Math.Floor(horizontal_padding / 2);
            int top_padding = (int)Math.Floor(vertical_padding / 2);

            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, w, h),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            int bytes = image_data.Stride * image_data.Height;
            byte[] buffer = new byte[bytes];
            Marshal.Copy(image_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(image_data);

            Bitmap padded_image = new Bitmap(FFTSize, FFTSize);

            BitmapData padded_data = padded_image.LockBits(
                new Rectangle(0, 0, FFTSize, FFTSize),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            int padded_bytes = padded_data.Stride * padded_data.Height;
            byte[] result = new byte[padded_bytes];

            for (int i = 3; i < padded_bytes; i += 4)
            {
                result[i] = 255;
            }

            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    int image_position = y * image_data.Stride + x * 4;
                    int padding_position = y * padded_data.Stride + x * 4;
                    for (int i = 0; i < 3; i++)
                    {
                        result[padded_data.Stride * top_padding + 4 * left_padding + padding_position + i] = buffer[image_position + i];
                    }
                }
            }

            Marshal.Copy(result, 0, padded_data.Scan0, padded_bytes);
            padded_image.UnlockBits(padded_data);

            return padded_image;
        }

        public Complex[] Inverse(Complex[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Complex.Conjugate(input[i]);
            }

            var transform = Forward(input, false);

            for (int i = 0; i < input.Length; i++)
            {
                transform[i] = Complex.Conjugate(transform[i]);
            }

            return transform;
        }

        public Bitmap Inverse(Complex[][] frequencies)
        {
            var p = new Complex[FFTSize][];
            var f = new Complex[FFTSize][];
            var t = new Complex[FFTSize][];

            Bitmap image = new Bitmap(FFTSize, FFTSize);
            BitmapData image_data = image.LockBits(
                new Rectangle(0, 0, FFTSize, FFTSize),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);
            int bytes = image_data.Stride * image_data.Height;
            byte[] result = new byte[bytes];

            for (int i = 0; i < FFTSize; i++)
            {
                p[i] = Inverse(frequencies[i]);
            }

            for (int i = 0; i < FFTSize; i++)
            {
                t[i] = new Complex[FFTSize];
                for (int j = 0; j < FFTSize; j++)
                {
                    t[i][j] = p[j][i] / (FFTSize * FFTSize);
                }
                f[i] = Inverse(t[i]);
            }

            double max = 0;

            for (int y = 0; y < FFTSize; y++)
            {
                for (int x = 0; x < FFTSize; x++)
                {
                    double mag = f[x][y].Magnitude;
                    if (mag > max)
                    {
                        max = mag;
                    }
                }
            }
            Debug.WriteLine(max);
            for (int y = 0; y < FFTSize; y++)
            {
                for (int x = 0; x < FFTSize; x++)
                {
                    int pixel_position = y * image_data.Stride + x * 4;
                    for (int i = 0; i < 3; i++)
                    {
                        double mag = f[x][y].Magnitude;
                        result[pixel_position + i] = (byte)(mag / max * 255);
                        //Debug.WriteLine(result[pixel_position + i]);
                    }
                    result[pixel_position + 3] = 255;
                }
            }

            Marshal.Copy(result, 0, image_data.Scan0, bytes);
            image.UnlockBits(image_data);
            return image;
        }
    }
}
