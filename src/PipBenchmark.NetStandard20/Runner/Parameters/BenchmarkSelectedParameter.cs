using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Utilities;

namespace PipBenchmark.Runner.Parameters
{
    public class BenchmarkSelectedParameter : Parameter
    {
        private BenchmarkInstance _benchmark;

        public BenchmarkSelectedParameter(BenchmarkInstance benchmark)
            : base(
                $"{benchmark.Suite.Name}.{benchmark.Name}.Selected",
                $"Selecting benchmark {benchmark.Name} in suite {benchmark.Suite.Name}",
                "true"
            )
        {
            _benchmark = benchmark;
        }

        public override string Value
        {
            get => Converter.BooleanToString(_benchmark.IsSelected);
            set => _benchmark.IsSelected = Converter.StringToBoolean(value, false);
        }
    }
}
