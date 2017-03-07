using System;
using System.Collections.Generic;

namespace PipBenchmark
{
    public abstract class Benchmark
    {
        private string _name;
        private string _description;
        private IExecutionContext _context;

        public Benchmark(string name, string description)
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

        public virtual void SetUp() { }

        public abstract void Execute();

        public virtual void TearDown() { }
    }
}
