using PipBenchmark.Runner.Benchmarks;
using System.Collections.Generic;

namespace PipBenchmark.Runner.Execution
{
    internal class ExecutionContext : IExecutionContext
    {
        private ExecutionStrategy _strategy;
        private ResultAggregator _aggregator;
        private BenchmarkSuiteInstance _suite;

        public ExecutionContext(BenchmarkSuiteInstance suite,
            ResultAggregator aggregator, ExecutionStrategy strategy)
        {
            _strategy = strategy;
            _aggregator = aggregator;
            _suite = suite;
        }

        public Dictionary<string, Parameter> Parameters => _suite.Suite.Parameters;

        public void IncrementCounter()
        {
            _aggregator.IncrementCounter(1);
        }

        public void IncrementCounter(int increment)
        {
            _aggregator.IncrementCounter(increment);
        }

        public void SendMessage(string message)
        {
            _aggregator.SendMessage(message);
        }

        public void ReportError(string errorMessage)
        {
            _aggregator.ReportError(errorMessage);
        }

        public bool IsStopped => _strategy.IsStopped;

        public void Stop()
        {
            _strategy.Stop();
        }
    }
}
