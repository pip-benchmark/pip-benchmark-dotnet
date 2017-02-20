using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PipBenchmark.Runner.Gui.Errors
{
    public partial class ErrorDialog : Form
    {
        public ErrorDialog()
        {
            InitializeComponent();
        }

        public void ToggleDetails(bool detailMode)
        {
            if (detailMode)
            {
                detailsButton.Text = "Details <<";
                stackTraceTextBox.Visible = true;
                this.Height = 540;
            }
            else
            {
                detailsButton.Text = "Details >>";
                stackTraceTextBox.Visible = false;
                this.Height = 200;
            }
        }

        private void OnDetailsClick(object sender, EventArgs e)
        {
            ToggleDetails(!stackTraceTextBox.Visible);
        }

        private void OnOkClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void OnAbortClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
        public static DialogResult ShowDialog(IWin32Window owner, string message, Exception exception)
        {
            return ShowDialog(owner, "Error", message, exception, false);
        }

        public static DialogResult ShowDialog(IWin32Window owner, string title, string message,
            Exception exception)
        {
            return ShowDialog(owner, title, message, exception, false);
        }

        public static DialogResult ShowDialog(IWin32Window owner, string title, string message,
            Exception exception, bool abortQuery)
        {
            ErrorDialog errorDialog = new ErrorDialog();
            errorDialog.ToggleDetails(false);
            
            errorDialog.Text = string.IsNullOrEmpty(title) ? "Error" : title;
            errorDialog.messageLabel.Text = message;
            errorDialog.detailsLabel.Text = exception != null ? exception.Message : "No details...";
            errorDialog.stackTraceTextBox.Text = exception != null ? exception.StackTrace : "";

            errorDialog.okButton.Visible = abortQuery == false;
            errorDialog.continueButton.Visible = abortQuery == true;
            errorDialog.abortButton.Visible = abortQuery == true;

            errorDialog.ShowDialog(owner);

            return errorDialog.DialogResult;
        }

    }
}
