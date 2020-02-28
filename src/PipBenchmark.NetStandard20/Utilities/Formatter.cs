using System;
using System.Text;

namespace PipBenchmark.Utilities
{
    public static class Formatter
    {
        public static string PadLeft(string value, int length, string padSymbol)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(padSymbol);
            builder.Append(value);
            builder.Append(padSymbol);

            while (builder.Length < length + 2)
            {
                builder.Insert(0, padSymbol);
            }

            return builder.ToString();
        }

        public static string PadRight(string value, int length, string padSymbol)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(padSymbol);
            builder.Append(value);
            builder.Append(padSymbol);

            while (builder.Length < length + 2)
            {
                builder.Append(padSymbol);
            }

            return builder.ToString();
        }

        public static string FormatNumber(decimal value, int decimals = 2)
        {
            if (decimals > 99) decimals = 99;
            if (decimals < 0) decimals = 0;
            
            string format = "{0:N" + decimals + "}";
            return String.Format(format, value);
        }

        public static string FormatDate(DateTime date)
        {
            string value = date.ToShortDateString();
            return value;
        }

        public static string FormatTime(DateTime date)
        {
            return date.ToShortTimeString();
        }

        public static string FormatTimeSpan(long ticks)
        {
            TimeSpan timeSpan = new TimeSpan(ticks);
            return $"{timeSpan:G}";
        }
    }
}
