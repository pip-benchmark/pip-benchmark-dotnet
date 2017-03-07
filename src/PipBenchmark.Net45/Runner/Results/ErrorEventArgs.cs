using System;

namespace PipBenchmark.Runner.Results
{
    public class ErrorEventArgs : EventArgs
    {
        private object _error;

        public ErrorEventArgs(object error)
        {
            _error = error;
        }

        public object Error
        {
            get { return _error; }
        }
    }
}
