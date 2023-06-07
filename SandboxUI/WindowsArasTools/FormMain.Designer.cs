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
            this.Tab305parts = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.TabWhereUsed = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.TabControl.SuspendLayout();
            this.TabCADPDFs.SuspendLayout();
            this.TlpCADPDFs.SuspendLayout();
            this.Tab305parts.SuspendLayout();
            this.TabWhereUsed.SuspendLayout();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabCADPDFs);
            this.TabControl.Controls.Add(this.Tab305parts);
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
            this.RtbCADPDFs.Text = "Replace this text with a list of Aras part numbers (Separated by new line) that h" +
    "ave an associated CAD PDF that you would like to download.";
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
            // Tab305parts
            // 
            this.Tab305parts.Controls.Add(this.label1);
            this.Tab305parts.Location = new System.Drawing.Point(4, 22);
            this.Tab305parts.Name = "Tab305parts";
            this.Tab305parts.Size = new System.Drawing.Size(786, 418);
            this.Tab305parts.TabIndex = 1;
            this.Tab305parts.Text = "305-* Parts";
            this.Tab305parts.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(786, 418);
            this.label1.TabIndex = 0;
            this.label1.Text = "Coming Soon";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.Size = new System.Drawing.Size(800, 450);
            this.TLP.TabIndex = 1;
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
            this.Tab305parts.ResumeLayout(false);
            this.TabWhereUsed.ResumeLayout(false);
            this.TLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabCADPDFs;
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.TabPage Tab305parts;
        private System.Windows.Forms.TabPage TabWhereUsed;
        private System.Windows.Forms.TableLayoutPanel TlpCADPDFs;
        private System.Windows.Forms.RichTextBox RtbCADPDFs;
        private System.Windows.Forms.Button BtnCADPDFs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

