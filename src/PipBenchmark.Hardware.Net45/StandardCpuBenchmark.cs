using System;
using System.Collections.Generic;

namespace PipBenchmark.Hardware
{
    public class StandardCpuBenchmark : Benchmark
    {
        private const int NumberOfAttempts = 2000;

        public StandardCpuBenchmark()
            : base("CPU", "Measures CPU speed by running arythmetical operations")
        {
        }

        public override void Execute()
        {
            // Count increment, comparison and goto for 1 arithmetic operation
            for (double value = 0; value < NumberOfAttempts; value++)
            {
                double result1 = value + value;
                double result2 = result1 - value;
                double result3 = result1 * result2;
                double result4 = result2 / result3;
                Math.Log(result4);
            }
        }
    }
}
