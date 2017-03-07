using System;
using System.Collections.Generic;
using System.Windows.Forms;

using PipBenchmark.Gui.Initialization;
using PipBenchmark.Gui.Config;
using PipBenchmark.Gui.Execution;
using PipBenchmark.Gui.Results;
using PipBenchmark.Gui.Environment;

namespace PipBenchmark.Gui.Shell
{
    public interface IMainView
    {
        Form Handler { get; }
        string FormTitle { set; }
        string StatusMessage { set; }
        string SelectedView { get; set; }

        IInitializationView InitializationView { get; }
        IConfigurationView ConfigurationView { get; }
        IExecutionView ExecutionView { get; }
        IResultsView ResultsView { get; }
        IEnvironmentView EnvironmentView { get; }

        event EventHandler LoadTestSuiteClicked;
        event EventHandler LoadConfigurationClicked;
        event EventHandler SaveConfigurationClicked;
        event EventHandler PrintReportClicked;
        event EventHandler SaveReportClicked;
        event EventHandler StartBenchmarkingClicked;
        event EventHandler StopBenchmarkingClicked;
        event EventHandler UpdateSystemBenchmarkClicked;
        event EventHandler AboutClicked;
        event EventHandler ExitClicked;
        event EventHandler FormExited;

        event EventHandler ConfigurationViewActivated;
    }
}
