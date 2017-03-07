using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PipBenchmark.Gui.AsyncWait
{
    public partial class AsyncWaitDialog : Form, IAsyncWaitView
    {
        public AsyncWaitDialog()
        {
            InitializeComponent();
        }

        private event EventHandler _formClosed;

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (_formClosed != null)
            {
                _formClosed(sender, EventArgs.Empty);
            }
        }

        #region IAsyncWaitView Members

        public string Title
        {
            set { this.Text = value; }
        }

        public string StatusMessage
        {
            get { return statusMessageLabel.Text; }
            set { statusMessageLabel.Text = value; }
        }

        public event EventHandler AbortClicked
        {
            add 
            { 
                abortButton.Click += value;
                _formClosed += value;
            }
            remove 
            { 
                abortButton.Click -= value;
                _formClosed -= value;
            }
        }

        public void Show(Form parentForm)
        {
            if (!Visible)
            {
                ShowDialog(parentForm);
            }
        }

        #endregion
    }
}
