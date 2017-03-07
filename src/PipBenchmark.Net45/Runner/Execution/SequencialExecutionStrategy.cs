using PipBenchmark.Runner;
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
        private Task[] _tasks = null;
        private BenchmarkInstance _runningBenchmark = null;
        private double _ticksPerTransaction = 0;
        private List<BenchmarkResult> _results = new List<BenchmarkResult>();

        public SequencialExecutionStrategy(ExecutionManager process, List<BenchmarkInstance> benchmarks)
            : base(process, benchmarks)
        {
        }

        public override void Start()
        {
            if (Process.Duration <= 0)
                throw new ArgumentException("Duration was not set");

            if (Process.MeasurementType == MeasurementType.Peak)
                _ticksPerTransaction = 0;
            else
                _ticksPerTransaction = 1000.0 / Process.NominalRate * Process.NumberOfThreads;

            _running = true;

            // Start control thread
            var token = _controlTaskCancellation.Token;
            _controlTask = Task.Run(() => ControlBenchmarking(token), token);
            //_controlTask.Wait(token);
            //_controlTask.Name = "Benchmarking Control Thread";
            //_tasks[index].Priority = ThreadPriority.Highest;
            //_controlTask.Start();
        }

        public override bool IsStopped
        {
            get { return !_running; }
        }

        public override void Stop()
        {
            _running = false;

            // Give time for threads to stop on their own
            Thread.Sleep(3000);

            // Stop control thread
            if (_controlTask != null)
            {
                _controlTaskCancellation.Cancel();
                _controlTask = null;
            }

            // Stop benchmarking threads
            StopBenchmarkingThreads();
        }

        public override List<BenchmarkResult> GetResults()
        {
            return _results;
        }

        private void ControlBenchmarking(CancellationToken token)
        {
            try
            {
                NotifyResultUpdate(ExecutionState.Starting);

                foreach (BenchmarkInstance benchmark in Benchmarks)
                {
                    if (token.IsCancellationRequested)
                        break;

                    InitializeMeasurements();
                    CurrentResult.Benchmarks.Add(benchmark);

                    benchmark.Suite.SetUp(new ExecutionContext(this, benchmark.Suite));
                    try
                    {
                        if (!benchmark.IsPassive)
                        {
                            StartBenchmarkingThreads(benchmark);
                        }

                        // Wait for set duration
                        Thread.Sleep(Process.Duration);

                        if (!benchmark.IsPassive)
                        {
                            _controlTaskCancellation.Cancel();
                            StopBenchmarkingThreads();
                        }
                    }
                    finally
                    {
                        benchmark.Suite.TearDown();
                    }

                    _results.Add(CurrentResult);
                }

                _controlTask = null;
                Process.Stop();
            }
            finally
            {
                _controlTaskCancellation.Cancel();

                StopBenchmarkingThreads();

                NotifyResultUpdate(ExecutionState.Completed);
            }
        }

        private void StartBenchmarkingThreads(BenchmarkInstance benchmark)
        {
            lock (SyncRoot)
            {
                _runningBenchmark = benchmark;

                _tasks = new Task[Process.NumberOfThreads];
                for (int index = 0; index < Process.NumberOfThreads; index++)
                {
                    _tasks[index] = Task.Run(() => PerformBenchmarking(_controlTaskCancellation.Token));
                    //_tasks[index].Name = string.Format("Benchmarking Thread #{0}/{1}", index, Process.NumberOfThreads);
                    //_tasks[index].Priority = ThreadPriority.Highest;
                    //_tasks[index].Start();
                }

                //Task.WaitAll(_tasks);
            }
        }

        private void StopBenchmarkingThreads()
        {
            lock (SyncRoot)
            {
                _runningBenchmark = null;
                
                if (_tasks != null)
                {
                    for (int index = 0; index < _tasks.Length; index++)
                    {
                        //_tasks[index].Abort();
                        _tasks[index] = null;
                    }
                    _tasks = null;
                }
            }
        }

        private void PerformBenchmarking(CancellationToken token)
        {
            BenchmarkInstance benchmark = _runningBenchmark;
            int lastExecutedTicks = System.Environment.TickCount;
            int endTicks = System.Environment.TickCount + Process.Duration;

            try
            {
                int currentTicks = System.Environment.TickCount;

                while (_running && benchmark == _runningBenchmark && endTicks > currentTicks)
                {
                    if (Process.MeasurementType == MeasurementType.Nominal)
                    {
                        double ticksToNextTransaction = _ticksPerTransaction
                            - (currentTicks - lastExecutedTicks);

                        // Wait to ensure nominal transaction rate
                        if (ticksToNextTransaction > 0)
                            Thread.Sleep((int)ticksToNextTransaction);
                    }

                    lastExecutedTicks = currentTicks;
                    ExecuteBenchmark(benchmark);
                    currentTicks = System.Environment.TickCount;
                    IncrementCounter(1, lastExecutedTicks);

                    if (token.IsCancellationRequested)
                        break;
                }
            }
            catch (OperationCanceledException)
            {
                // Ignore the exception...
            }
        }
    }
}
