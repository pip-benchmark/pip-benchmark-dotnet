using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PipBenchmark.Gui.Environment;

namespace PipBenchmark.Gui.Environment
{
    public partial class EnvironmentPerspective : UserControl, IEnvironmentView
    {
        public EnvironmentPerspective()
        {
            InitializeComponent();
        }

        #region IEnvironmentView Members

        public List<EnvironmentParameter> SystemInformation
        {
            set 
            {
                systemParametersDataGridView.AutoGenerateColumns = false;
                systemParametersDataGridView.DataSource = value;
            }
        }

        public string CpuPerformance
        {
            set { cpuPerformanceTextBox.Text = value; }
        }

        public string VideoPerformance
        {
            set { videoPerformanceTextBox.Text = value; }
        }

        public string DiskPerformance
        {
            set { diskPerformanceTextBox.Text = value; }
        }

        public event EventHandler UpdateSystemBenchmarkClicked
        {
            add { updateSystemBenchmarkButton.Click += value; }
            remove { updateSystemBenchmarkButton.Click -= value; }
        }

        #endregion
    }
}
