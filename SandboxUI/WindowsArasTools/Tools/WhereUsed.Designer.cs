namespace WindowsArasTools.Tools
{
    partial class WhereUsed
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
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.TxtPartNumber = new System.Windows.Forms.TextBox();
            this.BtnRun = new System.Windows.Forms.Button();
            this.WebBrowser = new System.Windows.Forms.WebBrowser();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnChurnCSV = new System.Windows.Forms.Button();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 2;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP.Controls.Add(this.TxtPartNumber, 0, 0);
            this.TLP.Controls.Add(this.BtnRun, 0, 1);
            this.TLP.Controls.Add(this.WebBrowser, 0, 2);
            this.TLP.Controls.Add(this.BtnSave, 0, 3);
            this.TLP.Controls.Add(this.BtnChurnCSV, 1, 0);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 4;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.Size = new System.Drawing.Size(180, 150);
            this.TLP.TabIndex = 0;
            // 
            // TxtPartNumber
            // 
            this.TxtPartNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPartNumber.Location = new System.Drawing.Point(3, 4);
            this.TxtPartNumber.Name = "TxtPartNumber";
            this.TxtPartNumber.Size = new System.Drawing.Size(93, 20);
            this.TxtPartNumber.TabIndex = 1;
            this.TxtPartNumber.Text = "305-0059";
            this.TxtPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtPartNumber.TextChanged += new System.EventHandler(this.TxtPartNumber_TextChanged);
            // 
            // BtnRun
            // 
            this.BtnRun.AutoSize = true;
            this.BtnRun.BackColor = System.Drawing.Color.LightGreen;
            this.TLP.SetColumnSpan(this.BtnRun, 2);
            this.BtnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRun.Location = new System.Drawing.Point(3, 32);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(174, 25);
            this.BtnRun.TabIndex = 0;
            this.BtnRun.Text = "Get Where Used Quantities";
            this.BtnRun.UseVisualStyleBackColor = false;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // WebBrowser
            // 
            this.TLP.SetColumnSpan(this.WebBrowser, 2);
            this.WebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowser.Location = new System.Drawing.Point(3, 63);
            this.WebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser.Name = "WebBrowser";
            this.WebBrowser.Size = new System.Drawing.Size(174, 53);
            this.WebBrowser.TabIndex = 2;
            // 
            // BtnSave
            // 
            this.BtnSave.AutoSize = true;
            this.BtnSave.BackColor = System.Drawing.Color.White;
            this.TLP.SetColumnSpan(this.BtnSave, 2);
            this.BtnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(3, 122);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(174, 25);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save Webpage";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnChurnCSV
            // 
            this.BtnChurnCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChurnCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChurnCSV.Location = new System.Drawing.Point(102, 3);
            this.BtnChurnCSV.Name = "BtnChurnCSV";
            this.BtnChurnCSV.Size = new System.Drawing.Size(75, 23);
            this.BtnChurnCSV.TabIndex = 4;
            this.BtnChurnCSV.Text = "Churn CSV";
            this.BtnChurnCSV.UseVisualStyleBackColor = true;
            this.BtnChurnCSV.Click += new System.EventHandler(this.BtnChurnCSV_Click);
            // 
            // WhereUsed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TLP);
            this.MinimumSize = new System.Drawing.Size(180, 150);
            this.Name = "WhereUsed";
            this.Size = new System.Drawing.Size(180, 150);
            this.TLP.ResumeLayout(false);
            this.TLP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.TextBox TxtPartNumber;
        private System.Windows.Forms.WebBrowser WebBrowser;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnChurnCSV;
    }
}
