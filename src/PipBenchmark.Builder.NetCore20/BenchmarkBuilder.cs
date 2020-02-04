using PipBenchmark.Runner;
using PipBenchmark.Runner.Config;

namespace PipBenchmark.Builder
{
    public abstract class BenchmarkBuilder
    {
        protected readonly BenchmarkRunner _runner =new BenchmarkRunner();
        public void AddSuite(BenchmarkSuite suite)
        {
            _runner.Benchmarks.AddSuite(suite);
        }

        public void WithParams(bool isForceContinue = false, MeasurementType measurementType = MeasurementType.Peak,
            double nominalRate = 1, ExecutionType executionType = ExecutionType.Proportional)
        {
            _runner.Configuration.ForceContinue = isForceContinue;
            _runner.Configuration.MeasurementType = measurementType;
            _runner.Configuration.NominalRate = nominalRate;
            _runner.Configuration.ExecutionType = executionType;
        }

        public void InThreads(int numberOfThreads)
        {
            _runner.Configuration.NumberOfThreads = numberOfThreads;
        }

        public void DurationOf(int seconds)
        {
            _runner.Configuration.Duration = seconds;
        }

        public void SelectTest(string[] benchmarkNames = null)
        {
            if (benchmarkNames==null || benchmarkNames.Length == 0)
                _runner.Benchmarks.SelectAll();
            else
            {
                foreach (var benchmark in benchmarkNames)
                    _runner.Benchmarks.SelectByName(new string[] { benchmark });
            }
        }

        public BenchmarkRunner Create()
        {
            return _runner;
        }

    }
}