namespace PipBenchmark.Hardware
{
    public class StandardHardwareBenchmarkSuite : BenchmarkSuite
    {
        private StandardCpuBenchmark _cpuBenchmarkTest;
        private StandardDiskBenchmark _diskBenchmarkTest;
#if !NETSTANDARD2_0
        private StandardVideoBenchmark _videoBenchmarkTest;
#endif

        public StandardHardwareBenchmarkSuite()
            : base("StandardBenchmark", "Standard hardware benchmark")
        {
            _cpuBenchmarkTest = new StandardCpuBenchmark();
            AddBenchmark(_cpuBenchmarkTest);

            _diskBenchmarkTest = new StandardDiskBenchmark();
            AddBenchmark(_diskBenchmarkTest);

#if !NETSTANDARD2_0
            _videoBenchmarkTest = new StandardVideoBenchmark();
            AddBenchmark(_videoBenchmarkTest);
#endif
        }

        public StandardCpuBenchmark CpuBenchmarkTest
        {
            get { return _cpuBenchmarkTest; }
        }

        public StandardDiskBenchmark DiskBenchmarkTest
        {
            get { return _diskBenchmarkTest; }
        }

#if !NETSTANDARD2_0
        public StandardVideoBenchmark VideoBenchmarkTest
        {
            get { return _videoBenchmarkTest; }
        }
#endif

        //public void DisableAllTest()
        //{
        //    foreach (BenchmarkInstance test in Benchmarks)
        //    {
        //        test.Enabled = false;
        //    }
        //}
    }
}
