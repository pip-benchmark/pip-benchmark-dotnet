using System;
using PipBenchmark.Console;
using PipBenchmark.Runner.Console;

namespace PipBenchmark.Builder.Builders
{
    public class ArgsBenchmarkBuilder: BenchmarkBuilder
    {
        public ArgsBenchmarkBuilder()
        {
            WithParams();
            
            ConsoleEventPrinter.Add(_runner);
            _runner.Results.Updated -= ConsoleEventPrinter.OnResultUpdated;
        }

        public ArgsBenchmarkBuilder WithArgs(string[] args)
        {
            CommandLineArgs processedArgs = new CommandLineArgs(args);
            
                if (processedArgs.ShowHelp)
                {
                    HelpPrinter.Print();
                    return this;
                }

                // Load assemblies
                foreach (string assemblyFile in processedArgs.Assemblies)
                    _runner.Benchmarks.AddSuitesFromAssembly(assemblyFile);

                // Load configuration
                if (processedArgs.ConfigurationFile != null)
                    _runner.Parameters.LoadFromFile(processedArgs.ConfigurationFile);

                // Set parameters
                if (processedArgs.Parameters.Count > 0)
                    _runner.Parameters.Set(processedArgs.Parameters);


                // Configure benchmarking
                _runner.Configuration.ForceContinue = processedArgs.IsForceContinue;
                _runner.Configuration.MeasurementType = processedArgs.MeasurementType;
                _runner.Configuration.NominalRate = processedArgs.NominalRate;
                _runner.Configuration.ExecutionType = processedArgs.ExecutionType;
                
                return this;
        }
    }
}