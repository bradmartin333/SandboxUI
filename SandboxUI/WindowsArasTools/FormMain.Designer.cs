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
            this.TabWhereUsed = new System.Windows.Forms.TabPage();
            this.whereUsed1 = new WindowsArasTools.Tools.WhereUsed();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.TabPartLookup = new System.Windows.Forms.TabPage();
            this.TabDocumentLookup = new System.Windows.Forms.TabPage();
            this.TabFunButton = new System.Windows.Forms.TabPage();
            this.BtnFun = new System.Windows.Forms.Button();
            this.CbxDanger = new System.Windows.Forms.CheckBox();
            this.TabControl.SuspendLayout();
            this.TabCADFiles.SuspendLayout();
            this.TabWhereUsed.SuspendLayout();
            this.TLP.SuspendLayout();
            this.TabFunButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabCADFiles);
            this.TabControl.Controls.Add(this.TabWhereUsed);
            this.TabControl.Controls.Add(this.TabPartLookup);
            this.TabControl.Controls.Add(this.TabDocumentLookup);
            this.TabControl.Controls.Add(this.TabFunButton);
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
            // TabPartLookup
            // 
            this.TabPartLookup.BackColor = System.Drawing.Color.LightGreen;
            this.TabPartLookup.Location = new System.Drawing.Point(4, 22);
            this.TabPartLookup.Name = "TabPartLookup";
            this.TabPartLookup.Padding = new System.Windows.Forms.Padding(3);
            this.TabPartLookup.Size = new System.Drawing.Size(786, 418);
            this.TabPartLookup.TabIndex = 5;
            this.TabPartLookup.Text = "Part Lookup";
            // 
            // TabDocumentLookup
            // 
            this.TabDocumentLookup.BackColor = System.Drawing.Color.LightBlue;
            this.TabDocumentLookup.Location = new System.Drawing.Point(4, 22);
            this.TabDocumentLookup.Name = "TabDocumentLookup";
            this.TabDocumentLookup.Padding = new System.Windows.Forms.Padding(3);
            this.TabDocumentLookup.Size = new System.Drawing.Size(786, 418);
            this.TabDocumentLookup.TabIndex = 6;
            this.TabDocumentLookup.Text = "Document Lookup";
            // 
            // TabFunButton
            // 
            this.TabFunButton.Controls.Add(this.CbxDanger);
            this.TabFunButton.Controls.Add(this.BtnFun);
            this.TabFunButton.Location = new System.Drawing.Point(4, 22);
            this.TabFunButton.Name = "TabFunButton";
            this.TabFunButton.Padding = new System.Windows.Forms.Padding(3);
            this.TabFunButton.Size = new System.Drawing.Size(786, 418);
            this.TabFunButton.TabIndex = 7;
            this.TabFunButton.Text = "Fun Button";
            this.TabFunButton.UseVisualStyleBackColor = true;
            // 
            // BtnFun
            // 
            this.BtnFun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFun.Location = new System.Drawing.Point(357, 167);
            this.BtnFun.Name = "BtnFun";
            this.BtnFun.Size = new System.Drawing.Size(59, 53);
            this.BtnFun.TabIndex = 0;
            this.BtnFun.Text = "fun";
            this.BtnFun.UseVisualStyleBackColor = true;
            this.BtnFun.Click += new System.EventHandler(this.BtnFun_Click);
            // 
            // CbxDanger
            // 
            this.CbxDanger.AutoSize = true;
            this.CbxDanger.Checked = true;
            this.CbxDanger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxDanger.Location = new System.Drawing.Point(64, 54);
            this.CbxDanger.Name = "CbxDanger";
            this.CbxDanger.Size = new System.Drawing.Size(61, 17);
            this.CbxDanger.TabIndex = 1;
            this.CbxDanger.Text = "Danger";
            this.CbxDanger.UseVisualStyleBackColor = true;
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
            this.TabWhereUsed.ResumeLayout(false);
            this.TLP.ResumeLayout(false);
            this.TabFunButton.ResumeLayout(false);
            this.TabFunButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabCADFiles;
        private Tools.CADFiles cadFiles1;
        private System.Windows.Forms.TabPage TabWhereUsed;
        private Tools.WhereUsed whereUsed1;
        private System.Windows.Forms.TabPage TabPartLookup;
        private System.Windows.Forms.TabPage TabDocumentLookup;
        private System.Windows.Forms.TabPage TabFunButton;
        private System.Windows.Forms.Button BtnFun;
        private System.Windows.Forms.CheckBox CbxDanger;
    }
}

