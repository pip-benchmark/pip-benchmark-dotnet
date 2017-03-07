using PipBenchmark.Runner.Benchmarks;
using PipBenchmark.Runner.Config;
using PipBenchmark.Utilities;
using System.Collections.Generic;
using System.IO;

namespace PipBenchmark.Runner.Parameters
{
    public class ParametersManager
    {
        private ConfigurationManager _configuration;
        private List<Parameter> _parameters = new List<Parameter>();

        public ParametersManager(ConfigurationManager configuration)
        {
            _configuration = configuration;

            _parameters.Add(new NumberOfThreadsParameter(_configuration));
            _parameters.Add(new MeasurementTypeParameter(_configuration));
            _parameters.Add(new NominalRateParameter(_configuration));
            _parameters.Add(new ExecutionTypeParameter(_configuration));
            _parameters.Add(new DurationParameter(_configuration));
        }

        public List<Parameter> UserDefined
        {
            get
            {
                var parameters = new List<Parameter>();

                foreach (Parameter parameter in _parameters)
                {
                    if (!parameter.Name.EndsWith(".Selected")
                        && !parameter.Name.EndsWith(".Proportion")
                        && !parameter.Name.StartsWith("General."))
                    {
                        parameters.Add(parameter);
                    }
                }

                return parameters; 
            }
        }

        public List<Parameter> All
        {
            get { return _parameters; }
        }

        public void LoadFromFile(string path)
        {
            Properties properties = new Properties();
            using (Stream stream = File.OpenRead(path))
            {
                properties.LoadFromStream(stream);

                foreach (KeyValuePair<string, string> pair in properties)
                {
                    foreach (Parameter parameter in _parameters)
                    {
                        if (parameter.Name == pair.Key)
                            parameter.Value = pair.Value;
                    }
                }
            }

            _configuration.NotifyChanged();
        }

        public void SaveToFile(string path)
        {
            Properties properties = new Properties();
            using (Stream stream = File.OpenWrite(path))
            {
                foreach (Parameter parameter in _parameters)
                    properties.Add(parameter.Name, parameter.Value);

                properties.SaveToStream(stream);
            }
        }

        public void AddSuite(BenchmarkSuiteInstance suite)
        {
            // Create benchmark related parameters
            foreach (BenchmarkInstance benchmark in suite.Benchmarks)
            {
                Parameter benchmarkSelectedParameter
                    = new BenchmarkSelectedParameter(benchmark);
                _parameters.Add(benchmarkSelectedParameter);

                Parameter benchmarkProportionParameter
                    = new BenchmarkProportionParameter(benchmark);
                _parameters.Add(benchmarkProportionParameter);
            }

            // Create suite parameters
            foreach (Parameter parameter in suite.Parameters)
            {
                Parameter suiteParameter
                    = new BenchmarkSuiteParameter(suite, parameter);
                _parameters.Add(suiteParameter);
            }
        }

        public void RemoveForSuite(BenchmarkSuiteInstance suite)
        {
            string parameterNamePrefix = suite.Name + ".";

            for (int index = _parameters.Count - 1; index >= 0; index--)
            {
                Parameter parameter = _parameters[index];
                // Remove parameter from the list
                if (parameter.Name.StartsWith(parameterNamePrefix))
                    _parameters.RemoveAt(index);
            }

            _configuration.NotifyChanged();
        }

        public void SetToDefault()
        {
            foreach (Parameter parameter in _parameters)
            {
                BenchmarkSuiteParameter suiteParameter = parameter as BenchmarkSuiteParameter;
                if (suiteParameter != null)
                    suiteParameter.Value = suiteParameter.DefaultValue;
            }

            _configuration.NotifyChanged();
        }

        public void Set(Dictionary<string, string> parameters)
        {
            foreach (Parameter parameter in _parameters)
            {
                if (parameters.ContainsKey(parameter.Name))
                    parameter.Value = parameters[parameter.Name];
            }

            _configuration.NotifyChanged();
        }

    }
}
