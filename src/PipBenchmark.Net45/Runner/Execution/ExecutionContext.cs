using PipBenchmark.Runner.Benchmarks;
using System.Collections.Generic;

namespace PipBenchmark.Runner.Execution
{
    internal class ExecutionContext : IExecutionContext
    {
        private ExecutionStrategy _strategy;
        private BenchmarkSuiteInstance _suite;

        public ExecutionContext(ExecutionStrategy strategy, BenchmarkSuiteInstance suite)
        {
            _strategy = strategy;
            _suite = suite;
        }

        public Dictionary<string, Parameter> Parameters
        {
            get { return _suite.Suite.Parameters; }
        }

        public void IncrementCounter()
        {
            _strategy.IncrementCounter(1);
        }

        public void IncrementCounter(int increment)
        {
            _strategy.IncrementCounter(increment);
        }

        public void SendMessage(string message)
        {
            _strategy.SendMessage(message);
        }

        public void ReportError(string errorMessage)
        {
            _strategy.ReportError(errorMessage);
        }

        public bool IsStopped
        {
            get { return _strategy.IsStopped; }
        }

        public void Stop()
        {
            _strategy.Process.Stop();
        }
    }
}
