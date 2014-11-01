namespace ArchiveViewer.Views
{
    partial class SerialPortSettingsView
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
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Panel panel3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Panel panel2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Panel panel4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Panel panel5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Panel panel7;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Panel panel8;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Panel panel6;
            System.Windows.Forms.Label label4;
            this.mPortNameCmbBx = new System.Windows.Forms.ComboBox();
            this.mBaudRateCmbBx = new System.Windows.Forms.ComboBox();
            this.mParityCmbBx = new System.Windows.Forms.ComboBox();
            this.mStopBitsCmbBx = new System.Windows.Forms.ComboBox();
            this.mHandshakeCmbBx = new System.Windows.Forms.ComboBox();
            this.mResponseTimeoutNumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.mDataBitsNumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mApplyBtn = new System.Windows.Forms.Button();
            this.mCancelBtn = new System.Windows.Forms.Button();
            flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            label3 = new System.Windows.Forms.Label();
            panel4 = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            panel5 = new System.Windows.Forms.Panel();
            label6 = new System.Windows.Forms.Label();
            panel7 = new System.Windows.Forms.Panel();
            label7 = new System.Windows.Forms.Label();
            panel8 = new System.Windows.Forms.Panel();
            label8 = new System.Windows.Forms.Label();
            panel6 = new System.Windows.Forms.Panel();
            label4 = new System.Windows.Forms.Label();
            flowLayoutPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mResponseTimeoutNumUpDwn)).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDataBitsNumUpDwn)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.tableLayoutPanel1.SetColumnSpan(flowLayoutPanel, 3);
            flowLayoutPanel.Controls.Add(panel1);
            flowLayoutPanel.Controls.Add(panel3);
            flowLayoutPanel.Controls.Add(panel2);
            flowLayoutPanel.Controls.Add(panel4);
            flowLayoutPanel.Controls.Add(panel5);
            flowLayoutPanel.Controls.Add(panel7);
            flowLayoutPanel.Controls.Add(panel8);
            flowLayoutPanel.Controls.Add(panel6);
            flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new System.Drawing.Size(401, 180);
            flowLayoutPanel.TabIndex = 50;
            // 
            // panel1
            // 
            panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel1.Controls.Add(this.mPortNameCmbBx);
            panel1.Controls.Add(label1);
            panel1.Location = new System.Drawing.Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(394, 28);
            panel1.TabIndex = 50;
            // 
            // mPortNameCmbBx
            // 
            this.mPortNameCmbBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mPortNameCmbBx.FormattingEnabled = true;
            this.mPortNameCmbBx.Location = new System.Drawing.Point(71, 3);
            this.mPortNameCmbBx.Name = "mPortNameCmbBx";
            this.mPortNameCmbBx.Size = new System.Drawing.Size(320, 21);
            this.mPortNameCmbBx.TabIndex = 48;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label1.Location = new System.Drawing.Point(7, 6);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(58, 13);
            label1.TabIndex = 35;
            label1.Text = "Port name:";
            // 
            // panel3
            // 
            panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel3.Controls.Add(this.mBaudRateCmbBx);
            panel3.Controls.Add(label2);
            panel3.Location = new System.Drawing.Point(3, 37);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(194, 28);
            panel3.TabIndex = 51;
            // 
            // mBaudRateCmbBx
            // 
            this.mBaudRateCmbBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mBaudRateCmbBx.FormattingEnabled = true;
            this.mBaudRateCmbBx.Location = new System.Drawing.Point(72, 4);
            this.mBaudRateCmbBx.Name = "mBaudRateCmbBx";
            this.mBaudRateCmbBx.Size = new System.Drawing.Size(119, 21);
            this.mBaudRateCmbBx.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label2.Location = new System.Drawing.Point(7, 7);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 13);
            label2.TabIndex = 36;
            label2.Text = "Baud rate:";
            // 
            // panel2
            // 
            panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel2.Controls.Add(label3);
            panel2.Controls.Add(this.mParityCmbBx);
            panel2.Location = new System.Drawing.Point(203, 37);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(194, 28);
            panel2.TabIndex = 52;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label3.Location = new System.Drawing.Point(7, 6);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(36, 13);
            label3.TabIndex = 38;
            label3.Text = "Parity:";
            // 
            // mParityCmbBx
            // 
            this.mParityCmbBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mParityCmbBx.FormattingEnabled = true;
            this.mParityCmbBx.Location = new System.Drawing.Point(72, 3);
            this.mParityCmbBx.Name = "mParityCmbBx";
            this.mParityCmbBx.Size = new System.Drawing.Size(119, 21);
            this.mParityCmbBx.TabIndex = 39;
            // 
            // panel4
            // 
            panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel4.Controls.Add(this.mStopBitsCmbBx);
            panel4.Controls.Add(label5);
            panel4.Location = new System.Drawing.Point(3, 71);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(194, 28);
            panel4.TabIndex = 53;
            // 
            // mStopBitsCmbBx
            // 
            this.mStopBitsCmbBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mStopBitsCmbBx.FormattingEnabled = true;
            this.mStopBitsCmbBx.Location = new System.Drawing.Point(72, 4);
            this.mStopBitsCmbBx.Name = "mStopBitsCmbBx";
            this.mStopBitsCmbBx.Size = new System.Drawing.Size(119, 21);
            this.mStopBitsCmbBx.TabIndex = 43;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label5.Location = new System.Drawing.Point(7, 7);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(51, 13);
            label5.TabIndex = 42;
            label5.Text = "Stop bits:";
            // 
            // panel5
            // 
            panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel5.Controls.Add(this.mHandshakeCmbBx);
            panel5.Controls.Add(label6);
            panel5.Location = new System.Drawing.Point(203, 71);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(194, 28);
            panel5.TabIndex = 54;
            // 
            // mHandshakeCmbBx
            // 
            this.mHandshakeCmbBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mHandshakeCmbBx.FormattingEnabled = true;
            this.mHandshakeCmbBx.Location = new System.Drawing.Point(71, 3);
            this.mHandshakeCmbBx.Name = "mHandshakeCmbBx";
            this.mHandshakeCmbBx.Size = new System.Drawing.Size(120, 21);
            this.mHandshakeCmbBx.TabIndex = 45;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label6.Location = new System.Drawing.Point(7, 6);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(65, 13);
            label6.TabIndex = 44;
            label6.Text = "Handshake:";
            // 
            // panel7
            // 
            panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel7.Controls.Add(this.mResponseTimeoutNumUpDwn);
            panel7.Controls.Add(label7);
            panel7.Location = new System.Drawing.Point(3, 105);
            panel7.Name = "panel7";
            panel7.Size = new System.Drawing.Size(194, 28);
            panel7.TabIndex = 56;
            // 
            // mResponseTimeoutNumUpDwn
            // 
            this.mResponseTimeoutNumUpDwn.Location = new System.Drawing.Point(86, 5);
            this.mResponseTimeoutNumUpDwn.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.mResponseTimeoutNumUpDwn.Name = "mResponseTimeoutNumUpDwn";
            this.mResponseTimeoutNumUpDwn.Size = new System.Drawing.Size(105, 20);
            this.mResponseTimeoutNumUpDwn.TabIndex = 47;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label7.Location = new System.Drawing.Point(7, 7);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(73, 13);
            label7.TabIndex = 46;
            label7.Text = "Read timeout:";
            // 
            // panel8
            // 
            panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel8.Controls.Add(this.numericUpDown1);
            panel8.Controls.Add(label8);
            panel8.Location = new System.Drawing.Point(203, 105);
            panel8.Name = "panel8";
            panel8.Size = new System.Drawing.Size(194, 28);
            panel8.TabIndex = 57;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(86, 5);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(105, 20);
            this.numericUpDown1.TabIndex = 47;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label8.Location = new System.Drawing.Point(7, 7);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(72, 13);
            label8.TabIndex = 46;
            label8.Text = "Write timeout:";
            // 
            // panel6
            // 
            panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel6.Controls.Add(this.mDataBitsNumUpDwn);
            panel6.Controls.Add(label4);
            panel6.Location = new System.Drawing.Point(3, 139);
            panel6.Name = "panel6";
            panel6.Size = new System.Drawing.Size(194, 28);
            panel6.TabIndex = 55;
            // 
            // mDataBitsNumUpDwn
            // 
            this.mDataBitsNumUpDwn.Location = new System.Drawing.Point(86, 5);
            this.mDataBitsNumUpDwn.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.mDataBitsNumUpDwn.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.mDataBitsNumUpDwn.Name = "mDataBitsNumUpDwn";
            this.mDataBitsNumUpDwn.Size = new System.Drawing.Size(105, 20);
            this.mDataBitsNumUpDwn.TabIndex = 41;
            this.mDataBitsNumUpDwn.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            label4.Location = new System.Drawing.Point(7, 7);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(52, 13);
            label4.TabIndex = 40;
            label4.Text = "Data bits:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(flowLayoutPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mApplyBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mCancelBtn, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 216);
            this.tableLayoutPanel1.TabIndex = 51;
            // 
            // mApplyBtn
            // 
            this.mApplyBtn.Location = new System.Drawing.Point(250, 189);
            this.mApplyBtn.Name = "mApplyBtn";
            this.mApplyBtn.Size = new System.Drawing.Size(74, 23);
            this.mApplyBtn.TabIndex = 51;
            this.mApplyBtn.Text = "Apply";
            this.mApplyBtn.UseVisualStyleBackColor = true;
            // 
            // mCancelBtn
            // 
            this.mCancelBtn.Location = new System.Drawing.Point(330, 189);
            this.mCancelBtn.Name = "mCancelBtn";
            this.mCancelBtn.Size = new System.Drawing.Size(74, 23);
            this.mCancelBtn.TabIndex = 52;
            this.mCancelBtn.Text = "Cancel";
            this.mCancelBtn.UseVisualStyleBackColor = true;
            // 
            // SerialPortSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(200, 30);
            this.Name = "SerialPortSettingsView";
            this.Size = new System.Drawing.Size(407, 216);
            this.Load += new System.EventHandler(this.OnLoad);
            flowLayoutPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mResponseTimeoutNumUpDwn)).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mDataBitsNumUpDwn)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox mPortNameCmbBx;
        private System.Windows.Forms.ComboBox mBaudRateCmbBx;
        private System.Windows.Forms.ComboBox mParityCmbBx;
        private System.Windows.Forms.ComboBox mStopBitsCmbBx;
        private System.Windows.Forms.ComboBox mHandshakeCmbBx;
        private System.Windows.Forms.NumericUpDown mDataBitsNumUpDwn;
        private System.Windows.Forms.NumericUpDown mResponseTimeoutNumUpDwn;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button mApplyBtn;
        private System.Windows.Forms.Button mCancelBtn;

    }
}
