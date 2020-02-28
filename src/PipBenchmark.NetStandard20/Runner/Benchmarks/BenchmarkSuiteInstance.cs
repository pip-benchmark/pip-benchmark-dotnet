using System;
using System.Collections.Generic;
using System.Linq;
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

        public BenchmarkSuite Suite => _suite;

        public string Name => _suite.Name;

        public string Description => _suite.Description;

        //public Assembly Assembly
        //{
        //    get { return _suite.GetType().Assembly; }
        //}

        public List<Parameter> Parameters => new List<Parameter>(_suite.Parameters.Values);

        public List<BenchmarkInstance> Benchmarks
        {
            get { return _benchmarks; }
        }

        public List<BenchmarkInstance> Selected
        {
            get
            {
                return _benchmarks.Where(benchmark => benchmark.IsSelected).ToList();
            }
        }

        public void SelectAll()
        {
            foreach (var benchmark in _benchmarks)
                benchmark.IsSelected = true;
        }

        public void SelectByName(string benchmarkName)
        {
            foreach (var benchmark in _benchmarks.Where(benchmark => benchmark.Name == benchmarkName))
            {
                benchmark.IsSelected = true;
            }
        }

        public void UnselectAll()
        {
            foreach (var benchmark in _benchmarks)
                benchmark.IsSelected = false;
        }

        public void UnselectByName(string benchmarkName)
        {
            foreach (var benchmark in _benchmarks.Where(benchmark => benchmark.Name == benchmarkName))
            {
                benchmark.IsSelected = false;
            }
        }

        public void SetUp(IExecutionContext context)
        {
            _suite.Context = context;
            _suite.SetUp();

            foreach (var benchmark in _benchmarks.Where(benchmark => benchmark.IsSelected))
            {
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
