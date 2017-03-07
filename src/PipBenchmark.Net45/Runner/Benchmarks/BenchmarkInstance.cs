namespace PipBenchmark.Runner.Benchmarks
{
    public class BenchmarkInstance
    {
        private BenchmarkSuiteInstance _suite;
        private Benchmark _benchmark;
        private bool _selected = false;
        private int _proportion = 100;
        private double _startRange;
        private double _endRange;

        public BenchmarkInstance(BenchmarkSuiteInstance suite, Benchmark benchmark)
        {
            _suite = suite;
            _benchmark = benchmark;
        }

        public BenchmarkSuiteInstance Suite
        {
            get { return _suite; }
        }

        public Benchmark Benchmark
        {
            get { return _benchmark; }
        }

        public string Name
        {
            get { return _benchmark.Name; }
        }

        public string FullName
        {
            get { return _suite.Name + "." + _benchmark.Name; }
        }

        public string Description
        {
            get { return _benchmark.Description; }
        }

        public bool IsSelected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public bool IsPassive
        {
            get { return _benchmark is PassiveBenchmark; }
        }

        public int Proportion
        {
            get { return _proportion; }
            set { _proportion = System.Math.Max(0, System.Math.Min(10000, value)); }
        }

        public double StartRange
        {
            get { return _startRange; }
            set { _startRange = value; }
        }

        public double EndRange
        {
            get { return _endRange; }
            set { _endRange = value; }
        }

        public bool WithinRange(double proportion)
        {
            return proportion >= _startRange && proportion < _endRange;
        }

        public void SetUp(IExecutionContext context)
        {
            _benchmark.Context = context;
            _benchmark.SetUp();
        }

        public void Execute()
        {
            _benchmark.Execute();
        }

        public void TearDown()
        {
            _benchmark.TearDown();
            _benchmark.Context = null;
        }
    }
}
