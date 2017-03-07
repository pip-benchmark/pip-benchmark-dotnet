using PipBenchmark.Runner.Execution;
using System;

namespace PipBenchmark.Runner.Results
{
    public class ResultEventArgs : EventArgs
    {
        private ExecutionState _state;
        private BenchmarkResult _result;

        public ResultEventArgs(ExecutionState state, BenchmarkResult result)
        {
            _state = state;
            _result = result;
        }

        public ExecutionState State
        {
            get { return _state; }
        }

        public BenchmarkResult Result
        {
            get { return _result; }
        }

    }
}
