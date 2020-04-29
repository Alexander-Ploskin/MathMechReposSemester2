namespace Clock
{
    partial class Clock
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
            this.Front = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Front)).BeginInit();
            this.SuspendLayout();
            // 
            // Front
            // 
            this.Front.BackColor = System.Drawing.SystemColors.Window;
            this.Front.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Front.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Front.Location = new System.Drawing.Point(0, 0);
            this.Front.Name = "Front";
            this.Front.Size = new System.Drawing.Size(384, 361);
            this.Front.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Front.TabIndex = 1;
            this.Front.TabStop = false;
            // 
            // Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.Front);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Clock";
            this.Text = "Clock";
            ((System.ComponentModel.ISupportInitialize)(this.Front)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox Front;
    }
}

