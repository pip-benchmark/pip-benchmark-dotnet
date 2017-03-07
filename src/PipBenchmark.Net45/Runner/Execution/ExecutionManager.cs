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
        protected ConfigurationManager _configuration;
        protected ResultsManager _results;

        private static readonly object SyncRoot = new object();
        private bool _running;
        private ExecutionStrategy _strategy = null;
 
        public ExecutionManager(ConfigurationManager configuration, ResultsManager results)
        {
            _configuration = configuration;
            _results = results;
        }

        public bool IsRunning
        {
            get { return _running; }
        }

        public void Start(List<BenchmarkInstance> benchmarks)
        {
            if (benchmarks.Count == 0)
                throw new ArgumentException("There are no benchmarks to execute");

            if (_running) Stop();
            _running = true;

            _results.Clear();
            NotifyUpdated(ExecutionState.Running);

            // Create requested test strategy
            if (_configuration.ExecutionType == ExecutionType.Sequential)
                _strategy = new SequencialExecutionStrategy(_configuration, _results, this, benchmarks);
            else
                _strategy = new ProportionalExecutionStrategy(_configuration, _results, this, benchmarks);

            _strategy.Start();
        }

        public void Stop()
        {
            if (_running)
            {
                lock (SyncRoot)
                {
                    if (_running)
                    {
                        _running = false;

                        // Null strategy to avoid double entry
                        if (_strategy != null)
                        {
                            _strategy.Stop();
                            _strategy = null;
                        }

                        NotifyUpdated(ExecutionState.Completed);
                    }
                }
            }
        }

        public void Run(List<BenchmarkInstance> benchmarks)
        {
            Start(benchmarks);
            try
            {
                while (IsRunning)
                {
                    Thread.Sleep(500);
                }
            }
            catch (ThreadInterruptedException)
            {
                // Ignore...
            }
            finally
            {
                Stop();
            }
        }

        public event EventHandler<ExecutionEventArgs> Updated;

        public void NotifyUpdated(ExecutionState state)
        {
            if (Updated != null)
            {
                Updated(this, new ExecutionEventArgs(state));
                Thread.Sleep(0);
            }
        }

    }
}
