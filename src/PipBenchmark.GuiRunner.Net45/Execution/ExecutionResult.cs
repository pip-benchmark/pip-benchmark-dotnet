﻿using PipBenchmark.Runner;
using PipBenchmark.Runner.Results;
using System;
using System.Collections.Generic;

namespace PipBenchmark.Gui.Execution
{
    public class ExecutionResult
    {
        private string _benchmarkName;
        private double _performance;
        private double _cpuLoad;
        private double _memoryUsage;

        public ExecutionResult(BenchmarkResult result)
        {
            _benchmarkName = result.Benchmarks.Count != 1 ? "All" : result.Benchmarks[0].FullName;
            _performance = result.PerformanceMeasurement.AverageValue;
            _cpuLoad = result.CpuLoadMeasurement.AverageValue;
            _memoryUsage = result.MemoryUsageMeasurement.AverageValue;
        }

        public string Benchmark
        {
            get { return _benchmarkName; }
        }

        public double Performance
        {
            get { return _performance; }
        }

        public double CpuLoad
        {
            get { return _cpuLoad; }
        }

        public double MemoryUsage
        {
            get { return _memoryUsage; }
        }

        public void Update(BenchmarkResult result)
        {
            _performance = result.PerformanceMeasurement.AverageValue;
            _cpuLoad = result.CpuLoadMeasurement.AverageValue;
            _memoryUsage = result.MemoryUsageMeasurement.AverageValue;
        }
    }
}
