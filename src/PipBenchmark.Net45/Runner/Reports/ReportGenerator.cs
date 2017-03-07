﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PipBenchmark.Utilities;
using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Results;
using PipBenchmark.Runner.Config;

namespace PipBenchmark.Runner.Reports
{
    public class ReportGenerator
    {
        private const string SeparatorLine = "***************************************************************\r\n";
        private const string NewLine = "\r\n";

        public ReportGenerator(BenchmarkRunner runner)
        {
            Runner = runner;
        }

        public BenchmarkRunner Runner { get; }

        public void SaveToFile(string fileName)
        {
            using (FileStream stream = File.OpenWrite(fileName))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(Generate());
                }
            }
        }

        public string Generate()
        {
            StringBuilder builder = new StringBuilder();
            GenerateHeader(builder);
            GenerateBenchmarkList(builder);

            if (Runner.Process.Results.Count > 1)
                GenerateMultipleResults(builder);
            else
                GenerateSingleResult(builder);

            GenerateErrors(builder);

            GenerateSystemInformation(builder);
            GenerateSystemBenchmark(builder);
            GenerateParameters(builder);
            return builder.ToString();
        }

        private void GenerateHeader(StringBuilder builder)
        {
            builder.Append(SeparatorLine);
            builder.Append(NewLine);
            builder.Append("             P E R F O R M A N C E    R E P O R T");
            builder.Append(NewLine);
            builder.Append(NewLine);
            builder.Append("                 Generated by Pip.Benchmark");
            builder.Append(NewLine);
            builder.Append(string.Format("          at {0}, {1}",
                DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString()));
            builder.Append(NewLine);
            builder.Append(SeparatorLine);
            builder.Append(NewLine);
        }

        private void GenerateBenchmarkList(StringBuilder builder)
        {
            builder.Append("Executed Benchmarks:");
            builder.Append(NewLine);
            int index = 0;
            foreach (BenchmarkInstance benchmark in Runner.SuiteManager.SelectedBenchmarks)
            {
                index++;
                builder.Append(string.Format("  {0}. {1}.{2} [{3}%, {4}]",
                    index, benchmark.Suite.Name, benchmark.Name, benchmark.Proportion,
                    benchmark.Suite.Assembly.GetName().Name + ".dll"));
                builder.Append(NewLine);
            }
            builder.Append(NewLine);
        }

        private void GenerateMultipleResults(StringBuilder builder)
        {
            builder.Append("Benchmarking Results:");
            builder.Append(NewLine);

            List<BenchmarkResult> results = Runner.Process.Results;
            string[,] resultTable = new string[results.Count + 1, 4];

            // Fill column headers
            resultTable[0, 0] = "Benchmark";
            resultTable[0, 1] = "Performance (tps)";
            resultTable[0, 2] = "CPU Load (%)";
            resultTable[0, 3] = "Memory Usage (Mb)";

            int[] columnSizes = new int[] { 9, 17, 12, 17 };

            for (int index = 0; index < results.Count; index++)
            {
                resultTable[index + 1, 0] = results[index].Benchmarks[0].FullName;
                columnSizes[0] = Math.Max(resultTable[index + 1, 0].Length, columnSizes[0]);

                resultTable[index + 1, 1] = results[index].PerformanceMeasurement.AverageValue.ToString("0.##");
                columnSizes[1] = Math.Max(resultTable[index + 1, 1].Length, columnSizes[1]);

                resultTable[index + 1, 2] = results[index].CpuLoadMeasurement.AverageValue.ToString("0.##");
                columnSizes[2] = Math.Max(resultTable[index + 1, 2].Length, columnSizes[2]);

                resultTable[index + 1, 3] = results[index].MemoryUsageMeasurement.AverageValue.ToString("0.##");
                columnSizes[3] = Math.Max(resultTable[index + 1, 3].Length, columnSizes[3]);
            }

            for (int rowIndex = 0; rowIndex < results.Count + 1; rowIndex++)
            {
                // Draw upper line
                if (rowIndex == 0)
                {
                    builder.Append('+');
                    for (int columnIndex = 0; columnIndex < 4; columnIndex++)
                    {
                        builder.Append(Formatter.PadRight("", columnSizes[columnIndex], "-"));
                        builder.Append('+');
                    }
                    builder.Append(NewLine);
                }

                // Draw content
                builder.Append('|');
                builder.Append(Formatter.PadRight(resultTable[rowIndex, 0], columnSizes[0], " "));
                builder.Append('|');
                builder.Append(Formatter.PadLeft(resultTable[rowIndex, 1], columnSizes[1], " "));
                builder.Append('|');
                builder.Append(Formatter.PadLeft(resultTable[rowIndex, 2], columnSizes[2], " "));
                builder.Append('|');
                builder.Append(Formatter.PadLeft(resultTable[rowIndex, 3], columnSizes[3], " "));
                builder.Append('|');
                builder.Append(NewLine);

                // Draw bottom line
                builder.Append('+');
                for (int columnIndex = 0; columnIndex < 4; columnIndex++)
                {
                    builder.Append(Formatter.PadRight("", columnSizes[columnIndex], "-"));
                    builder.Append('+');
                }
                builder.Append(NewLine);
            }

            builder.Append(NewLine);
        }

        private void GenerateSingleResult(StringBuilder builder)
        {
            if (Runner.Process.Results.Count == 0)
            {
                return;
            }
            BenchmarkResult result = Runner.Process.Results[0];

            builder.Append("Benchmarking Results:");
            builder.Append(NewLine);
            if (Runner.Process.MeasurementType == MeasurementType.Peak)
            {
                builder.Append("  Measurement Type: Peak performance");
            }
            else
            {
                builder.Append(string.Format("  Measurement Type: Nominal rate at {0} tps",
                    Runner.Process.NominalRate));
            }
            builder.Append(NewLine);

            builder.Append(string.Format("  Start Time:   {0}", result.StartTime.ToLongTimeString()));
            builder.Append(NewLine);
            DateTime endTime = result.StartTime.Add(result.ElapsedTime);
            builder.Append(string.Format("  End Time:     {0}", endTime.ToLongTimeString()));
            builder.Append(NewLine);
            builder.Append(string.Format("  Elapsed Time: {0}", result.ElapsedTime.ToString()));
            builder.Append(NewLine);
            builder.Append(string.Format("  Min Performance (tps):     {0}",
                result.PerformanceMeasurement.MinValue.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Average Performance (tps): {0}",
                result.PerformanceMeasurement.AverageValue.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Max Performance (tps):     {0}",
                result.PerformanceMeasurement.MaxValue.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Min CPU Load (%):          {0}",
                result.CpuLoadMeasurement.MinValue.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Average CPU Load (%):      {0}",
                result.CpuLoadMeasurement.AverageValue.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Max CPU Load (%):          {0}",
                result.CpuLoadMeasurement.MaxValue.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Min Memory Usage (Mb):     {0}",
                result.MemoryUsageMeasurement.MinValue.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Average Memory Usage (Mb): {0}",
                result.MemoryUsageMeasurement.AverageValue.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Max Memory Usage (Mb):     {0}",
                result.MemoryUsageMeasurement.MaxValue.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(NewLine);
        }

        private void GenerateErrors(StringBuilder builder)
        {
            var addedErrors = false;

            foreach (var result in Runner.Process.Results)
            {
                if (result.Errors.Count == 0)
                    continue;

                if (addedErrors == false)
                {
                    builder.Append("Errors:");
                    builder.Append(NewLine);

                    addedErrors = true;
                }

                foreach (var error in result.Errors)
                {
                    builder.Append(error);
                    builder.Append(NewLine);
                }
            }

            if (addedErrors)
                builder.Append(NewLine);
        }

        private void GenerateSystemInformation(StringBuilder builder)
        {
            builder.Append("System Information:");
            builder.Append(NewLine);
            foreach (KeyValuePair<string, string> pair in Runner.EnvironmentState.SystemInformation)
            {
                builder.Append(string.Format("  {0}: {1}", pair.Key, pair.Value));
                builder.Append(NewLine);
            }
            builder.Append(NewLine);
        }

        private void GenerateSystemBenchmark(StringBuilder builder)
        {
            builder.Append("System Benchmarking:");
            builder.Append(NewLine);
            builder.Append(string.Format("  CPU Performance (MFLOP/s): {0}",
                Runner.EnvironmentState.CpuBenchmark.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Video Performance (GOP/s): {0}",
                Runner.EnvironmentState.VideoBenchmark.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(string.Format("  Disk Performance (MB/s):   {0}",
                Runner.EnvironmentState.DiskBenchmark.ToString("0.##")));
            builder.Append(NewLine);
            builder.Append(NewLine);
        }

        private void GenerateParameters(StringBuilder builder)
        {
            builder.Append("Parameters:");
            builder.Append(NewLine);
            foreach (Parameter parameter in Runner.ConfigurationManager.AllParameters)
            {
                builder.Append(string.Format("  {0}={1}", parameter.Name, parameter.Value));
                builder.Append(NewLine);
            }
            builder.Append(NewLine);
        }
    }
}
