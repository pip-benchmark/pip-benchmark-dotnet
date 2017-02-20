using PipBenchmark;
using System.Threading;

namespace PipBenchmark.Sample
{
    public class SampleBenchmarkSuite : BenchmarkSuite
    {
        public SampleBenchmarkSuite() 
            : base("Samples", "Provides sample benchmarks")
        {
            AddParameter("Greeting", "Greeting message", "Hello world!");

            AddBenchmark(new SampleBenchmark());
        }

        public override void SetUp()
        {
            for (int index = 0; index < 3; index++)
            {
                Context.SendMessage("Initializing Sample suite " + index + "...");
                Thread.Sleep(1000);
            }
        }

        public override void TearDown()
        {
            for (int index = 0; index < 3; index++)
            {
                Context.SendMessage("Initializing Sample suite " + index + "...");
                Thread.Sleep(1000);
            }
        }
    }
}
