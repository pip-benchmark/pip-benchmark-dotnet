using PipBenchmark;

namespace PipBenchmark.NetStandard20Test
{
    public class BenchmarkSuiteTest : BenchmarkSuite
    {
        public BenchmarkSuiteTest()
            : base("Test", "Measures performance of Test service")
        {
            AddBenchmark(CreateBenchmark("Test", "Measures performance of Test", BenchmarkTest));
        }

        public override void SetUp()
        {
            // Some setups
        }

        public override void TearDown()
        {
        }

        public void BenchmarkTest() {
            var result = 0;

            for (var i = 0; i < 1000; i++) {
                result += 5;
                result *= 10;
            }
        }
    }
}
