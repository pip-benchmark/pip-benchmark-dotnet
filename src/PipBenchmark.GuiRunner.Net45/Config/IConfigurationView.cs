using System;
using System.Collections.Generic;

namespace PipBenchmark.Gui.Config
{
    public interface IConfigurationView
    {
        List<Parameter> Configuration { set; }

        event EventHandler LoadConfigurationClicked;
        event EventHandler SaveConfigurationClicked;
        event EventHandler SetToDefaultClicked;

        void RefreshData();
    }
}
