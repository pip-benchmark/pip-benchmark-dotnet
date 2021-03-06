﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PipBenchmark.Utilities
{
    public class Properties : Dictionary<string, string>
    {
        List<PropertyFileLine> _lines = new List<PropertyFileLine>();

        public void LoadFromStream(Stream stream)
        {
            _lines.Clear();

            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    PropertyFileLine line = new PropertyFileLine(reader.ReadLine());
                    _lines.Add(line);
                }
            }

            PopulateItems();
        }

        private void PopulateItems()
        {
            Clear();

            foreach (PropertyFileLine line in _lines)
            {
                if (!string.IsNullOrEmpty(line.Key))
                {
                    Add(line.Key, line.Value);
                }
            }
        }

        public void SaveToStream(Stream stream)
        {
            SynchronizeItems();

            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (PropertyFileLine line in _lines)
                {
                    writer.WriteLine(line.Line);
                }
            }
        }

        private PropertyFileLine FindLine(string key)
        {
            foreach (PropertyFileLine line in _lines)
            {
                if (line.Key == key)
                {
                    return line;
                }
            }
            return null;
        }

        private void SynchronizeItems()
        {
            // Update existing values and create missing lines
            foreach (KeyValuePair<string, string> pair in this)
            {
                PropertyFileLine line = FindLine(pair.Key);
                if (line != null)
                {
                    line.Value = pair.Value;
                }
                else
                {
                    line = new PropertyFileLine(pair.Key, pair.Value, null);
                    _lines.Add(line);
                }
            }

            // Remove lines mismatched with listed keys
            for (int index = _lines.Count - 1; index >= 0; index--)
            {
                PropertyFileLine line = _lines[index];
                if (string.IsNullOrEmpty(line.Key) == false
                    && this.ContainsKey(line.Key) == false)
                {
                    _lines.RemoveAt(index);
                }
            }
        }

        public string GetAsString(string key, string defaultValue)
        {
            return this.ContainsKey(key) ? this[key] : defaultValue;
        }

        public void SetAsString(string key, string value)
        {
            this[key] = value;
        }

        public int GetAsInteger(string key, int defaultValue)
        {
            return this.ContainsKey(key) ? Converter.StringToInteger(this[key], defaultValue) : defaultValue;
        }

        public void SetAsInteger(string key, int value)
        {
            this[key] = Converter.IntegerToString(value);
        }

        public long GetAsLong(string key, long defaultValue)
        {
            return this.ContainsKey(key) ? Converter.StringToLong(this[key], defaultValue) : defaultValue;
        }

        public void SetAsLong(string key, long value)
        {
            this[key] = Converter.LongToString(value);
        }

        public double GetAsDouble(string key, double defaultValue)
        {
            return this.ContainsKey(key) ? Converter.StringToDouble(this[key], defaultValue) : defaultValue;
        }

        public void SetAsDouble(string key, double value)
        {
            this[key] = Converter.DoubleToString(value);
        }

        public bool GetAsBoolean(string key, bool defaultValue)
        {
            return this.ContainsKey(key) ? Converter.StringToBoolean(this[key], defaultValue) : defaultValue;
        }

        public void SetAsBoolean(string key, bool value)
        {
            this[key] = Converter.BooleanToString(value);
        }

        public DateTime GetAsDateTime(string key, DateTime defaultValue)
        {
            return this.ContainsKey(key) ? Converter.StringToDateTime(this[key], defaultValue) : defaultValue;
        }

        public void SetAsDateTime(string key, DateTime value)
        {
            this[key] = Converter.DateTimeToString(value);
        }

        public TimeSpan GetAsTimeSpan(string key, TimeSpan defaultValue)
        {
            return this.ContainsKey(key) ? Converter.StringToTimeSpan(this[key], defaultValue) : defaultValue;
        }

        public void SetAsTimeSpan(string key, TimeSpan value)
        {
            this[key] = Converter.TimeSpanToString(value);
        }

    }
}
