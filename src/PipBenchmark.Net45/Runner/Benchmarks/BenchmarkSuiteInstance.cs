using System;
using System.Collections.Generic;
using System.Reflection;

namespace PipBenchmark.Runner.Benchmarks
{
    public class BenchmarkSuiteInstance
    {
        private BenchmarkSuite _suite;
        private List<BenchmarkInstance> _benchmarks = new List<BenchmarkInstance>();

        public BenchmarkSuiteInstance(BenchmarkSuite suite)
        {
            _suite = suite;

            foreach (var benchmark in suite.Benchmarks)
                _benchmarks.Add(new BenchmarkInstance(this, benchmark));
        }

        public BenchmarkSuite Suite
        {
            get { return _suite; }
        }

        public string Name
        {
            get { return _suite.Name; }
        }

        public string Description
        {
            get { return _suite.Description; }
        }

        public Assembly Assembly
        {
            get { return _suite.GetType().Assembly; }
        }

        public Dictionary<string, Parameter> Parameters
        {
            get { return _suite.Parameters; }
        }

        public List<BenchmarkInstance> Benchmarks
        {
            get { return _benchmarks; }
        }

        public void SelectAllBenchmarks()
        {
            foreach (var benchmark in _benchmarks)
                benchmark.IsSelected = true;
        }

        public void SelectBenchmark(string benchmarkName)
        {
            foreach (var benchmark in _benchmarks)
            {
                if (benchmark.Name == benchmarkName)
                    benchmark.IsSelected = true;
            }
        }

        public void UnselectAllBenchmarks()
        {
            foreach (var benchmark in _benchmarks)
                benchmark.IsSelected = false;
        }

        public void UnselectBenchmark(string benchmarkName)
        {
            foreach (var benchmark in _benchmarks)
            {
                if (benchmark.Name == benchmarkName)
                    benchmark.IsSelected = false;
            }
        }

        public void SetUp(IExecutionContext context)
        {
            _suite.Context = context;
            _suite.SetUp();

            foreach (BenchmarkInstance benchmark in _benchmarks)
            {
                if (benchmark.IsSelected)
                    benchmark.SetUp(context);
            }
        }

        public void TearDown()
        {
            foreach (BenchmarkInstance benchmark in _benchmarks)
            {
                if (benchmark.IsSelected)
                    benchmark.TearDown();
            }

            _suite.TearDown();
            _suite.Context = null;

        }
    }
}
