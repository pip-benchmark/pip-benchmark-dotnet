using PipBenchmark.Runner.Execution;
using PipBenchmark.Utilities;

namespace PipBenchmark.Runner.Config
{
    public class NumberOfThreadsParameter : Parameter
    {
        private BenchmarkProcess _process;

        public NumberOfThreadsParameter(BenchmarkProcess process)
            : base(
                "General.Benchmarking.NumberOfThreads",
                "Number of threads for concurrent benchmarking",
                "1"
            )
        {
            _process = process;
        }

        public override string Value
        {
            get { return Converter.IntegerToString(_process.NumberOfThreads); }
            set { _process.NumberOfThreads = Converter.StringToInteger(value, 1); }
        }
    }
}
