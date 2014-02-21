namespace GroundControl.Views
{
    partial class ProcessingView
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
            System.Windows.Forms.ProgressBar progressBar;
            progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(12, 13);
            progressBar.MarqueeAnimationSpeed = 20;
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(319, 28);
            progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            progressBar.TabIndex = 0;
            // 
            // ProcessingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 53);
            this.ControlBox = false;
            this.Controls.Add(progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProcessingView";
            this.Text = "ProcessingView";
            this.ResumeLayout(false);

        }

        #endregion


    }
}