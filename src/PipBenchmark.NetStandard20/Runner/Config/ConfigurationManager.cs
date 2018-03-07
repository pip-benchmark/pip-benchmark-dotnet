using PipBenchmark.Runner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PipBenchmark.Runner.Config
{
    public class ConfigurationManager
    {
        private readonly List<Parameter> _parameters = new List<Parameter>();
        private readonly List<BenchmarkSuiteInstance> _suites = new List<BenchmarkSuiteInstance>();

        public ConfigurationManager(BenchmarkRunner runner)
        {
            Runner = runner;
        }

        public BenchmarkRunner Runner { get; }

        public List<Parameter> FilteredParameters
        {
            get
            {
                CreateParametersForSuite();

                var filteredParameters = new List<Parameter>();

                var selectedSuite = new HashSet<BenchmarkSuiteInstance>();
                foreach (var benchmark in Runner.SuiteManager.SelectedBenchmarks)
                {
                    selectedSuite.Add(benchmark.Suite);
                }

                foreach (var suite in selectedSuite)
                {
                    // Create indirect test suite parameters
                    foreach (Parameter originalParameter in suite.Parameters.Values)
                    {
                        filteredParameters.Add(new IndirectSuiteParameter(suite, originalParameter));
                    }
                }

                //if (true)
                //{
                //    foreach (Parameter parameter in _parameters)
                //    {
                //        if (!parameter.Name.EndsWith(".Selected", StringComparison.InvariantCultureIgnoreCase)
                //            && !parameter.Name.EndsWith(".Proportion", StringComparison.InvariantCultureIgnoreCase)
                //            && !parameter.Name.StartsWith("General.", StringComparison.InvariantCultureIgnoreCase))
                //        {
                //            filteredParameters.Add(parameter);
                //        }
                //    }
                //}

                return filteredParameters; 
            }
        }

        public List<Parameter> AllParameters
        {
            get { return _parameters; }
        }

        public event EventHandler ConfigurationUpdated;

        public void LoadConfigurationFromFile(string fileName)
        {
            Properties properties = new Properties();
            using (Stream stream = File.OpenRead(fileName))
            {
                properties.LoadFromStream(stream);

                foreach (KeyValuePair<string, string> pair in properties)
                    SetParameterValue(pair.Key, pair.Value);
            }

            //NotifyConfigurationUpdated();
        }

        private void SetParameterValue(string parameterName, string value)
        {
            foreach (Parameter parameter in _parameters)
            {
                if (parameter.Name.Equals(parameterName, StringComparison.InvariantCultureIgnoreCase))
                    parameter.Value = value;
            }
        }

        public void SaveConfigurationToFile(string fileName)
        {
            Properties properties = new Properties();
            using (Stream stream = File.OpenWrite(fileName))
            {
                foreach (Parameter parameter in _parameters)
                    properties.Add(parameter.Name, parameter.Value);

                properties.SaveToStream(stream);
            }
        }

        private void NotifyConfigurationUpdated()
        {
            if (ConfigurationUpdated != null)
                ConfigurationUpdated(this, EventArgs.Empty);
        }

        public void AddSuite(BenchmarkSuiteInstance suite)
        {
            _suites.Add(suite);
        }

        private void CreateParametersForSuite()
        {
            _parameters.Clear();

            _parameters.Add(new NumberOfThreadsParameter(Runner.Process));
            _parameters.Add(new MeasurementTypeParameter(Runner.Process));
            _parameters.Add(new NominalRateParameter(Runner.Process));
            _parameters.Add(new ExecutionTypeParameter(Runner.Process));
            _parameters.Add(new DurationParameter(Runner.Process));

            // Create benchmark related parameters
            foreach (BenchmarkInstance benchmark in _suites.SelectMany(x => x.Benchmarks))
            {
                Parameter selectedParameter
                    = new BenchmarkSelectedParameter(benchmark);
                _parameters.Add(selectedParameter);

                Parameter proportionParameter
                    = new BenchmarkProportionParameter(benchmark);
                _parameters.Add(proportionParameter);
            }

            foreach (var suite in _suites)
            {
                // Create indirect test suite parameters
                foreach (Parameter originalParameter in suite.Parameters.Values)
                {
                    Parameter indirectParameter
                        = new IndirectSuiteParameter(suite, originalParameter);
                    _parameters.Add(indirectParameter);
                }
            }
        }

        public void RemoveParametersForSuite(BenchmarkSuiteInstance suite)
        {
            string parameterNamePrefix = suite.Name + ".";
            for (int index = _parameters.Count - 1; index >= 0; index--)
            {
                Parameter parameter = _parameters[index];
                // Remove parameter from the list
                if (parameter.Name.StartsWith(parameterNamePrefix, StringComparison.InvariantCultureIgnoreCase))
                    _parameters.RemoveAt(index);
            }

            //NotifyConfigurationUpdated();
        }

        public void SetConfigurationToDefault()
        {
            foreach (Parameter parameter in _parameters)
            {
                IndirectSuiteParameter indirectParameter = parameter as IndirectSuiteParameter;
                if (indirectParameter != null)
                    indirectParameter.Value = indirectParameter.DefaultValue;
            }
        }

        public void SetConfiguration(Dictionary<string, string> parameters)
        {
            foreach (Parameter parameter in _parameters)
            {
                if (parameters.ContainsKey(parameter.Name))
                    parameter.AsString = parameters[parameter.Name];
            }
        }

    }
}
