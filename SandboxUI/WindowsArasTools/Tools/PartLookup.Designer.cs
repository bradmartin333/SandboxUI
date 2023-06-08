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
            this.RtbKeywords = new System.Windows.Forms.RichTextBox();
            this.RtbResults = new System.Windows.Forms.RichTextBox();
            this.FlowCache = new System.Windows.Forms.FlowLayoutPanel();
            this.LblFileCache = new System.Windows.Forms.Label();
            this.BtnDownloadCache = new System.Windows.Forms.Button();
            this.TlpPartLookup.SuspendLayout();
            this.FlowPrefix.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumPrefixC)).BeginInit();
            this.FlowCache.SuspendLayout();
            this.SuspendLayout();
            // 
            // TlpPartLookup
            // 
            this.TlpPartLookup.ColumnCount = 2;
            this.TlpPartLookup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.Controls.Add(this.FlowPrefix, 0, 0);
            this.TlpPartLookup.Controls.Add(this.RtbKeywords, 0, 1);
            this.TlpPartLookup.Controls.Add(this.RtbResults, 0, 2);
            this.TlpPartLookup.Controls.Add(this.FlowCache, 2, 0);
            this.TlpPartLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpPartLookup.Location = new System.Drawing.Point(0, 0);
            this.TlpPartLookup.Name = "TlpPartLookup";
            this.TlpPartLookup.RowCount = 3;
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
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
            this.FlowPrefix.Size = new System.Drawing.Size(269, 31);
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
            this.NumPrefixA.ValueChanged += new System.EventHandler(this.NumPrefix_ValueChanged);
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
            this.NumPrefixB.ValueChanged += new System.EventHandler(this.NumPrefix_ValueChanged);
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
            this.NumPrefixC.ValueChanged += new System.EventHandler(this.NumPrefix_ValueChanged);
            // 
            // RtbKeywords
            // 
            this.TlpPartLookup.SetColumnSpan(this.RtbKeywords, 2);
            this.RtbKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbKeywords.Location = new System.Drawing.Point(3, 40);
            this.RtbKeywords.Name = "RtbKeywords";
            this.RtbKeywords.Size = new System.Drawing.Size(544, 75);
            this.RtbKeywords.TabIndex = 3;
            this.RtbKeywords.Text = "Enter keywords (One per line)";
            this.RtbKeywords.TextChanged += new System.EventHandler(this.RtbKeywords_TextChanged);
            // 
            // RtbResults
            // 
            this.TlpPartLookup.SetColumnSpan(this.RtbResults, 2);
            this.RtbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbResults.Location = new System.Drawing.Point(3, 121);
            this.RtbResults.Name = "RtbResults";
            this.RtbResults.Size = new System.Drawing.Size(544, 76);
            this.RtbResults.TabIndex = 4;
            this.RtbResults.Text = "";
            // 
            // FlowCache
            // 
            this.FlowCache.AutoSize = true;
            this.FlowCache.Controls.Add(this.LblFileCache);
            this.FlowCache.Controls.Add(this.BtnDownloadCache);
            this.FlowCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowCache.Location = new System.Drawing.Point(278, 3);
            this.FlowCache.Name = "FlowCache";
            this.FlowCache.Size = new System.Drawing.Size(269, 31);
            this.FlowCache.TabIndex = 2;
            // 
            // LblFileCache
            // 
            this.LblFileCache.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblFileCache.AutoSize = true;
            this.LblFileCache.Location = new System.Drawing.Point(3, 9);
            this.LblFileCache.Name = "LblFileCache";
            this.LblFileCache.Size = new System.Drawing.Size(57, 13);
            this.LblFileCache.TabIndex = 0;
            this.LblFileCache.Text = "File Cache";
            // 
            // BtnDownloadCache
            // 
            this.BtnDownloadCache.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnDownloadCache.AutoSize = true;
            this.BtnDownloadCache.BackColor = System.Drawing.Color.LightGray;
            this.BtnDownloadCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDownloadCache.Location = new System.Drawing.Point(66, 3);
            this.BtnDownloadCache.Name = "BtnDownloadCache";
            this.BtnDownloadCache.Size = new System.Drawing.Size(75, 25);
            this.BtnDownloadCache.TabIndex = 1;
            this.BtnDownloadCache.Text = "Download";
            this.BtnDownloadCache.UseVisualStyleBackColor = false;
            this.BtnDownloadCache.Click += new System.EventHandler(this.BtnDownloadCache_Click);
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
        private System.Windows.Forms.FlowLayoutPanel FlowCache;
        private System.Windows.Forms.Label LblFileCache;
        private System.Windows.Forms.Button BtnDownloadCache;
        private System.Windows.Forms.RichTextBox RtbKeywords;
        private System.Windows.Forms.RichTextBox RtbResults;
    }
}
