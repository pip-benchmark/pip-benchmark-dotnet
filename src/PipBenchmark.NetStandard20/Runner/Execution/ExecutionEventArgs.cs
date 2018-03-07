using System;

namespace PipBenchmark.Runner.Execution
{
    public class ExecutionEventArgs : EventArgs
    {
        private ExecutionState _state;

        public ExecutionEventArgs(ExecutionState state)
        {
            _state = state;
        }

        public ExecutionState State
        {
            get { return _state; }
        }
    }
}
