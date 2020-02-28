using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PipBenchmark.Utilities.Random;

namespace PipBenchmark.Runner.Execution
{
    public class ProportionalExecutionStrategy : ExecutionStrategy
    {
        private bool _running = false;
        private ResultAggregator _aggregator;
        private double _ticksPerTransaction = 0;
        private readonly CancellationTokenSource _controlTaskCancellation = new CancellationTokenSource();
        private Task[] _tasks;

        public ProportionalExecutionStrategy(ConfigurationManager configuration,
            ResultsManager results, ExecutionManager execution,
            List<BenchmarkInstance> benchmarks)
            : base(configuration, results, execution, benchmarks)
        {
            _aggregator = new ResultAggregator(results, benchmarks);
        }

        public override bool IsStopped => !_running;

        public override void Start()
        {
            if (_running) return;

            _running = true;
            _aggregator.Start();

            CalculateProportionalRanges();
 
            if (_configuration.MeasurementType == MeasurementType.Peak)
                _ticksPerTransaction = 0;
            else
                _ticksPerTransaction = 1000.0 / _configuration.NominalRate * _configuration.NumberOfThreads;

            // Initialize and start
            foreach (BenchmarkSuiteInstance suite in _suites)
                suite.SetUp(new ExecutionContext(suite, _aggregator, this));

            // Start benchmarking threads
            var token = _controlTaskCancellation.Token;
            _tasks = new Task[_configuration.NumberOfThreads];
            for (int index = 0; index < _configuration.NumberOfThreads; index++)
            {
                _tasks[index] = Task.Run(() => Execute(token), token);
            }

            Task.Run(() => Control(token), token);
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
                        _aggregator.Stop();

                        // Give time for threads to stop on their own
                        Thread.Sleep(100);

                        _execution?.Stop();

                        _controlTaskCancellation.Cancel();

                        // Stop benchmarking threads
                        if (_tasks != null)
                        {
                            for (int index = 0; index < _tasks.Length; index++)
                            {
                                _tasks[index] = null;
                            }
                            _tasks = null;
                        }

                        foreach (BenchmarkSuiteInstance suite in _suites)
                            suite.TearDown();
                    }
                }
            }
        }

        private void CalculateProportionalRanges()
        {
            double proportionSum = 0;
            foreach (BenchmarkInstance benchmark in _activeBenchmarks)
            {
                proportionSum += benchmark.Proportion;
            }

            double startRange = 0;
            foreach (BenchmarkInstance benchmark in _activeBenchmarks)
            {
                double normalizedProportion = ((double)benchmark.Proportion) / proportionSum;
                benchmark.StartRange = startRange;
                benchmark.EndRange = startRange + normalizedProportion;
                startRange += normalizedProportion;
            }
        }

        private BenchmarkInstance ChooseBenchmarkProportionally()
        {
            double selector = RandomDouble.NextDouble(1.0);
            return _activeBenchmarks.FirstOrDefault(benchmark => benchmark.WithinRange(selector));
        }

        private void Control(CancellationToken token)
        {
            try
            {
                Task.Delay(_configuration.Duration * 1000, token).Wait(token);
            }
            catch (OperationCanceledException)
            {
                // Ignore...
            }
            finally
            {
                Stop();
            }
        }

        private void ExecuteBenchmark(BenchmarkInstance benchmark)
        {
            try
            {
                benchmark.Execute();
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _results.NotifyError(ex);

                if (!_configuration.ForceContinue)
                    throw;
            }
        }

        private void Execute(CancellationToken token)
        {
            int lastExecutedTicks = System.Environment.TickCount;
            int benchmarkCount = _activeBenchmarks.Count;
            BenchmarkInstance onlyBenchmark = benchmarkCount == 1
                ? _activeBenchmarks[0]
                : null;

            try
            {
                while (_running && !token.IsCancellationRequested)
                {
                    if (_configuration.MeasurementType == MeasurementType.Nominal)
                    {
                        double ticksToNextTransaction = _ticksPerTransaction
                            - (System.Environment.TickCount - lastExecutedTicks);

                        // Wait to ensure nominal transaction rate
                        if (ticksToNextTransaction > 0)
                            Thread.Sleep((int)ticksToNextTransaction);
                    }

                    var benchmark = onlyBenchmark ?? ChooseBenchmarkProportionally();

                    if (benchmark != null)
                    {
                        ExecuteBenchmark(benchmark);
                        lastExecutedTicks = System.Environment.TickCount;
                        _aggregator.IncrementCounter(1, lastExecutedTicks);
                    }
                    else
                    {
                        Thread.Sleep(500);
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Ignore the exception...
            }
        }
    }
}
