namespace GroundControl.Views
{
    internal partial class AppView
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.mStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.mRadDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            this.mVisualStudio2012LightTheme = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            this.mSerialPort = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.mStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mRadDock)).BeginInit();
            this.mRadDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // 
            // radMenu1
            // 
            this.radMenu1.Location = new System.Drawing.Point(3, 3);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(848, 20);
            this.radMenu1.TabIndex = 0;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "VisualStudio2012Light";
            this.tableLayoutPanel1.Controls.Add(this.radMenu1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mStatusStrip, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.mRadDock, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(854, 508);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // mStatusStrip
            // 
            this.mStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.mStatusStrip.Location = new System.Drawing.Point(0, 486);
            this.mStatusStrip.Name = "mStatusStrip";
            this.mStatusStrip.Size = new System.Drawing.Size(854, 22);
            this.mStatusStrip.TabIndex = 1;
            this.mStatusStrip.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.toolStripProgressBar1.Visible = false;
            // 
            // mRadDock
            // 
            this.mRadDock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mRadDock.Controls.Add(this.documentContainer1);
            this.mRadDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mRadDock.IsCleanUpTarget = true;
            this.mRadDock.Location = new System.Drawing.Point(0, 27);
            this.mRadDock.MainDocumentContainer = this.documentContainer1;
            this.mRadDock.Name = "mRadDock";
            this.mRadDock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.mRadDock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.mRadDock.Size = new System.Drawing.Size(854, 457);
            this.mRadDock.SplitterWidth = 2;
            this.mRadDock.TabIndex = 2;
            this.mRadDock.TabStop = false;
            this.mRadDock.Text = "radDock1";
            this.mRadDock.ThemeName = "VisualStudio2012Light";
            // 
            // documentContainer1
            // 
            this.documentContainer1.Name = "documentContainer1";
            // 
            // 
            // 
            this.documentContainer1.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.documentContainer1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Fill;
            this.documentContainer1.SplitterWidth = 2;
            this.documentContainer1.ThemeName = "VisualStudio2012Light";
            // 
            // mSerialPort
            // 
            this.mSerialPort.BaudRate = 115200;
            this.mSerialPort.PortName = "COM5";
            // 
            // AppView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AppView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.mStatusStrip.ResumeLayout(false);
            this.mStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mRadDock)).EndInit();
            this.mRadDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.Themes.VisualStudio2012LightTheme mVisualStudio2012LightTheme;
        private System.Windows.Forms.StatusStrip mStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private Telerik.WinControls.UI.Docking.RadDock mRadDock;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
        private System.IO.Ports.SerialPort mSerialPort;
        private Telerik.WinControls.UI.RadMenu radMenu1;
    }
}

