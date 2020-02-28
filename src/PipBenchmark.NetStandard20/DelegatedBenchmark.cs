using System;

namespace PipBenchmark
{
    public class DelegatedBenchmark : Benchmark
    {
        private readonly Action _executeAction;

        public DelegatedBenchmark(string name, string description, Action executeAction)
            : base(name, description)
        {
            _executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
        }

        public override void Execute()
        {
            _executeAction();
        }
    }
}
