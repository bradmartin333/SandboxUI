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
            this.tabCADPDFs = new System.Windows.Forms.TabPage();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.tab305parts = new System.Windows.Forms.TabPage();
            this.tabWhereUsed = new System.Windows.Forms.TabPage();
            this.TabControl.SuspendLayout();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabCADPDFs);
            this.TabControl.Controls.Add(this.tab305parts);
            this.TabControl.Controls.Add(this.tabWhereUsed);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(3, 3);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(794, 444);
            this.TabControl.TabIndex = 0;
            // 
            // tabCADPDFs
            // 
            this.tabCADPDFs.Location = new System.Drawing.Point(4, 22);
            this.tabCADPDFs.Name = "tabCADPDFs";
            this.tabCADPDFs.Padding = new System.Windows.Forms.Padding(3);
            this.tabCADPDFs.Size = new System.Drawing.Size(786, 418);
            this.tabCADPDFs.TabIndex = 0;
            this.tabCADPDFs.Text = "CAD PDFs";
            this.tabCADPDFs.UseVisualStyleBackColor = true;
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
            this.tab305parts.Location = new System.Drawing.Point(4, 22);
            this.tab305parts.Name = "tab305parts";
            this.tab305parts.Size = new System.Drawing.Size(786, 418);
            this.tab305parts.TabIndex = 1;
            this.tab305parts.Text = "305-* Parts";
            this.tab305parts.UseVisualStyleBackColor = true;
            // 
            // tabWhereUsed
            // 
            this.tabWhereUsed.Location = new System.Drawing.Point(4, 22);
            this.tabWhereUsed.Name = "tabWhereUsed";
            this.tabWhereUsed.Size = new System.Drawing.Size(786, 418);
            this.tabWhereUsed.TabIndex = 2;
            this.tabWhereUsed.Text = "Where Used";
            this.tabWhereUsed.UseVisualStyleBackColor = true;
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
            this.TLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabCADPDFs;
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.TabPage tab305parts;
        private System.Windows.Forms.TabPage tabWhereUsed;
    }
}

