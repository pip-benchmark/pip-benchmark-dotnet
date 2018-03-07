using System;
using System.Collections.Generic;

using PipBenchmark.Runner.Execution;
using PipBenchmark.Runner;

namespace PipBenchmark.Runner.Config
{
    public class MeasurementTypeParameter : Parameter
    {
        private BenchmarkProcess _process;

        public MeasurementTypeParameter(BenchmarkProcess process)
            : base(
                "General.Benchmarking.MeasurementType",
                "Measurement type: peak or nominal",
                "Peak"
            )
        {
            _process = process;
        }

        public override string Value
        {
            get { return _process.MeasurementType == MeasurementType.Peak ? "Peak" : "Nominal"; }
            set 
            { 
                _process.MeasurementType = value.StartsWith("p", StringComparison.InvariantCultureIgnoreCase)
                    ? MeasurementType.Peak : MeasurementType.Nominal; 
            }
        }
    }
}
