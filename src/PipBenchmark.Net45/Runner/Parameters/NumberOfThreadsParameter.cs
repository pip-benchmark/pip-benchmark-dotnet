using PipBenchmark.Runner.Config;
using PipBenchmark.Utilities;

namespace PipBenchmark.Runner.Parameters
{
    public class NumberOfThreadsParameter : Parameter
    {
        private ConfigurationManager _configuration;

        public NumberOfThreadsParameter(ConfigurationManager configuration)
            : base(
                "General.Benchmarking.NumberOfThreads",
                "Number of threads for concurrent benchmarking",
                "1"
            )
        {
            _configuration = configuration;
        }

        public override string Value
        {
            get { return Converter.IntegerToString(_configuration.NumberOfThreads); }
            set { _configuration.NumberOfThreads = Converter.StringToInteger(value, 1); }
        }
    }
}
