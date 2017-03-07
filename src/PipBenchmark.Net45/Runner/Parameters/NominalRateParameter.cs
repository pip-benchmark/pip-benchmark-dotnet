using PipBenchmark.Runner.Config;
using PipBenchmark.Utilities;

namespace PipBenchmark.Runner.Parameters
{
    public class NominalRateParameter : Parameter
    {
        private ConfigurationManager _configuration;

        public NominalRateParameter(ConfigurationManager configuration)
            : base(
                "General.Benchmarking.NominalRate",
                "Rate for nominal benchmarking in TPS",
                "1"
            )
        {
            _configuration = configuration;
        }

        public override string Value
        {
            get { return Converter.DoubleToString(_configuration.NominalRate); }
            set { _configuration.NominalRate = Converter.StringToDouble(value, 1); }
        }
    }
}
