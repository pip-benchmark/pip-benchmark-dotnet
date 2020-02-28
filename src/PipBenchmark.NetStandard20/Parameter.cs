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
        
        public string AsNullableString
        {
            get { return Value; }
        }
        
        public string AsStringWithDefault
        {
            get { return Value??_defaultValue; }
        }
        
        public bool AsBoolean
        {
            get { return (bool)Converter.StringToBoolean(Value, false); }
            set { Value = Converter.BooleanToString(value); }
        }
        
        public bool? AsNullableBoolean
        {
            get { return string.IsNullOrEmpty(Value) ? null : (bool?) Converter.StringToBoolean(Value, false); }
        }

        public bool AsBooleanWithDefault(bool defaultValue)
        {
            return (bool)Converter.StringToBoolean(Value, defaultValue);
            
        }

        public int AsInteger
        {
            get { return Converter.StringToInteger(Value, 0); }
            set { Value = Converter.IntegerToString(value); }
        }
        
        public int? AsNullableInteger
        {
            get { return string.IsNullOrEmpty(Value) ? null : (int?) Converter.StringToInteger(Value, 0); }
        }

        public int AsIntegerWithDefault(int defaultValue)
        {
            return Converter.StringToInteger(Value, defaultValue);
        }

        public long AsLong
        {
            get { return Converter.StringToLong(Value, 0); }
            set { Value = Converter.LongToString(value); }
        }
        
        public long? AsNullableLong
        {
            get { return string.IsNullOrEmpty(Value) ? null : (long?) Converter.StringToLong(Value, 0); }
        }
        
        public long AsLongWithDefault(long defaultValue)
        {
            return Converter.StringToLong(Value, defaultValue);
        }        

        public float AsFloat
        {
            get { return Converter.StringToFloat(Value, 0); }
            set { Value = Converter.FloatToString(value); }
        }
        
        public float? AsNullableFloat
        {
            get { return string.IsNullOrEmpty(Value) ? null : (float?) Converter.StringToFloat(Value, 0); }
        }
        
        public float AsFloatWithDefault(float defaultValue)
        {
            return Converter.StringToFloat(Value, defaultValue);
        }               

        public double AsDouble
        {
            get { return Converter.StringToDouble(Value, 0); }
            set { Value = Converter.DoubleToString(value); }
        }
        
        public double? AsNullableDouble
        {
            get { return string.IsNullOrEmpty(Value) ? null : (double?) Converter.StringToDouble(Value, 0); }
        }
        
        public double AsDoubleWithDefault(double defaultValue)
        {
            return Converter.StringToDouble(Value, defaultValue);
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
