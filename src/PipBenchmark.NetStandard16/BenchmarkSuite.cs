using System;
using System.Collections.Generic;

namespace PipBenchmark
{
    public abstract class BenchmarkSuite
    {
        private string _name;
        private string _description;
        private Dictionary<string, Parameter> _parameters = new Dictionary<string, Parameter>();
        private List<Benchmark> _benchmarks = new List<Benchmark>();
        private IExecutionContext _context;

        protected BenchmarkSuite(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public IExecutionContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public Dictionary<string, Parameter> Parameters
        {
            get { return _parameters; }
        }

        protected Parameter AddParameter(Parameter parameter)
        {
            _parameters.Add(parameter.Name, parameter);
            return parameter;
        }

        protected Parameter AddParameter(string name, string description)
        {
            Parameter parameter = new Parameter(name, description, null);
            _parameters.Add(name, parameter);
            return parameter;
        }

        protected Parameter AddParameter(string name, string description, string defaultValue)
        {
            Parameter parameter = new Parameter(name, description, defaultValue);
            _parameters.Add(name, parameter);
            return parameter;
        }

        public List<Benchmark> Benchmarks
        {
            get { return _benchmarks; }
        }

        protected Benchmark AddBenchmark(Benchmark benchmark)
        {
            _benchmarks.Add(benchmark);
            return benchmark;
        }

        protected Benchmark AddBenchmark(string name, string description, Action executeAction)
        {
            Benchmark benchmark = new DelegatedBenchmark(name, description, executeAction);
            _benchmarks.Add(benchmark);
            return benchmark;
        }

        public virtual void SetUp() { }
        public virtual void TearDown() { }
    }
}
