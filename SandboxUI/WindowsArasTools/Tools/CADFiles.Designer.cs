namespace WindowsArasTools.Tools
{
    partial class CADFiles
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
            this.TlpCADPDFs = new System.Windows.Forms.TableLayoutPanel();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.BTN = new System.Windows.Forms.Button();
            this.TlpCADPDFs.SuspendLayout();
            this.SuspendLayout();
            // 
            // TlpCADPDFs
            // 
            this.TlpCADPDFs.ColumnCount = 1;
            this.TlpCADPDFs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpCADPDFs.Controls.Add(this.RTB, 0, 0);
            this.TlpCADPDFs.Controls.Add(this.BTN, 0, 1);
            this.TlpCADPDFs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpCADPDFs.Location = new System.Drawing.Point(0, 0);
            this.TlpCADPDFs.Name = "TlpCADPDFs";
            this.TlpCADPDFs.RowCount = 2;
            this.TlpCADPDFs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpCADPDFs.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpCADPDFs.Size = new System.Drawing.Size(140, 70);
            this.TlpCADPDFs.TabIndex = 1;
            // 
            // RTB
            // 
            this.RTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB.Location = new System.Drawing.Point(3, 3);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(134, 35);
            this.RTB.TabIndex = 0;
            this.RTB.Text = "";
            // 
            // BTN
            // 
            this.BTN.BackColor = System.Drawing.Color.LightGreen;
            this.BTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN.Location = new System.Drawing.Point(3, 44);
            this.BTN.Name = "BTN";
            this.BTN.Size = new System.Drawing.Size(134, 23);
            this.BTN.TabIndex = 1;
            this.BTN.Text = "Go";
            this.BTN.UseVisualStyleBackColor = false;
            this.BTN.Click += new System.EventHandler(this.BTN_Click);
            // 
            // CADPDFs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TlpCADPDFs);
            this.MinimumSize = new System.Drawing.Size(140, 70);
            this.Name = "CADPDFs";
            this.Size = new System.Drawing.Size(140, 70);
            this.TlpCADPDFs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TlpCADPDFs;
        private System.Windows.Forms.RichTextBox RTB;
        private System.Windows.Forms.Button BTN;
    }
}
