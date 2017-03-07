using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PipBenchmark.Gui;
using PipBenchmark.Gui.Benchmarks;
using PipBenchmark.Gui.Parameters;
using PipBenchmark.Gui.Execution;
using PipBenchmark.Gui.Results;
using PipBenchmark.Gui.Environment;

namespace PipBenchmark.Gui.Shell
{
    public partial class MainForm : Form, IMainView
    {
        private ToolStripMenuItem[] viewMenuItems;
        private TabPage[] viewTabPages;
            
        public MainForm()
        {
            InitializeComponent();
            InitializeNavigation();
        }

        private void InitializeNavigation()
        {
            viewMenuItems = new ToolStripMenuItem[]
            {
                initializationToolStripMenuItem, configurationToolStripMenuItem,
                executionToolStripMenuItem, resultsToolStripMenuItem, 
                environmentToolStripMenuItem
            };

            viewTabPages = new TabPage[]
            {
                benchmarksTabPage, parametersTabPage,
                executionTabPage, resultsTabPage,
                environmentTabPage
            };
        }

        private void OnViewItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            SwitchView(menuItem);
        }

        private void SwitchView(ToolStripMenuItem menuItem)
        {
            for (int index = 0; index < viewMenuItems.Length; index++)
            {
                if (viewMenuItems[index] == menuItem)
                {
                    viewMenuItems[index].Checked = true;
                    contentTabControl.SelectedTab = viewTabPages[index];
                }
                else
                {
                    viewMenuItems[index].Checked = false;
                }
            }
        }

        private void OnContentTabClick(object sender, EventArgs e)
        {
            for (int index = 0; index < viewTabPages.Length; index++)
            {
                if (viewTabPages[index] == contentTabControl.SelectedTab)
                {
                    viewMenuItems[index].Checked = true;
                }
                else
                {
                    viewMenuItems[index].Checked = false;
                }
            }
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            SwitchView(initializationToolStripMenuItem);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (FormExited != null)
            {
                FormExited(this, EventArgs.Empty);
            }
        }

        #region IMainView Members

        public Form Handler
        {
            get { return this; }
        }

        public string FormTitle
        {
            set { this.Text = value; }
        }

        public string StatusMessage
        {
            set { statusLabel.Text = value; }
        }

        public string SelectedView
        {
            get { return contentTabControl.SelectedTab.Text; }
            set 
            {
                if (value.Equals("Initialization", StringComparison.InvariantCultureIgnoreCase))
                {
                    SwitchView(initializationToolStripMenuItem);
                }
                else if (value.Equals("Configuration", StringComparison.InvariantCultureIgnoreCase))
                {
                    SwitchView(configurationToolStripMenuItem);
                }
                else if (value.Equals("Execution", StringComparison.InvariantCultureIgnoreCase))
                {
                    SwitchView(executionToolStripMenuItem);
                }
                else if (value.Equals("Results", StringComparison.InvariantCultureIgnoreCase))
                {
                    SwitchView(resultsToolStripMenuItem);
                }
                else if (value.Equals("Environment", StringComparison.InvariantCultureIgnoreCase))
                {
                    SwitchView(environmentToolStripMenuItem);
                }
                else
                {
                    SwitchView(initializationToolStripMenuItem);
                }
            }
        }

        public IBenchmarksView BenchmarksView 
        {
            get { return benchmarksPerspective; }
        }

        public IParametersView ParametersView 
        {
            get { return parametersPerspective; }
        }

        public IExecutionView ExecutionView 
        {
            get { return executionPerspective; }
        }

        public IResultsView ResultsView 
        {
            get { return resultsPerspective; }
        }

        public IEnvironmentView EnvironmentView 
        {
            get { return environmentPerspective; }
        }

        public event EventHandler LoadSuiteClicked
        {
            add { loadSuiteToolStripMenuItem.Click += value; }
            remove { loadSuiteToolStripMenuItem.Click -= value; }
        }

        public event EventHandler LoadParametersClicked
        {
            add { loadParametersToolStripMenuItem.Click += value; }
            remove { loadParametersToolStripMenuItem.Click -= value; }
        }

        public event EventHandler SaveParametersClicked
        {
            add { saveParametersToolStripMenuItem.Click += value; }
            remove { saveParametersToolStripMenuItem.Click -= value; }
        }

        public event EventHandler PrintReportClicked
        {
            add { printReportToolStripMenuItem.Click += value; }
            remove { printReportToolStripMenuItem.Click -= value; }
        }

        public event EventHandler SaveReportClicked
        {
            add { saveReportToolStripMenuItem.Click += value; }
            remove { saveReportToolStripMenuItem.Click -= value; }
        }

        public event EventHandler StartBenchmarkingClicked
        {
            add { startBenchmarkingToolStripMenuItem.Click += value; }
            remove { startBenchmarkingToolStripMenuItem.Click -= value; }
        }

        public event EventHandler StopBenchmarkingClicked
        {
            add { stopBenchmarkingToolStripMenuItem.Click += value; }
            remove { stopBenchmarkingToolStripMenuItem.Click -= value; }
        }

        public event EventHandler UpdateSystemBenchmarkClicked
        {
            add { benchmarkEnvironmentToolStripMenuItem.Click += value; }
            remove { benchmarkEnvironmentToolStripMenuItem.Click -= value; }
        }

        public event EventHandler AboutClicked
        {
            add { aboutToolStripMenuItem.Click += value; }
            remove { aboutToolStripMenuItem.Click -= value; }
        }

        public event EventHandler ExitClicked
        {
            add { exitToolStripMenuItem.Click += value; }
            remove { exitToolStripMenuItem.Click -= value; }
        }

        public event EventHandler FormExited;

        public event EventHandler ParametersViewActivated
        {
            add { contentTabControl.SelectedIndexChanged += value; }
            remove { contentTabControl.SelectedIndexChanged -= value; }
        }

        #endregion

    }
}
