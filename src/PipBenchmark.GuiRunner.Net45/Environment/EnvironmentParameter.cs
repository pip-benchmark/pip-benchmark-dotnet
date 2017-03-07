using System;
using System.Collections.Generic;

namespace PipBenchmark.Gui.Environment
{
    public class EnvironmentParameter
    {
        private string _parameter;
        private string _value;

        public EnvironmentParameter(string parameter, string value)
        {
            _parameter = parameter;
            _value = value;
        }

        public string Parameter
        {
            get { return _parameter; }
        }

        public string Value
        {
            get { return _value; }
        }
    }
}
