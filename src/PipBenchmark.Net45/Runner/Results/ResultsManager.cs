using System;
using System.Collections.Generic;
using System.Threading;

namespace PipBenchmark.Runner.Results
{
    public class ResultsManager
    {
        private List<BenchmarkResult> _results = new List<BenchmarkResult>();

        public ResultsManager() { }

        public List<BenchmarkResult> All
        {
            get { return _results; }
        }

        public void Add(BenchmarkResult result)
        {
            _results.Add(result);
        }

        public void Clear()
        {
            _results.Clear();
        }

        public event EventHandler<ResultEventArgs> Updated;

        public void NotifyUpdated(BenchmarkResult result)
        {
            if (Updated != null)
            {
                Updated(this, new ResultEventArgs(result));
                Thread.Sleep(0);
            }
        }

        public event EventHandler<MessageEventArgs> Message;

        public void NotifyMessage(string message)
        {
            if (Message != null)
            {
                Message(this, new MessageEventArgs(message));
                Thread.Sleep(0);
            }
        }

        public event EventHandler<ErrorEventArgs> Error;

        public void NotifyError(object error)
        {
            if (Error != null)
            {
                Error(this, new ErrorEventArgs(error));
                Thread.Sleep(0);
            }
        }

    }
}
