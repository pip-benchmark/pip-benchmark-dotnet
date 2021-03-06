﻿using PipBenchmark.Runner;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Console;
using PipBenchmark.Sample.NetCore20;
using System;
using PipBenchmark.Console;
using PipBenchmark.Utilities;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var benchmark = new ConsoleBenchmarkBuilder()
                .AddSuite(new SampleBenchmarkSuite())
                .InThreads(1)
                .ForDuration(15)
                .ForceContinue(true)
                .WithAllBenchmarks()
                .Create();

            benchmark.Run();

            var report = benchmark.Report.Generate();
            Console.Out.WriteLine();
            Console.Out.Write(report);
        }
    }
}
