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
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.tab305parts = new System.Windows.Forms.TabPage();
            this.tabWhereUsed = new System.Windows.Forms.TabPage();
            this.TlpCADPDFs = new System.Windows.Forms.TableLayoutPanel();
            this.RtbCADPDFs = new System.Windows.Forms.RichTextBox();
            this.BtnCADPDFs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CADPDFsWorker = new System.ComponentModel.BackgroundWorker();
            this.TabControl.SuspendLayout();
            this.TabCADPDFs.SuspendLayout();
            this.TLP.SuspendLayout();
            this.tab305parts.SuspendLayout();
            this.tabWhereUsed.SuspendLayout();
            this.TlpCADPDFs.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabCADPDFs);
            this.TabControl.Controls.Add(this.tab305parts);
            this.TabControl.Controls.Add(this.tabWhereUsed);
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
            // tab305parts
            // 
            this.tab305parts.Controls.Add(this.label1);
            this.tab305parts.Location = new System.Drawing.Point(4, 22);
            this.tab305parts.Name = "tab305parts";
            this.tab305parts.Size = new System.Drawing.Size(786, 418);
            this.tab305parts.TabIndex = 1;
            this.tab305parts.Text = "305-* Parts";
            this.tab305parts.UseVisualStyleBackColor = true;
            // 
            // tabWhereUsed
            // 
            this.tabWhereUsed.Controls.Add(this.label2);
            this.tabWhereUsed.Location = new System.Drawing.Point(4, 22);
            this.tabWhereUsed.Name = "tabWhereUsed";
            this.tabWhereUsed.Size = new System.Drawing.Size(786, 418);
            this.tabWhereUsed.TabIndex = 2;
            this.tabWhereUsed.Text = "Where Used";
            this.tabWhereUsed.UseVisualStyleBackColor = true;
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
            this.BtnCADPDFs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCADPDFs.Location = new System.Drawing.Point(3, 386);
            this.BtnCADPDFs.Name = "BtnCADPDFs";
            this.BtnCADPDFs.Size = new System.Drawing.Size(774, 23);
            this.BtnCADPDFs.TabIndex = 1;
            this.BtnCADPDFs.Text = "Go";
            this.BtnCADPDFs.UseVisualStyleBackColor = false;
            this.BtnCADPDFs.Click += new System.EventHandler(this.BtnCADPDFs_Click);
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
            // CADPDFsWorker
            // 
            this.CADPDFsWorker.WorkerReportsProgress = true;
            this.CADPDFsWorker.WorkerSupportsCancellation = true;
            this.CADPDFsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CADPDFsWorker_DoWork);
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
            this.TLP.ResumeLayout(false);
            this.tab305parts.ResumeLayout(false);
            this.tabWhereUsed.ResumeLayout(false);
            this.TlpCADPDFs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabCADPDFs;
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.TabPage tab305parts;
        private System.Windows.Forms.TabPage tabWhereUsed;
        private System.Windows.Forms.TableLayoutPanel TlpCADPDFs;
        private System.Windows.Forms.RichTextBox RtbCADPDFs;
        private System.Windows.Forms.Button BtnCADPDFs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker CADPDFsWorker;
    }
}

