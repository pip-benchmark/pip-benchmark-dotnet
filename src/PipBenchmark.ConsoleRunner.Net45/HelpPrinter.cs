using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipBenchmark.Console
{
    public static class HelpPrinter
    {
        public static void Print()
        {
            System.Console.Out.WriteLine("Pip.Benchmark Console Runner. (c) Conceptual Vision Consulting LLC 2017");
            System.Console.Out.WriteLine();
            System.Console.Out.WriteLine("Command Line Parameters:");
            System.Console.Out.WriteLine("-a <assembly>    - Assembly with benchmarks to be loaded. You may include multiple assemblies");
            System.Console.Out.WriteLine("-p <param>=<value> - Set parameter value. You may include multiple parameters");
            System.Console.Out.WriteLine("-b <benchmark>   - Name of benchmark to be executed. You may include multiple benchmarks");
            System.Console.Out.WriteLine("-c <config file> - File with configuration parameters to be loaded");
            System.Console.Out.WriteLine("-r <report file> - File to save benchmarking report");
            System.Console.Out.WriteLine("-d <seconds>     - Benchmarking duration in seconds");
            System.Console.Out.WriteLine("-h               - Display this help screen");
            System.Console.Out.WriteLine("-B               - Show all available benchmarks");
            System.Console.Out.WriteLine("-P               - Show all available parameters");
            System.Console.Out.WriteLine("-e               - Benchmark environment");
            System.Console.Out.WriteLine("-x [proportional|sequencial] - Execution type: Proportional or Sequencial");
            System.Console.Out.WriteLine("-m [peak|nominal] - Measurement type: Peak or Nominal");
            System.Console.Out.WriteLine("-n <rate>        - Nominal rate in transactions per second");
        }
    }
}
