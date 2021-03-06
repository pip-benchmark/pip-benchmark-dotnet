﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using PipBenchmark.Gui;
using PipBenchmark.Gui.Shell;
using PipBenchmark.Runner;
using PipBenchmark.Runner.Config;

namespace PipBenchmark.Gui
{
    static class Program
    {
        private static bool ExecuteBatchMode(CommandLineArgs args, BenchmarkRunner runner)
        {
            try
            {
                if (args.ShowHelp)
                {
                    HelpPrinter.Print();
                    return true;
                }

                // Load assemblies
                foreach (string assemblyFile in args.Assemblies)
                    runner.Benchmarks.AddSuitesFromAssembly(assemblyFile);

                // Load configuration
                if (args.ConfigurationFile != null)
                    runner.Parameters.LoadFromFile(args.ConfigurationFile);

                // Set parameters
                if (args.Parameters.Count > 0)
                    runner.Parameters.Set(args.Parameters);

                if (args.BatchMode)
                {
                    // Benchmark the environment
                    if (args.BenchmarkEnvironment)
                        runner.Environment.Measure(true, true, true);

                    // Configure benchmarking
                    runner.Configuration.MeasurementType = args.MeasurementType;
                    runner.Configuration.NominalRate = args.NominalRate;
                    runner.Configuration.ExecutionType = args.ExecutionType;
                    runner.Configuration.Duration = args.Duration;

                    // Perform benchmarking
                    runner.Start();

                    if (runner.Configuration.ExecutionType == ExecutionType.Proportional)
                    {
                        Thread.Sleep(args.Duration);
                        runner.Stop();
                    }

                    if (runner.Results.All.Count > 0)
                        System.Console.Out.Write("{0}", runner.Results.All[0].PerformanceMeasurement.AverageValue);

                    // Generate report
                    if (args.ReportFile != null)
                        File.WriteAllText(args.ReportFile, runner.Report.Generate());

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Found", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                System.Console.Out.WriteLine("Error: {0}", ex.Message);
                return true;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BenchmarkRunner runner = new BenchmarkRunner();
            CommandLineArgs processedArgs = new CommandLineArgs(args);

            if (!ExecuteBatchMode(processedArgs, runner))
            {
                MainForm mainForm = new MainForm();
                MainController mainController = new MainController(mainForm, runner);
                Application.Run(mainForm);
            }
        }
    }
}
