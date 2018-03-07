using PipBenchmark.Runner.Execution;
using PipBenchmark.Utilities;

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
            get { return Converter.DoubleToString(_process.NominalRate); }
            set { _process.NominalRate = Converter.StringToDouble(value, 1); }
        }
    }
}
