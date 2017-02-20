using PipBenchmark.Runner;
using System;
using System.Collections.Generic;

namespace PipBenchmark.Runner.Gui.Execution
{
    public interface IExecutionView
    {
        string StartTime { set; }
        string EndTime { set; }
        string ElapsedTime { set; }
        string MinPerformance { set; }
        string AveragePerformance { set; }
        string MaxPerformance { set; }
        string MinCpuLoad { set; }
        string AverageCpuLoad { set; }
        string MaxCpuLoad { set; }
        string MinMemoryUsage { set; }
        string AverageMemoryUsage { set; }
        string MaxMemoryUsage { set; }
        List<ExecutionResult> ExecutionResults { set; }

        int NumberOfThreads { get; set; }
        MeasurementType MeasurementType { get; set; }
        double NominalRate { get; set; }
        ExecutionType ExecutionType { get; set; }
        int Duration { get; set; }
        bool PerformanceChartEnabled { get; set; }
        string PerformanceChartName { get;  set; }
        string BenchmarkActionButton { get; set; }
        bool ShowPerformanceChart { get; set; }

        event EventHandler BenchmarkActionClicked;
        event EventHandler DataUpdated;

        void AddCurrentPerformancePoint(double currentPerformance);
        void ClearPerformancePoints();
    }
}
