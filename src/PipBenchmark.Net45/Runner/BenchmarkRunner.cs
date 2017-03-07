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
        private BenchmarkSuiteManager _suiteManager;
        private ParametersManager _configurationManager;
        private ExecutionManager _process;
        private ReportGenerator _reportGenerator;
        private EnvironmentState _environmentState;

        public BenchmarkRunner()
        {
            _suiteManager = new BenchmarkSuiteManager(this);
            _process = new ExecutionManager(this);
            _configurationManager = new ParametersManager(this);
            _reportGenerator = new ReportGenerator(this);
            _environmentState = new EnvironmentState(this);
        }

        public ParametersManager ConfigurationManager
        {
            get { return _configurationManager; }
        }

        public ExecutionManager Process
        {
            get { return _process; }
        }

        public BenchmarkSuiteManager SuiteManager
        {
            get { return _suiteManager; }
        }

        public ReportGenerator ReportGenerator
        {
            get { return _reportGenerator; }
        }

        public EnvironmentState EnvironmentState
        {
            get { return _environmentState; }
        }

        public List<BenchmarkSuiteInstance> Suites
        {
            get { return SuiteManager.Suites; }
        }

        public void AddSuiteFromClass(string suiteClassName)
        {
            SuiteManager.AddSuiteFromClass(suiteClassName);
        }

        public void AddSuite(BenchmarkSuite suite)
        {
            SuiteManager.AddSuite(suite);
        }

        public void AddSuite(BenchmarkSuiteInstance suite)
        {
            SuiteManager.AddSuite(suite);
        }

        public void LoadSuitesFromAssembly(string assemblyName)
        {
            SuiteManager.LoadSuitesFromAssembly(assemblyName);
        }

        public void RemoveSuite(string suiteName)
        {
            SuiteManager.RemoveSuite(suiteName);
        }

        public void RemoveSuite(BenchmarkSuite suite)
        {
            SuiteManager.RemoveSuite(suite);
        }

        public void RemoveSuite(BenchmarkSuiteInstance suite)
        {
            SuiteManager.RemoveSuite(suite);
        }

        public void RemoveAllSuites()
        {
            SuiteManager.RemoveAllSuites();
        }

        public void SelectAllBenchmarks()
        {
            SuiteManager.SelectAllBenchmarks();
        }

        public void SelectBenchmarks(params string[] benchmarkNames)
        {
            SuiteManager.SelectBenchmarks(benchmarkNames);
        }

        public void SelectBenchmarks(params Benchmark[] benchmarks)
        {

            SuiteManager.SelectBenchmarks(benchmarks);
        }

        public List<Parameter> Configuration
        {
            get { return ConfigurationManager.FilteredParameters; }
        }

        public void LoadConfigurationFromFile(string fileName)
        {
            ConfigurationManager.LoadConfigurationFromFile(fileName);
        }

        public void SaveConfigurationToFile(string fileName)
        {
            ConfigurationManager.SaveConfigurationToFile(fileName);
        }

        public void SetConfigurationToDefault()
        {
            ConfigurationManager.SetConfigurationToDefault();
        }

        public void SetConfiguration(Dictionary<string, string> parameters)
        {
            ConfigurationManager.SetConfiguration(parameters);
        }

        public event EventHandler ConfigurationUpdated
        {
            add { ConfigurationManager.ConfigurationUpdated += value; }
            remove { ConfigurationManager.ConfigurationUpdated -= value; }
        }

        public int NumberOfThreads
        {
            get { return Process.NumberOfThreads; }
            set { Process.NumberOfThreads = value; }
        }

        public MeasurementType MeasurementType
        {
            get { return Process.MeasurementType; }
            set { Process.MeasurementType = value; }
        }

        public double NominalRate
        {
            get { return Process.NominalRate; }
            set { Process.NominalRate = value; }
        }

        public ExecutionType ExecutionType
        {
            get { return Process.ExecutionType; }
            set { Process.ExecutionType = value; }
        }

        public int Duration
        {
            get { return Process.Duration; }
            set { Process.Duration = value; }
        }

        public bool IsForceContinue
        {
            get { return Process.IsForceContinue; }
            set { Process.IsForceContinue = value; }
        }

        public List<BenchmarkResult> Results
        {
            get { return Process.Results; }
        }

        public event EventHandler<ResultEventArgs> ResultUpdated
        {
            add { Process.ResultUpdated += value; }
            remove { Process.ResultUpdated -= value; }
        }

        public event EventHandler<MessageEventArgs> MessageSent
        {
            add { Process.MessageSent += value; }
            remove { Process.MessageSent -= value; }
        }

        public event EventHandler<MessageEventArgs> ErrorReported
        {
            add { Process.ErrorReported += value; }
            remove { Process.ErrorReported -= value; }
        }

        public bool IsRunning
        {
            get { return Process.IsRunning; }
        }

        public void Start()
        {
            Process.Start(SuiteManager.Suites);
        }

        public void Stop()
        {
            Process.Stop();
        }

        public void Run()
        {
            Start();

            var duration = Process.Duration;
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
            return ReportGenerator.Generate();
        }

        public void SaveReportToFile(string fileName)
        {
            ReportGenerator.SaveToFile(fileName);
        }

        public IDictionary<string, string> SystemInformation
        {
            get { return EnvironmentState.SystemInformation; }
        }

        public double CpuBenchmark
        {
            get { return EnvironmentState.CpuBenchmark; }
        }

        public double VideoBenchmark
        {
            get { return EnvironmentState.VideoBenchmark; }
        }

        public double DiskBenchmark
        {
            get { return EnvironmentState.DiskBenchmark; }
        }

        public void BenchmarkEnvironment(bool cpu = true, bool disk = true, bool video = true)
        {
            EnvironmentState.BenchmarkEnvironment(cpu, disk, video);
        }

    }
}
