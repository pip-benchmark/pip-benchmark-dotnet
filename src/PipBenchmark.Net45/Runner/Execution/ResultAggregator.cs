using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Results;
using System;
using System.Collections.Generic;

namespace PipBenchmark.Runner.Execution
{
    public class ResultAggregator
    {
        private const int MaxErrorCount = 1000;

        private readonly object _syncRoot = new object();
        private ResultsManager _results;
        private List<BenchmarkInstance> _benchmarks;
        private double _transactionCounter = 0;
        private BenchmarkResult _result = null;
        private TransactionMeter _transactionMeter;
        private CpuLoadMeter _cpuLoadMeter;
        private MemoryUsageMeter _memoryUsageMeter;

        public ResultAggregator(ResultsManager results, List<BenchmarkInstance> benchmarks)
        {
            _results = results;
            _benchmarks = benchmarks;

            _cpuLoadMeter = new CpuLoadMeter();
            _transactionMeter = new TransactionMeter();
            _memoryUsageMeter = new MemoryUsageMeter();

            Start();
        }

        public BenchmarkResult Result
        {
            get { return _result; }
        }

        public void Start()
        {
            _result = new BenchmarkResult(_benchmarks);
            _result.StartTime = DateTime.Now;

            _transactionCounter = 0;
            _transactionMeter.Clear();
            _cpuLoadMeter.Clear();
            _memoryUsageMeter.Clear();
        }

        public void IncrementCounter(int increment)
        {
            IncrementCounter(increment, System.Environment.TickCount);
        }

        public void IncrementCounter(int increment, int currentTicks)
        {
            _transactionCounter += increment;

            // If it's less then a second then wait
            int measureInterval = currentTicks - _transactionMeter.LastMeasuredTicks;
            if (measureInterval >= 1000 && _result != null)
            {
                lock (_syncRoot)
                {
                    measureInterval = currentTicks - _transactionMeter.LastMeasuredTicks;
                    if (measureInterval >= 1000)
                    {
                        // Perform measurements
                        _transactionMeter.SetTransactionCounter(_transactionCounter);
                        _transactionCounter = 0;
                        _transactionMeter.Measure();
                        _cpuLoadMeter.Measure();
                        _memoryUsageMeter.Measure();

                        // Store measurement results
                        _result.ElapsedTime = DateTime.Now - _result.StartTime;
                        _result.PerformanceMeasurement = _transactionMeter.Measurement;
                        _result.CpuLoadMeasurement = _cpuLoadMeter.Measurement;
                        _result.MemoryUsageMeasurement = _memoryUsageMeter.Measurement;

                        _results.NotifyUpdated(_result);
                    }
                }
            }
        }

        public void SendMessage(string message)
        {
            _results.NotifyMessage(message);
        }

        public void ReportError(object error)
        {
            lock (_syncRoot)
            {
                if (_result.Errors.Count < MaxErrorCount)
                    _result.Errors.Add(error);
            }

            _results.NotifyError(error);
        }

        public void Stop()
        {
            _results.Add(_result);
        }
    }
}
