using PipBenchmark.Runner;
using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Results;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PipBenchmark.Runner.Execution
{
    public class ExecutionManager
    {
        protected static readonly object SyncRoot = new object();
        protected ConfigurationManager _configuration;
        private ExecutionStrategy _strategy = null;
        private List<BenchmarkSuiteInstance> _suites;
 
        private readonly List<BenchmarkResult> _results = new List<BenchmarkResult>();

        public ExecutionManager(ConfigurationManager configuration, BenchmarkRunner runner)
        {
            _configuration = configuration;
            Runner = runner;
        }

        public BenchmarkRunner Runner { get; }

        public bool IsRunning
        {
            get { return _strategy != null; }
        }

        public List<BenchmarkResult> Results
        {
            get { return _results; }
        }

        public event EventHandler<ResultEventArgs> ResultUpdated;
        public event EventHandler<MessageEventArgs> MessageSent;
        public event EventHandler<MessageEventArgs> ErrorReported;

        public void Start(BenchmarkSuiteInstance suite)
        {
            Start(new BenchmarkSuiteInstance[] { suite });
        }

        public void Start(IEnumerable<BenchmarkSuiteInstance> suites)
        {
            if (_strategy != null)
                Stop();

            // Identify active tests
            _suites = new List<BenchmarkSuiteInstance>(suites);
            List<BenchmarkInstance> selectedBenchmarks = new List<BenchmarkInstance>();
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                {
                    if (benchmark.Selected)
                        selectedBenchmarks.Add(benchmark);
                }
            }

            // Check if there is at least one test defined
            if (selectedBenchmarks.Count == 0)
                throw new ArgumentException("There are no benchmarks to execute");

            // Create requested test strategy
            if (_configuration.ExecutionType == ExecutionType.Sequential)
                _strategy = new SequencialExecutionStrategy(_configuration, this, selectedBenchmarks);
            else
                _strategy = new ProportionalExecutionStrategy(_configuration, this, selectedBenchmarks);

            // Initialize parameters and start 
            _results.Clear();

            try
            {
                _strategy.Start();
            }
            catch
            {
                Stop();
                throw;
            }
        }

        public void Stop()
        {
            if (_strategy == null)
                return;

            lock (SyncRoot)
            {
                if (_strategy == null)
                    return;

                // Stop strategy
                _strategy?.Stop();

                // Fill results
                _results.Clear();

                if (_strategy == null)
                    return;

                _results.AddRange(_strategy.GetResults());
                _strategy = null;
            }
        }

        internal void NotifyResultsUpdated(ExecutionState state, BenchmarkResult result)
        {
            if (ResultUpdated != null)
            {
                ResultUpdated(this, new ResultEventArgs(state, result));
                Thread.Sleep(0);
            }
        }

        internal void NotifyMessageSent(string message)
        {
            if (MessageSent != null)
            {
                MessageSent(this, new MessageEventArgs(message));
                Thread.Sleep(0);
            }
        }

        internal void NotifyErrorReported(string errorMessage)
        {
            if (ErrorReported != null)
            {
                ErrorReported(this, new MessageEventArgs(errorMessage));
                Thread.Sleep(0);
            }
        }
    }
}
