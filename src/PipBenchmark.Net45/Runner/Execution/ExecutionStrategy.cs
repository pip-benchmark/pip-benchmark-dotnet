using PipBenchmark.Runner;
using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Results;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PipBenchmark.Runner.Execution
{
    public abstract class ExecutionStrategy
    {
        private const int MaxErrorCount = 1000;

        private readonly object _syncRoot = new object();
        private ExecutionManager _process;
        private List<BenchmarkInstance> _benchmarks;
        private List<BenchmarkSuiteInstance> _suites;

        private double _transactionCounter = 0;

        private BenchmarkResult _currentResult = null;

        private TransactionMeter _transactionMeter;
        private CpuLoadMeter _cpuLoadMeter;
        private MemoryUsageMeter _memoryUsageMeter;

        protected ExecutionStrategy(ExecutionManager parentProcess, List<BenchmarkInstance> benchmarks)
        {
            _process = parentProcess;
            _benchmarks = benchmarks;
            _suites = GetAllSuitesFromBenchmarks(benchmarks);

            _cpuLoadMeter = new CpuLoadMeter();
            _transactionMeter = new TransactionMeter();
            _memoryUsageMeter = new MemoryUsageMeter();
        }

        private List<BenchmarkSuiteInstance> GetAllSuitesFromBenchmarks(List<BenchmarkInstance> benchmarks)
        {
            List<BenchmarkSuiteInstance> suites = new List<BenchmarkSuiteInstance>();
            foreach (BenchmarkInstance benchmark in benchmarks)
            {
                BenchmarkSuiteInstance suite = benchmark.Suite;
                if (!suites.Contains(suite))
                    suites.Add(suite);
            }
            return suites;
        }

        protected object SyncRoot
        {
            get { return _syncRoot; }
        }

        public ExecutionManager Process
        {
            get { return _process; }
        }

        public List<BenchmarkInstance> Benchmarks
        {
            get { return _benchmarks; }
        }

        public List<BenchmarkSuiteInstance> Suites
        {
            get { return _suites; }
        }

        protected BenchmarkResult CurrentResult
        {
            get { return _currentResult; }
        }

        public abstract void Start();
        public abstract bool IsStopped { get; }
        public abstract void Stop();
        public abstract List<BenchmarkResult> GetResults();

        public void SendMessage(string message)
        {
            _process.NotifyMessageSent(message);
        }

        protected void InitializeMeasurements()
        {
            _currentResult = new BenchmarkResult();
            _currentResult.StartTime = DateTime.Now;

            _transactionCounter = 0;
            _transactionMeter.Reset();
            _cpuLoadMeter.Reset();
            _memoryUsageMeter.Reset();
        }

        public void IncrementCounter(int increment)
        {
            IncrementCounter(increment, System.Environment.TickCount);
        }

        protected void IncrementCounter(int increment, int currentTicks)
        {
            _transactionCounter += increment;

            // If it's less then a second then wait
            int measureInterval = currentTicks - _transactionMeter.LastMeasuredTicks;
            if (measureInterval >= 1000 && _currentResult != null)
            {
                lock (_syncRoot)
                {
                    measureInterval = currentTicks - _transactionMeter.LastMeasuredTicks;
                    if (measureInterval >= 1000)
                    {
                        // Perform measurements
                        _transactionMeter.SetCounter(_transactionCounter);
                        _transactionCounter = 0;
                        _transactionMeter.Measure();
                        _cpuLoadMeter.Measure();
                        _memoryUsageMeter.Measure();

                        // Store measurement results
                        _currentResult.ElapsedTime = DateTime.Now - _currentResult.StartTime;
                        _currentResult.PerformanceMeasurement = _transactionMeter.Measurement;
                        _currentResult.CpuLoadMeasurement = _cpuLoadMeter.Measurement;
                        _currentResult.MemoryUsageMeasurement = _memoryUsageMeter.Measurement;

                        NotifyResultUpdate(ExecutionState.Running);
                    }
                }
            }
        }

        public void ReportError(string errorMessage)
        {
            lock (_syncRoot)
            {
                if (_currentResult.Errors.Count < MaxErrorCount)
                    _currentResult.Errors.Add(errorMessage);
            }

            Process.NotifyErrorReported(errorMessage);
        }

        protected void ExecuteBenchmark(BenchmarkInstance benchmark)
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
                ReportError(ex.Message);

                if (!Process.IsForceContinue)
                    throw ex;
            }
        }

        protected void NotifyResultUpdate(ExecutionState status)
        {
            Process.NotifyResultsUpdated(status, _currentResult);
        }
    }
}
