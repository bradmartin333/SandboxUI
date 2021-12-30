using System;
using System.Windows.Forms;

namespace GNUtesting
{
    public partial class Form1 : Form
    {
        private const string LOGPATH = @"S:\rustometry\tests\files\test_point_cloud.txt";

        public Form1()
        {
            InitializeComponent();
            GnuPlot.SPlot(LOGPATH);
        }
    }
}
