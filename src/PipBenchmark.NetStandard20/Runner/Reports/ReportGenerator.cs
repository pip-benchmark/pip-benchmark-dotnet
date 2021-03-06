﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using PipBenchmark.Utilities;
using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Results;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Environment;
using PipBenchmark.Runner.Parameters;

namespace PipBenchmark.Runner.Reports
{
    public class ReportGenerator
    {
        private const string SeparatorLine = "***************************************************************\r\n";
        private const string NewLine = "\r\n";

        private ConfigurationManager _configuration;
        private ResultsManager _results;
        private ParametersManager _parameters;
        private BenchmarksManager _benchmarks;
        private EnvironmentManager _environment;

        public ReportGenerator(ConfigurationManager configuration,
            ResultsManager results, ParametersManager parameters,
            BenchmarksManager benchmarks, EnvironmentManager environment)
        {
            _configuration = configuration;
            _results = results;
            _parameters = parameters;
            _benchmarks = benchmarks;
            _environment = environment;
        }

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

            if (_results.All.Count > 1)
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
            builder.Append($"          at {DateTime.Now.ToLongDateString()}, {DateTime.Now.ToLongTimeString()}");
            builder.Append(NewLine);
            builder.Append(SeparatorLine);
            builder.Append(NewLine);
        }

        private void GenerateBenchmarkList(StringBuilder builder)
        {
            builder.Append("Executed Benchmarks:");
            builder.Append(NewLine);
            int index = 0;
            foreach (BenchmarkInstance benchmark in _benchmarks.Selected)
            {
                index++;
                builder.Append($"  {index}. {benchmark.Suite.Name}.{benchmark.Name} [{benchmark.Proportion}%]");
                builder.Append(NewLine);
            }
            builder.Append(NewLine);
        }

        private void GenerateMultipleResults(StringBuilder builder)
        {
            builder.Append("Benchmarking Results:");
            builder.Append(NewLine);

            List<BenchmarkResult> results = _results.All;
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
            if (_results.All.Count == 0)
            {
                return;
            }
            BenchmarkResult result = _results.All[0];

            builder.Append("Benchmarking Results:");
            builder.Append(NewLine);
            if (_configuration.MeasurementType == MeasurementType.Peak)
            {
                builder.Append("  Measurement Type: Peak performance");
            }
            else
            {
                builder.Append($"  Measurement Type: Nominal rate at {_configuration.NominalRate} tps");
            }
            builder.Append(NewLine);

            builder.Append($"  Start Time:   {result.StartTime.ToLongTimeString()}");
            builder.Append(NewLine);
            DateTime endTime = result.StartTime.Add(result.ElapsedTime);
            builder.Append($"  End Time:     {endTime.ToLongTimeString()}");
            builder.Append(NewLine);
            builder.Append($"  Elapsed Time: {result.ElapsedTime.ToString()}");
            builder.Append(NewLine);
            builder.Append($"  Min Performance (tps):     {result.PerformanceMeasurement.MinValue:0.##}");
            builder.Append(NewLine);
            builder.Append(
                $"  Average Performance (tps): {result.PerformanceMeasurement.AverageValue:0.##}");
            builder.Append(NewLine);
            builder.Append($"  Max Performance (tps):     {result.PerformanceMeasurement.MaxValue:0.##}");
            builder.Append(NewLine);
            builder.Append($"  Min CPU Load (%):          {result.CpuLoadMeasurement.MinValue:0.##}");
            builder.Append(NewLine);
            builder.Append($"  Average CPU Load (%):      {result.CpuLoadMeasurement.AverageValue:0.##}");
            builder.Append(NewLine);
            builder.Append($"  Max CPU Load (%):          {result.CpuLoadMeasurement.MaxValue:0.##}");
            builder.Append(NewLine);
            builder.Append($"  Min Memory Usage (Mb):     {result.MemoryUsageMeasurement.MinValue:0.##}");
            builder.Append(NewLine);
            builder.Append(
                $"  Average Memory Usage (Mb): {result.MemoryUsageMeasurement.AverageValue:0.##}");
            builder.Append(NewLine);
            builder.Append($"  Max Memory Usage (Mb):     {result.MemoryUsageMeasurement.MaxValue:0.##}");
            builder.Append(NewLine);
            builder.Append(NewLine);
        }

        private void GenerateErrors(StringBuilder builder)
        {
            var addedErrors = false;

            foreach (var result in _results.All)
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
            foreach (KeyValuePair<string, string> pair in _environment.SystemInfo)
            {
                builder.Append($"  {pair.Key}: {pair.Value}");
                builder.Append(NewLine);
            }
            builder.Append(NewLine);
        }

        private void GenerateSystemBenchmark(StringBuilder builder)
        {
            builder.Append("System Benchmarking:");
            builder.Append(NewLine);
            builder.Append($"  CPU Performance (MFLOP/s): {_environment.CpuMeasurement:0.##}");
            builder.Append(NewLine);
            builder.Append($"  Video Performance (GOP/s): {_environment.VideoMeasurement:0.##}");
            builder.Append(NewLine);
            builder.Append($"  Disk Performance (MB/s):   {_environment.DiskMeasurement:0.##}");
            builder.Append(NewLine);
            builder.Append(NewLine);
        }

        private void GenerateParameters(StringBuilder builder)
        {
            builder.Append("Parameters:");
            builder.Append(NewLine);
            foreach (Parameter parameter in _parameters.All)
            {
                builder.Append($"  {parameter.Name}={parameter.Value}");
                builder.Append(NewLine);
            }
            builder.Append(NewLine);
        }
    }
}
