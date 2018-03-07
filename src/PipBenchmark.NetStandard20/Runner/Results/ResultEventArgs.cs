using System;

namespace PipBenchmark.Runner.Results
{
    public class ResultEventArgs : EventArgs
    {
        private BenchmarkResult _result;

        public ResultEventArgs(BenchmarkResult result)
        {
            _result = result;
        }

        public BenchmarkResult Result
        {
            get { return _result; }
        }

    }
}
