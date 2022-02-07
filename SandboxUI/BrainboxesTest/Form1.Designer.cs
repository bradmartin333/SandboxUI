namespace BrainboxesTest
{
    partial class Form1
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
            this.hue = new System.Windows.Forms.VScrollBar();
            this.intensity = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hue
            // 
            this.hue.Location = new System.Drawing.Point(9, 9);
            this.hue.Name = "hue";
            this.hue.Size = new System.Drawing.Size(65, 243);
            this.hue.TabIndex = 0;
            this.hue.Value = 17;
            this.hue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Hue_Scroll);
            // 
            // intensity
            // 
            this.intensity.Location = new System.Drawing.Point(88, 9);
            this.intensity.Name = "intensity";
            this.intensity.Size = new System.Drawing.Size(65, 243);
            this.intensity.TabIndex = 1;
            this.intensity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Intensity_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "hue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "intensity";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(166, 284);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intensity);
            this.Controls.Add(this.hue);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VScrollBar hue;
        private System.Windows.Forms.VScrollBar intensity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

