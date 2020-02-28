using PipBenchmark.Runner.Benchmarks;
using System;
using System.Collections.Generic;

namespace PipBenchmark.Runner.Results
{
    public class BenchmarkResult
    {
        public List<BenchmarkInstance> Benchmarks { get; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public TimeSpan ElapsedTime { get; set; } = TimeSpan.Zero;
        public Measurement PerformanceMeasurement { get; set; } = new Measurement(0,0,0,0);
        public Measurement CpuLoadMeasurement { get; set; } = new Measurement(0,0,0,0);
        public List<object> Errors { get; } = new List<object>();
        public Measurement MemoryUsageMeasurement { get; set; } = new Measurement(0,0,0,0);
        public BenchmarkResult(List<BenchmarkInstance> benchmarks)
        {
            Benchmarks = benchmarks;
        }
    }
}
