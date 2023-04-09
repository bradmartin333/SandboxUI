/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageConvolutionFilters
{
    public static class ExtBitmap
    {
        public static Bitmap ConvolutionFilter<T>(this Bitmap src, T filter) where T : ConvolutionFilterBase
        {
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
            return resBmp;
        }

        private static byte Clamp(double i, double min = 0, double max = 255)
        {
            if (i < min) i = min;
            else if (i > max) i = max;
            return (byte)i;
        }
    }  
}
