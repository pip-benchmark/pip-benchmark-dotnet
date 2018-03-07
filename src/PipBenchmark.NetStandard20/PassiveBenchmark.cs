using System;

namespace PipBenchmark
{
    public abstract class PassiveBenchmark : Benchmark
    {
        public PassiveBenchmark(string name, string description)
            : base(name, description)
        { }

        public override void Execute()
        {
            throw new InvalidOperationException("Active measurement via Execute is not allowed for passive benchmarks");
        }
    }
}