using System;

namespace PipBenchmark.Runner.Execution
{
    public class ExecutionEventArgs : EventArgs
    {
        public ExecutionState State { get; }
        public ExecutionEventArgs(ExecutionState state)
        {
            State = state;
        }
    }
}
