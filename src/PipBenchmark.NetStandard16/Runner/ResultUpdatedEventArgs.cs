using System;

namespace PipBenchmark.Runner
{
    public class ResultUpdatedEventArgs : EventArgs
    {
        private ExecutionState _state;
        private BenchmarkResult _result;

        public ResultUpdatedEventArgs(ExecutionState state, BenchmarkResult result)
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
