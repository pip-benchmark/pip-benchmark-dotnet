﻿using PipBenchmark.Runner;
using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Results;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PipBenchmark.Runner.Execution
{
    public class ProportionalExecutionStrategy : ExecutionStrategy
    {
        private bool _running = false;
        private readonly CancellationTokenSource _controlTaskCancellation = new CancellationTokenSource();
        private Task[] _tasks = null;
        private double _ticksPerTransaction = 0;

        public ProportionalExecutionStrategy(ConfigurationManager configuration, 
            ExecutionManager parentProcess, List<BenchmarkInstance> benchmarks)
            : base(configuration, parentProcess, benchmarks)
        {
            CalculateExecutionTriggers();
        }

        private void CalculateExecutionTriggers()
        {
            double proportionSum = 0;
            double startExecutionTrigger = 0;

            foreach (BenchmarkInstance benchmark in Benchmarks)
            {
                if (!benchmark.Passive)
                {
                    double normalizedProportion = ((double)benchmark.Proportion) / proportionSum;
                    benchmark.StartRange = startExecutionTrigger;
                    benchmark.EndRange = startExecutionTrigger + normalizedProportion;
                    startExecutionTrigger += normalizedProportion;
                }
                else
                {
                    benchmark.StartRange = 0;
                    benchmark.EndRange = 0;
                }
            }
        }

        public override void Start()
        {
            InitializeMeasurements();

            foreach (BenchmarkInstance benchmark in Benchmarks)
                CurrentResult.Benchmarks.Add(benchmark);

            if (_configuration.MeasurementType == MeasurementType.Peak)
                _ticksPerTransaction = 0;
            else
                _ticksPerTransaction = 1000.0 / _configuration.NominalRate * _configuration.NumberOfThreads;

            // Initialize test suites
            foreach (BenchmarkSuiteInstance suite in Suites)
                suite.SetUp(new ExecutionContext(this, suite));

            _running = true;

            // Start benchmarking threads
            _tasks = new Task[_configuration.NumberOfThreads];
            var token = _controlTaskCancellation.Token;
            for (int index = 0; index < _configuration.NumberOfThreads; index++)
            {
                _tasks[index] = Task.Run(() => PerformBenchmarking(token), token);
                //_tasks[index].Name = string.Format("Benchmarking Thread #{0}/{1}", index, Process.NumberOfThreads);
                //_tasks[index].Priority = ThreadPriority.Highest;
                //_tasks[index].Start();
                //Task.WaitAll(_tasks);
            }
        }

        public override bool IsStopped
        {
            get { return _running; }
        }

        public override void Stop()
        {
            _running = false;

            // Give time for threads to stop on their own
            Thread.Sleep(3000);

            _controlTaskCancellation.Cancel();

            // Stop benchmarking threads
            if (_tasks != null)
            {
                for (int index = 0; index < _tasks.Length; index++)
                {
                    //_tasks[index].Abort();
                    _tasks[index] = null;
                }
                _tasks = null;
            }

            // Deinitialize test suites
            foreach (BenchmarkSuiteInstance suite in Suites)
                suite.TearDown();
        }

        public override List<BenchmarkResult> GetResults()
        {
            List<BenchmarkResult> results = new List<BenchmarkResult>();

            if (CurrentResult != null)
                results.Add(CurrentResult);

            return results;
        }

        private void PerformBenchmarking(CancellationToken token)
        {
            System.Random randomGenerator = new System.Random();
            int lastExecutedTicks = System.Environment.TickCount;
            int numberOfTests = Benchmarks.Count;
            BenchmarkInstance firstBenchmark = Benchmarks.Count == 1 ? Benchmarks[0] : null;

            NotifyResultUpdate(ExecutionState.Starting);

            try
            {
                while (_running)
                {
                    if (_configuration.MeasurementType == MeasurementType.Nominal)
                    {
                        double ticksToNextTransaction = _ticksPerTransaction
                            - (System.Environment.TickCount - lastExecutedTicks);

                        // Wait to ensure nominal transaction rate
                        if (ticksToNextTransaction > 0)
                            Thread.Sleep((int)ticksToNextTransaction);
                    }

                    if (numberOfTests == 1)
                    {
                        ExecuteBenchmark(firstBenchmark);
                        lastExecutedTicks = System.Environment.TickCount;
                        IncrementCounter(1, lastExecutedTicks);
                    }
                    else if (numberOfTests == 0)
                    {
                        Thread.Sleep(500);
                    }
                    else
                    {
                        double selector = randomGenerator.NextDouble();
                        for (int index = 0; index < Benchmarks.Count; index++)
                        {
                            var benchmark = Benchmarks[index];
                            if (benchmark.WithinRange(selector))
                            {
                                lastExecutedTicks = System.Environment.TickCount;
                                ExecuteBenchmark(benchmark);
                                IncrementCounter(1, lastExecutedTicks);
                                break;
                            }
                        }
                    }

                    if (token.IsCancellationRequested)
                        break;
                }
            }
            catch (OperationCanceledException)
            {
                // Ignore the exception...
            }
            finally
            {
                NotifyResultUpdate(ExecutionState.Completed);
            }
        }
    }
}
