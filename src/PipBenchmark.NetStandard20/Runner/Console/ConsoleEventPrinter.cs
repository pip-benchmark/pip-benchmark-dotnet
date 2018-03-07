using PipBenchmark.Runner.Execution;
using PipBenchmark.Runner.Results;
using System;

namespace PipBenchmark.Runner.Console
{
    public static class ConsoleEventPrinter
    {
        public static void Add(BenchmarkRunner runner)
        {
            runner.Results.Error += OnErrorReported;
            runner.Results.Message += OnMessageSent;
            runner.Results.Updated += OnResultUpdated;
        }

        public static void Remove(BenchmarkRunner runner)
        {
            runner.Results.Error -= OnErrorReported;
            runner.Results.Message -= OnMessageSent;
            runner.Results.Updated -= OnResultUpdated;
        }

        public static void OnExecutionUpdated(object sender, ExecutionEventArgs args)
        {
            if (args.State == ExecutionState.Running)
            {
                System.Console.Out.WriteLine("Benchmarking...");
            }
            else if (args.State == ExecutionState.Completed)
            {
                System.Console.Out.WriteLine("Completed benchmarking.");
            }
        }

        public static void OnResultUpdated(object sender, ResultEventArgs args)
        {
            System.Console.Out.WriteLine("{0} Performance: {1} {2}>{3}>{4} CPU Load: {5} {6}>{7}>{8} Errors: {9}",
                DateTime.Now.ToLongTimeString(),
                args.Result.PerformanceMeasurement.CurrentValue.ToString("0.##"),
                args.Result.PerformanceMeasurement.MinValue.ToString("0.##"),
                args.Result.PerformanceMeasurement.AverageValue.ToString("0.##"),
                args.Result.PerformanceMeasurement.MaxValue.ToString("0.##"),
                args.Result.CpuLoadMeasurement.CurrentValue.ToString("0.##"),
                args.Result.CpuLoadMeasurement.MinValue.ToString("0.##"),
                args.Result.CpuLoadMeasurement.AverageValue.ToString("0.##"),
                args.Result.CpuLoadMeasurement.MaxValue.ToString("0.##"),
                args.Result.Errors.Count.ToString("0.##"));
        }

        public static void OnMessageSent(object sender, MessageEventArgs args)
        {
            System.Console.Out.WriteLine(args.Message);
        }

        public static void OnErrorReported(object sender, ErrorEventArgs args)
        {
            System.Console.Error.WriteLine("Error: " + args.Error);
        }
    }
}
