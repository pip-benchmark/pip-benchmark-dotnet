namespace PipBenchmark.Gui.Environment
{
    partial class EnvironmentPerspective
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
            this.systemInformationLabel = new System.Windows.Forms.Label();
            this.systemParametersDataGridView = new System.Windows.Forms.DataGridView();
            this.parameterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.diskPerformanceTextBox = new System.Windows.Forms.TextBox();
            this.videoPerformanceTextBox = new System.Windows.Forms.TextBox();
            this.cpuPerformanceTextBox = new System.Windows.Forms.TextBox();
            this.diskPerformanceLabel = new System.Windows.Forms.Label();
            this.videoPerformanceLabel = new System.Windows.Forms.Label();
            this.cpuPerformanceLabel = new System.Windows.Forms.Label();
            this.updateSystemBenchmarkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.systemParametersDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // systemInformationLabel
            // 
            this.systemInformationLabel.AutoSize = true;
            this.systemInformationLabel.Location = new System.Drawing.Point(26, 19);
            this.systemInformationLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.systemInformationLabel.Name = "systemInformationLabel";
            this.systemInformationLabel.Size = new System.Drawing.Size(201, 25);
            this.systemInformationLabel.TabIndex = 0;
            this.systemInformationLabel.Text = "System Information:";
            // 
            // systemParametersDataGridView
            // 
            this.systemParametersDataGridView.AllowUserToAddRows = false;
            this.systemParametersDataGridView.AllowUserToDeleteRows = false;
            this.systemParametersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.systemParametersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.systemParametersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameterColumn,
            this.valueColumn});
            this.systemParametersDataGridView.Location = new System.Drawing.Point(26, 50);
            this.systemParametersDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.systemParametersDataGridView.Name = "systemParametersDataGridView";
            this.systemParametersDataGridView.Size = new System.Drawing.Size(948, 427);
            this.systemParametersDataGridView.TabIndex = 1;
            // 
            // parameterColumn
            // 
            this.parameterColumn.DataPropertyName = "Parameter";
            this.parameterColumn.HeaderText = "Parameter";
            this.parameterColumn.MinimumWidth = 100;
            this.parameterColumn.Name = "parameterColumn";
            this.parameterColumn.ReadOnly = true;
            this.parameterColumn.Width = 200;
            // 
            // valueColumn
            // 
            this.valueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueColumn.DataPropertyName = "Value";
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.Name = "valueColumn";
            this.valueColumn.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.diskPerformanceTextBox);
            this.groupBox1.Controls.Add(this.videoPerformanceTextBox);
            this.groupBox1.Controls.Add(this.cpuPerformanceTextBox);
            this.groupBox1.Controls.Add(this.diskPerformanceLabel);
            this.groupBox1.Controls.Add(this.videoPerformanceLabel);
            this.groupBox1.Controls.Add(this.cpuPerformanceLabel);
            this.groupBox1.Location = new System.Drawing.Point(26, 488);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.groupBox1.Size = new System.Drawing.Size(948, 200);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "System Benchmark Results";
            // 
            // diskPerformanceTextBox
            // 
            this.diskPerformanceTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.diskPerformanceTextBox.Location = new System.Drawing.Point(342, 140);
            this.diskPerformanceTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.diskPerformanceTextBox.Name = "diskPerformanceTextBox";
            this.diskPerformanceTextBox.ReadOnly = true;
            this.diskPerformanceTextBox.Size = new System.Drawing.Size(196, 31);
            this.diskPerformanceTextBox.TabIndex = 5;
            // 
            // videoPerformanceTextBox
            // 
            this.videoPerformanceTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.videoPerformanceTextBox.Location = new System.Drawing.Point(342, 88);
            this.videoPerformanceTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.videoPerformanceTextBox.Name = "videoPerformanceTextBox";
            this.videoPerformanceTextBox.ReadOnly = true;
            this.videoPerformanceTextBox.Size = new System.Drawing.Size(196, 31);
            this.videoPerformanceTextBox.TabIndex = 4;
            // 
            // cpuPerformanceTextBox
            // 
            this.cpuPerformanceTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.cpuPerformanceTextBox.Location = new System.Drawing.Point(342, 38);
            this.cpuPerformanceTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.cpuPerformanceTextBox.Name = "cpuPerformanceTextBox";
            this.cpuPerformanceTextBox.ReadOnly = true;
            this.cpuPerformanceTextBox.Size = new System.Drawing.Size(196, 31);
            this.cpuPerformanceTextBox.TabIndex = 3;
            // 
            // diskPerformanceLabel
            // 
            this.diskPerformanceLabel.AutoSize = true;
            this.diskPerformanceLabel.Location = new System.Drawing.Point(26, 146);
            this.diskPerformanceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.diskPerformanceLabel.Name = "diskPerformanceLabel";
            this.diskPerformanceLabel.Size = new System.Drawing.Size(257, 25);
            this.diskPerformanceLabel.TabIndex = 2;
            this.diskPerformanceLabel.Text = "Disk Performance (MB/s):";
            // 
            // videoPerformanceLabel
            // 
            this.videoPerformanceLabel.AutoSize = true;
            this.videoPerformanceLabel.Location = new System.Drawing.Point(26, 96);
            this.videoPerformanceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.videoPerformanceLabel.Name = "videoPerformanceLabel";
            this.videoPerformanceLabel.Size = new System.Drawing.Size(284, 25);
            this.videoPerformanceLabel.TabIndex = 1;
            this.videoPerformanceLabel.Text = "Video Performance (GOP/s):";
            // 
            // cpuPerformanceLabel
            // 
            this.cpuPerformanceLabel.AutoSize = true;
            this.cpuPerformanceLabel.Location = new System.Drawing.Point(26, 44);
            this.cpuPerformanceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cpuPerformanceLabel.Name = "cpuPerformanceLabel";
            this.cpuPerformanceLabel.Size = new System.Drawing.Size(300, 25);
            this.cpuPerformanceLabel.TabIndex = 0;
            this.cpuPerformanceLabel.Text = "CPU Performance (MFLOP/s):";
            // 
            // updateSystemBenchmarkButton
            // 
            this.updateSystemBenchmarkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateSystemBenchmarkButton.Location = new System.Drawing.Point(722, 700);
            this.updateSystemBenchmarkButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateSystemBenchmarkButton.Name = "updateSystemBenchmarkButton";
            this.updateSystemBenchmarkButton.Size = new System.Drawing.Size(252, 44);
            this.updateSystemBenchmarkButton.TabIndex = 3;
            this.updateSystemBenchmarkButton.Text = "Update Benchmark";
            this.updateSystemBenchmarkButton.UseVisualStyleBackColor = true;
            // 
            // EnvironmentPerspective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.updateSystemBenchmarkButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.systemParametersDataGridView);
            this.Controls.Add(this.systemInformationLabel);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EnvironmentPerspective";
            this.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.Size = new System.Drawing.Size(1000, 769);
            ((System.ComponentModel.ISupportInitialize)(this.systemParametersDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label systemInformationLabel;
        private System.Windows.Forms.DataGridView systemParametersDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label cpuPerformanceLabel;
        private System.Windows.Forms.Button updateSystemBenchmarkButton;
        private System.Windows.Forms.TextBox diskPerformanceTextBox;
        private System.Windows.Forms.TextBox videoPerformanceTextBox;
        private System.Windows.Forms.TextBox cpuPerformanceTextBox;
        private System.Windows.Forms.Label diskPerformanceLabel;
        private System.Windows.Forms.Label videoPerformanceLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueColumn;
    }
}
