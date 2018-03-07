using PipBenchmark.Runner.Execution;
using PipBenchmark.Utilities;

namespace PipBenchmark.Runner.Config
{
    public class DurationParameter : Parameter
    {
        private BenchmarkProcess _process;

        public DurationParameter(BenchmarkProcess process)
            : base(
                "General.Benchmarking.Duration",
                "Duration of benchmark execution in seconds",
                "60"
            )
        {
            _process = process;
        }

        public override string Value
        {
            get { return Converter.IntegerToString(_process.Duration); }
            set { _process.Duration = Converter.StringToInteger(value, 60); }
        }
    }
}
