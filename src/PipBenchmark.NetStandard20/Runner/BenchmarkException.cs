using System;

namespace PipBenchmark.Runner
{
    public class BenchmarkException : Exception
    {
        public BenchmarkException(string message)
            : base(message)
        {
        }

        public BenchmarkException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
