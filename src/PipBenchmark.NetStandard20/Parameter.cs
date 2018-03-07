using PipBenchmark.Utilities;
using System;

namespace PipBenchmark
{
    public class Parameter
    {
        private string _name;
        private string _description;
        private string _defaultValue;
        private string _value;

        public Parameter(string name, string description, string defaultValue)
        {
            _name = name;
            _description = description;
            _defaultValue = defaultValue;
            _value = defaultValue;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string DefaultValue
        {
            get { return _defaultValue; }
        }

        public virtual string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string AsString
        {
            get { return Value; }
            set { Value = value; }
        }

        public bool AsBoolean
        {
            get { return Converter.StringToBoolean(Value); }
            set { Value = Converter.BooleanToString(value); }
        }

        public int AsInteger
        {
            get { return Converter.StringToInteger(Value, 0); }
            set { Value = Converter.IntegerToString(value); }
        }

        public long AsLong
        {
            get { return Converter.StringToLong(Value, 0); }
            set { Value = Converter.LongToString(value); }
        }

        public float AsFloat
        {
            get { return Converter.StringToFloat(Value, 0); }
            set { Value = Converter.FloatToString(value); }
        }

        public double AsDouble
        {
            get { return Converter.StringToDouble(Value, 0); }
            set { Value = Converter.DoubleToString(value); }
        }

        public DateTime AsDateTime
        {
            get { return Converter.StringToDateTime(Value, new DateTime(1900, 1, 1)); }
            set { Value = Converter.DateTimeToString(value); }
        }

        public TimeSpan AsTimeSpan
        {
            get { return Converter.StringToTimeSpan(Value, new TimeSpan(0)); }
            set { Value = Converter.TimeSpanToString(value); }
        }


    }
}
