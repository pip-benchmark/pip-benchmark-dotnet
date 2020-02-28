using System;

namespace PipBenchmark.Runner.Results
{
    public class MessageEventArgs : EventArgs
    {
        public string Message { get; }
        public MessageEventArgs(string message)
        {
            Message = message;
        }
    }
}
