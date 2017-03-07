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
            this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.initializationTabPage = new System.Windows.Forms.TabPage();
            this.initializationPerspective = new PipBenchmark.Gui.Initialization.InitializationPerspective();
            this.configurationTabPage = new System.Windows.Forms.TabPage();
            this.configurationPerspective = new PipBenchmark.Gui.Config.ConfigurationPerspective();
            this.executionTabPage = new System.Windows.Forms.TabPage();
            this.executionPerspective = new PipBenchmark.Gui.Execution.ExecutionPerspective();
            this.resultsTabPage = new System.Windows.Forms.TabPage();
            this.resultsPerspective = new PipBenchmark.Gui.Results.ResultsPerspective();
            this.environmentTabPage = new System.Windows.Forms.TabPage();
            this.environmentPerspective = new PipBenchmark.Gui.Environment.EnvironmentPerspective();
            this.mainStatusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.contentTabControl.SuspendLayout();
            this.initializationTabPage.SuspendLayout();
            this.configurationTabPage.SuspendLayout();
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
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 448);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(548, 22);
            this.mainStatusStrip.TabIndex = 0;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(16, 17);
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
            this.mainMenuStrip.Size = new System.Drawing.Size(548, 24);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSuiteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.loadConfigurationToolStripMenuItem,
            this.saveConfigurationToolStripMenuItem,
            this.toolStripMenuItem2,
            this.saveReportToolStripMenuItem,
            this.printReportToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadSuiteToolStripMenuItem
            // 
            this.loadSuiteToolStripMenuItem.Name = "loadSuiteToolStripMenuItem";
            this.loadSuiteToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.loadSuiteToolStripMenuItem.Text = "&Load Benchmark Suite...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(198, 6);
            // 
            // loadConfigurationToolStripMenuItem
            // 
            this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.loadConfigurationToolStripMenuItem.Text = "&Load Configuration...";
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveConfigurationToolStripMenuItem.Text = "&Save Configuration...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(198, 6);
            // 
            // saveReportToolStripMenuItem
            // 
            this.saveReportToolStripMenuItem.Name = "saveReportToolStripMenuItem";
            this.saveReportToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveReportToolStripMenuItem.Text = "Save &Report...";
            // 
            // printReportToolStripMenuItem
            // 
            this.printReportToolStripMenuItem.Name = "printReportToolStripMenuItem";
            this.printReportToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.printReportToolStripMenuItem.Text = "&Print Report...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(198, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
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
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // initializationToolStripMenuItem
            // 
            this.initializationToolStripMenuItem.Name = "initializationToolStripMenuItem";
            this.initializationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.initializationToolStripMenuItem.Text = "&Initialization";
            this.initializationToolStripMenuItem.Click += new System.EventHandler(this.OnViewItemClick);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.configurationToolStripMenuItem.Text = "&Configuration";
            this.configurationToolStripMenuItem.Click += new System.EventHandler(this.OnViewItemClick);
            // 
            // executionToolStripMenuItem
            // 
            this.executionToolStripMenuItem.Name = "executionToolStripMenuItem";
            this.executionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.executionToolStripMenuItem.Text = "&Execution";
            this.executionToolStripMenuItem.Click += new System.EventHandler(this.OnViewItemClick);
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.resultsToolStripMenuItem.Text = "&Results";
            this.resultsToolStripMenuItem.Click += new System.EventHandler(this.OnViewItemClick);
            // 
            // environmentToolStripMenuItem
            // 
            this.environmentToolStripMenuItem.Name = "environmentToolStripMenuItem";
            this.environmentToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
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
            this.benchmarkToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.benchmarkToolStripMenuItem.Text = "&Benchmark";
            // 
            // startBenchmarkingToolStripMenuItem
            // 
            this.startBenchmarkingToolStripMenuItem.Name = "startBenchmarkingToolStripMenuItem";
            this.startBenchmarkingToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.startBenchmarkingToolStripMenuItem.Text = "&Start Benchmarking";
            // 
            // stopBenchmarkingToolStripMenuItem
            // 
            this.stopBenchmarkingToolStripMenuItem.Name = "stopBenchmarkingToolStripMenuItem";
            this.stopBenchmarkingToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.stopBenchmarkingToolStripMenuItem.Text = "&Stop Benchmarking";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(202, 6);
            // 
            // benchmarkEnvironmentToolStripMenuItem
            // 
            this.benchmarkEnvironmentToolStripMenuItem.Name = "benchmarkEnvironmentToolStripMenuItem";
            this.benchmarkEnvironmentToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.benchmarkEnvironmentToolStripMenuItem.Text = "&Benchmark Environment";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // contentTabControl
            // 
            this.contentTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTabControl.Controls.Add(this.initializationTabPage);
            this.contentTabControl.Controls.Add(this.configurationTabPage);
            this.contentTabControl.Controls.Add(this.executionTabPage);
            this.contentTabControl.Controls.Add(this.resultsTabPage);
            this.contentTabControl.Controls.Add(this.environmentTabPage);
            this.contentTabControl.Location = new System.Drawing.Point(0, 23);
            this.contentTabControl.Name = "contentTabControl";
            this.contentTabControl.SelectedIndex = 0;
            this.contentTabControl.Size = new System.Drawing.Size(548, 428);
            this.contentTabControl.TabIndex = 2;
            this.contentTabControl.Click += new System.EventHandler(this.OnContentTabClick);
            // 
            // initializationTabPage
            // 
            this.initializationTabPage.Controls.Add(this.initializationPerspective);
            this.initializationTabPage.Location = new System.Drawing.Point(4, 22);
            this.initializationTabPage.Name = "initializationTabPage";
            this.initializationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.initializationTabPage.Size = new System.Drawing.Size(540, 402);
            this.initializationTabPage.TabIndex = 0;
            this.initializationTabPage.Text = "Initialization";
            this.initializationTabPage.UseVisualStyleBackColor = true;
            // 
            // initializationPerspective
            // 
            this.initializationPerspective.AllBenchmarks = null;
            this.initializationPerspective.AllSuites = null;
            this.initializationPerspective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.initializationPerspective.Location = new System.Drawing.Point(3, 3);
            this.initializationPerspective.Margin = new System.Windows.Forms.Padding(6);
            this.initializationPerspective.Name = "initializationPerspective";
            this.initializationPerspective.Size = new System.Drawing.Size(534, 396);
            this.initializationPerspective.TabIndex = 0;
            // 
            // configurationTabPage
            // 
            this.configurationTabPage.Controls.Add(this.configurationPerspective);
            this.configurationTabPage.Location = new System.Drawing.Point(4, 22);
            this.configurationTabPage.Name = "configurationTabPage";
            this.configurationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.configurationTabPage.Size = new System.Drawing.Size(540, 402);
            this.configurationTabPage.TabIndex = 1;
            this.configurationTabPage.Text = "Configuration";
            this.configurationTabPage.UseVisualStyleBackColor = true;
            // 
            // configurationPerspective
            // 
            this.configurationPerspective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configurationPerspective.Location = new System.Drawing.Point(3, 3);
            this.configurationPerspective.Margin = new System.Windows.Forms.Padding(6);
            this.configurationPerspective.Name = "configurationPerspective";
            this.configurationPerspective.Padding = new System.Windows.Forms.Padding(10);
            this.configurationPerspective.Size = new System.Drawing.Size(534, 396);
            this.configurationPerspective.TabIndex = 0;
            // 
            // executionTabPage
            // 
            this.executionTabPage.Controls.Add(this.executionPerspective);
            this.executionTabPage.Location = new System.Drawing.Point(4, 22);
            this.executionTabPage.Name = "executionTabPage";
            this.executionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.executionTabPage.Size = new System.Drawing.Size(540, 402);
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
            this.executionPerspective.ExecutionType = ExecutionType.Proportional;
            this.executionPerspective.Location = new System.Drawing.Point(3, 3);
            this.executionPerspective.Margin = new System.Windows.Forms.Padding(6);
            this.executionPerspective.MeasurementType = MeasurementType.Nominal;
            this.executionPerspective.MinimumSize = new System.Drawing.Size(535, 400);
            this.executionPerspective.Name = "executionPerspective";
            this.executionPerspective.NominalRate = 1D;
            this.executionPerspective.NumberOfThreads = 1;
            this.executionPerspective.Padding = new System.Windows.Forms.Padding(10);
            this.executionPerspective.PerformanceChartEnabled = true;
            this.executionPerspective.PerformanceChartName = "Performance Chart";
            this.executionPerspective.ShowPerformanceChart = true;
            this.executionPerspective.Size = new System.Drawing.Size(535, 400);
            this.executionPerspective.TabIndex = 0;
            // 
            // resultsTabPage
            // 
            this.resultsTabPage.Controls.Add(this.resultsPerspective);
            this.resultsTabPage.Location = new System.Drawing.Point(4, 22);
            this.resultsTabPage.Name = "resultsTabPage";
            this.resultsTabPage.Size = new System.Drawing.Size(540, 402);
            this.resultsTabPage.TabIndex = 3;
            this.resultsTabPage.Text = "Results";
            this.resultsTabPage.UseVisualStyleBackColor = true;
            // 
            // resultsPerspective
            // 
            this.resultsPerspective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsPerspective.Location = new System.Drawing.Point(0, 0);
            this.resultsPerspective.Margin = new System.Windows.Forms.Padding(6);
            this.resultsPerspective.Name = "resultsPerspective";
            this.resultsPerspective.Padding = new System.Windows.Forms.Padding(10);
            this.resultsPerspective.ReportContent = "";
            this.resultsPerspective.Size = new System.Drawing.Size(540, 402);
            this.resultsPerspective.TabIndex = 0;
            // 
            // environmentTabPage
            // 
            this.environmentTabPage.Controls.Add(this.environmentPerspective);
            this.environmentTabPage.Location = new System.Drawing.Point(4, 22);
            this.environmentTabPage.Name = "environmentTabPage";
            this.environmentTabPage.Size = new System.Drawing.Size(540, 402);
            this.environmentTabPage.TabIndex = 4;
            this.environmentTabPage.Text = "Environment";
            this.environmentTabPage.UseVisualStyleBackColor = true;
            // 
            // environmentPerspective
            // 
            this.environmentPerspective.Dock = System.Windows.Forms.DockStyle.Fill;
            this.environmentPerspective.Location = new System.Drawing.Point(0, 0);
            this.environmentPerspective.Margin = new System.Windows.Forms.Padding(6);
            this.environmentPerspective.Name = "environmentPerspective";
            this.environmentPerspective.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.environmentPerspective.Size = new System.Drawing.Size(540, 402);
            this.environmentPerspective.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 470);
            this.Controls.Add(this.contentTabControl);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(564, 500);
            this.Name = "MainForm";
            this.Text = "Pip.Benchmark";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.contentTabControl.ResumeLayout(false);
            this.initializationTabPage.ResumeLayout(false);
            this.configurationTabPage.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
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
        private System.Windows.Forms.TabPage initializationTabPage;
        private System.Windows.Forms.TabPage configurationTabPage;
        private System.Windows.Forms.TabPage executionTabPage;
        private System.Windows.Forms.TabPage resultsTabPage;
        private System.Windows.Forms.TabPage environmentTabPage;
        private PipBenchmark.Gui.Initialization.InitializationPerspective initializationPerspective;
        private PipBenchmark.Gui.Config.ConfigurationPerspective configurationPerspective;
        private PipBenchmark.Gui.Execution.ExecutionPerspective executionPerspective;
        private PipBenchmark.Gui.Results.ResultsPerspective resultsPerspective;
        private PipBenchmark.Gui.Environment.EnvironmentPerspective environmentPerspective;
    }
}

