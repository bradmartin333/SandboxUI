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
            this.TabCADFiles = new System.Windows.Forms.TabPage();
            this.cadFiles1 = new WindowsArasTools.Tools.CADFiles();
            this.TabPartLookup = new System.Windows.Forms.TabPage();
            this.TabFileLookup = new System.Windows.Forms.TabPage();
            this.TabWhereUsed = new System.Windows.Forms.TabPage();
            this.whereUsed1 = new WindowsArasTools.Tools.WhereUsed();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.partLookup1 = new WindowsArasTools.Tools.PartLookup();
            this.fileLookup1 = new WindowsArasTools.Tools.FileLookup();
            this.TabControl.SuspendLayout();
            this.TabCADFiles.SuspendLayout();
            this.TabPartLookup.SuspendLayout();
            this.TabFileLookup.SuspendLayout();
            this.TabWhereUsed.SuspendLayout();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabCADFiles);
            this.TabControl.Controls.Add(this.TabPartLookup);
            this.TabControl.Controls.Add(this.TabWhereUsed);
            this.TabControl.Controls.Add(this.TabFileLookup);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(3, 3);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(794, 444);
            this.TabControl.TabIndex = 0;
            // 
            // TabCADFiles
            // 
            this.TabCADFiles.Controls.Add(this.cadFiles1);
            this.TabCADFiles.Location = new System.Drawing.Point(4, 22);
            this.TabCADFiles.Name = "TabCADFiles";
            this.TabCADFiles.Size = new System.Drawing.Size(786, 418);
            this.TabCADFiles.TabIndex = 3;
            this.TabCADFiles.Text = "CAD Files";
            this.TabCADFiles.UseVisualStyleBackColor = true;
            // 
            // cadFiles1
            // 
            this.cadFiles1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cadFiles1.Location = new System.Drawing.Point(0, 0);
            this.cadFiles1.MinimumSize = new System.Drawing.Size(140, 70);
            this.cadFiles1.Name = "cadFiles1";
            this.cadFiles1.Size = new System.Drawing.Size(786, 418);
            this.cadFiles1.TabIndex = 0;
            // 
            // TabPartLookup
            // 
            this.TabPartLookup.BackColor = System.Drawing.Color.LightBlue;
            this.TabPartLookup.Controls.Add(this.partLookup1);
            this.TabPartLookup.Location = new System.Drawing.Point(4, 22);
            this.TabPartLookup.Name = "TabPartLookup";
            this.TabPartLookup.Size = new System.Drawing.Size(786, 418);
            this.TabPartLookup.TabIndex = 1;
            this.TabPartLookup.Text = "Part Lookup";
            // 
            // TabFileLookup
            // 
            this.TabFileLookup.BackColor = System.Drawing.Color.LightGreen;
            this.TabFileLookup.Controls.Add(this.fileLookup1);
            this.TabFileLookup.Location = new System.Drawing.Point(4, 22);
            this.TabFileLookup.Name = "TabFileLookup";
            this.TabFileLookup.Size = new System.Drawing.Size(786, 418);
            this.TabFileLookup.TabIndex = 5;
            this.TabFileLookup.Text = "File Lookup";
            // 
            // TabWhereUsed
            // 
            this.TabWhereUsed.Controls.Add(this.whereUsed1);
            this.TabWhereUsed.Location = new System.Drawing.Point(4, 22);
            this.TabWhereUsed.Name = "TabWhereUsed";
            this.TabWhereUsed.Size = new System.Drawing.Size(786, 418);
            this.TabWhereUsed.TabIndex = 4;
            this.TabWhereUsed.Text = "Where Used";
            this.TabWhereUsed.UseVisualStyleBackColor = true;
            // 
            // whereUsed1
            // 
            this.whereUsed1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whereUsed1.Location = new System.Drawing.Point(0, 0);
            this.whereUsed1.MinimumSize = new System.Drawing.Size(180, 150);
            this.whereUsed1.Name = "whereUsed1";
            this.whereUsed1.Size = new System.Drawing.Size(786, 418);
            this.whereUsed1.TabIndex = 0;
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
            // partLookup1
            // 
            this.partLookup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partLookup1.Location = new System.Drawing.Point(0, 0);
            this.partLookup1.MinimumSize = new System.Drawing.Size(550, 200);
            this.partLookup1.Name = "partLookup1";
            this.partLookup1.Size = new System.Drawing.Size(786, 418);
            this.partLookup1.TabIndex = 0;
            // 
            // fileLookup1
            // 
            this.fileLookup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileLookup1.Location = new System.Drawing.Point(0, 0);
            this.fileLookup1.MinimumSize = new System.Drawing.Size(550, 200);
            this.fileLookup1.Name = "fileLookup1";
            this.fileLookup1.Size = new System.Drawing.Size(786, 418);
            this.fileLookup1.TabIndex = 0;
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
            this.TabCADFiles.ResumeLayout(false);
            this.TabPartLookup.ResumeLayout(false);
            this.TabFileLookup.ResumeLayout(false);
            this.TabWhereUsed.ResumeLayout(false);
            this.TLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.TabPage TabPartLookup;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabCADFiles;
        private Tools.CADFiles cadFiles1;
        private System.Windows.Forms.TabPage TabWhereUsed;
        private Tools.WhereUsed whereUsed1;
        private System.Windows.Forms.TabPage TabFileLookup;
        private Tools.PartLookup partLookup1;
        private Tools.FileLookup fileLookup1;
    }
}

