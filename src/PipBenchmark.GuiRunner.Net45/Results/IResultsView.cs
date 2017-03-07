using System;
using System.Collections.Generic;

namespace PipBenchmark.Gui.Results
{
    public interface IResultsView
    {
        string ReportContent { get; set; }
        string SelectedReportContent { get; }

        event EventHandler SaveReportClicked;
        event EventHandler PrintReportClicked;
    }
}
