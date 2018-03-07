using PipBenchmark.Runner.Benchmarks;

namespace PipBenchmark.Runner.Parameters
{
    public class BenchmarkSuiteParameter : Parameter
    {
        private BenchmarkSuiteInstance _suite;
        private Parameter _originalParameter;

        public BenchmarkSuiteParameter(BenchmarkSuiteInstance suite,
            Parameter originalParameter)
            : base(string.Format("{0}.{1}", suite.Name, originalParameter.Name),
            originalParameter.Description, originalParameter.DefaultValue)
        {
            _suite = suite;
            _originalParameter = originalParameter;
        }

        public override string Value
        {
            get { return _originalParameter.Value; }
            set { _originalParameter.Value = value; }
        }
    }
}
