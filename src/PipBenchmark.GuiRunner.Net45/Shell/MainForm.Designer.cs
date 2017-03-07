using PipBenchmark.Runner.Config;

namespace PipBenchmark.Gui.Shell
{
    partial class MainForm
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
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSuiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initializationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.environmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.benchmarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startBenchmarkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBenchmarkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.benchmarkEnvironmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentTabControl = new System.Windows.Forms.TabControl();
            this.benchmarksTabPage = new System.Windows.Forms.TabPage();
            this.benchmarksPerspective = new PipBenchmark.Gui.Benchmarks.BenchmarksPerspective();
            this.parametersTabPage = new System.Windows.Forms.TabPage();
            this.parametersPerspective = new PipBenchmark.Gui.Parameters.ParametersPerspective();
            this.executionTabPage = new System.Windows.Forms.TabPage();
            this.executionPerspective = new PipBenchmark.Gui.Execution.ExecutionPerspective();
            this.resultsTabPage = new System.Windows.Forms.TabPage();
            this.resultsPerspective = new PipBenchmark.Gui.Results.ResultsPerspective();
            this.environmentTabPage = new System.Windows.Forms.TabPage();
            this.environmentPerspective = new PipBenchmark.Gui.Environment.EnvironmentPerspective();
            this.mainStatusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.contentTabControl.SuspendLayout();
            this.benchmarksTabPage.SuspendLayout();
            this.parametersTabPage.SuspendLayout();
            this.executionTabPage.SuspendLayout();
            this.resultsTabPage.SuspendLayout();
            this.environmentTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 867);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(1096, 37);
            this.mainStatusStrip.TabIndex = 0;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(30, 32);
            this.statusLabel.Text = "...";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.benchmarkToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.mainMenuStrip.Size = new System.Drawing.Size(1096, 44);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSuiteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.loadParametersToolStripMenuItem,
            this.saveParametersToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveReportToolStripMenuItem,
            this.printReportToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadSuiteToolStripMenuItem
            // 
            this.loadSuiteToolStripMenuItem.Name = "loadSuiteToolStripMenuItem";
            this.loadSuiteToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.loadSuiteToolStripMenuItem.Text = "&Load Suite...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(302, 6);
            // 
            // loadParametersToolStripMenuItem
            // 
            this.loadParametersToolStripMenuItem.Name = "loadParametersToolStripMenuItem";
            this.loadParametersToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.loadParametersToolStripMenuItem.Text = "&Load Parameters...";
            // 
            // saveParametersToolStripMenuItem
            // 
            this.saveParametersToolStripMenuItem.Name = "saveParametersToolStripMenuItem";
            this.saveParametersToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.saveParametersToolStripMenuItem.Text = "&Save Parameters...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(302, 6);
            // 
            // saveReportToolStripMenuItem
            // 
            this.saveReportToolStripMenuItem.Name = "saveReportToolStripMenuItem";
            this.saveReportToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.saveReportToolStripMenuItem.Text = "Save &Report...";
            // 
            // printReportToolStripMenuItem
            // 
            this.printReportToolStripMenuItem.Name = "printReportToolStripMenuItem";
            this.printReportToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.printReportToolStripMenuItem.Text = "&Print Report...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(302, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(305, 38);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initializationToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.executionToolStripMenuItem,
            this.resultsToolStripMenuItem,
            this.environmentToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(78, 36);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // initializationToolStripMenuItem
            // 
            this.initializationToolStripMenuItem.Name = "initializationToolStripMenuItem";
            this.initializationToolStripMenuItem.Size = new System.Drawing.Size(251, 38);
            this.initializationToolStripMenuItem.Text = "&Benchmarks";
            this.initializationToolStripMenuItem.Click += new System.EventHandler(this.OnViewItemClick);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(251, 38);
            this.configurationToolStripMenuItem.Text = "&Parameters";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.OnViewItemClick);
            // 
            // executionToolStripMenuItem
            // 
            this.executionToolStripMenuItem.Name = "executionToolStripMenuItem";
            this.executionToolStripMenuItem.Size = new System.Drawing.Size(251, 38);
            this.executionToolStripMenuItem.Text = "&Execution";
            this.executionToolStripMenuItem.Click += new System.EventHandler(this.OnViewItemClick);
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(251, 38);
            this.resultsToolStripMenuItem.Text = "&Results";
            this.resultsToolStripMenuItem.Click += new System.EventHandler(this.OnViewItemClick);
            // 
            // environmentToolStripMenuItem
            // 
            this.environmentToolStripMenuItem.Name = "environmentToolStripMenuItem";
            this.environmentToolStripMenuItem.Size = new System.Drawing.Size(251, 38);
            this.environmentToolStripMenuItem.Text = "E&nvironment";
            this.environmentToolStripMenuItem.Click += new System.EventHandler(this.OnViewItemClick);
            // 
            // benchmarkToolStripMenuItem
            // 
            this.benchmarkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startBenchmarkingToolStripMenuItem,
            this.stopBenchmarkingToolStripMenuItem,
            this.toolStripMenuItem4,
            this.benchmarkEnvironmentToolStripMenuItem});
            this.benchmarkToolStripMenuItem.Name = "benchmarkToolStripMenuItem";
            this.benchmarkToolStripMenuItem.Size = new System.Drawing.Size(119, 36);
            this.benchmarkToolStripMenuItem.Text = "&Measure";
            // 
            // startBenchmarkingToolStripMenuItem
            // 
            this.startBenchmarkingToolStripMenuItem.Name = "startBenchmarkingToolStripMenuItem";
            this.startBenchmarkingToolStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.startBenchmarkingToolStripMenuItem.Text = "&Start Measuring";
            // 
            // stopBenchmarkingToolStripMenuItem
            // 
            this.stopBenchmarkingToolStripMenuItem.Name = "stopBenchmarkingToolStripMenuItem";
            this.stopBenchmarkingToolStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.stopBenchmarkingToolStripMenuItem.Text = "&Stop Measuring";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(347, 6);
            // 
            // benchmarkEnvironmentToolStripMenuItem
            // 
            this.benchmarkEnvironmentToolStripMenuItem.Name = "benchmarkEnvironmentToolStripMenuItem";
            this.benchmarkEnvironmentToolStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.benchmarkEnvironmentToolStripMenuItem.Text = "&Measure Environment";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(195, 38);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // contentTabControl
            // 
            this.contentTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTabControl.Controls.Add(this.benchmarksTabPage);
            this.contentTabControl.Controls.Add(this.parametersTabPage);
            this.contentTabControl.Controls.Add(this.executionTabPage);
            this.contentTabControl.Controls.Add(this.resultsTabPage);
            this.contentTabControl.Controls.Add(this.environmentTabPage);
            this.contentTabControl.Location = new System.Drawing.Point(0, 44);
            this.contentTabControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.contentTabControl.Name = "contentTabControl";
            this.contentTabControl.SelectedIndex = 0;
            this.contentTabControl.Size = new System.Drawing.Size(1096, 823);
            this.contentTabControl.TabIndex = 2;
            this.contentTabControl.Click += new System.EventHandler(this.OnContentTabClick);
            // 
            // benchmarksTabPage
            // 
            this.benchmarksTabPage.Controls.Add(this.benchmarksPerspective);
            this.benchmarksTabPage.Location = new System.Drawing.Point(8, 39);
            this.benchmarksTabPage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.benchmarksTabPage.Name = "benchmarksTabPage";
            this.benchmarksTabPage.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.benchmarksTabPage.Size = new System.Drawing.Size(1080, 776);
            this.benchmarksTabPage.TabIndex = 0;
            this.benchmarksTabPage.Text = "Benchmarks";
            this.benchmarksTabPage.UseVisualStyleBackColor = true;
            // 
            // benchmarksPerspective
            // 
            this.benchmarksPerspective.AllBenchmarks = null;
            this.benchmarksPerspective.AllSuites = null;
            this.benchmarksPerspective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.benchmarksPerspective.Location = new System.Drawing.Point(6, 6);
            this.benchmarksPerspective.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.benchmarksPerspective.Name = "benchmarksPerspective";
            this.benchmarksPerspective.Size = new System.Drawing.Size(1068, 764);
            this.benchmarksPerspective.TabIndex = 0;
            // 
            // parametersTabPage
            // 
            this.parametersTabPage.Controls.Add(this.parametersPerspective);
            this.parametersTabPage.Location = new System.Drawing.Point(8, 39);
            this.parametersTabPage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.parametersTabPage.Name = "parametersTabPage";
            this.parametersTabPage.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.parametersTabPage.Size = new System.Drawing.Size(1080, 776);
            this.parametersTabPage.TabIndex = 1;
            this.parametersTabPage.Text = "Parameters";
            this.parametersTabPage.UseVisualStyleBackColor = true;
            // 
            // parametersPerspective
            // 
            this.parametersPerspective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersPerspective.Location = new System.Drawing.Point(6, 6);
            this.parametersPerspective.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.parametersPerspective.Name = "parametersPerspective";
            this.parametersPerspective.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.parametersPerspective.Size = new System.Drawing.Size(1068, 764);
            this.parametersPerspective.TabIndex = 0;
            // 
            // executionTabPage
            // 
            this.executionTabPage.Controls.Add(this.executionPerspective);
            this.executionTabPage.Location = new System.Drawing.Point(8, 39);
            this.executionTabPage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.executionTabPage.Name = "executionTabPage";
            this.executionTabPage.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.executionTabPage.Size = new System.Drawing.Size(1080, 776);
            this.executionTabPage.TabIndex = 2;
            this.executionTabPage.Text = "Execution";
            this.executionTabPage.UseVisualStyleBackColor = true;
            // 
            // executionPerspective
            // 
            this.executionPerspective.AutoSize = true;
            this.executionPerspective.BenchmarkActionButton = "Start";
            this.executionPerspective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.executionPerspective.Duration = 1;
            this.executionPerspective.ExecutionType = PipBenchmark.Runner.Config.ExecutionType.Proportional;
            this.executionPerspective.Location = new System.Drawing.Point(6, 6);
            this.executionPerspective.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.executionPerspective.MeasurementType = PipBenchmark.Runner.Config.MeasurementType.Nominal;
            this.executionPerspective.MinimumSize = new System.Drawing.Size(1070, 769);
            this.executionPerspective.Name = "executionPerspective";
            this.executionPerspective.NominalRate = 1D;
            this.executionPerspective.NumberOfThreads = 1;
            this.executionPerspective.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.executionPerspective.PerformanceChartEnabled = true;
            this.executionPerspective.PerformanceChartName = "Performance Chart";
            this.executionPerspective.ShowPerformanceChart = true;
            this.executionPerspective.Size = new System.Drawing.Size(1070, 769);
            this.executionPerspective.TabIndex = 0;
            // 
            // resultsTabPage
            // 
            this.resultsTabPage.Controls.Add(this.resultsPerspective);
            this.resultsTabPage.Location = new System.Drawing.Point(8, 39);
            this.resultsTabPage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.resultsTabPage.Name = "resultsTabPage";
            this.resultsTabPage.Size = new System.Drawing.Size(1080, 776);
            this.resultsTabPage.TabIndex = 3;
            this.resultsTabPage.Text = "Results";
            this.resultsTabPage.UseVisualStyleBackColor = true;
            // 
            // resultsPerspective
            // 
            this.resultsPerspective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsPerspective.Location = new System.Drawing.Point(0, 0);
            this.resultsPerspective.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.resultsPerspective.Name = "resultsPerspective";
            this.resultsPerspective.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.resultsPerspective.ReportContent = "";
            this.resultsPerspective.Size = new System.Drawing.Size(1080, 776);
            this.resultsPerspective.TabIndex = 0;
            // 
            // environmentTabPage
            // 
            this.environmentTabPage.Controls.Add(this.environmentPerspective);
            this.environmentTabPage.Location = new System.Drawing.Point(8, 39);
            this.environmentTabPage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.environmentTabPage.Name = "environmentTabPage";
            this.environmentTabPage.Size = new System.Drawing.Size(1080, 776);
            this.environmentTabPage.TabIndex = 4;
            this.environmentTabPage.Text = "Environment";
            this.environmentTabPage.UseVisualStyleBackColor = true;
            // 
            // environmentPerspective
            // 
            this.environmentPerspective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.environmentPerspective.Location = new System.Drawing.Point(0, 0);
            this.environmentPerspective.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.environmentPerspective.Name = "environmentPerspective";
            this.environmentPerspective.Padding = new System.Windows.Forms.Padding(20, 19, 20, 19);
            this.environmentPerspective.Size = new System.Drawing.Size(1080, 776);
            this.environmentPerspective.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 904);
            this.Controls.Add(this.contentTabControl);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(1102, 896);
            this.Name = "MainForm";
            this.Text = "Pip.Benchmark";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.contentTabControl.ResumeLayout(false);
            this.benchmarksTabPage.ResumeLayout(false);
            this.parametersTabPage.ResumeLayout(false);
            this.executionTabPage.ResumeLayout(false);
            this.executionTabPage.PerformLayout();
            this.resultsTabPage.ResumeLayout(false);
            this.environmentTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSuiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveParametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initializationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem environmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem benchmarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem startBenchmarkingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopBenchmarkingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem benchmarkEnvironmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl contentTabControl;
        private System.Windows.Forms.TabPage benchmarksTabPage;
        private System.Windows.Forms.TabPage parametersTabPage;
        private System.Windows.Forms.TabPage executionTabPage;
        private System.Windows.Forms.TabPage resultsTabPage;
        private System.Windows.Forms.TabPage environmentTabPage;
        private PipBenchmark.Gui.Benchmarks.BenchmarksPerspective benchmarksPerspective;
        private PipBenchmark.Gui.Parameters.ParametersPerspective parametersPerspective;
        private PipBenchmark.Gui.Execution.ExecutionPerspective executionPerspective;
        private PipBenchmark.Gui.Results.ResultsPerspective resultsPerspective;
        private PipBenchmark.Gui.Environment.EnvironmentPerspective environmentPerspective;
    }
}

