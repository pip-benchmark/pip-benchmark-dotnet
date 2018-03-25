using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PipBenchmark.Runner.Execution
{
    public class MemoryUsageMeter : BenchmarkMeter
    {
        public MemoryUsageMeter()
            : base()
        {
        }

        public override double Measure()
        {
            double memoryMeasureInterval = (DateTime.Now - LastMeasuredTime).TotalSeconds;
            if (memoryMeasureInterval > 0.5)
            {
                return base.Measure();
            }
            return CurrentValue;
        }

        protected override double PerformMeasurement()
        {
            return GetUsedMemory();
        }

#if !NETSTANDARD2_0
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
            public MEMORYSTATUSEX()
            {
                this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);

        private double GetUsedMemory()
        {
            MEMORYSTATUSEX memoryStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memoryStatus))
            {
                return (double)((memoryStatus.ullTotalPhys - memoryStatus.ullAvailPhys) / 1024 / 1024);
            }
            return 0;
        }
#else
        private double GetUsedMemory()
        {
            return 0;
        }
#endif
    }
}
