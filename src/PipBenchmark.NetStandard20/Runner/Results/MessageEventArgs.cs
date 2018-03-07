using System;

namespace PipBenchmark.Runner.Results
{
    public class MessageEventArgs : EventArgs
    {
        private string _message;

        public MessageEventArgs(string message)
        {
            _message = message;
        }

        public string Message
        {
            get { return _message; }
        }
    }
}
