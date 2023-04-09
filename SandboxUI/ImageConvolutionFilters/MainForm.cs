using System;
using System.Collections.Generic;
using System.Drawing;
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

            cmbFilterType.DataSource = filterList;
            cmbFilterType.DisplayMember = "FilterName";
            cmbFilterType.SelectedIndex = 0;

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (PBX.BackgroundImage == null || cmbFilterType.SelectedItem == null) return;
            PBX.Image = ((Bitmap)PBX.BackgroundImage).ConvolutionFilter((ConvolutionFilterBase)cmbFilterType.SelectedItem);
        }

        private void SelectedFilterIndexChangedEventHandler(object sender, EventArgs e) => ApplyFilter();
    }
}
