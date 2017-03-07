using PipBenchmark.Runner;
using PipBenchmark.Runner.Config;
using PipBenchmark.Utilities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PipBenchmark.Console
{
    public class CommandLineArgs
    {
        private List<string> _assemblies = new List<string>();
        private List<string> _benchmarks = new List<string>();
        private Dictionary<string, string> _parameters = new Dictionary<string, string>();
        private string _configurationFile;
        private string _reportFile = string.Format("BenchmarkReport.txt");
        private int _duration = Timeout.Infinite;
        private bool _showHelp = false;
        private bool _showBenchmarks = false;
        private bool _showParameters = false;
        private bool _benchmarkEnvironment = false;
        private MeasurementType _measurementType = MeasurementType.Peak;
        private ExecutionType _executionType = ExecutionType.Proportional;
        private bool _forceContinue = false;
        private double _nominalRate = 1;

        public CommandLineArgs(string[] args)
        {
            ProcessArguments(args);
        }

        private void ProcessArguments(string[] args)
        {
            for (int index = 0; index < args.Length; ++index)
            {
                var arg = args[index];
                var moreArgs = index < args.Length - 1;

                if ((arg == "-a" || arg == "--assembly") && moreArgs)
                {
                    string assemblyName = args[++index];
                    _assemblies.Add(assemblyName);
                }
                else if ((arg == "-b" || arg == "--benchmark") && moreArgs)
                {
                    string benchmark = args[++index];
                    _benchmarks.Add(benchmark);
                }
                else if ((arg == "-p" || arg == "--param") && moreArgs)
                {
                    string param = args[++index];
                    int pos = param.IndexOf('=');
                    string key = pos > 0 ? param.Substring(0, pos) : param;
                    string value = pos > 0 ? param.Substring(pos + 1) : null;
                    _parameters[param] = value;
                }
                else if ((arg == "-c" || arg == "--config") && moreArgs)
                {
                    _configurationFile = args[++index];
                }
                else if ((arg == "-r" || arg == "--report") && moreArgs)
                {
                    _reportFile = args[++index];
                }
                else if ((arg == "-d" || arg == "--duration") && moreArgs)
                {
                    _duration = (int)(Converter.StringToDouble(args[++index], 30) * 1000);
                }
                else if ((arg == "-m" || arg == "--measure") && moreArgs)
                {
                    _measurementType = args[++index].ToLowerInvariant() == "nominal"
                        ? MeasurementType.Nominal : MeasurementType.Peak;
                }
                else if ((arg == "-e" || arg == "--execute") && moreArgs)
                {
                    var execution = args[++index].ToLowerInvariant();
                    _executionType = execution == "seq" || execution == "sequential"
                        ? ExecutionType.Sequential : ExecutionType.Proportional;
                }
                else if ((arg == "-n" || arg == "--nominal") && moreArgs)
                {
                    _nominalRate = Converter.StringToDouble(args[++index], 1);
                }
                else if (arg == "-f" || arg == "--force")
                {
                    _forceContinue = true;
                }
                else if (arg == "-h" || arg == "--help")
                {
                    _showHelp = true;
                }
                else if (arg == "-B" || arg == "--show-benchmarks")
                {
                    _showBenchmarks = true;
                }
                else if (arg == "-P" || arg == "--show-params")
                {
                    _showParameters = true;
                }
                else if (arg == "-e" || arg == "--environment")
                {
                    _benchmarkEnvironment = true;
                }
            }
        }

        public List<string> Assemblies
        {
            get { return _assemblies; }
        }

        public List<string> Benchmarks
        {
            get { return _benchmarks; }
        }

        public Dictionary<string, string> Parameters
        {
            get { return _parameters; }
        }

        public string ConfigurationFile
        {
            get { return _configurationFile; }
        }

        public string ReportFile
        {
            get { return _reportFile; }
        }

        public int Duration
        {
            get { return _duration; }
        }

        public bool IsForceContinue
        {
            get { return _forceContinue; }
        }

        public bool ShowHelp
        {
            get { return _showHelp; }
        }

        public bool ShowBenchmarks
        {
            get { return _showBenchmarks; }
        }

        public bool ShowParameters
        {
            get { return _showParameters; }
        }

        public bool BenchmarkEnvironment
        {
            get { return _benchmarkEnvironment; }
        }

        public MeasurementType MeasurementType
        {
            get { return _measurementType; }
        }

        public double NominalRate
        {
            get { return _nominalRate; }
        }

        public ExecutionType ExecutionType
        {
            get { return _executionType; }
        }
    }
}
