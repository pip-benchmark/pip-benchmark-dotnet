using PipBenchmark.Runner.Execution;

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
            get { return SimpleTypeConverter.IntegerToString(_process.Duration / 1000); }
            set { _process.Duration = SimpleTypeConverter.StringToInteger(value, 60) * 1000; }
        }
    }
}
