using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PipBenchmark.Runner.Benchmarks
{
    public class BenchmarksManager
    {
        private readonly List<BenchmarkSuiteInstance> _suites = new List<BenchmarkSuiteInstance>();

        public BenchmarksManager(BenchmarkRunner runner)
        {
            Runner = runner;
        }

        public BenchmarkRunner Runner { get; }

        public List<BenchmarkSuiteInstance> Suites => _suites;

        public List<BenchmarkInstance> SelectedBenchmarks
        {
            get
            {
                List<BenchmarkInstance> benchmarks = new List<BenchmarkInstance>();

                foreach (BenchmarkSuiteInstance suite in _suites)
                {
                    foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                    {
                        if (benchmark.IsSelected)
                            benchmarks.Add(benchmark);
                    }
                }

                return benchmarks;
            }
        }

        public void SelectAllBenchmarks()
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                    benchmark.IsSelected = true;
            }
        }

        public void SelectBenchmarks(string[] benchmarkNames)
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                {
                    if (benchmarkNames.Contains(benchmark.FullName))
                        benchmark.IsSelected = true;
                }
            }
        }

        public void SelectBenchmarks(Benchmark[] benchmarks)
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                {
                    if (benchmarks.Contains(benchmark.Benchmark))
                        benchmark.IsSelected = true;
                }
            }
        }

        public void UnselectAllBenchmarks()
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                    benchmark.IsSelected = false;
            }
        }

        public void UnselectBenchmark(string[] benchmarkNames)
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                {
                    if (benchmarkNames.Contains(benchmark.FullName))
                        benchmark.IsSelected = false;
                }
            }
        }

        public void UnselectBenchmarks(Benchmark[] benchmarks)
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                {
                    if (benchmarks.Contains(benchmark.Benchmark))
                        benchmark.IsSelected = false;
                }
            }
        }

        private BenchmarkSuiteInstance FindSuite(string suiteName)
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                if (suite.Name.Equals(suiteName, StringComparison.InvariantCultureIgnoreCase))
                    return suite;
            }

            return null;
        }

        public void AddSuiteFromClass(string suiteClassName)
        {
            Type suiteType = Type.GetType(suiteClassName, true);
            var suite = (BenchmarkSuite)Activator.CreateInstance(suiteType);
            var instance = new BenchmarkSuiteInstance(suite);
            AddSuite(instance);
        }

        public void AddSuite(BenchmarkSuite suite)
        {
            var instance = new BenchmarkSuiteInstance(suite);
            AddSuite(instance);
        }

        public void AddSuite(BenchmarkSuiteInstance instance)
        {
            Runner.Execution.Stop();
            _suites.Add(instance);
            Runner.Parameters.AddSuite(instance);
        }

        public void LoadSuitesFromAssembly(string assemblyName)
        {
            Runner.Execution.Stop();

            // Load assembly
            Assembly assembly = Assembly.LoadFrom(assemblyName);

            // Find benchmark suites
            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(BenchmarkSuite)) && !type.IsAbstract)
                {
                    BenchmarkSuite suite = Activator.CreateInstance(type) as BenchmarkSuite;
                    var instance = new BenchmarkSuiteInstance(suite);
                    _suites.Add(instance);
                    Runner.Parameters.AddSuite(instance);
                }
            }
        }

        public void RemoveSuite(BenchmarkSuite suite)
        {
            foreach (var instance in _suites)
            {
                if (instance.Suite == suite)
                {
                    RemoveSuite(instance);
                    return;
                }
            }
        }

        public void RemoveSuite(BenchmarkSuiteInstance suite)
        {
            Runner.Execution.Stop();

            Runner.Parameters.RemoveForSuite(suite);

            _suites.Remove(suite);
        }

        public void RemoveSuite(string suiteName)
        {
            Runner.Execution.Stop();

            BenchmarkSuiteInstance suite = FindSuite(suiteName);
            if (suite != null)
            {
                Runner.Parameters.RemoveForSuite(suite);
                _suites.Remove(suite);
            }
        }

        public void RemoveAllSuites()
        {
            Runner.Execution.Stop();

            foreach (BenchmarkSuiteInstance suite in _suites)
                Runner.Parameters.RemoveForSuite(suite);

            _suites.Clear();
        }
    }
}
