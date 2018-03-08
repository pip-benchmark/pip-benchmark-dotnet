using PipBenchmark;

namespace PipBenchmark.NetStandard20Test
{
    public class BenchmarkSuiteTest : BenchmarkSuite
    {
        public BenchmarkSuiteTest()
            : base("Test", "Measures performance of Test service")
        {
            AddBenchmark(CreateBenchmark("Test", "Measures performance of Test", BenchmarkTest));
            AddBenchmark(CreateBenchmark("Test2", "Measures performance of Test2", BenchmarkTest2));
        }

        public override void SetUp()
        {
            // Set up suite
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

            System.Console.Out.WriteLine("Execute BenchmarkTest");
        }

        public void BenchmarkTest2()
        {
            var result = 0;

            for (var i = 0; i < 1000; i++)
            {
                result += 5;
                result *= 100;
            }

            System.Console.Out.WriteLine("Execute BenchmarkTest2");
        }
    }
}
