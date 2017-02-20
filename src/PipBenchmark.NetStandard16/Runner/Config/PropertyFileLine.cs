using System;
using System.Collections.Generic;
using System.Text;

namespace PipBenchmark.Runner.Config
{
    public class PropertyFileLine
    {
        private string _line;
        private string _key;
        private string _value;
        private string _comment;

        public PropertyFileLine(string key, string value, string comment)
        {
            _key = key;
            _value = value;
            _comment = comment;
            ComposeNewLine();
        }

        public PropertyFileLine(string line)
        {
            ParseLine(line);
        }

        public string Key
        {
            get { return _key; }
        }

        public string Value
        {
            get { return _value; }
            set 
            {
                if (_value != value)
                {
                    _value = value;
                    ComposeNewLine();
                }
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    ComposeNewLine();
                }
            }
        }

        public string Line
        {
            get { return _line; }
        }

        private void ComposeNewLine()
        {
            StringBuilder builder = new StringBuilder(255);
            if (!string.IsNullOrEmpty(_key))
            {
                builder.Append(EncodeValue(_key));
                builder.Append('=');
                builder.Append(EncodeValue(_value));
            }
            if (!string.IsNullOrEmpty(_comment))
            {
                builder.Append(" ;");
                builder.Append(_comment);
            }
            _line = builder.ToString();
        }

        private void ParseLine(string line)
        {
            _line = line;

            // Parse comment
            int commentIndex = IndexOfComment(line);
            if (commentIndex >= 0)
            {
                _comment = line.Substring(commentIndex + 1, line.Length - commentIndex - 1);
                line = line.Substring(0, commentIndex);
            }

            // Parse key and value
            int assignmentIndex = line.IndexOf('=');
            if (assignmentIndex >= 0)
            {
                _value = line.Substring(assignmentIndex + 1, line.Length - assignmentIndex - 1);
                _value = DecodeValue(_value);
                _key = line.Substring(0, assignmentIndex);
                _key = DecodeValue(_key);
            }
            else
            {
                _key = DecodeValue(line);
                _value = string.Empty;
            }
        }

        private int IndexOfComment(string value)
        {
            bool partOfString = false;
            char stringDelimiter = ' ';
            for (int index = 0; index < value.Length; index++)
            {
                char chr = value[index];
                if (partOfString == false && chr == ';')
                {
                    return index;
                }
                else if (partOfString == true && chr == stringDelimiter)
                {
                    partOfString = false;
                }
                else if (partOfString == false && (chr == '\'' || chr == '\"'))
                {
                    partOfString = true;
                    stringDelimiter = chr;
                }
            }
            return -1;
        }

        private string DecodeValue(string value)
        {
            value = value.Trim();
            if (value.StartsWith("'") && value.EndsWith("'"))
            {
                value = value.Substring(1, value.Length - 2);
                value = value.Replace("''", "'");
            }
            if (value.StartsWith("\"") && value.EndsWith("\""))
            {
                value = value.Substring(1, value.Length - 2);
                value = value.Replace("\"\"", "\"");
            }
            return value;
        }

        private string EncodeValue(string value)
        {
            if (value == null)
            {
                return value;
            }

            if (value.StartsWith(" ") || value.EndsWith(" ") || value.IndexOf(';') >= 0)
            {
                value = value.Replace("\"", "\"\"");
                value = "\"" + value + "\"";
            }
            return value;
        }

        public override string ToString()
        {
            return _line;
        }
    }
}
