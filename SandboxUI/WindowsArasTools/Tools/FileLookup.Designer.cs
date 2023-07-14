namespace WindowsArasTools.Tools
{
    partial class FileLookup
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
            this.RtbKeywords = new System.Windows.Forms.RichTextBox();
            this.RtbResults = new System.Windows.Forms.RichTextBox();
            this.FlowCache = new System.Windows.Forms.FlowLayoutPanel();
            this.LblFileCache = new System.Windows.Forms.Label();
            this.BtnDownloadCache = new System.Windows.Forms.Button();
            this.TlpPartLookup.SuspendLayout();
            this.FlowCache.SuspendLayout();
            this.SuspendLayout();
            // 
            // TlpPartLookup
            // 
            this.TlpPartLookup.ColumnCount = 1;
            this.TlpPartLookup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpPartLookup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TlpPartLookup.Controls.Add(this.RtbKeywords, 0, 1);
            this.TlpPartLookup.Controls.Add(this.RtbResults, 0, 2);
            this.TlpPartLookup.Controls.Add(this.FlowCache, 0, 0);
            this.TlpPartLookup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpPartLookup.Location = new System.Drawing.Point(0, 0);
            this.TlpPartLookup.Name = "TlpPartLookup";
            this.TlpPartLookup.RowCount = 3;
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpPartLookup.Size = new System.Drawing.Size(550, 200);
            this.TlpPartLookup.TabIndex = 1;
            // 
            // RtbKeywords
            // 
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
            this.FlowCache.Location = new System.Drawing.Point(3, 3);
            this.FlowCache.Name = "FlowCache";
            this.FlowCache.Size = new System.Drawing.Size(544, 31);
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
            // FileLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TlpPartLookup);
            this.MinimumSize = new System.Drawing.Size(550, 200);
            this.Name = "FileLookup";
            this.Size = new System.Drawing.Size(550, 200);
            this.TlpPartLookup.ResumeLayout(false);
            this.TlpPartLookup.PerformLayout();
            this.FlowCache.ResumeLayout(false);
            this.FlowCache.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlpPartLookup;
        private System.Windows.Forms.FlowLayoutPanel FlowCache;
        private System.Windows.Forms.Label LblFileCache;
        private System.Windows.Forms.Button BtnDownloadCache;
        private System.Windows.Forms.RichTextBox RtbKeywords;
        private System.Windows.Forms.RichTextBox RtbResults;
    }
}
