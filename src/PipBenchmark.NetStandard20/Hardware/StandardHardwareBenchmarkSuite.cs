using System;
using System.Collections.Generic;

namespace PipBenchmark.Hardware
{
    public class StandardHardwareBenchmarkSuite : BenchmarkSuite
    {
        private StandardCpuBenchmark _cpuBenchmarkTest;
        private StandardDiskBenchmark _diskBenchmarkTest;
        private StandardVideoBenchmark _videoBenchmarkTest;

        public StandardHardwareBenchmarkSuite()
            : base("StandardBenchmark", "Standard hardware benchmark")
        {
            _cpuBenchmarkTest = new StandardCpuBenchmark();
            AddBenchmark(_cpuBenchmarkTest);

            _diskBenchmarkTest = new StandardDiskBenchmark();
            AddBenchmark(_diskBenchmarkTest);

            _videoBenchmarkTest = new StandardVideoBenchmark();
            AddBenchmark(_videoBenchmarkTest);
        }

        public StandardCpuBenchmark CpuBenchmarkTest
        {
            get { return _cpuBenchmarkTest; }
        }

        public StandardDiskBenchmark DiskBenchmarkTest
        {
            get { return _diskBenchmarkTest; }
        }

        public StandardVideoBenchmark VideoBenchmarkTest
        {
            get { return _videoBenchmarkTest; }
        }

        //public void DisableAllTest()
        //{
        //    foreach (BenchmarkInstance test in Benchmarks)
        //    {
        //        test.Enabled = false;
        //    }
        //}
    }
}
