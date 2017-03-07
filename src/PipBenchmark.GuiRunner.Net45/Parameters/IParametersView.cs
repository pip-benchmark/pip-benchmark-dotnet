using System;
using System.Collections.Generic;

namespace PipBenchmark.Gui.Parameters
{
    public interface IParametersView
    {
        List<Parameter> Data { set; }

        event EventHandler LoadClicked;
        event EventHandler SaveClicked;
        event EventHandler SetToDefaultClicked;

        void RefreshData();
    }
}
