using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Environment;
using PipBenchmark.Runner.Execution;
using PipBenchmark.Runner.Parameters;
using PipBenchmark.Runner.Reports;
using PipBenchmark.Runner.Results;
using System.Collections.Generic;

namespace PipBenchmark.Runner
{
    public class BenchmarkRunner
    {
        private ConfigurationManager _configuration;
        private ResultsManager _results;
        private ParametersManager _parameters;
        private BenchmarksManager _benchmarks;
        private ExecutionManager _execution;
        private ReportGenerator _report;
        private EnvironmentManager _environment;

        public BenchmarkRunner()
        {
            _configuration = new ConfigurationManager();
            _parameters = new ParametersManager(_configuration);
            _results = new ResultsManager();
            _benchmarks = new BenchmarksManager(_parameters);
            _execution = new ExecutionManager(_configuration, _results);
            _environment = new EnvironmentManager();
            _report = new ReportGenerator(_configuration, _results, _parameters,
                _benchmarks, _environment);
        }

        public ConfigurationManager Configuration
        {
            get { return _configuration; }
        }

        public ParametersManager Parameters
        {
            get { return _parameters; }
        }

        public ResultsManager Results
        {
            get { return _results; }
        }

        public ExecutionManager Execution
        {
            get { return _execution; }
        }

        public BenchmarksManager Benchmarks
        {
            get { return _benchmarks; }
        }

        public ReportGenerator Report
        {
            get { return _report; }
        }

        public EnvironmentManager Environment
        {
            get { return _environment; }
        }

        public List<BenchmarkSuiteInstance> Suites
        {
            get { return Benchmarks.Suites; }
        }

        public bool IsRunning
        {
            get { return Execution.IsRunning; }
        }

        public void Start()
        {
            Execution.Start(Benchmarks.Selected);
        }

        public void Stop()
        {
            Execution.Stop();
        }

        public void Run()
        {
            Execution.Run(Benchmarks.Selected);
        }

    }
}
