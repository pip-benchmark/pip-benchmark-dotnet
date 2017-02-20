namespace PipBenchmark.Runner.Gui
{
    public static class HelpPrinter
    {
        public static void Print()
        {
            System.Console.Out.WriteLine("Pip.Benchmark GUI Runner. (c) Conceptual Vision Consulting LLC 2017");
            System.Console.Out.WriteLine();
            System.Console.Out.WriteLine("Command Line Parameters:");
            System.Console.Out.WriteLine("-a <assembly>    - Assembly with test suite(s) to be loaded. You may include multiple assemblies");
            System.Console.Out.WriteLine("-p <param>=value> - Name of benchmark to be executed. You may include multiple parameters");
            System.Console.Out.WriteLine("-b <benchmark>   - Name of benchmark to be executed. You may include multiple benchmarks");
            System.Console.Out.WriteLine("-c <config file> - File with configuration parameters to be loaded");
            System.Console.Out.WriteLine("-r <report file> - File to save benchmarking report");
            System.Console.Out.WriteLine("-d <seconds>     - Benchmarking time specified in seconds");
            System.Console.Out.WriteLine("-h               - Display this help screen");
            System.Console.Out.WriteLine("-e               - Benchmark environment");
            System.Console.Out.WriteLine("-x [proportional|sequencial] - Execution type");
            System.Console.Out.WriteLine("-m [pick|nominal] - Measurement type: Peak or Nominal");
            System.Console.Out.WriteLine("-n <rate>        - Nominal performance in transactions per second");
            System.Console.Out.WriteLine("--batch          - Run in batch mode same as Console runner");
        }
    }
}
