using System;
using System.Collections.Generic;

using PipBenchmark.Runner.Execution;
using PipBenchmark.Runner;

namespace PipBenchmark.Runner.Config
{
    public class ExecutionTypeParameter : Parameter
    {
        private BenchmarkProcess _process;

        public ExecutionTypeParameter(BenchmarkProcess process)
            : base(
                "General.Benchmarking.ExecutionType",
                "Execution type: proportional or sequencial",
                "Proportional"
            )
        {
            _process = process;
        }

        public override string Value
        {
            get { return _process.ExecutionType == ExecutionType.Proportional ? "Proportional" : "Sequencial"; }
            set
            {
                _process.ExecutionType = value.StartsWith("p", StringComparison.InvariantCultureIgnoreCase)
                    ? ExecutionType.Proportional : ExecutionType.Sequential;
            }
        }
    }
}
