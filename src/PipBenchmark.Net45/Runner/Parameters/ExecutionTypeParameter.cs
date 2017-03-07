using System;
using System.Collections.Generic;

using PipBenchmark.Runner.Execution;
using PipBenchmark.Runner;
using PipBenchmark.Runner.Config;

namespace PipBenchmark.Runner.Parameters
{
    public class ExecutionTypeParameter : Parameter
    {
        private ExecutionManager _process;

        public ExecutionTypeParameter(ExecutionManager process)
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
