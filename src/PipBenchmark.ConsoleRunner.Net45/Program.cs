using PipBenchmark.Runner;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Console;
using System;
using System.IO;
using System.Threading;

namespace PipBenchmark.Console
{
    class Program
    {
        private static void ExecuteBatchMode(CommandLineArgs args, BenchmarkRunner runner)
        {
            try
            {
                if (args.ShowHelp)
                {
                    HelpPrinter.Print();
                    return;
                }

                // Load assemblies
                foreach (string assemblyFile in args.Assemblies)
                    runner.LoadSuitesFromAssembly(assemblyFile);

                // Load configuration
                if (args.ConfigurationFile != null)
                    runner.Parameters.LoadFromFile(args.ConfigurationFile);

                // Set parameters
                if (args.Parameters.Count > 0)
                    runner.Parameters.Set(args.Parameters);

                if (args.ShowBenchmarks)
                {
                    PrintBenchmarks(runner);
                    return;
                }

                if (args.ShowParameters)
                {
                    PrintParameters(runner);
                    return;
                }

                // Benchmark the environment
                if (args.BenchmarkEnvironment)
                {
                    System.Console.Out.WriteLine("Benchmarking Environment (wait up to 2 mins)...");
                    runner.BenchmarkEnvironment();
                    System.Console.Out.WriteLine("CPU: {0}, Video: {1}, Disk: {2}",
                        runner.CpuBenchmark.ToString("0.##"), 
                        runner.VideoBenchmark.ToString("0.##"),
                        runner.DiskBenchmark.ToString("0.##")
                    );
                }

                // Configure benchmarking
                runner.Configuration.ForceContinue = args.IsForceContinue;
                runner.Configuration.MeasurementType = args.MeasurementType;
                runner.Configuration.NominalRate = args.NominalRate;
                runner.Configuration.ExecutionType = args.ExecutionType;
                runner.Configuration.Duration = args.Duration;

                // Enable benchmarks
                if (args.Benchmarks.Count == 0)
                    runner.SelectAllBenchmarks();
                else
                {
                    foreach (var benchmarkName in args.Benchmarks)
                        runner.SelectBenchmarks(benchmarkName);
                }

                // Perform benchmarking
                runner.Start();
                if (runner.Configuration.ExecutionType == ExecutionType.Proportional)
                {
                    Thread.Sleep(args.Duration);
                    runner.Stop();
                }

                if (runner.Results.Count > 0)
                    System.Console.Out.Write("{0}", runner.Results[0].PerformanceMeasurement.AverageValue);

                // Generate report
                if (args.ReportFile != null)
                {
                    using (FileStream stream = File.OpenWrite(args.ReportFile))
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                            writer.Write(runner.GenerateReport());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine("Error: {0}", ex.Message);
            }
        }


        private static void PrintBenchmarks(BenchmarkRunner runner)
        {
            System.Console.Out.WriteLine("Pip.Benchmark Console Runner. (c) Conceptual Vision Consulting LLC 2017");
            System.Console.Out.WriteLine();
            System.Console.Out.WriteLine("Loaded Benchmarks:");

            foreach (var suite in runner.Suites)
            {
                foreach (var benchmark in suite.Benchmarks)
                {
                    System.Console.Out.WriteLine("{0} - {1}", benchmark.FullName, benchmark.Description);
                }
            }
        }

        private static void PrintParameters(BenchmarkRunner runner)
        {
            System.Console.Out.WriteLine("Pip.Benchmark Console Runner. (c) Conceptual Vision Consulting LLC 2017");
            System.Console.Out.WriteLine();
            System.Console.Out.WriteLine("Configuration Parameters:");

            runner.SelectAllBenchmarks();
            foreach (var parameter in runner.Parameters.UserDefined)
            {
                var defaultValue = string.IsNullOrEmpty(parameter.DefaultValue) ? "" : " (Default: " + parameter.DefaultValue + ")";
                System.Console.Out.WriteLine("{0} - {1}{2}", parameter.Name, parameter.Description, defaultValue);
            }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            BenchmarkRunner runner = new BenchmarkRunner();
            ConsoleEventPrinter.Add(runner);

            CommandLineArgs processedArgs = new CommandLineArgs(args);
            ExecuteBatchMode(processedArgs, runner);
        }
    }
}
