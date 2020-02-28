using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Utilities;

namespace PipBenchmark.Runner.Parameters
{
    public class BenchmarkProportionParameter : Parameter
    {
        private BenchmarkInstance _benchmark;

        public BenchmarkProportionParameter(BenchmarkInstance benchmark)
            : base(
                $"{benchmark.Suite.Name}.{benchmark.Name}.Proportion",
                $"Sets execution proportion for benchmark {benchmark.Name} in suite {benchmark.Suite.Name}",
                "100"
            )
        {
            _benchmark = benchmark;
        }

        public override string Value
        {
            get => Converter.IntegerToString(_benchmark.Proportion);
            set => _benchmark.Proportion = Converter.StringToInteger(value, 100);
        }
    }
}
