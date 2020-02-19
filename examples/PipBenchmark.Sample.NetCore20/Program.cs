using PipBenchmark.Builder.Builders;
using PipBenchmark.Runner;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Console;
using PipBenchmark.Sample.NetCore20;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var benchmark = new ConsoleBenchmarkBuilder()
                .AddSuite(new SampleBenchmarkSuite())
                .InThreads(1)
                .DurationOf(15)
                .WithParams(isForceContinue:true)
                .SelectTest()
                .Create();

            benchmark.Run();

            var report = benchmark.Report.Generate();
            Console.Out.WriteLine();
            Console.Out.Write(report);
        }
    }
}
