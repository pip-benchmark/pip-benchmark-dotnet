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
            get { return SimpleTypeConverter.StringToBoolean(Value); }
            set { Value = SimpleTypeConverter.BooleanToString(value); }
        }

        public int AsInteger
        {
            get { return SimpleTypeConverter.StringToInteger(Value, 0); }
            set { Value = SimpleTypeConverter.IntegerToString(value); }
        }

        public long AsLong
        {
            get { return SimpleTypeConverter.StringToLong(Value, 0); }
            set { Value = SimpleTypeConverter.LongToString(value); }
        }

        public float AsFloat
        {
            get { return SimpleTypeConverter.StringToFloat(Value, 0); }
            set { Value = SimpleTypeConverter.FloatToString(value); }
        }

        public double AsDouble
        {
            get { return SimpleTypeConverter.StringToDouble(Value, 0); }
            set { Value = SimpleTypeConverter.DoubleToString(value); }
        }

        public DateTime AsDateTime
        {
            get { return SimpleTypeConverter.StringToDateTime(Value, new DateTime(1900, 1, 1)); }
            set { Value = SimpleTypeConverter.DateTimeToString(value); }
        }

        public TimeSpan AsTimeSpan
        {
            get { return SimpleTypeConverter.StringToTimeSpan(Value, new TimeSpan(0)); }
            set { Value = SimpleTypeConverter.TimeSpanToString(value); }
        }


    }
}
