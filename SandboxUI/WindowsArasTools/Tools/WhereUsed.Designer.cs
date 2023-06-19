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
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.ColumnCount = 1;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLP.Controls.Add(this.TxtPartNumber, 0, 0);
            this.TLP.Controls.Add(this.BtnRun, 0, 1);
            this.TLP.Controls.Add(this.RTB, 0, 2);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 3;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.Size = new System.Drawing.Size(180, 150);
            this.TLP.TabIndex = 0;
            // 
            // TxtPartNumber
            // 
            this.TxtPartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtPartNumber.Location = new System.Drawing.Point(3, 3);
            this.TxtPartNumber.Name = "TxtPartNumber";
            this.TxtPartNumber.Size = new System.Drawing.Size(174, 20);
            this.TxtPartNumber.TabIndex = 1;
            this.TxtPartNumber.Text = "305-0059";
            this.TxtPartNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtPartNumber.TextChanged += new System.EventHandler(this.TxtPartNumber_TextChanged);
            // 
            // BtnRun
            // 
            this.BtnRun.AutoSize = true;
            this.BtnRun.BackColor = System.Drawing.Color.LightGreen;
            this.BtnRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRun.Location = new System.Drawing.Point(3, 29);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(174, 25);
            this.BtnRun.TabIndex = 0;
            this.BtnRun.Text = "Get Where Used Quantities";
            this.BtnRun.UseVisualStyleBackColor = false;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // RTB
            // 
            this.RTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB.Location = new System.Drawing.Point(3, 60);
            this.RTB.Name = "RTB";
            this.RTB.Size = new System.Drawing.Size(174, 87);
            this.RTB.TabIndex = 3;
            this.RTB.Text = "";
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
        private System.Windows.Forms.RichTextBox RTB;
    }
}
