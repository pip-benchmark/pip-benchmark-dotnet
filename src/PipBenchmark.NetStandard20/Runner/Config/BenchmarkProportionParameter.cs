using PipBenchmark.Runner;
using PipBenchmark.Utilities;

namespace PipBenchmark.Runner.Config
{
    public class BenchmarkProportionParameter : Parameter
    {
        private BenchmarkInstance _benchmark;

        public BenchmarkProportionParameter(BenchmarkInstance benchmark)
            : base(
                string.Format("{0}.{1}.Proportion", benchmark.Suite.Name, benchmark.Name),
                string.Format("Sets execution proportion for benchmark {0} in suite {1}", benchmark.Name, benchmark.Suite.Name),
                "100"
            )
        {
            _benchmark = benchmark;
        }

        public override string Value
        {
            get { return Converter.IntegerToString(_benchmark.Proportion); }
            set { _benchmark.Proportion = Converter.StringToInteger(value, 100); }
        }
    }
}
