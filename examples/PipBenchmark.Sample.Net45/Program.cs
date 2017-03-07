using PipBenchmark.Runner;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipBenchmark.Sample.Net45
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new BenchmarkRunner();
            ConsoleEventPrinter.Add(runner);

            runner.AddSuite(new SampleBenchmarkSuite());
            runner.SelectAllBenchmarks();

            runner.Duration = 15000;
            runner.MeasurementType = MeasurementType.Peak;
            runner.NumberOfThreads = 1;
            runner.ExecutionType = ExecutionType.Proportional;
            runner.IsForceContinue = true;

            //runner.BenchmarkEnvironment(true, true, true);

            runner.Run();

            var report = runner.GenerateReport();
            Console.Out.WriteLine();
            Console.Out.Write(report);
        }
    }
}
