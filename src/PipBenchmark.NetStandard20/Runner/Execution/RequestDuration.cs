﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PipBenchmark.Runner.Execution
{
    public class RequestDuration
    {
        private class BenchmarkMetric
        {
            public readonly string BenchmarkName;
            public TimeSpan Duration;
            public readonly bool IsError;

            public BenchmarkMetric(string name, TimeSpan duration, bool isError)
            {
                BenchmarkName = name;
                Duration = duration;
                IsError = isError;
            }
        }

        public class BenchmarkGroup
        {
            public string BenchmarkName;
            public double Duration;
            public int Count;
            public int Errors;
        }

        private readonly List<BenchmarkMetric> _benchmarkMetrics = new List<BenchmarkMetric> { };

        public Stopwatch Start()
        {
            var timer = new Stopwatch();
            timer.Start();

            return timer;
        }

        public void Stop(string benchmarkName, Stopwatch timer, bool isError = false)
        {
            timer.Stop();
            _benchmarkMetrics.Add(new BenchmarkMetric(benchmarkName, timer.Elapsed, isError));
        }

        public List<BenchmarkGroup> GetAverageReport()
        {
            var report = _benchmarkMetrics
                .GroupBy(m => m.BenchmarkName)
                .Select(g => new BenchmarkGroup
                {
                    BenchmarkName = g.Key,
                    Duration = g.Average(m => m.Duration.TotalMilliseconds),
                    Count = g.Count(),
                    Errors = g.Count(m => m.IsError)
                });

            return report.ToList();
        }
    }
}
