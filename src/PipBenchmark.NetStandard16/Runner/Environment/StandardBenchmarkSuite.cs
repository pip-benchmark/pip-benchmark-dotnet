﻿namespace PipBenchmark.Runner.Environment
{
    public class StandardBenchmarkSuite : BenchmarkSuite
    {
        private DefaultCpuBenchmark _cpuBenchmark;
        private DefaultDiskBenchmark _diskBenchmark;
        private DefaultVideoBenchmark _videoBenchmark;

        public StandardBenchmarkSuite()
            : base("System", "Measures overall system performance")
        {
            _cpuBenchmark = new DefaultCpuBenchmark();
            AddBenchmark(_cpuBenchmark);

            _diskBenchmark = new DefaultDiskBenchmark();
            AddBenchmark(_diskBenchmark);

            _videoBenchmark = new DefaultVideoBenchmark();
            AddBenchmark(_videoBenchmark);

            CreateParameter("FilePath", "Path where test file is located on disk", "");
            CreateParameter("FileSize", "Size of the test file",
#if !CompactFramework
                "102400000"
#else
                "2048000"
#endif
                );
            CreateParameter("ChunkSize", "Size of a chunk that read or writter from/to test file", "1024000");
            CreateParameter("OperationTypes", "Types of test operations: read, write or all", "all");
        }

        public DefaultCpuBenchmark CpuBenchmark
        {
            get { return _cpuBenchmark; }
        }

        public DefaultDiskBenchmark DiskBenchmark
        {
            get { return _diskBenchmark; }
        }

        public DefaultVideoBenchmark VideoBenchmark
        {
            get { return _videoBenchmark; }
        }
    }
}
