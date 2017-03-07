using PipBenchmark.Runner.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PipBenchmark.Runner.Benchmarks
{
    public class BenchmarksManager
    {
        private ParametersManager _parameters;
        private readonly List<BenchmarkSuiteInstance> _suites = new List<BenchmarkSuiteInstance>();

        public BenchmarksManager(ParametersManager parameters)
        {
            _parameters = parameters;
        }

        public List<BenchmarkSuiteInstance> Suites
        {
            get { return _suites; }
        }

        public List<BenchmarkInstance> Selected
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

        public void SelectAll()
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                    benchmark.IsSelected = true;
            }
        }

        public void SelectByName(string[] benchmarkNames)
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

        public void Select(Benchmark[] benchmarks)
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

        public void UnselectAll()
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
            {
                foreach (BenchmarkInstance benchmark in suite.Benchmarks)
                    benchmark.IsSelected = false;
            }
        }

        public void UnselectByName(string[] benchmarkNames)
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

        public void Unselect(Benchmark[] benchmarks)
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
            _suites.Add(instance);
            _parameters.AddSuite(instance);
        }

        public void AddSuitesFromAssembly(string assemblyName)
        {
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
                    _parameters.AddSuite(instance);
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
            _parameters.RemoveForSuite(suite);

            _suites.Remove(suite);
        }

        public void RemoveSuiteByName(string suiteName)
        {
            BenchmarkSuiteInstance suite = FindSuite(suiteName);
            if (suite != null)
            {
                _parameters.RemoveForSuite(suite);
                _suites.Remove(suite);
            }
        }

        public void Clear()
        {
            foreach (BenchmarkSuiteInstance suite in _suites)
                _parameters.RemoveForSuite(suite);

            _suites.Clear();
        }
    }
}
