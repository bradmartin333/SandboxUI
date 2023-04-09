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
            CmbFilterType.SelectedIndex = 0;

            ApplyFilter();
        }

        private void SelectedFilterIndexChangedEventHandler(object sender, EventArgs e) => ApplyFilter();

        private void ApplyFilter()
        {
            if (PBX.BackgroundImage == null || CmbFilterType.SelectedItem == null) return;
            Bitmap src = (Bitmap)PBX.BackgroundImage;
            ConvolutionFilterBase filter = (ConvolutionFilterBase)CmbFilterType.SelectedItem;

            BitmapData srcData = src.LockBits(new Rectangle(0, 0, src.Width, src.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] srcBuf = new byte[srcData.Stride * srcData.Height];
            byte[] resBuf = new byte[srcData.Stride * srcData.Height];
            Marshal.Copy(srcData.Scan0, srcBuf, 0, srcBuf.Length);
            src.UnlockBits(srcData);

            int filterOffset = (filter.FilterMatrix.GetLength(1) - 1) / 2;
            for (int offsetY = filterOffset; offsetY < src.Height - filterOffset; offsetY++)
                for (int offsetX = filterOffset; offsetX < src.Width - filterOffset; offsetX++)
                {
                    double b = 0, g = 0, r = 0;
                    int byteOffset = offsetY * srcData.Stride + offsetX * 4;
                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            int calcOffset = byteOffset + (filterX * 4) + (filterY * srcData.Stride);
                            double filterVal = filter.FilterMatrix[filterY + filterOffset, filterX + filterOffset];
                            b += srcBuf[calcOffset] * filterVal;
                            g += srcBuf[calcOffset + 1] * filterVal;
                            r += srcBuf[calcOffset + 2] * filterVal;
                        }
                    resBuf[byteOffset] = Clamp(filter.Factor * b + filter.Bias);
                    resBuf[byteOffset + 1] = Clamp(filter.Factor * g + filter.Bias);
                    resBuf[byteOffset + 2] = Clamp(filter.Factor * r + filter.Bias);
                    resBuf[byteOffset + 3] = 255;
                }

            Bitmap resBmp = new Bitmap(src.Width, src.Height);
            BitmapData resData = resBmp.LockBits(new Rectangle(0, 0, resBmp.Width, resBmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
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
