using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using PipBenchmark.Gui.Results;

namespace PipBenchmark.Gui.Results
{
    public partial class ResultsPerspective : UserControl, IResultsView
    {
        public ResultsPerspective()
        {
            InitializeComponent();
        }

        #region IResultsView Members

        public string ReportContent
        {
            get { return reportContentTextBox.Text; }
            set { reportContentTextBox.Text = value; }
        }

        public string SelectedReportContent 
        {
            get { return reportContentTextBox.SelectedText; }
        }

        public event EventHandler SaveReportClicked
        {
            add { saveReportButton.Click += value; }
            remove { saveReportButton.Click -= value; }
        }

        public event EventHandler PrintReportClicked
        {
            add { printReportButton.Click += value; }
            remove { printReportButton.Click -= value; }
        }

        #endregion
    }
}
