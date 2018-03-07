using PipBenchmark.Runner.Config;
using System;

namespace PipBenchmark.Runner.Parameters
{
    public class MeasurementTypeParameter : Parameter
    {
        private ConfigurationManager _configuration;

        public MeasurementTypeParameter(ConfigurationManager configuration)
            : base(
                "General.Benchmarking.MeasurementType",
                "Measurement type: peak or nominal",
                "Peak"
            )
        {
            _configuration = configuration;
        }

        public override string Value
        {
            get { return _configuration.MeasurementType == MeasurementType.Peak ? "Peak" : "Nominal"; }
            set 
            { 
                _configuration.MeasurementType = value.StartsWith("p", StringComparison.InvariantCultureIgnoreCase)
                    ? MeasurementType.Peak : MeasurementType.Nominal; 
            }
        }
    }
}
