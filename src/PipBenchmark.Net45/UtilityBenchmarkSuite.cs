using System;
using System.Collections.Generic;
using System.Threading;

namespace PipBenchmark
{
    public class UtilityBenchmarkTestSuite : BenchmarkSuite
    {
        private Random _randomGenerator = new Random();

        public UtilityBenchmarkTestSuite()
            : base("Utility", "Set of utility benchmark tests")
        {
            AddBenchmark("Empty", "Does nothing", ExecuteEmpty);
            AddBenchmark("RandomDelay", "Introduces random delay to measuring thread", ExecuteRandomDelay);
        }

        public override void SetUp()
        {
        }

        public override void TearDown()
        {
        }

        public void ExecuteEmpty()
        {
        }

        public void ExecuteRandomDelay()
        {
            Thread.Sleep(_randomGenerator.Next(0, 1000));
        }
    }
}
