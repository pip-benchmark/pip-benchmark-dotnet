using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.IO;

using PipBenchmark.Runner.Execution;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner;

namespace PipBenchmark.Runner.Environment
{
    public class EnvironmentState : BenchmarkProcess
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
            get { return new SystemInformation(); }
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

                //if (video)
                //    _videoBenchmark = ComputeVideoBenchmark();

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
            BenchmarkProperties properties = new BenchmarkProperties();
            properties.Load();

            _cpuBenchmark = properties.GetAsDouble("System.CpuBenchmark", 0);
            _videoBenchmark = properties.GetAsDouble("System.VideoBenchmark", 0);
            _diskBenchmark = properties.GetAsDouble("System.DiskBenchmark", 0);
        }

        private void SaveSystemBenchmarks()
        {
            BenchmarkProperties properties = new BenchmarkProperties();

            properties.SetAsDouble("System.CpuBenchmark", _cpuBenchmark);
            properties.SetAsDouble("System.VideoBenchmark", _videoBenchmark);
            properties.SetAsDouble("System.DiskBenchmark", _diskBenchmark);

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

        //private double ComputeVideoBenchmark()
        //{
        //    var suite = new StandardBenchmarkSuite();
        //    var instance = new BenchmarkSuiteInstance(suite);
        //    instance.UnselectAllBenchmarks();
        //    instance.SelectBenchmark(suite.VideoBenchmark.Name);

        //    base.Start(instance);
        //    Thread.Sleep(WaitTimeout);
        //    base.Stop();

        //    return base.Results[0].PerformanceMeasurement.AverageValue;
        //}

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
