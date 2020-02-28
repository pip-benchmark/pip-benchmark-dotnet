using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Results;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PipBenchmark.Runner.Execution
{
    public class SequencialExecutionStrategy : ExecutionStrategy
    {
        private bool _running = false;
        private readonly CancellationTokenSource _controlTaskCancellation = new CancellationTokenSource();
        private Task _controlTask = null;

        public SequencialExecutionStrategy(ConfigurationManager configuration,
            ResultsManager results, ExecutionManager execution,
            List<BenchmarkInstance> benchmarks)
            : base(configuration, results, execution, benchmarks)
        { }

        public override bool IsStopped => !_running;

        public override void Start()
        {
            if (_configuration.Duration <= 0)
                throw new ArgumentException("Duration was not set");

            if (_running) return;
            _running = true;

            // Start control thread
            var token = _controlTaskCancellation.Token;
            _controlTask = Task.Run(() => Execute(token), token);
        }

        public override void Stop()
        {
            if (_running)
            {
                lock (_syncRoot)
                {
                    if (_running)
                    {
                        _running = false;

                        // Stop control thread
                        if (_controlTask != null)
                        {
                            _controlTaskCancellation.Cancel();
                            _controlTask = null;
                        }

                        _execution?.Stop();
                    }
                }
            }
        }

        private void Execute(CancellationToken token)
        {
            ProportionalExecutionStrategy current = null;

            try
            {
                foreach (var benchmark in _benchmarks)
                {
                    // Skip if benchmarking was interrupted
                    if (!_running || token.IsCancellationRequested)
                        break;

                    // Start embedded strategy
                    var benchmarks = new List<BenchmarkInstance> {benchmark};
                    current = new ProportionalExecutionStrategy(_configuration, _results, null, benchmarks);

                    current.Start();

                    Task.Delay(_configuration.Duration * 1000, token).Wait(token);

                    // Stop embedded strategy
                    current.Stop();
                }
            }
            catch (OperationCanceledException)
            {
                // Ignore...
            }
            finally
            {
                current?.Stop();

                _controlTask = null;

                Stop();
            }
        }
    }
}
