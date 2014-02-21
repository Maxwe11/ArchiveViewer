namespace GroundControl.Archives.Views
{
    partial class ArchivesView
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
            Telerik.WinControls.Themes.VisualStudio2012LightTheme visualStudio2012LightTheme;
            this.mRadDock = new Telerik.WinControls.UI.Docking.RadDock();
            this.documentContainer1 = new Telerik.WinControls.UI.Docking.DocumentContainer();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            visualStudio2012LightTheme = new Telerik.WinControls.Themes.VisualStudio2012LightTheme();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mRadDock)).BeginInit();
            this.mRadDock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(this.mRadDock, 0, 0);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 1;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new System.Drawing.Size(564, 352);
            tableLayoutPanel.TabIndex = 1;
            // 
            // mRadDock
            // 
            this.mRadDock.Controls.Add(this.documentContainer1);
            this.mRadDock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mRadDock.DocumentManager.DocumentInsertOrder = Telerik.WinControls.UI.Docking.DockWindowInsertOrder.ToBack;
            this.mRadDock.IsCleanUpTarget = true;
            this.mRadDock.Location = new System.Drawing.Point(0, 0);
            this.mRadDock.MainDocumentContainer = this.documentContainer1;
            this.mRadDock.Name = "mRadDock";
            this.mRadDock.Padding = new System.Windows.Forms.Padding(0);
            // 
            // 
            // 
            this.mRadDock.RootElement.MinSize = new System.Drawing.Size(25, 25);
            this.mRadDock.Size = new System.Drawing.Size(564, 352);
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
            // ArchivesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tableLayoutPanel);
            this.Name = "ArchivesView";
            this.Size = new System.Drawing.Size(564, 352);
            this.Load += new System.EventHandler(this.OnLoad);
            tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mRadDock)).EndInit();
            this.mRadDock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentContainer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.Docking.RadDock mRadDock;
        private Telerik.WinControls.UI.Docking.DocumentContainer documentContainer1;
    }
}
