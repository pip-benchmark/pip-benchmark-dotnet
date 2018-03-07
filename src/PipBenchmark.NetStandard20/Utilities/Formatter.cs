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
    }
}
