using System;

namespace PipBenchmark.Runner.Results
{
    public class ResultEventArgs : EventArgs
    {
        public BenchmarkResult Result { get; }
        public ResultEventArgs(BenchmarkResult result)
        {
            Result = result;
        }
    }
}
