using System;
using System.Threading;

#if !NETSTANDARD2_0
using System.Diagnostics;
#endif

namespace PipBenchmark.Runner.Execution
{
    public class CpuLoadMeter : BenchmarkMeter, IDisposable
    {
        public CpuLoadMeter()
            : base()
        {
            // First request to CPU load is very slow. So we do it during initialization
            PerformMeasurement();
        }

        public override double Measure()
        {
            double cpuLoadMeasureInterval = (DateTime.Now - LastMeasuredTime).TotalSeconds;
            if (cpuLoadMeasureInterval > 0.5)
            {
                return base.Measure();
            }
            return CurrentValue;
        }

#if !NETSTANDARD2_0
        private PerformanceCounter _processorLoadCounter;

        protected override double PerformMeasurement()
        {
            PerformanceCounter counter = GetCounter();
            return counter != null ? counter.NextValue() : 0;
        }

        private PerformanceCounter GetCounter()
        {
            if (_processorLoadCounter == null)
            {
                try
                {
                    _processorLoadCounter = new PerformanceCounter();
                    _processorLoadCounter.CategoryName = "Processor";
                    _processorLoadCounter.CounterName = "% Processor Time";
                    _processorLoadCounter.InstanceName = "_Total";
                }
                catch
                {
                    // Ignore exception
                }
            }
            return _processorLoadCounter;
        }

        private void DisposeCounter()
        {
            if (_processorLoadCounter != null)
            {
                _processorLoadCounter.Dispose();
                _processorLoadCounter = null;
            }
        }
#else
        protected override double PerformMeasurement()
        {
            return 0;
        }

        private void DisposeCounter()
        { }
#endif

        public void Dispose()
        {
            DisposeCounter();
        }

    }
}
