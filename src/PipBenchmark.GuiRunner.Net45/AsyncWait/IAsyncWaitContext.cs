using System;
using System.Collections.Generic;
using System.Threading;

namespace PipBenchmark.Runner.Gui.AsyncWait
{
    public interface IAsyncWaitContext
    {
        object State { get; }
        object[] StateArray { get; }
        bool Aborted { get; }
        string StatusMessage { get; set; }
        object Result { get; set; }

        void UpdateUI(WaitCallback callback, object state);
    }

    public delegate void AsyncWaitCallback(IAsyncWaitContext context);
}
