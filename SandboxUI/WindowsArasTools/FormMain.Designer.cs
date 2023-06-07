namespace WindowsArasTools
{
    partial class FormMain
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabCADPDFs = new System.Windows.Forms.TabPage();
            this.TlpCADPDFs = new System.Windows.Forms.TableLayoutPanel();
            this.RtbCADPDFs = new System.Windows.Forms.RichTextBox();
            this.BtnCADPDFs = new System.Windows.Forms.Button();
            this.TabPartLookup = new System.Windows.Forms.TabPage();
            this.TabWhereUsed = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.TlpPartLookup = new System.Windows.Forms.TableLayoutPanel();
            this.FlowPrefix = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowMaxNum = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowCache = new System.Windows.Forms.FlowLayoutPanel();
            this.RtbKeywords = new System.Windows.Forms.RichTextBox();
            this.RtbResults = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NumPrefixA = new System.Windows.Forms.NumericUpDown();
            this.NumPrefixB = new System.Windows.Forms.NumericUpDown();
            this.NumPrefixC = new System.Windows.Forms.NumericUpDown();
            this.NumSuffixA = new System.Windows.Forms.NumericUpDown();
            this.NumSuffixB = new System.Windows.Forms.NumericUpDown();
            this.NumSuffixC = new System.Windows.Forms.NumericUpDown();
            this.NumSuffixD = new System.Windows.Forms.NumericUpDown();
            this.BtnDownload = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.TabCADPDFs.SuspendLayout();
            this.TlpCADPDFs.SuspendLayout();
            this.TabPartLookup.SuspendLayout();
            this.TabWhereUsed.SuspendLayout();
            this.TLP.SuspendLayout();
            this.TlpPartLookup.SuspendLayout();
            this.FlowPrefix.SuspendLayout();
            this.FlowMaxNum.SuspendLayout();
            this.FlowCache.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixD)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabCADPDFs);
            this.TabControl.Controls.Add(this.TabPartLookup);
            this.TabControl.Controls.Add(this.TabWhereUsed);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(3, 3);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(794, 444);
            this.TabControl.TabIndex = 0;
            // 
            // TabCADPDFs
            // 
            this.TabCADPDFs.Controls.Add(this.TlpCADPDFs);
            this.TabCADPDFs.Location = new System.Drawing.Point(4, 22);
            this.TabCADPDFs.Name = "TabCADPDFs";
            this.TabCADPDFs.Padding = new System.Windows.Forms.Padding(3);
            this.TabCADPDFs.Size = new System.Drawing.Size(786, 418);
            this.TabCADPDFs.TabIndex = 0;
            this.TabCADPDFs.Text = "CAD PDFs";
            this.TabCADPDFs.UseVisualStyleBackColor = true;
            // 
            // TlpCADPDFs
            // 
            this.TlpCADPDFs.ColumnCount = 1;
            this.TlpCADPDFs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpCADPDFs.Controls.Add(this.RtbCADPDFs, 0, 0);
            this.TlpCADPDFs.Controls.Add(this.BtnCADPDFs, 0, 1);
            this.TlpCADPDFs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpCADPDFs.Location = new System.Drawing.Point(3, 3);
            this.TlpCADPDFs.Name = "TlpCADPDFs";
            this.TlpCADPDFs.RowCount = 2;
            this.TlpCADPDFs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpCADPDFs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpCADPDFs.Size = new System.Drawing.Size(780, 412);
            this.TlpCADPDFs.TabIndex = 0;
            // 
            // RtbCADPDFs
            // 
            this.RtbCADPDFs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbCADPDFs.Location = new System.Drawing.Point(3, 3);
            this.RtbCADPDFs.Name = "RtbCADPDFs";
            this.RtbCADPDFs.Size = new System.Drawing.Size(774, 377);
            this.RtbCADPDFs.TabIndex = 0;
            this.RtbCADPDFs.Text = "";
            // 
            // BtnCADPDFs
            // 
            this.BtnCADPDFs.BackColor = System.Drawing.Color.LightGreen;
            this.BtnCADPDFs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnCADPDFs.Enabled = false;
            this.BtnCADPDFs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCADPDFs.Location = new System.Drawing.Point(3, 386);
            this.BtnCADPDFs.Name = "BtnCADPDFs";
            this.BtnCADPDFs.Size = new System.Drawing.Size(774, 23);
            this.BtnCADPDFs.TabIndex = 1;
            this.BtnCADPDFs.Text = "Go";
            this.BtnCADPDFs.UseVisualStyleBackColor = false;
            // 
            // TabPartLookup
            // 
            this.TabPartLookup.Controls.Add(this.TlpPartLookup);
            this.TabPartLookup.Location = new System.Drawing.Point(4, 22);
            this.TabPartLookup.Name = "TabPartLookup";
            this.TabPartLookup.Size = new System.Drawing.Size(786, 418);
            this.TabPartLookup.TabIndex = 1;
            this.TabPartLookup.Text = "Part Lookup";
            this.TabPartLookup.UseVisualStyleBackColor = true;
            // 
            // TabWhereUsed
            // 
            this.TabWhereUsed.Controls.Add(this.label2);
            this.TabWhereUsed.Location = new System.Drawing.Point(4, 22);
            this.TabWhereUsed.Name = "TabWhereUsed";
            this.TabWhereUsed.Size = new System.Drawing.Size(786, 418);
            this.TabWhereUsed.TabIndex = 2;
            this.TabWhereUsed.Text = "Where Used";
            this.TabWhereUsed.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(786, 418);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coming Soon";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 1;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.Controls.Add(this.TabControl, 0, 0);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 1;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.TLP.Size = new System.Drawing.Size(800, 450);
            this.TLP.TabIndex = 1;
            // 
            // TlpPartLookup
            // 
            this.TlpPartLookup.ColumnCount = 2;
            this.TlpPartLookup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.Controls.Add(this.FlowPrefix, 0, 0);
            this.TlpPartLookup.Controls.Add(this.FlowMaxNum, 1, 0);
            this.TlpPartLookup.Controls.Add(this.FlowCache, 0, 1);
            this.TlpPartLookup.Controls.Add(this.RtbKeywords, 0, 2);
            this.TlpPartLookup.Controls.Add(this.RtbResults, 0, 3);
            this.TlpPartLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpPartLookup.Location = new System.Drawing.Point(0, 0);
            this.TlpPartLookup.Name = "TlpPartLookup";
            this.TlpPartLookup.RowCount = 4;
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.Size = new System.Drawing.Size(786, 418);
            this.TlpPartLookup.TabIndex = 0;
            // 
            // FlowPrefix
            // 
            this.FlowPrefix.AutoSize = true;
            this.FlowPrefix.Controls.Add(this.label1);
            this.FlowPrefix.Controls.Add(this.NumPrefixA);
            this.FlowPrefix.Controls.Add(this.NumPrefixB);
            this.FlowPrefix.Controls.Add(this.NumPrefixC);
            this.FlowPrefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowPrefix.Location = new System.Drawing.Point(3, 3);
            this.FlowPrefix.Name = "FlowPrefix";
            this.FlowPrefix.Size = new System.Drawing.Size(387, 26);
            this.FlowPrefix.TabIndex = 0;
            // 
            // FlowMaxNum
            // 
            this.FlowMaxNum.AutoSize = true;
            this.FlowMaxNum.Controls.Add(this.label3);
            this.FlowMaxNum.Controls.Add(this.NumSuffixA);
            this.FlowMaxNum.Controls.Add(this.NumSuffixB);
            this.FlowMaxNum.Controls.Add(this.NumSuffixC);
            this.FlowMaxNum.Controls.Add(this.NumSuffixD);
            this.FlowMaxNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowMaxNum.Location = new System.Drawing.Point(396, 3);
            this.FlowMaxNum.Name = "FlowMaxNum";
            this.FlowMaxNum.Size = new System.Drawing.Size(387, 26);
            this.FlowMaxNum.TabIndex = 1;
            // 
            // FlowCache
            // 
            this.FlowCache.AutoSize = true;
            this.TlpPartLookup.SetColumnSpan(this.FlowCache, 2);
            this.FlowCache.Controls.Add(this.label4);
            this.FlowCache.Controls.Add(this.BtnDownload);
            this.FlowCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowCache.Location = new System.Drawing.Point(3, 35);
            this.FlowCache.Name = "FlowCache";
            this.FlowCache.Size = new System.Drawing.Size(780, 29);
            this.FlowCache.TabIndex = 2;
            // 
            // RtbKeywords
            // 
            this.TlpPartLookup.SetColumnSpan(this.RtbKeywords, 2);
            this.RtbKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbKeywords.Location = new System.Drawing.Point(3, 70);
            this.RtbKeywords.Name = "RtbKeywords";
            this.RtbKeywords.Size = new System.Drawing.Size(780, 169);
            this.RtbKeywords.TabIndex = 3;
            this.RtbKeywords.Text = "Enter keywords (One per line)";
            // 
            // RtbResults
            // 
            this.TlpPartLookup.SetColumnSpan(this.RtbResults, 2);
            this.RtbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbResults.Location = new System.Drawing.Point(3, 245);
            this.RtbResults.Name = "RtbResults";
            this.RtbResults.Size = new System.Drawing.Size(780, 170);
            this.RtbResults.TabIndex = 4;
            this.RtbResults.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prefix";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Max Suffix";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "File Cache";
            // 
            // NumPrefixA
            // 
            this.NumPrefixA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumPrefixA.Location = new System.Drawing.Point(42, 3);
            this.NumPrefixA.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumPrefixA.Name = "NumPrefixA";
            this.NumPrefixA.Size = new System.Drawing.Size(40, 20);
            this.NumPrefixA.TabIndex = 1;
            this.NumPrefixA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPrefixA.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // NumPrefixB
            // 
            this.NumPrefixB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumPrefixB.Location = new System.Drawing.Point(88, 3);
            this.NumPrefixB.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumPrefixB.Name = "NumPrefixB";
            this.NumPrefixB.Size = new System.Drawing.Size(40, 20);
            this.NumPrefixB.TabIndex = 2;
            this.NumPrefixB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NumPrefixC
            // 
            this.NumPrefixC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumPrefixC.Location = new System.Drawing.Point(134, 3);
            this.NumPrefixC.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumPrefixC.Name = "NumPrefixC";
            this.NumPrefixC.Size = new System.Drawing.Size(40, 20);
            this.NumPrefixC.TabIndex = 3;
            this.NumPrefixC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumPrefixC.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // NumSuffixA
            // 
            this.NumSuffixA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumSuffixA.Location = new System.Drawing.Point(65, 3);
            this.NumSuffixA.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumSuffixA.Name = "NumSuffixA";
            this.NumSuffixA.Size = new System.Drawing.Size(40, 20);
            this.NumSuffixA.TabIndex = 2;
            this.NumSuffixA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSuffixA.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // NumSuffixB
            // 
            this.NumSuffixB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumSuffixB.Location = new System.Drawing.Point(111, 3);
            this.NumSuffixB.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumSuffixB.Name = "NumSuffixB";
            this.NumSuffixB.Size = new System.Drawing.Size(40, 20);
            this.NumSuffixB.TabIndex = 3;
            this.NumSuffixB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSuffixB.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // NumSuffixC
            // 
            this.NumSuffixC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumSuffixC.Location = new System.Drawing.Point(157, 3);
            this.NumSuffixC.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumSuffixC.Name = "NumSuffixC";
            this.NumSuffixC.Size = new System.Drawing.Size(40, 20);
            this.NumSuffixC.TabIndex = 4;
            this.NumSuffixC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSuffixC.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // NumSuffixD
            // 
            this.NumSuffixD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NumSuffixD.Location = new System.Drawing.Point(203, 3);
            this.NumSuffixD.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumSuffixD.Name = "NumSuffixD";
            this.NumSuffixD.Size = new System.Drawing.Size(40, 20);
            this.NumSuffixD.TabIndex = 5;
            this.NumSuffixD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumSuffixD.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // BtnDownload
            // 
            this.BtnDownload.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnDownload.BackColor = System.Drawing.Color.LightGray;
            this.BtnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDownload.Location = new System.Drawing.Point(66, 3);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(75, 23);
            this.BtnDownload.TabIndex = 1;
            this.BtnDownload.Text = "Download";
            this.BtnDownload.UseVisualStyleBackColor = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TLP);
            this.Name = "FormMain";
            this.Text = "Windows Aras Tools";
            this.TabControl.ResumeLayout(false);
            this.TabCADPDFs.ResumeLayout(false);
            this.TlpCADPDFs.ResumeLayout(false);
            this.TabPartLookup.ResumeLayout(false);
            this.TabWhereUsed.ResumeLayout(false);
            this.TLP.ResumeLayout(false);
            this.TlpPartLookup.ResumeLayout(false);
            this.TlpPartLookup.PerformLayout();
            this.FlowPrefix.ResumeLayout(false);
            this.FlowPrefix.PerformLayout();
            this.FlowMaxNum.ResumeLayout(false);
            this.FlowMaxNum.PerformLayout();
            this.FlowCache.ResumeLayout(false);
            this.FlowCache.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabCADPDFs;
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.TabPage TabPartLookup;
        private System.Windows.Forms.TabPage TabWhereUsed;
        private System.Windows.Forms.TableLayoutPanel TlpCADPDFs;
        private System.Windows.Forms.RichTextBox RtbCADPDFs;
        private System.Windows.Forms.Button BtnCADPDFs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel TlpPartLookup;
        private System.Windows.Forms.FlowLayoutPanel FlowPrefix;
        private System.Windows.Forms.FlowLayoutPanel FlowMaxNum;
        private System.Windows.Forms.FlowLayoutPanel FlowCache;
        private System.Windows.Forms.RichTextBox RtbKeywords;
        private System.Windows.Forms.RichTextBox RtbResults;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumPrefixA;
        private System.Windows.Forms.NumericUpDown NumPrefixB;
        private System.Windows.Forms.NumericUpDown NumPrefixC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumSuffixA;
        private System.Windows.Forms.NumericUpDown NumSuffixB;
        private System.Windows.Forms.NumericUpDown NumSuffixC;
        private System.Windows.Forms.NumericUpDown NumSuffixD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnDownload;
    }
}

