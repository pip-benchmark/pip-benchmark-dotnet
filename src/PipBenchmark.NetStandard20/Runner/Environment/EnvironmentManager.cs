using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Execution;
using PipBenchmark.Runner.Results;
using PipBenchmark.Utilities.Config;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PipBenchmark.Runner.Environment
{
    public class EnvironmentManager : ExecutionManager
    {
        private const int Duration = 5;

        private double _cpuBenchmark;
        private double _videoBenchmark;
        private double _diskBenchmark;

        public EnvironmentManager()
            : base(new ConfigurationManager(), new ResultsManager())
        {
            _configuration.Duration = Duration;

            try
            {
                Load();
            }
            catch (Exception)
            {
                // Ignore. It shall never happen here...
            }
        }

        public ConfigParams SystemInfo
        {
            get { return new SystemInfo(); }
        }

        public double CpuMeasurement
        {
            get { return _cpuBenchmark; }
        }

        public double VideoMeasurement
        {
            get { return _videoBenchmark; }
        }

        public double DiskMeasurement
        {
            get { return _diskBenchmark; }
        }

        public void Measure(bool cpu, bool disk, bool video)
        {
            try
            {
                if (cpu)
                    _cpuBenchmark = MeasureCpu();

#if !NETSTANDARD2_0
                if (video)
                    _videoBenchmark = MeasureVideo();
#endif

                if (disk)
                    _diskBenchmark = MeasureDisk();

                try
                {
                    StopMeasure();
                }
                catch
                {
                    // Ignore disk errors
                }
            }
            catch
            {
                base.Stop();
            }
        }

        private void Load()
        {
            EnvironmentProperties properties = new EnvironmentProperties();
            properties.Load();

            _cpuBenchmark = properties.GetAsDouble("CpuMeasurement", 0);
            _videoBenchmark = properties.GetAsDouble("VideoMeasurement", 0);
            _diskBenchmark = properties.GetAsDouble("DiskMeasurement", 0);
        }

        private void StopMeasure()
        {
            EnvironmentProperties properties = new EnvironmentProperties();

            properties.SetAsDouble("CpuMeasurement", _cpuBenchmark);
            properties.SetAsDouble("VideoMeasurement", _videoBenchmark);
            properties.SetAsDouble("DiskMeasurement", _diskBenchmark);

            properties.Save();
        }

        private double MeasureCpu()
        {
            var suite = new StandardBenchmarkSuite();
            var instance = new BenchmarkSuiteInstance(suite);

            instance.UnselectAll();
            instance.SelectByName(suite.CpuBenchmark.Name);

            Start(instance.Selected);
            Thread.Sleep(Duration * 1000);
            base.Stop();

            return _results.All[0].PerformanceMeasurement.AverageValue;
        }

#if !NETSTANDARD2_0
        private double MeasureVideo()
        {
            var suite = new StandardBenchmarkSuite();
            var instance = new BenchmarkSuiteInstance(suite);

            instance.UnselectAll();
            instance.SelectByName(suite.VideoBenchmark.Name);

            Start(instance.Selected);
            Thread.Sleep(Duration * 1000);
            base.Stop();

            return _results.All[0].PerformanceMeasurement.AverageValue;
        }
#endif

        private double MeasureDisk()
        {
            var suite = new StandardBenchmarkSuite();
            var instance = new BenchmarkSuiteInstance(suite);

            instance.UnselectAll();
            instance.SelectByName(suite.DiskBenchmark.Name);

            Start(instance.Selected);
            Thread.Sleep(Duration * 1000);
            Stop();

            return _results.All[0].PerformanceMeasurement.AverageValue;
        }

    }
}
