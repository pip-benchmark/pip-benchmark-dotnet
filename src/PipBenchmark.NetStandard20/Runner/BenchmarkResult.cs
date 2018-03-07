using System;
using System.Collections.Generic;

namespace PipBenchmark.Runner
{
    public class BenchmarkResult
    {
        private List<BenchmarkInstance> _benchmarks = new List<BenchmarkInstance>();
        private DateTime _startTime = DateTime.Now;
        private TimeSpan _elapsedTime;
        private Measurement _performanceMeasurement;
        private Measurement _cpuLoadMeasurement;
        private Measurement _memoryUsageMeasurement;
        private List<string> _errors = new List<string>();

        public BenchmarkResult()
        {
        }

        public List<BenchmarkInstance> Benchmarks
        {
            get { return _benchmarks; }
        }

        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            set { _elapsedTime = value; }
        }

        public Measurement PerformanceMeasurement
        {
            get { return _performanceMeasurement; }
            set { _performanceMeasurement = value; }
        }

        public Measurement CpuLoadMeasurement
        {
            get { return _cpuLoadMeasurement; }
            set { _cpuLoadMeasurement = value; }
        }

        public Measurement MemoryUsageMeasurement
        {
            get { return _memoryUsageMeasurement; }
            set { _memoryUsageMeasurement = value; }
        }

        public List<string> Errors
        {
            get { return _errors; }
        }
    }
}
