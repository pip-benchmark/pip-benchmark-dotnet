using System;
using PipBenchmark.Console;
using PipBenchmark.Runner.Console;

namespace PipBenchmark.Builder.Builders
{
    public class ConsoleBenchmarkBuilder: BenchmarkBuilder
    {
        public ConsoleBenchmarkBuilder()
        {
            WithParams();
            
            ConsoleEventPrinter.Add(_runner);
            _runner.Results.Updated -= ConsoleEventPrinter.OnResultUpdated;
        }
    }
}