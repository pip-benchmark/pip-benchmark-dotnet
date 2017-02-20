using PipBenchmark.Runner.Execution;

namespace PipBenchmark.Runner.Config
{
    public class NominalRateParameter : Parameter
    {
        private BenchmarkProcess _process;

        public NominalRateParameter(BenchmarkProcess process)
            : base(
                "General.Benchmarking.NominalRate",
                "Rate for nominal benchmarking in TPS",
                "1"
            )
        {
            _process = process;
        }

        public override string Value
        {
            get { return SimpleTypeConverter.DoubleToString(_process.NominalRate); }
            set { _process.NominalRate = SimpleTypeConverter.StringToDouble(value, 1); }
        }
    }
}
