using System;
using System.Drawing;
using System.Windows.Forms;

namespace BrainboxesTest
{
    public partial class Form1 : Form
    {
        readonly Brainboxes.IO.EDDevice Brainbox;

        public Form1()
        {
            InitializeComponent();
            Brainbox = Brainboxes.IO.EDDevice.Create("192.168.127.254");
            Brainbox.AOutputs.AValues = 0.0;
            SetColor();
        }

        private void Hue_Scroll(object sender, ScrollEventArgs e)
        {
            SetColor();
        }

        private void Intensity_Scroll(object sender, ScrollEventArgs e)
        {
            SetColor();
        }

        private void SetColor()
        {
            Color c = ColorFromHSV((100 - hue.Value) * 3.6, (100 - intensity.Value) / 100.0);
            Brainbox.AOutputs[0].AValue = Map(c.R);
            Brainbox.AOutputs[1].AValue = Map(c.G);
            Brainbox.AOutputs[2].AValue = Map(c.B);
        }

        private static Color ColorFromHSV(double hue, double value, double saturation = 1)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value *= 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        private double Map(double value, double fromLow = 0, double fromHigh = 255, double toLow = 2.5, double toHigh = 0)
        {
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }
    }
}
