namespace ImageConvolutionFilters
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PBX = new System.Windows.Forms.PictureBox();
            this.CmbFilterType = new System.Windows.Forms.ComboBox();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).BeginInit();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // PBX
            // 
            this.PBX.BackColor = System.Drawing.Color.Transparent;
            this.PBX.BackgroundImage = global::ImageConvolutionFilters.Properties.Resources.IMG_8853_Small;
            this.PBX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBX.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBX.Location = new System.Drawing.Point(3, 3);
            this.PBX.Name = "PBX";
            this.PBX.Size = new System.Drawing.Size(786, 591);
            this.PBX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBX.TabIndex = 13;
            this.PBX.TabStop = false;
            // 
            // CmbFilterType
            // 
            this.CmbFilterType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFilterType.FormattingEnabled = true;
            this.CmbFilterType.Location = new System.Drawing.Point(3, 600);
            this.CmbFilterType.Name = "CmbFilterType";
            this.CmbFilterType.Size = new System.Drawing.Size(786, 24);
            this.CmbFilterType.TabIndex = 1;
            this.CmbFilterType.SelectedIndexChanged += new System.EventHandler(this.SelectedFilterIndexChangedEventHandler);
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 1;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.Controls.Add(this.PBX, 0, 0);
            this.TLP.Controls.Add(this.CmbFilterType, 0, 1);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 2;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.Size = new System.Drawing.Size(792, 627);
            this.TLP.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(792, 627);
            this.Controls.Add(this.TLP);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Convolution Filter";
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).EndInit();
            this.TLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBX;
        private System.Windows.Forms.ComboBox CmbFilterType;
        private System.Windows.Forms.TableLayoutPanel TLP;
    }
}

