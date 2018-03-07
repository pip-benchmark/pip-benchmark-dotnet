using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Results;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PipBenchmark.Runner.Execution
{
    public abstract class ExecutionStrategy
    {
        protected ConfigurationManager _configuration;
        protected ResultsManager _results;
        protected ExecutionManager _execution;
        protected readonly object _syncRoot = new object();
        protected List<BenchmarkInstance> _benchmarks;
        protected List<BenchmarkInstance> _activeBenchmarks;
        protected List<BenchmarkSuiteInstance> _suites;

        protected ExecutionStrategy(ConfigurationManager configuration, 
            ResultsManager results, ExecutionManager execution, 
            List<BenchmarkInstance> benchmarks)
        {
            _configuration = configuration;
            _results = results;
            _execution = execution;

            _benchmarks = benchmarks;
            _activeBenchmarks = GetActiveBenchmark(benchmarks);
            _suites = GetBenchmarkSuites(benchmarks);
        }

        private List<BenchmarkInstance> GetActiveBenchmark(List<BenchmarkInstance> benchmarks)
        {
            var activeBenchmarks = new List<BenchmarkInstance>();
            foreach (BenchmarkInstance benchmark in benchmarks)
            {
                if (!benchmark.IsPassive)
                    activeBenchmarks.Add(benchmark);
            }
            return activeBenchmarks;
        }

        private List<BenchmarkSuiteInstance> GetBenchmarkSuites(List<BenchmarkInstance> benchmarks)
        {
            var suites = new List<BenchmarkSuiteInstance>();
            foreach (BenchmarkInstance benchmark in benchmarks)
            {
                BenchmarkSuiteInstance suite = benchmark.Suite;
                if (!suites.Contains(suite))
                    suites.Add(suite);
            }
            return suites;
        }

        public abstract void Start();
        public abstract bool IsStopped { get; }
        public abstract void Stop();
    }
}
