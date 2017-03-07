using PipBenchmark.Runner.Parameters;
using PipBenchmark.Runner.Environment;
using PipBenchmark.Runner.Execution;
using PipBenchmark.Runner.Reports;

using System;
using System.Collections.Generic;
using System.Threading;
using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Config;
using PipBenchmark.Runner.Results;

namespace PipBenchmark.Runner
{
    public class BenchmarkRunner
    {
        private ConfigurationManager _configuration;
        private BenchmarksManager _benchmarks;
        private ParametersManager _parameters;
        private ExecutionManager _execution;
        private ReportGenerator _report;
        private EnvironmentState _environment;

        public BenchmarkRunner()
        {
            _configuration = new ConfigurationManager();
            _parameters = new ParametersManager(_configuration);
            _benchmarks = new BenchmarksManager(this);
            _execution = new ExecutionManager(_configuration, this);
            _report = new ReportGenerator(this);
            _environment = new EnvironmentState(this);
        }

        public ConfigurationManager Configuration
        {
            get { return _configuration; }
        }

        public ParametersManager Parameters
        {
            get { return _parameters; }
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

        public EnvironmentState Environment
        {
            get { return _environment; }
        }

        public List<BenchmarkSuiteInstance> Suites
        {
            get { return Benchmarks.Suites; }
        }

        public void AddSuiteFromClass(string suiteClassName)
        {
            Benchmarks.AddSuiteFromClass(suiteClassName);
        }

        public void AddSuite(BenchmarkSuite suite)
        {
            Benchmarks.AddSuite(suite);
        }

        public void AddSuite(BenchmarkSuiteInstance suite)
        {
            Benchmarks.AddSuite(suite);
        }

        public void LoadSuitesFromAssembly(string assemblyName)
        {
            Benchmarks.LoadSuitesFromAssembly(assemblyName);
        }

        public void RemoveSuite(string suiteName)
        {
            Benchmarks.RemoveSuite(suiteName);
        }

        public void RemoveSuite(BenchmarkSuite suite)
        {
            Benchmarks.RemoveSuite(suite);
        }

        public void RemoveSuite(BenchmarkSuiteInstance suite)
        {
            Benchmarks.RemoveSuite(suite);
        }

        public void RemoveAllSuites()
        {
            Benchmarks.RemoveAllSuites();
        }

        public void SelectAllBenchmarks()
        {
            Benchmarks.SelectAllBenchmarks();
        }

        public void SelectBenchmarks(params string[] benchmarkNames)
        {
            Benchmarks.SelectBenchmarks(benchmarkNames);
        }

        public void SelectBenchmarks(params Benchmark[] benchmarks)
        {
            Benchmarks.SelectBenchmarks(benchmarks);
        }

        public List<BenchmarkResult> Results
        {
            get { return Execution.Results; }
        }

        public event EventHandler<ResultEventArgs> ResultUpdated
        {
            add { Execution.ResultUpdated += value; }
            remove { Execution.ResultUpdated -= value; }
        }

        public event EventHandler<MessageEventArgs> MessageSent
        {
            add { Execution.MessageSent += value; }
            remove { Execution.MessageSent -= value; }
        }

        public event EventHandler<MessageEventArgs> ErrorReported
        {
            add { Execution.ErrorReported += value; }
            remove { Execution.ErrorReported -= value; }
        }

        public bool IsRunning
        {
            get { return Execution.IsRunning; }
        }

        public void Start()
        {
            Execution.Start(Benchmarks.Suites);
        }

        public void Stop()
        {
            Execution.Stop();
        }

        public void Run()
        {
            Start();

            var duration = _configuration.Duration;
            var lastTick = System.Environment.TickCount + duration;
            while (IsRunning)
            {
                if (duration > 0 && System.Environment.TickCount >= lastTick)
                    break;

                Thread.Sleep(500);
            }

            Stop();
        }

        public string GenerateReport()
        {
            return Report.Generate();
        }

        public void SaveReportToFile(string fileName)
        {
            Report.SaveToFile(fileName);
        }

        public IDictionary<string, string> SystemInformation
        {
            get { return Environment.SystemInformation; }
        }

        public double CpuBenchmark
        {
            get { return Environment.CpuBenchmark; }
        }

        public double VideoBenchmark
        {
            get { return Environment.VideoBenchmark; }
        }

        public double DiskBenchmark
        {
            get { return Environment.DiskBenchmark; }
        }

        public void BenchmarkEnvironment(bool cpu = true, bool disk = true, bool video = true)
        {
            Environment.BenchmarkEnvironment(cpu, disk, video);
        }

    }
}
