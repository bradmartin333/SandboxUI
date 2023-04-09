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
        private ConvolutionFilterBase Filter = null;

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
            CmbFilterType.SelectedIndex = 9;
        }

        private void SelectedFilterIndexChangedEventHandler(object sender, EventArgs e) => ApplyFilter();

        private void ApplyFilter()
        {
            if (PBX.BackgroundImage == null || CmbFilterType.SelectedItem == null) return;
            Bitmap src = (Bitmap)PBX.BackgroundImage;
            Filter = (ConvolutionFilterBase)CmbFilterType.SelectedItem;

            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);
            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] srcBuf = new byte[srcData.Stride * srcData.Height];
            byte[] resBuf = new byte[srcData.Stride * srcData.Height];
            Marshal.Copy(srcData.Scan0, srcBuf, 0, srcBuf.Length);
            src.UnlockBits(srcData);

            int fo = (Filter.FilterMatrix.GetLength(1) - 1) / 2; // Filter Offset
            for (int oy = fo; oy < src.Height - fo; oy++) // Offset Y
                for (int ox = fo; ox < src.Width - fo; ox++) // Offset X
                {
                    double[] pvs = new double[3]; // Pixel Vals
                    int bo = oy * srcData.Stride + ox * 4; // Byte Offset
                    for (int fy = -fo; fy <= fo; fy++) // Filter Y
                        for (int fx = -fo; fx <= fo; fx++) // Filter X
                        {
                            int co = bo + (fx * 4) + (fy * srcData.Stride); // Calculated Offset
                            double fv = Filter.FilterMatrix[fy + fo, fx + fo]; // Filter Val
                            for (int i = 0; i < pvs.Length; i++)
                                pvs[i] += srcBuf[co + i] * fv;
                        }
                    for (int i = 0; i < pvs.Length + 1; i++)
                        resBuf[bo + i] = i == pvs.Length ? byte.MaxValue : Clamp(pvs[i]);
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
            return (byte)(Filter.Factor * i + Filter.Bias);
        }
    }
}
