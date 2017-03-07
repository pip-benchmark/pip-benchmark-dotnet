using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PipBenchmark.Gui.AsyncWait
{
    public interface IAsyncWaitView
    {
        string Title { set; }
        string StatusMessage { get; set; }

        event EventHandler AbortClicked;

        void Show(Form parentForm);
        void Close();
    }
}
