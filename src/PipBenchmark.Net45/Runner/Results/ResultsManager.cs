using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipBenchmark.Runner.Results
{
    public class ResultsManager
    {
        private List<BenchmarkResult> _results = new List<BenchmarkResult>();

        public ResultsManager() { }

        public List<BenchmarkResult> All
        {
            get { return _results; }
        }

        public void Add(BenchmarkResult result)
        {
            _results.Add(result);
        }

        public void Clear()
        {
            _results.Clear();
        }
    }
}
