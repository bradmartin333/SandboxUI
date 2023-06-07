namespace WindowsArasTools.Tools
{
    partial class PartLookup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TlpPartLookup = new System.Windows.Forms.TableLayoutPanel();
            this.FlowPrefix = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumPrefixA = new System.Windows.Forms.NumericUpDown();
            this.NumPrefixB = new System.Windows.Forms.NumericUpDown();
            this.NumPrefixC = new System.Windows.Forms.NumericUpDown();
            this.FlowMaxNum = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.NumSuffixA = new System.Windows.Forms.NumericUpDown();
            this.NumSuffixB = new System.Windows.Forms.NumericUpDown();
            this.NumSuffixC = new System.Windows.Forms.NumericUpDown();
            this.NumSuffixD = new System.Windows.Forms.NumericUpDown();
            this.FlowCache = new System.Windows.Forms.FlowLayoutPanel();
            this.LblFileCache = new System.Windows.Forms.Label();
            this.BtnDownloadCache = new System.Windows.Forms.Button();
            this.RtbKeywords = new System.Windows.Forms.RichTextBox();
            this.RtbResults = new System.Windows.Forms.RichTextBox();
            this.TlpPartLookup.SuspendLayout();
            this.FlowPrefix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixC)).BeginInit();
            this.FlowMaxNum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixD)).BeginInit();
            this.FlowCache.SuspendLayout();
            this.SuspendLayout();
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
            this.TlpPartLookup.Size = new System.Drawing.Size(550, 200);
            this.TlpPartLookup.TabIndex = 1;
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
            this.FlowPrefix.Size = new System.Drawing.Size(269, 26);
            this.FlowPrefix.TabIndex = 0;
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
            // FlowMaxNum
            // 
            this.FlowMaxNum.AutoSize = true;
            this.FlowMaxNum.Controls.Add(this.label3);
            this.FlowMaxNum.Controls.Add(this.NumSuffixA);
            this.FlowMaxNum.Controls.Add(this.NumSuffixB);
            this.FlowMaxNum.Controls.Add(this.NumSuffixC);
            this.FlowMaxNum.Controls.Add(this.NumSuffixD);
            this.FlowMaxNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowMaxNum.Location = new System.Drawing.Point(278, 3);
            this.FlowMaxNum.Name = "FlowMaxNum";
            this.FlowMaxNum.Size = new System.Drawing.Size(269, 26);
            this.FlowMaxNum.TabIndex = 1;
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
            // FlowCache
            // 
            this.FlowCache.AutoSize = true;
            this.TlpPartLookup.SetColumnSpan(this.FlowCache, 2);
            this.FlowCache.Controls.Add(this.LblFileCache);
            this.FlowCache.Controls.Add(this.BtnDownloadCache);
            this.FlowCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowCache.Location = new System.Drawing.Point(3, 35);
            this.FlowCache.Name = "FlowCache";
            this.FlowCache.Size = new System.Drawing.Size(544, 29);
            this.FlowCache.TabIndex = 2;
            // 
            // LblFileCache
            // 
            this.LblFileCache.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblFileCache.AutoSize = true;
            this.LblFileCache.Location = new System.Drawing.Point(3, 8);
            this.LblFileCache.Name = "LblFileCache";
            this.LblFileCache.Size = new System.Drawing.Size(57, 13);
            this.LblFileCache.TabIndex = 0;
            this.LblFileCache.Text = "File Cache";
            // 
            // BtnDownloadCache
            // 
            this.BtnDownloadCache.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnDownloadCache.BackColor = System.Drawing.Color.LightGray;
            this.BtnDownloadCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDownloadCache.Location = new System.Drawing.Point(66, 3);
            this.BtnDownloadCache.Name = "BtnDownloadCache";
            this.BtnDownloadCache.Size = new System.Drawing.Size(75, 23);
            this.BtnDownloadCache.TabIndex = 1;
            this.BtnDownloadCache.Text = "Download";
            this.BtnDownloadCache.UseVisualStyleBackColor = false;
            // 
            // RtbKeywords
            // 
            this.TlpPartLookup.SetColumnSpan(this.RtbKeywords, 2);
            this.RtbKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbKeywords.Location = new System.Drawing.Point(3, 70);
            this.RtbKeywords.Name = "RtbKeywords";
            this.RtbKeywords.Size = new System.Drawing.Size(544, 60);
            this.RtbKeywords.TabIndex = 3;
            this.RtbKeywords.Text = "Enter keywords (One per line)";
            // 
            // RtbResults
            // 
            this.TlpPartLookup.SetColumnSpan(this.RtbResults, 2);
            this.RtbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbResults.Location = new System.Drawing.Point(3, 136);
            this.RtbResults.Name = "RtbResults";
            this.RtbResults.Size = new System.Drawing.Size(544, 61);
            this.RtbResults.TabIndex = 4;
            this.RtbResults.Text = "";
            // 
            // PartLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TlpPartLookup);
            this.MinimumSize = new System.Drawing.Size(550, 200);
            this.Name = "PartLookup";
            this.Size = new System.Drawing.Size(550, 200);
            this.TlpPartLookup.ResumeLayout(false);
            this.TlpPartLookup.PerformLayout();
            this.FlowPrefix.ResumeLayout(false);
            this.FlowPrefix.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixC)).EndInit();
            this.FlowMaxNum.ResumeLayout(false);
            this.FlowMaxNum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumSuffixD)).EndInit();
            this.FlowCache.ResumeLayout(false);
            this.FlowCache.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlpPartLookup;
        private System.Windows.Forms.FlowLayoutPanel FlowPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumPrefixA;
        private System.Windows.Forms.NumericUpDown NumPrefixB;
        private System.Windows.Forms.NumericUpDown NumPrefixC;
        private System.Windows.Forms.FlowLayoutPanel FlowMaxNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumSuffixA;
        private System.Windows.Forms.NumericUpDown NumSuffixB;
        private System.Windows.Forms.NumericUpDown NumSuffixC;
        private System.Windows.Forms.NumericUpDown NumSuffixD;
        private System.Windows.Forms.FlowLayoutPanel FlowCache;
        private System.Windows.Forms.Label LblFileCache;
        private System.Windows.Forms.Button BtnDownloadCache;
        private System.Windows.Forms.RichTextBox RtbKeywords;
        private System.Windows.Forms.RichTextBox RtbResults;
    }
}
