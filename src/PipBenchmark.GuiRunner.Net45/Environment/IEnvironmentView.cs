using System;
using System.Collections.Generic;

namespace PipBenchmark.Runner.Gui.Environment
{
    public interface IEnvironmentView
    {
        List<EnvironmentParameter> SystemInformation { set; }
        string CpuPerformance { set; }
        string VideoPerformance { set; }
        string DiskPerformance { set; }

        event EventHandler UpdateSystemBenchmarkClicked;
    }
}
