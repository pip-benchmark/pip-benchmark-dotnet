using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PipBenchmark.Gui.Parameters;

namespace PipBenchmark.Gui.Parameters
{
    public partial class ParametersPerspective : UserControl, IParametersView
    {
        public ParametersPerspective()
        {
            InitializeComponent();
        }

        #region IConfigurationView Members

        public List<Parameter> Data
        {
            set 
            {
                paramsDataGridView.AutoGenerateColumns = false;
                paramsBindingSource.DataSource = value;
                paramsBindingSource.ResetBindings(false);
            }
        }

        public event EventHandler LoadClicked
        {
            add { loadButton.Click += value; }
            remove { loadButton.Click -= value; }
        }

        public event EventHandler SaveClicked
        {
            add { saveButton.Click += value; }
            remove { saveButton.Click -= value; }
        }

        public event EventHandler SetToDefaultClicked
        {
            add { setToDefaultButton.Click += value; }
            remove { setToDefaultButton.Click -= value; }
        }

        public void RefreshData()
        {
            paramsBindingSource.ResetBindings(false);
        }

        #endregion
    }
}
