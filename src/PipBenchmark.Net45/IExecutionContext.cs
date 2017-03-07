using System.Collections.Generic;

namespace PipBenchmark
{
    public interface IExecutionContext
    {
        Dictionary<string, Parameter> Parameters { get; }

        void IncrementCounter();
        void IncrementCounter(int value);

        void SendMessage(string message);
        void ReportError(string errorMessage);

        bool IsStopped { get; }
        void Stop();
    }
}
