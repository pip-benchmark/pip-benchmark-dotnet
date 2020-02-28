using System;

namespace PipBenchmark.Runner.Results
{
    public class ErrorEventArgs : EventArgs
    {
        public object Error { get; }
        
        public ErrorEventArgs(object error)
        {
            Error = error;
        }
    }
}
