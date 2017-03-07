using PipBenchmark.Runner;
using PipBenchmark.Runner.Benchmarks;
using System;
using System.Collections.Generic;

namespace PipBenchmark.Gui.Benchmarks
{
    public interface IBenchmarksView
    {
        List<BenchmarkSuiteInstance> AllSuites { get; set; }
        List<BenchmarkSuiteInstance> SelectedSuites { get; }
        List<BenchmarkInstance> AllBenchmarks { get; set; }
        List<BenchmarkInstance> SelectedBenchmarks { get; }

        event EventHandler SuiteSelectedChanged;
        event EventHandler LoadSuiteClicked;
        event EventHandler UnloadSuiteClicked;
        event EventHandler UnloadSuitesClicked;
        event EventHandler SelectBenchmarkClicked;
        event EventHandler SelectAllBenchmarksClicked;
        event EventHandler UnselectBenchmarkClicked;
        event EventHandler UnselectAllBenchmarksClicked;

        void RefreshData();
    }
}
