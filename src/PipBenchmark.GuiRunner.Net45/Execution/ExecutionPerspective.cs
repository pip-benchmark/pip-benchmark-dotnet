using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PipBenchmark.Gui.Execution;
using PipBenchmark.Runner;
using PipBenchmark.Runner.Config;

namespace PipBenchmark.Gui.Execution
{
    public partial class ExecutionPerspective : UserControl, IExecutionView
    {
        public ExecutionPerspective()
        {
            InitializeComponent();
            InitializeResultsGrid();
        }

        private void InitializeResultsGrid()
        {
            resultsDataGridView.Left = benchmarkingResultsGroupBox.Left;
            resultsDataGridView.Top = benchmarkingResultsGroupBox.Top;
            resultsDataGridView.Width = benchmarkingResultsGroupBox.Width;
            resultsDataGridView.Height = performanceChart.Top
                + performanceChart.Height - benchmarkingResultsGroupBox.Top;

            benchmarkNameColumn.DataPropertyName = "Benchmark";
            performanceColumn.DataPropertyName = "Performance";
            cpuLoadColumn.DataPropertyName = "CpuLoad";
            memoryUsageColumn.DataPropertyName = "MemoryUsage";
        }

        #region IExecutionView Members

        public string StartTime
        {
            set { startTimeTextBox.Text = value; }
        }

        public string EndTime
        {
            set { endTimeTextBox.Text = value; }
        }

        public string ElapsedTime
        {
            set { elapsedTimeTextBox.Text = value; }
        }

        public string MinPerformance
        {
            set { minPerformanceTextBox.Text = value; }
        }

        public string AveragePerformance
        {
            set { averagePerformanceTextBox.Text = value; }
        }

        public string MaxPerformance
        {
            set { maxPerformanceTextBox.Text = value; }
        }

        public string MinCpuLoad
        {
            set { minCpuLoadTextBox.Text = value; }
        }

        public string AverageCpuLoad
        {
            set { averageCpuLoadTextBox.Text = value; }
        }

        public string MaxCpuLoad
        {
            set { maxCpuLoadTextBox.Text = value; }
        }

        public string MinMemoryUsage
        {
            set { minMemoryTextBox.Text = value; }
        }

        public string AverageMemoryUsage
        {
            set { averageMemoryTextBox.Text = value; }
        }

        public string MaxMemoryUsage
        {
            set { maxMemoryTextBox.Text = value; }
        }

        public List<ExecutionResult> ExecutionResults
        {
            set 
            {
                resultsDataGridView.DataSource = value;
                resultsDataGridView.Update();
            }
        }

        public int NumberOfThreads
        {
            get { return (int) numberOfThreadsNumericUpDown.Value; }
            set { numberOfThreadsNumericUpDown.Value = value; }
        }

        public MeasurementType MeasurementType
        {
            get 
            { 
                return peakPerformanceRadioButton.Checked
                    ? MeasurementType.Peak : MeasurementType.Nominal; 
            }
            set
            {
                peakPerformanceRadioButton.Checked = value == MeasurementType.Peak;
                nominalPerformanceRadioButton.Checked = value == MeasurementType.Nominal;
            }
        }

        public double NominalRate
        {
            get { return (double) nominalPerformanceNumericUpDown.Value; }
            set { nominalPerformanceNumericUpDown.Value = new Decimal(value); }
        }

        public string PerformanceChartName
        {
            get { return performanceChartEnabledCheckBox.Text; }
            set { performanceChartEnabledCheckBox.Text = value; }
        }

        public bool PerformanceChartEnabled
        {
            get { return performanceChartEnabledCheckBox.Checked; }
            set { performanceChartEnabledCheckBox.Checked = value; }
        }

        public ExecutionType ExecutionType
        {
            get 
            { 
                return sequentialExecutionCheckBox.Checked 
                    ? ExecutionType.Sequential 
                    : ExecutionType.Proportional; 
            }
            set 
            { 
                sequentialExecutionCheckBox.Checked 
                    = value == ExecutionType.Sequential; 
            }
        }

        public int Duration
        {
            get { return (int)durationNumericUpDown.Value; }
            set { durationNumericUpDown.Value = value; }
        }

        public bool ShowPerformanceChart
        {
            get { return !resultsDataGridView.Visible; }
            set 
            { 
                resultsDataGridView.Visible = !value;
                benchmarkingResultsGroupBox.Visible = value;
                performanceChartEnabledCheckBox.Visible = value;
                performanceChart.Visible = value;
            }
        }

        public string BenchmarkActionButton
        {
            get { return benchmarkActionButton.Text; }
            set { benchmarkActionButton.Text = value; }
        }

        public event EventHandler BenchmarkActionClicked
        {
            add { benchmarkActionButton.Click += value; }
            remove { benchmarkActionButton.Click -= value; }
        }

        public event EventHandler DataUpdated
        {
            add
            {
                numberOfThreadsNumericUpDown.ValueChanged += value;
                peakPerformanceRadioButton.Click += value;
                nominalPerformanceRadioButton.Click += value;
                nominalPerformanceNumericUpDown.ValueChanged += value;
                sequentialExecutionCheckBox.Click += value;
                durationNumericUpDown.ValueChanged += value;
            }
            remove
            {
                numberOfThreadsNumericUpDown.ValueChanged -= value;
                peakPerformanceRadioButton.Click -= value;
                nominalPerformanceRadioButton.Click -= value;
                nominalPerformanceNumericUpDown.ValueChanged -= value;
                sequentialExecutionCheckBox.Click -= value;
                durationNumericUpDown.Click -= value;
            }
        }

        public void AddCurrentPerformancePoint(double currentPerformance)
        {
            if (performanceChartEnabledCheckBox.Checked)
            {
                performanceChart.AddValue(new Decimal(currentPerformance));
            }
        }

        public void ClearPerformancePoints()
        {
            performanceChart.Clear();
        }

        #endregion

    }
}