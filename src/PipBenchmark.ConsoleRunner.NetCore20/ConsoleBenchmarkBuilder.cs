using PipBenchmark.Runner;
using PipBenchmark.Runner.Console;

namespace PipBenchmark.Console
{
    public class ConsoleBenchmarkBuilder: BenchmarkBuilder
    {
        public BenchmarkBuilder ConfigureWithArgs(string[] args)
        {
            CommandLineArgs processedArgs = new CommandLineArgs(args);

            // Load modules
            foreach (string assemblyFile in processedArgs.Assemblies)
                _runner.Benchmarks.AddSuitesFromAssembly(assemblyFile);
            // Load test suites classes
            foreach (var className in processedArgs.Classes)
                this._runner.Benchmarks.AddSuiteFromClass(className);
            // Load configuration
            if (processedArgs.ConfigurationFile != null)
                _runner.Parameters.LoadFromFile(processedArgs.ConfigurationFile);
            // Set parameters
            if (processedArgs.Parameters.Count > 0)
                _runner.Parameters.Set(processedArgs.Parameters);
            // Select benchmarks
            if (processedArgs.Benchmarks.Count == 0)
                this._runner.Benchmarks.SelectAll();
            else
                this._runner.Benchmarks.SelectByName(processedArgs.Benchmarks.ToArray());
            // Configure benchmarking
            _runner.Configuration.ForceContinue = processedArgs.IsForceContinue;
            _runner.Configuration.MeasurementType = processedArgs.MeasurementType;
            _runner.Configuration.NominalRate = processedArgs.NominalRate;
            _runner.Configuration.ExecutionType = processedArgs.ExecutionType;
            _runner.Configuration.Duration = processedArgs.Duration;

            return this;
        }

        public override BenchmarkRunner Create()
        {
            _runner = base.Create();
            ConsoleEventPrinter.Add(_runner);
            return _runner;
        }
    }
}