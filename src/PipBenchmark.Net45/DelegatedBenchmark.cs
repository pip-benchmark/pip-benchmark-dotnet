using System;

namespace PipBenchmark
{
    public class DelegatedBenchmark : Benchmark
    {
        private Action _executeAction;

        public DelegatedBenchmark(string name, string description, Action executeAction)
            : base(name, description)
        {
            if (executeAction == null)
                throw new ArgumentNullException("executeAction");

            _executeAction = executeAction;
        }

        public override void SetUp() { }

        public override void Execute()
        {
            _executeAction();
        }

        public override void TearDown() { }
    }
}
