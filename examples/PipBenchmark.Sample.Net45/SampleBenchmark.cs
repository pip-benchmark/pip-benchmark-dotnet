﻿using PipBenchmark.Utilities;
using PipBenchmark.Utilities.Random;
using System.Threading;

namespace PipBenchmark.Sample
{
    public class SampleBenchmark: Benchmark
    {
        private string _greeting;

        public SampleBenchmark()
            : base("Sample", "Sample benchmark that does nothing")
        { }

        public override void SetUp()
        {
            // Do nothing...
            _greeting = Context.Parameters["Greeting"].AsString;
        }

        public override void Execute()
        {
            // Randomly generate message or errors
            
            if (RandomBoolean.Chance(1, 10))
                Context.SendMessage(_greeting);
            else if (RandomBoolean.Chance(1, 10))
                Context.ReportError("Something bad happend...");

            // Just wait and do nothing
            Thread.Sleep(500);
        }

        public override void TearDown()
        {
            // Do nothing...
        }
    }
}
