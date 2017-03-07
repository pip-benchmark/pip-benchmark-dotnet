using PipBenchmark.Gui.Shell;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PipBenchmark.Gui.Errors
{
    public class ErrorHandlingController : AbstractChildController
    {
        public ErrorHandlingController(MainController mainController)
            : base(mainController)
        {
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
#if !CompactFramework
            Application.ThreadException += OnThreadException;
#endif
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }

#if !CompactFramework
        private void OnThreadException(object sender, ThreadExceptionEventArgs args)
        {
            Exception exception = args.Exception;
            if (ShowErrorDialog("Found Error", "Captured unhandled exception",
                exception, true) == DialogResult.Abort)
            {
                Application.Exit();
            }
        }
#endif

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception exception = args.ExceptionObject as Exception;
            if (ShowErrorDialog("Found Error", "Captured unhandled exception",
                exception, true) == DialogResult.Abort)
            {
                Application.Exit();
            }
        }

        private delegate void ShowErrorDialogDelegate(string operation, string message,
            Exception exception);

        public void ShowErrorDialog(string operation, string message, Exception exception)
        {
            if (MainController.View.Handler.InvokeRequired)
            {
                MainController.View.Handler.BeginInvoke(new ShowErrorDialogDelegate(ShowErrorDialog),
                    operation, message, exception);
            }
            else
            {
                ErrorDialog.ShowDialog(MainController.View.Handler, operation, message, exception, false);
            }
        }

        public DialogResult ShowErrorDialog(string operation, string message,
            Exception exception, bool abortQuery)
        {
            DialogResult result = ErrorDialog.ShowDialog(MainController.View.Handler, operation,
                message, exception, abortQuery);
            MainController.SetStatusMessage(string.Format("Error: {0}", message));
            return result;
        }

    }
}
