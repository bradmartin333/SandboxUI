using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ImageConvolutionFilters
{
    public partial class MainForm : Form
    {        
        public MainForm()
        {
            InitializeComponent();

            List<ConvolutionFilterBase> filterList = new List<ConvolutionFilterBase>
            {
                new Blur3x3Filter(),
                new Blur5x5Filter(),
                new Gaussian3x3BlurFilter(),
                new Gaussian5x5BlurFilter(),
                new SoftenFilter(),
                new MotionBlurFilter(),
                new MotionBlurLeftToRightFilter(),
                new MotionBlurRightToLeftFilter(),
                new HighPass3x3Filter(),
                new EdgeDetectionFilter(),
                new HorizontalEdgeDetectionFilter(),
                new VerticalEdgeDetectionFilter(),
                new EdgeDetection45DegreeFilter(),
                new EdgeDetectionTopLeftBottomRightFilter(),
                new SharpenFilter(),
                new Sharpen3x3Filter(),
                new Sharpen3x3FactorFilter(),
                new Sharpen5x5Filter(),
                new IntenseSharpenFilter(),
                new EmbossFilter(),
                new Emboss45DegreeFilter(),
                new EmbossTopLeftBottomRightFilter(),
                new IntenseEmbossFilter()
            };

            CmbFilterType.DataSource = filterList;
            CmbFilterType.DisplayMember = "FilterName";
            CmbFilterType.SelectedIndex = 1;
        }

        private void SelectedFilterIndexChangedEventHandler(object sender, EventArgs e) => ApplyFilter();

        private void ApplyFilter()
        {
            if (PBX.BackgroundImage == null || CmbFilterType.SelectedItem == null) return;
            Bitmap src = (Bitmap)PBX.BackgroundImage;
            ConvolutionFilterBase f = (ConvolutionFilterBase)CmbFilterType.SelectedItem;

            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);
            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] srcBuf = new byte[srcData.Stride * srcData.Height];
            byte[] resBuf = new byte[srcData.Stride * srcData.Height];
            Marshal.Copy(srcData.Scan0, srcBuf, 0, srcBuf.Length);
            src.UnlockBits(srcData);

            int fo = (f.FilterMatrix.GetLength(1) - 1) / 2; // Filter offset
            for (int oy = fo; oy < src.Height - fo; oy++) // Offset y
                for (int ox = fo; ox < src.Width - fo; ox++) // Offset x
                {
                    double[] pvs = new double[3]; // Pixel vals
                    int bo = oy * srcData.Stride + ox * 4; // Byte offset
                    for (int fy = -fo; fy <= fo; fy++) // Filter y
                        for (int fx = -fo; fx <= fo; fx++) // Filter x
                        {
                            int co = bo + (fx * 4) + (fy * srcData.Stride); // Calculated offset
                            double fv = f.FilterMatrix[fy + fo, fx + fo]; // Filter val
                            for (int pi = 0; pi < 3; pi++) // Pixel index
                                pvs[pi] += srcBuf[co + pi] * fv;
                        }
                    for (int pi = 0; pi <= 3; pi++) // Pixel index
                        resBuf[bo + pi] = pi == pvs.Length ? byte.MaxValue : Clamp(f.Factor * pvs[pi] + f.Bias);
                }

            Bitmap resBmp = new Bitmap(src.Width, src.Height);
            BitmapData resData = resBmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(resBuf, 0, resData.Scan0, resBuf.Length);
            resBmp.UnlockBits(resData);

            PBX.Image = resBmp;
        }

        private byte Clamp(double i, double min = 0, double max = 255)
        {
            if (i < min) i = min;
            else if (i > max) i = max;
            return (byte)i;
        }
    }
}
