using System;

namespace PipBenchmark.Runner
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
