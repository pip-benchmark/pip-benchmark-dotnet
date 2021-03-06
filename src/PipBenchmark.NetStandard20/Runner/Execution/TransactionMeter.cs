﻿namespace PipBenchmark.Runner.Execution
{
    public class TransactionMeter : BenchmarkMeter
    {
        private double _counter;
        private int _lastMeasuredTicks = 0;

        public int LastMeasuredTicks => _lastMeasuredTicks;

        public void IncrementCounter()
        {
            _counter++;
        }

        public void SetTransactionCounter(double value)
        {
            _counter = value;
        }

        protected override double PerformMeasurement()
        {
            int currentTicks = System.Environment.TickCount;
            double durationInMsecs = currentTicks - _lastMeasuredTicks;
            double result = _counter * 1000 / durationInMsecs;
            _lastMeasuredTicks = currentTicks;
            _counter = 0;
            return result;
        }
    }
}
