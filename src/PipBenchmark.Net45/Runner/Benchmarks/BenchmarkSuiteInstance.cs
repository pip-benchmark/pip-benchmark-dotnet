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

        //public Assembly Assembly
        //{
        //    get { return _suite.GetType().Assembly; }
        //}

        public List<Parameter> Parameters
        {
            get { return new List<Parameter>(_suite.Parameters.Values); }
        }

        public List<BenchmarkInstance> Benchmarks
        {
            get { return _benchmarks; }
        }

        public List<BenchmarkInstance> Selected
        {
            get
            {
                var benchmarks = new List<BenchmarkInstance>();
                foreach (var benchmark in _benchmarks)
                {
                    if (benchmark.Selected)
                        benchmarks.Add(benchmark);
                }
                return benchmarks;
            }
        }

        public void SelectAll()
        {
            foreach (var benchmark in _benchmarks)
                benchmark.Selected = true;
        }

        public void SelectByName(string benchmarkName)
        {
            foreach (var benchmark in _benchmarks)
            {
                if (benchmark.Name == benchmarkName)
                    benchmark.Selected = true;
            }
        }

        public void UnselectAll()
        {
            foreach (var benchmark in _benchmarks)
                benchmark.Selected = false;
        }

        public void UnselectByName(string benchmarkName)
        {
            foreach (var benchmark in _benchmarks)
            {
                if (benchmark.Name == benchmarkName)
                    benchmark.Selected = false;
            }
        }

        public void SetUp(IExecutionContext context)
        {
            _suite.Context = context;
            _suite.SetUp();

            foreach (BenchmarkInstance benchmark in _benchmarks)
            {
                if (benchmark.Selected)
                    benchmark.SetUp(context);
            }
        }

        public void TearDown()
        {
            foreach (BenchmarkInstance benchmark in _benchmarks)
            {
                if (benchmark.Selected)
                    benchmark.TearDown();
            }

            _suite.TearDown();
            _suite.Context = null;

        }
    }
}
