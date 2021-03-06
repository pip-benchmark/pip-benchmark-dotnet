﻿using PipBenchmark.Runner;
using PipBenchmark.Utilities;
using System;
using System.Collections.Generic;

namespace PipBenchmark.Runner.Config
{
    public class BenchmarkSelectedParameter : Parameter
    {
        private BenchmarkInstance _benchmark;

        public BenchmarkSelectedParameter(BenchmarkInstance benchmark)
            : base(
                string.Format("{0}.{1}.Selected", benchmark.Suite.Name, benchmark.Name),
                string.Format("Selecting benchmark {0} in suite {1}", benchmark.Name, benchmark.Suite.Name),
                "true"
            )
        {
            _benchmark = benchmark;
        }

        public override string Value
        {
            get { return Converter.BooleanToString(_benchmark.IsSelected); }
            set { _benchmark.IsSelected = Converter.StringToBoolean(value); }
        }
    }
}
