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
            switch (args.State)
            {
                case ExecutionState.Running:
                    System.Console.Out.WriteLine("Benchmarking...");
                    break;
                case ExecutionState.Completed:
                    System.Console.Out.WriteLine("Completed benchmarking.");
                    break;
                case ExecutionState.Initial:
                    System.Console.Out.WriteLine("Init benchmarking.");
                    break;
                default:
                    System.Console.Out.WriteLine("Unknown.");
                    break;
            }
        }

        public static void OnResultUpdated(object sender, ResultEventArgs args)
        {
            System.Console.Out.WriteLine(
                "{0} Performance: {1:0.##} {2:0.##}>{3:0.##}>{4:0.##} CPU Load: {5:0.##} {6:0.##}>{7:0.##}>{8:0.##} Errors: {9:0.##}",
                DateTime.Now.ToLongTimeString(), args.Result.PerformanceMeasurement.CurrentValue,
                args.Result.PerformanceMeasurement.MinValue, args.Result.PerformanceMeasurement.AverageValue,
                args.Result.PerformanceMeasurement.MaxValue, args.Result.CpuLoadMeasurement.CurrentValue,
                args.Result.CpuLoadMeasurement.MinValue, args.Result.CpuLoadMeasurement.AverageValue,
                args.Result.CpuLoadMeasurement.MaxValue, args.Result.Errors.Count);
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
