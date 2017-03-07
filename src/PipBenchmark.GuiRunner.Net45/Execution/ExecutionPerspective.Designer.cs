namespace PipBenchmark.Gui.Execution
{
    partial class ExecutionPerspective
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
            PipBenchmark.Gui.Charts.ChartPen chartPen1 = new PipBenchmark.Gui.Charts.ChartPen();
            PipBenchmark.Gui.Charts.ChartPen chartPen2 = new PipBenchmark.Gui.Charts.ChartPen();
            PipBenchmark.Gui.Charts.ChartPen chartPen3 = new PipBenchmark.Gui.Charts.ChartPen();
            PipBenchmark.Gui.Charts.ChartPen chartPen4 = new PipBenchmark.Gui.Charts.ChartPen();
            this.benchmarkingResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.memoryLabel = new System.Windows.Forms.Label();
            this.maxMemoryTextBox = new System.Windows.Forms.TextBox();
            this.averageMemoryTextBox = new System.Windows.Forms.TextBox();
            this.minMemoryTextBox = new System.Windows.Forms.TextBox();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.maxCpuLoadTextBox = new System.Windows.Forms.TextBox();
            this.averageCpuLoadTextBox = new System.Windows.Forms.TextBox();
            this.minCpuLoadTextBox = new System.Windows.Forms.TextBox();
            this.performanceLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.maxPerformanceTextBox = new System.Windows.Forms.TextBox();
            this.averagePerformanceTextBox = new System.Windows.Forms.TextBox();
            this.minPerformanceTextBox = new System.Windows.Forms.TextBox();
            this.maxPerformanceLabel = new System.Windows.Forms.Label();
            this.averagePerformanceLabel = new System.Windows.Forms.Label();
            this.minPerformanceLabel = new System.Windows.Forms.Label();
            this.elapsedTimeTextBox = new System.Windows.Forms.TextBox();
            this.endTimeTextBox = new System.Windows.Forms.TextBox();
            this.startTimeTextBox = new System.Windows.Forms.TextBox();
            this.elapsedTimeLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.performanceChartEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.benchmarkActionButton = new System.Windows.Forms.Button();
            this.benchmarkingSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.durationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sequentialExecutionCheckBox = new System.Windows.Forms.CheckBox();
            this.nominalPerformanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.nominalPerformanceRadioButton = new System.Windows.Forms.RadioButton();
            this.peakPerformanceRadioButton = new System.Windows.Forms.RadioButton();
            this.testingModeLabel = new System.Windows.Forms.Label();
            this.numberOfThreadsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.numberOfThreadsLabel = new System.Windows.Forms.Label();
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.benchmarkNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpuLoadColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memoryUsageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performanceChart = new PipBenchmark.Gui.Charts.PerformanceChart();
            this.benchmarkingResultsGroupBox.SuspendLayout();
            this.benchmarkingSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nominalPerformanceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfThreadsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // benchmarkingResultsGroupBox
            // 
            this.benchmarkingResultsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.benchmarkingResultsGroupBox.Controls.Add(this.memoryLabel);
            this.benchmarkingResultsGroupBox.Controls.Add(this.maxMemoryTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.averageMemoryTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.minMemoryTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.cpuLabel);
            this.benchmarkingResultsGroupBox.Controls.Add(this.maxCpuLoadTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.averageCpuLoadTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.minCpuLoadTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.performanceLabel);
            this.benchmarkingResultsGroupBox.Controls.Add(this.timeLabel);
            this.benchmarkingResultsGroupBox.Controls.Add(this.maxPerformanceTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.averagePerformanceTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.minPerformanceTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.maxPerformanceLabel);
            this.benchmarkingResultsGroupBox.Controls.Add(this.averagePerformanceLabel);
            this.benchmarkingResultsGroupBox.Controls.Add(this.minPerformanceLabel);
            this.benchmarkingResultsGroupBox.Controls.Add(this.elapsedTimeTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.endTimeTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.startTimeTextBox);
            this.benchmarkingResultsGroupBox.Controls.Add(this.elapsedTimeLabel);
            this.benchmarkingResultsGroupBox.Controls.Add(this.endTimeLabel);
            this.benchmarkingResultsGroupBox.Controls.Add(this.startTimeLabel);
            this.benchmarkingResultsGroupBox.Location = new System.Drawing.Point(26, 181);
            this.benchmarkingResultsGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.benchmarkingResultsGroupBox.Name = "benchmarkingResultsGroupBox";
            this.benchmarkingResultsGroupBox.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.benchmarkingResultsGroupBox.Size = new System.Drawing.Size(1018, 240);
            this.benchmarkingResultsGroupBox.TabIndex = 0;
            this.benchmarkingResultsGroupBox.TabStop = false;
            this.benchmarkingResultsGroupBox.Text = "Benchmarking Results";
            // 
            // memoryLabel
            // 
            this.memoryLabel.AutoSize = true;
            this.memoryLabel.Location = new System.Drawing.Point(802, 44);
            this.memoryLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.memoryLabel.Name = "memoryLabel";
            this.memoryLabel.Size = new System.Drawing.Size(139, 25);
            this.memoryLabel.TabIndex = 24;
            this.memoryLabel.Text = "Memory (Mb)";
            // 
            // maxMemoryTextBox
            // 
            this.maxMemoryTextBox.Location = new System.Drawing.Point(808, 175);
            this.maxMemoryTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.maxMemoryTextBox.Name = "maxMemoryTextBox";
            this.maxMemoryTextBox.Size = new System.Drawing.Size(160, 31);
            this.maxMemoryTextBox.TabIndex = 23;
            // 
            // averageMemoryTextBox
            // 
            this.averageMemoryTextBox.Location = new System.Drawing.Point(808, 125);
            this.averageMemoryTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.averageMemoryTextBox.Name = "averageMemoryTextBox";
            this.averageMemoryTextBox.Size = new System.Drawing.Size(160, 31);
            this.averageMemoryTextBox.TabIndex = 22;
            // 
            // minMemoryTextBox
            // 
            this.minMemoryTextBox.Location = new System.Drawing.Point(808, 75);
            this.minMemoryTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.minMemoryTextBox.Name = "minMemoryTextBox";
            this.minMemoryTextBox.Size = new System.Drawing.Size(160, 31);
            this.minMemoryTextBox.TabIndex = 21;
            // 
            // cpuLabel
            // 
            this.cpuLabel.AutoSize = true;
            this.cpuLabel.Location = new System.Drawing.Point(670, 44);
            this.cpuLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Size = new System.Drawing.Size(95, 25);
            this.cpuLabel.TabIndex = 20;
            this.cpuLabel.Text = "CPU (%)";
            // 
            // maxCpuLoadTextBox
            // 
            this.maxCpuLoadTextBox.Location = new System.Drawing.Point(676, 175);
            this.maxCpuLoadTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.maxCpuLoadTextBox.Name = "maxCpuLoadTextBox";
            this.maxCpuLoadTextBox.Size = new System.Drawing.Size(116, 31);
            this.maxCpuLoadTextBox.TabIndex = 19;
            // 
            // averageCpuLoadTextBox
            // 
            this.averageCpuLoadTextBox.Location = new System.Drawing.Point(676, 125);
            this.averageCpuLoadTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.averageCpuLoadTextBox.Name = "averageCpuLoadTextBox";
            this.averageCpuLoadTextBox.Size = new System.Drawing.Size(116, 31);
            this.averageCpuLoadTextBox.TabIndex = 18;
            // 
            // minCpuLoadTextBox
            // 
            this.minCpuLoadTextBox.Location = new System.Drawing.Point(676, 75);
            this.minCpuLoadTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.minCpuLoadTextBox.Name = "minCpuLoadTextBox";
            this.minCpuLoadTextBox.Size = new System.Drawing.Size(116, 31);
            this.minCpuLoadTextBox.TabIndex = 17;
            // 
            // performanceLabel
            // 
            this.performanceLabel.AutoSize = true;
            this.performanceLabel.Location = new System.Drawing.Point(484, 44);
            this.performanceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.performanceLabel.Name = "performanceLabel";
            this.performanceLabel.Size = new System.Drawing.Size(183, 25);
            this.performanceLabel.TabIndex = 13;
            this.performanceLabel.Text = "Performance (tps)";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(134, 44);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(59, 25);
            this.timeLabel.TabIndex = 12;
            this.timeLabel.Text = "Time";
            // 
            // maxPerformanceTextBox
            // 
            this.maxPerformanceTextBox.Location = new System.Drawing.Point(490, 175);
            this.maxPerformanceTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.maxPerformanceTextBox.Name = "maxPerformanceTextBox";
            this.maxPerformanceTextBox.Size = new System.Drawing.Size(170, 31);
            this.maxPerformanceTextBox.TabIndex = 11;
            // 
            // averagePerformanceTextBox
            // 
            this.averagePerformanceTextBox.Location = new System.Drawing.Point(490, 125);
            this.averagePerformanceTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.averagePerformanceTextBox.Name = "averagePerformanceTextBox";
            this.averagePerformanceTextBox.Size = new System.Drawing.Size(170, 31);
            this.averagePerformanceTextBox.TabIndex = 10;
            // 
            // minPerformanceTextBox
            // 
            this.minPerformanceTextBox.Location = new System.Drawing.Point(490, 75);
            this.minPerformanceTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.minPerformanceTextBox.Name = "minPerformanceTextBox";
            this.minPerformanceTextBox.Size = new System.Drawing.Size(170, 31);
            this.minPerformanceTextBox.TabIndex = 9;
            // 
            // maxPerformanceLabel
            // 
            this.maxPerformanceLabel.AutoSize = true;
            this.maxPerformanceLabel.Location = new System.Drawing.Point(378, 181);
            this.maxPerformanceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.maxPerformanceLabel.Name = "maxPerformanceLabel";
            this.maxPerformanceLabel.Size = new System.Drawing.Size(59, 25);
            this.maxPerformanceLabel.TabIndex = 8;
            this.maxPerformanceLabel.Text = "Max:";
            // 
            // averagePerformanceLabel
            // 
            this.averagePerformanceLabel.AutoSize = true;
            this.averagePerformanceLabel.Location = new System.Drawing.Point(378, 131);
            this.averagePerformanceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.averagePerformanceLabel.Name = "averagePerformanceLabel";
            this.averagePerformanceLabel.Size = new System.Drawing.Size(98, 25);
            this.averagePerformanceLabel.TabIndex = 7;
            this.averagePerformanceLabel.Text = "Average:";
            // 
            // minPerformanceLabel
            // 
            this.minPerformanceLabel.AutoSize = true;
            this.minPerformanceLabel.Location = new System.Drawing.Point(378, 81);
            this.minPerformanceLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.minPerformanceLabel.Name = "minPerformanceLabel";
            this.minPerformanceLabel.Size = new System.Drawing.Size(53, 25);
            this.minPerformanceLabel.TabIndex = 6;
            this.minPerformanceLabel.Text = "Min:";
            // 
            // elapsedTimeTextBox
            // 
            this.elapsedTimeTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.elapsedTimeTextBox.Location = new System.Drawing.Point(140, 175);
            this.elapsedTimeTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.elapsedTimeTextBox.Name = "elapsedTimeTextBox";
            this.elapsedTimeTextBox.ReadOnly = true;
            this.elapsedTimeTextBox.Size = new System.Drawing.Size(196, 31);
            this.elapsedTimeTextBox.TabIndex = 5;
            // 
            // endTimeTextBox
            // 
            this.endTimeTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.endTimeTextBox.Location = new System.Drawing.Point(140, 125);
            this.endTimeTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.endTimeTextBox.Name = "endTimeTextBox";
            this.endTimeTextBox.ReadOnly = true;
            this.endTimeTextBox.Size = new System.Drawing.Size(196, 31);
            this.endTimeTextBox.TabIndex = 4;
            // 
            // startTimeTextBox
            // 
            this.startTimeTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.startTimeTextBox.Location = new System.Drawing.Point(140, 75);
            this.startTimeTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.startTimeTextBox.Name = "startTimeTextBox";
            this.startTimeTextBox.ReadOnly = true;
            this.startTimeTextBox.Size = new System.Drawing.Size(196, 31);
            this.startTimeTextBox.TabIndex = 3;
            // 
            // elapsedTimeLabel
            // 
            this.elapsedTimeLabel.AutoSize = true;
            this.elapsedTimeLabel.Location = new System.Drawing.Point(32, 181);
            this.elapsedTimeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.elapsedTimeLabel.Name = "elapsedTimeLabel";
            this.elapsedTimeLabel.Size = new System.Drawing.Size(96, 25);
            this.elapsedTimeLabel.TabIndex = 2;
            this.elapsedTimeLabel.Text = "Elapsed:";
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(32, 131);
            this.endTimeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(56, 25);
            this.endTimeLabel.TabIndex = 1;
            this.endTimeLabel.Text = "End:";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(32, 81);
            this.startTimeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(63, 25);
            this.startTimeLabel.TabIndex = 0;
            this.startTimeLabel.Text = "Start:";
            // 
            // performanceChartEnabledCheckBox
            // 
            this.performanceChartEnabledCheckBox.AutoSize = true;
            this.performanceChartEnabledCheckBox.Checked = true;
            this.performanceChartEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.performanceChartEnabledCheckBox.Location = new System.Drawing.Point(26, 433);
            this.performanceChartEnabledCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.performanceChartEnabledCheckBox.Name = "performanceChartEnabledCheckBox";
            this.performanceChartEnabledCheckBox.Size = new System.Drawing.Size(224, 29);
            this.performanceChartEnabledCheckBox.TabIndex = 1;
            this.performanceChartEnabledCheckBox.Text = "Performance Chart";
            this.performanceChartEnabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // benchmarkActionButton
            // 
            this.benchmarkActionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.benchmarkActionButton.Location = new System.Drawing.Point(894, 700);
            this.benchmarkActionButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.benchmarkActionButton.Name = "benchmarkActionButton";
            this.benchmarkActionButton.Size = new System.Drawing.Size(150, 44);
            this.benchmarkActionButton.TabIndex = 3;
            this.benchmarkActionButton.Text = "Start";
            this.benchmarkActionButton.UseVisualStyleBackColor = true;
            // 
            // benchmarkingSettingsGroupBox
            // 
            this.benchmarkingSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.benchmarkingSettingsGroupBox.Controls.Add(this.durationNumericUpDown);
            this.benchmarkingSettingsGroupBox.Controls.Add(this.sequentialExecutionCheckBox);
            this.benchmarkingSettingsGroupBox.Controls.Add(this.nominalPerformanceNumericUpDown);
            this.benchmarkingSettingsGroupBox.Controls.Add(this.nominalPerformanceRadioButton);
            this.benchmarkingSettingsGroupBox.Controls.Add(this.peakPerformanceRadioButton);
            this.benchmarkingSettingsGroupBox.Controls.Add(this.testingModeLabel);
            this.benchmarkingSettingsGroupBox.Controls.Add(this.numberOfThreadsNumericUpDown);
            this.benchmarkingSettingsGroupBox.Controls.Add(this.numberOfThreadsLabel);
            this.benchmarkingSettingsGroupBox.Location = new System.Drawing.Point(26, 25);
            this.benchmarkingSettingsGroupBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.benchmarkingSettingsGroupBox.Name = "benchmarkingSettingsGroupBox";
            this.benchmarkingSettingsGroupBox.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.benchmarkingSettingsGroupBox.Size = new System.Drawing.Size(1018, 144);
            this.benchmarkingSettingsGroupBox.TabIndex = 5;
            this.benchmarkingSettingsGroupBox.TabStop = false;
            this.benchmarkingSettingsGroupBox.Text = "Benchmarking Settings";
            // 
            // durationNumericUpDown
            // 
            this.durationNumericUpDown.Location = new System.Drawing.Point(764, 38);
            this.durationNumericUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.durationNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.durationNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.durationNumericUpDown.Name = "durationNumericUpDown";
            this.durationNumericUpDown.Size = new System.Drawing.Size(144, 31);
            this.durationNumericUpDown.TabIndex = 7;
            this.durationNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // sequentialExecutionCheckBox
            // 
            this.sequentialExecutionCheckBox.AutoSize = true;
            this.sequentialExecutionCheckBox.Location = new System.Drawing.Point(408, 40);
            this.sequentialExecutionCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sequentialExecutionCheckBox.Name = "sequentialExecutionCheckBox";
            this.sequentialExecutionCheckBox.Size = new System.Drawing.Size(344, 29);
            this.sequentialExecutionCheckBox.TabIndex = 6;
            this.sequentialExecutionCheckBox.Text = "Execute Sequentially For (sec):";
            this.sequentialExecutionCheckBox.UseVisualStyleBackColor = true;
            // 
            // nominalPerformanceNumericUpDown
            // 
            this.nominalPerformanceNumericUpDown.DecimalPlaces = 2;
            this.nominalPerformanceNumericUpDown.Location = new System.Drawing.Point(596, 87);
            this.nominalPerformanceNumericUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nominalPerformanceNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nominalPerformanceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.nominalPerformanceNumericUpDown.Name = "nominalPerformanceNumericUpDown";
            this.nominalPerformanceNumericUpDown.Size = new System.Drawing.Size(162, 31);
            this.nominalPerformanceNumericUpDown.TabIndex = 5;
            this.nominalPerformanceNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nominalPerformanceRadioButton
            // 
            this.nominalPerformanceRadioButton.AutoSize = true;
            this.nominalPerformanceRadioButton.Location = new System.Drawing.Point(408, 88);
            this.nominalPerformanceRadioButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nominalPerformanceRadioButton.Name = "nominalPerformanceRadioButton";
            this.nominalPerformanceRadioButton.Size = new System.Drawing.Size(176, 29);
            this.nominalPerformanceRadioButton.TabIndex = 4;
            this.nominalPerformanceRadioButton.TabStop = true;
            this.nominalPerformanceRadioButton.Text = "Nominal (tps):";
            this.nominalPerformanceRadioButton.UseVisualStyleBackColor = true;
            // 
            // peakPerformanceRadioButton
            // 
            this.peakPerformanceRadioButton.AutoSize = true;
            this.peakPerformanceRadioButton.Location = new System.Drawing.Point(268, 89);
            this.peakPerformanceRadioButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.peakPerformanceRadioButton.Name = "peakPerformanceRadioButton";
            this.peakPerformanceRadioButton.Size = new System.Drawing.Size(92, 29);
            this.peakPerformanceRadioButton.TabIndex = 3;
            this.peakPerformanceRadioButton.TabStop = true;
            this.peakPerformanceRadioButton.Text = "Peak";
            this.peakPerformanceRadioButton.UseVisualStyleBackColor = true;
            // 
            // testingModeLabel
            // 
            this.testingModeLabel.AutoSize = true;
            this.testingModeLabel.Location = new System.Drawing.Point(26, 90);
            this.testingModeLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.testingModeLabel.Name = "testingModeLabel";
            this.testingModeLabel.Size = new System.Drawing.Size(230, 25);
            this.testingModeLabel.TabIndex = 2;
            this.testingModeLabel.Text = "Measure Performance:";
            // 
            // numberOfThreadsNumericUpDown
            // 
            this.numberOfThreadsNumericUpDown.Location = new System.Drawing.Point(260, 37);
            this.numberOfThreadsNumericUpDown.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.numberOfThreadsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfThreadsNumericUpDown.Name = "numberOfThreadsNumericUpDown";
            this.numberOfThreadsNumericUpDown.Size = new System.Drawing.Size(118, 31);
            this.numberOfThreadsNumericUpDown.TabIndex = 1;
            this.numberOfThreadsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numberOfThreadsLabel
            // 
            this.numberOfThreadsLabel.AutoSize = true;
            this.numberOfThreadsLabel.Location = new System.Drawing.Point(26, 40);
            this.numberOfThreadsLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.numberOfThreadsLabel.Name = "numberOfThreadsLabel";
            this.numberOfThreadsLabel.Size = new System.Drawing.Size(202, 25);
            this.numberOfThreadsLabel.TabIndex = 0;
            this.numberOfThreadsLabel.Text = "Number of Threads:";
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.AllowUserToAddRows = false;
            this.resultsDataGridView.AllowUserToDeleteRows = false;
            this.resultsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.benchmarkNameColumn,
            this.performanceColumn,
            this.cpuLoadColumn,
            this.memoryUsageColumn});
            this.resultsDataGridView.Location = new System.Drawing.Point(410, 433);
            this.resultsDataGridView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.RowHeadersVisible = false;
            this.resultsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultsDataGridView.Size = new System.Drawing.Size(574, 213);
            this.resultsDataGridView.TabIndex = 25;
            this.resultsDataGridView.Visible = false;
            // 
            // benchmarkNameColumn
            // 
            this.benchmarkNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.benchmarkNameColumn.HeaderText = "Benchmark";
            this.benchmarkNameColumn.MinimumWidth = 150;
            this.benchmarkNameColumn.Name = "benchmarkNameColumn";
            this.benchmarkNameColumn.ReadOnly = true;
            // 
            // performanceColumn
            // 
            this.performanceColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.performanceColumn.HeaderText = "Performance (tps)";
            this.performanceColumn.MinimumWidth = 120;
            this.performanceColumn.Name = "performanceColumn";
            this.performanceColumn.ReadOnly = true;
            // 
            // cpuLoadColumn
            // 
            this.cpuLoadColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cpuLoadColumn.HeaderText = "CPU Load (%)";
            this.cpuLoadColumn.MinimumWidth = 100;
            this.cpuLoadColumn.Name = "cpuLoadColumn";
            this.cpuLoadColumn.ReadOnly = true;
            // 
            // memoryUsageColumn
            // 
            this.memoryUsageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.memoryUsageColumn.HeaderText = "Memory Usage (Mb)";
            this.memoryUsageColumn.MinimumWidth = 130;
            this.memoryUsageColumn.Name = "memoryUsageColumn";
            this.memoryUsageColumn.ReadOnly = true;
            // 
            // performanceChart
            // 
            this.performanceChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.performanceChart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.performanceChart.Location = new System.Drawing.Point(26, 477);
            this.performanceChart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.performanceChart.Name = "performanceChart";
            this.performanceChart.PerfChartStyle.AntiAliasing = true;
            chartPen1.Color = System.Drawing.Color.LightGreen;
            chartPen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartPen1.Width = 1F;
            this.performanceChart.PerfChartStyle.AverageLinePen = chartPen1;
            this.performanceChart.PerfChartStyle.BackgroundColorBottom = System.Drawing.Color.DarkGreen;
            this.performanceChart.PerfChartStyle.BackgroundColorTop = System.Drawing.Color.DarkGreen;
            chartPen2.Color = System.Drawing.Color.Gold;
            chartPen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen2.Width = 1F;
            this.performanceChart.PerfChartStyle.ChartLinePen = chartPen2;
            chartPen3.Color = System.Drawing.Color.Black;
            chartPen3.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen3.Width = 1F;
            this.performanceChart.PerfChartStyle.HorizontalGridPen = chartPen3;
            this.performanceChart.PerfChartStyle.ShowAverageLine = true;
            this.performanceChart.PerfChartStyle.ShowHorizontalGridLines = true;
            this.performanceChart.PerfChartStyle.ShowVerticalGridLines = true;
            chartPen4.Color = System.Drawing.Color.Black;
            chartPen4.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartPen4.Width = 1F;
            this.performanceChart.PerfChartStyle.VerticalGridPen = chartPen4;
            this.performanceChart.ScaleMode = PipBenchmark.Gui.Charts.ScaleMode.Relative;
            this.performanceChart.Size = new System.Drawing.Size(1018, 212);
            this.performanceChart.TabIndex = 4;
            this.performanceChart.TimerInterval = 100;
            this.performanceChart.TimerMode = PipBenchmark.Gui.Charts.TimerMode.Disabled;
            // 
            // ExecutionPerspective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultsDataGridView);
            this.Controls.Add(this.benchmarkingSettingsGroupBox);
            this.Controls.Add(this.performanceChart);
            this.Controls.Add(this.benchmarkActionButton);
            this.Controls.Add(this.performanceChartEnabledCheckBox);
            this.Controls.Add(this.benchmarkingResultsGroupBox);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ExecutionPerspective";
            this.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.Size = new System.Drawing.Size(1070, 769);
            this.benchmarkingResultsGroupBox.ResumeLayout(false);
            this.benchmarkingResultsGroupBox.PerformLayout();
            this.benchmarkingSettingsGroupBox.ResumeLayout(false);
            this.benchmarkingSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nominalPerformanceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfThreadsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox benchmarkingResultsGroupBox;
        private System.Windows.Forms.TextBox elapsedTimeTextBox;
        private System.Windows.Forms.TextBox endTimeTextBox;
        private System.Windows.Forms.TextBox startTimeTextBox;
        private System.Windows.Forms.Label elapsedTimeLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.TextBox maxPerformanceTextBox;
        private System.Windows.Forms.TextBox averagePerformanceTextBox;
        private System.Windows.Forms.TextBox minPerformanceTextBox;
        private System.Windows.Forms.Label maxPerformanceLabel;
        private System.Windows.Forms.Label averagePerformanceLabel;
        private System.Windows.Forms.Label minPerformanceLabel;
        private System.Windows.Forms.CheckBox performanceChartEnabledCheckBox;
        private System.Windows.Forms.Button benchmarkActionButton;
        private PipBenchmark.Gui.Charts.PerformanceChart performanceChart;
        private System.Windows.Forms.GroupBox benchmarkingSettingsGroupBox;
        private System.Windows.Forms.RadioButton nominalPerformanceRadioButton;
        private System.Windows.Forms.RadioButton peakPerformanceRadioButton;
        private System.Windows.Forms.Label testingModeLabel;
        private System.Windows.Forms.NumericUpDown numberOfThreadsNumericUpDown;
        private System.Windows.Forms.Label numberOfThreadsLabel;
        private System.Windows.Forms.NumericUpDown nominalPerformanceNumericUpDown;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label performanceLabel;
        private System.Windows.Forms.Label cpuLabel;
        private System.Windows.Forms.TextBox maxCpuLoadTextBox;
        private System.Windows.Forms.TextBox averageCpuLoadTextBox;
        private System.Windows.Forms.TextBox minCpuLoadTextBox;
        private System.Windows.Forms.Label memoryLabel;
        private System.Windows.Forms.TextBox maxMemoryTextBox;
        private System.Windows.Forms.TextBox averageMemoryTextBox;
        private System.Windows.Forms.TextBox minMemoryTextBox;
        private System.Windows.Forms.NumericUpDown durationNumericUpDown;
        private System.Windows.Forms.CheckBox sequentialExecutionCheckBox;
        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn benchmarkNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn performanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpuLoadColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn memoryUsageColumn;
    }
}
