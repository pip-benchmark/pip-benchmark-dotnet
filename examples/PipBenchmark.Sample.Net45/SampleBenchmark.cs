using System.Threading;

namespace PipBenchmark.Sample
{
    public class SampleBenchmark: Benchmark
    {
        private RandomDataGenerator _random = new RandomDataGenerator();
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
            if (_random.Chance(1, 10))
                Context.SendMessage(_greeting);
            else if (_random.Chance(1, 10))
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
