using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

using PipBenchmark.Runner.Gui.Shell;

namespace PipBenchmark.Runner.Gui.AsyncWait
{
    public class AsyncWaitController : AbstractChildController, IAsyncWaitContext
    {
        private IAsyncWaitView _view;
        private AsyncWaitCallback _callback;
        private bool _processing = false;
        private bool _aborted = false;
        private bool _successfullyCompleted = false;
        private object _executionState;
        private Thread _executionThread = null;
        private Exception _executionException = null;
        private object _executionResult = null;

        public AsyncWaitController(MainController mainController)
            : base(mainController)
        {
        }

        public bool Processing
        {
            get { return _processing; }
        }

        public bool SuccessfullyCompleted
        {
            get { return _successfullyCompleted; }
        }

        public Exception ExecutionException
        {
            get { return _executionException; }
        }

        public object ExecutionResult
        {
            get { return _executionResult; }
        }

        public void ExecuteAndWait(string operation, string message,
            AsyncWaitCallback callback, object state)
        {
            if (!_processing)
            {
                _aborted = false;
                _processing = true;
                _executionState = state;
                _executionException = null;
                _executionResult = null;
                _callback = callback;

                _view = new AsyncWaitDialog();
                _view.AbortClicked += OnAbortClicked;
                _view.Title = operation;
                _view.StatusMessage = message;

                // Start the thread
                _executionThread = new Thread(OnExecuteCallback);
                _executionThread.Name = "AsyncWaitExecute";
                _executionThread.Start();

                // Delay to show view
                for (int index = 0; index < 5 && _processing; index++)
                {
                    Thread.Sleep(100);
                }

                if (_processing)
                {
                    _view.Show(MainController.View.Handler);
                }
            }
        }

        private void OnAbortClicked(object sender, EventArgs args)
        {
            _aborted = true;
            ThreadPool.QueueUserWorkItem(OnThreadKillCallback, _executionThread);
        }

        private void OnExecuteCallback()
        {
            try
            {
                _callback(this);
                _successfullyCompleted = true;
            }
            catch (ThreadAbortException)
            {
                // Ignore result of thread abortion
            }
            catch (Exception ex)
            {
                _executionException = ex;
            }
            finally
            {
                _executionThread = null;
                _processing = false;
                CloseView();
            }
        }

        private void OnThreadKillCallback(object state)
        {
            if (_processing && _executionThread != null)
            {
                _executionThread.Abort();
                _executionThread = null;
                _processing = false;
                CloseView();
            }
        }

        private void CloseView()
        {
            if (_view != null)
            {
                Control viewControl = _view as Control;
                if (viewControl.InvokeRequired)
                {
                    viewControl.BeginInvoke(new ThreadStart(CloseView));
                }
                else
                {
                    _view.Close();
                    _view = null;
                }
            }
        }

        private delegate void ParameterizedThreadStart(object message);

        private void UpdateStatusMessage(object message)
        {
            Control viewControl = _view as Control;
            if (viewControl.InvokeRequired)
            {
                viewControl.BeginInvoke(new ParameterizedThreadStart(UpdateStatusMessage),
                    message);
            }
            else
            {
                _view.StatusMessage = message != null ? message.ToString() : null;
            }
        }

        #region IAsyncWaitContext Members

        public object State
        {
            get { return _executionState; }
        }

        public object[] StateArray
        {
            get { return _executionState as object[]; }
        }

        public bool Aborted
        {
            get { return _aborted; }
        }

        public string StatusMessage
        {
            get { return _view != null ? _view.StatusMessage : string.Empty; }
            set { UpdateStatusMessage(value); }
        }

        public object Result
        {
            get { return _executionResult; }
            set { _executionResult = value; }
        }

        public void UpdateUI(WaitCallback callback, object state)
        {
            if (MainController.View.Handler.InvokeRequired)
            {
                MainController.View.Handler.BeginInvoke(new WaitCallback(callback), state);
            }
            else
            {
                callback(state);
            }
        }

        #endregion
    }
}
