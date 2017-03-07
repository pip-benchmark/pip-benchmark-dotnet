using PipBenchmark.Runner.Config;
using System;

namespace PipBenchmark.Runner.Parameters
{
    public class ExecutionTypeParameter : Parameter
    {
        private ConfigurationManager _configuration;

        public ExecutionTypeParameter(ConfigurationManager configuration)
            : base(
                "General.Benchmarking.ExecutionType",
                "Execution type: proportional or sequencial",
                "Proportional"
            )
        {
            _configuration = configuration;
        }

        public override string Value
        {
            get { return _configuration.ExecutionType == ExecutionType.Proportional ? "Proportional" : "Sequencial"; }
            set
            {
                _configuration.ExecutionType = value.StartsWith("p", StringComparison.InvariantCultureIgnoreCase)
                    ? ExecutionType.Proportional : ExecutionType.Sequential;
            }
        }
    }
}
