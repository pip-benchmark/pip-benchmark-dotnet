using PipBenchmark.Runner.Config;
using PipBenchmark.Utilities;

namespace PipBenchmark.Runner.Parameters
{
    public class DurationParameter : Parameter
    {
        private ConfigurationManager _configuration;

        public DurationParameter(ConfigurationManager configuration)
            : base(
                "General.Benchmarking.Duration",
                "Duration of benchmark execution in seconds",
                "60"
            )
        {
            _configuration = configuration;
        }

        public override string Value
        {
            get { return Converter.IntegerToString(_configuration.Duration); }
            set { _configuration.Duration = Converter.StringToInteger(value, 60); }
        }
    }
}
