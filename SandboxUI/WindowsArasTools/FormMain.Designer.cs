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
            this.cadpdFs1 = new WindowsArasTools.Tools.CADPDFs();
            this.TabPartLookup = new System.Windows.Forms.TabPage();
            this.partLookup1 = new WindowsArasTools.Tools.PartLookup();
            this.TabWhereUsed = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.TabControl.SuspendLayout();
            this.TabCADPDFs.SuspendLayout();
            this.TabPartLookup.SuspendLayout();
            this.TabWhereUsed.SuspendLayout();
            this.TLP.SuspendLayout();
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
            this.TabCADPDFs.Controls.Add(this.cadpdFs1);
            this.TabCADPDFs.Location = new System.Drawing.Point(4, 22);
            this.TabCADPDFs.Name = "TabCADPDFs";
            this.TabCADPDFs.Padding = new System.Windows.Forms.Padding(3);
            this.TabCADPDFs.Size = new System.Drawing.Size(786, 418);
            this.TabCADPDFs.TabIndex = 0;
            this.TabCADPDFs.Text = "CAD PDFs";
            this.TabCADPDFs.UseVisualStyleBackColor = true;
            // 
            // cadpdFs1
            // 
            this.cadpdFs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cadpdFs1.Location = new System.Drawing.Point(3, 3);
            this.cadpdFs1.MinimumSize = new System.Drawing.Size(140, 70);
            this.cadpdFs1.Name = "cadpdFs1";
            this.cadpdFs1.Size = new System.Drawing.Size(780, 412);
            this.cadpdFs1.TabIndex = 0;
            // 
            // TabPartLookup
            // 
            this.TabPartLookup.Controls.Add(this.partLookup1);
            this.TabPartLookup.Location = new System.Drawing.Point(4, 22);
            this.TabPartLookup.Name = "TabPartLookup";
            this.TabPartLookup.Size = new System.Drawing.Size(786, 418);
            this.TabPartLookup.TabIndex = 1;
            this.TabPartLookup.Text = "Part Lookup";
            this.TabPartLookup.UseVisualStyleBackColor = true;
            // 
            // partLookup1
            // 
            this.partLookup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partLookup1.Location = new System.Drawing.Point(0, 0);
            this.partLookup1.MinimumSize = new System.Drawing.Size(550, 200);
            this.partLookup1.Name = "partLookup1";
            this.partLookup1.Size = new System.Drawing.Size(786, 418);
            this.partLookup1.TabIndex = 0;
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
            this.TabPartLookup.ResumeLayout(false);
            this.TabWhereUsed.ResumeLayout(false);
            this.TLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage TabCADPDFs;
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.TabPage TabPartLookup;
        private System.Windows.Forms.TabPage TabWhereUsed;
        private System.Windows.Forms.Label label2;
        private Tools.CADPDFs cadpdFs1;
        private Tools.PartLookup partLookup1;
        private System.Windows.Forms.TabControl TabControl;
    }
}

