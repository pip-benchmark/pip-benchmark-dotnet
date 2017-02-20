using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PipBenchmark.Runner.Gui.Config;

namespace PipBenchmark.Runner.Gui.Config
{
    public partial class ConfigurationPerspective : UserControl, IConfigurationView
    {
        public ConfigurationPerspective()
        {
            InitializeComponent();
        }

        #region IConfigurationView Members

        public List<Parameter> Configuration
        {
            set 
            {
                configParamsDataGridView.AutoGenerateColumns = false;
                configParamsBindingSource.DataSource = value;
                configParamsBindingSource.ResetBindings(false);
            }
        }

        public event EventHandler LoadConfigurationClicked
        {
            add { loadConfigurationButton.Click += value; }
            remove { loadConfigurationButton.Click -= value; }
        }

        public event EventHandler SaveConfigurationClicked
        {
            add { saveConfigurationButton.Click += value; }
            remove { saveConfigurationButton.Click -= value; }
        }

        public event EventHandler SetToDefaultClicked
        {
            add { setToDefaultParamsButton.Click += value; }
            remove { setToDefaultParamsButton.Click -= value; }
        }

        public void RefreshData()
        {
            configParamsBindingSource.ResetBindings(false);
        }

        #endregion
    }
}
