using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.IO;

using PipBenchmark.Runner.Execution;
using PipBenchmark.Runner.Parameters;
using PipBenchmark.Runner;
using PipBenchmark.Runner.Benchmarks;

namespace PipBenchmark.Runner.Environment
{
    public class EnvironmentState : ExecutionManager
    {
        private const int WaitTimeout = 5000;

        private double _cpuBenchmark;
        private double _videoBenchmark;
        private double _diskBenchmark;

        public EnvironmentState(BenchmarkRunner runner)
            : base(runner)
        {
            LoadSystemBenchmarks();
        }

        public IDictionary<string, string> SystemInformation
        {
            get { return new SystemInfo(); }
        }

        public double CpuBenchmark
        {
            get { return _cpuBenchmark; }
        }

        public double VideoBenchmark
        {
            get { return _videoBenchmark; }
        }

        public double DiskBenchmark
        {
            get { return _diskBenchmark; }
        }

        public void BenchmarkEnvironment(bool cpu, bool disk, bool video)
        {
            try
            {
                if (cpu)
                    _cpuBenchmark = ComputeCpuBenchmark();

                if (video)
                    _videoBenchmark = ComputeVideoBenchmark();

                if (disk)
                    _diskBenchmark = ComputeDiskBenchmark();

                try
                {
                    SaveSystemBenchmarks();
                }
                catch
                {
                    // Ignore disk errors
                }
            }
            catch
            {
                Stop();
            }
        }

        private void LoadSystemBenchmarks()
        {
            EnvironmentProperties properties = new EnvironmentProperties();
            properties.Load();

            _cpuBenchmark = properties.GetAsDouble("CpuMeasurement", 0);
            _videoBenchmark = properties.GetAsDouble("VideoMeasurement", 0);
            _diskBenchmark = properties.GetAsDouble("DiskMeasurement", 0);
        }

        private void SaveSystemBenchmarks()
        {
            EnvironmentProperties properties = new EnvironmentProperties();

            properties.SetAsDouble("CpuMeasurement", _cpuBenchmark);
            properties.SetAsDouble("VideoMeasurement", _videoBenchmark);
            properties.SetAsDouble("DiskMeasurement", _diskBenchmark);
        
            properties.Save();
        }

        private double ComputeCpuBenchmark()
        {
            var suite = new StandardBenchmarkSuite();
            var instance = new BenchmarkSuiteInstance(suite);
            instance.UnselectAllBenchmarks();
            instance.SelectBenchmark(suite.CpuBenchmark.Name);

            base.Start(instance);
            Thread.Sleep(WaitTimeout);
            base.Stop();

            return base.Results[0].PerformanceMeasurement.AverageValue;
        }

        private double ComputeVideoBenchmark()
        {
            var suite = new StandardBenchmarkSuite();
            var instance = new BenchmarkSuiteInstance(suite);
            instance.UnselectAllBenchmarks();
            instance.SelectBenchmark(suite.VideoBenchmark.Name);

            base.Start(instance);
            Thread.Sleep(WaitTimeout);
            base.Stop();

            return base.Results[0].PerformanceMeasurement.AverageValue;
        }

        private double ComputeDiskBenchmark()
        {
            var suite = new StandardBenchmarkSuite();
            var instance = new BenchmarkSuiteInstance(suite);
            instance.UnselectAllBenchmarks();
            instance.SelectBenchmark(suite.DiskBenchmark.Name);

            base.Start(instance);
            Thread.Sleep(WaitTimeout);
            base.Stop();

            return base.Results[0].PerformanceMeasurement.AverageValue;
        }

    }
}
