using System;
using System.Globalization;

namespace PipBenchmark.Utilities
{
    public class Converter
    {
        public static int StringToInteger(string value, int defaultValue)
        {
            return (int)StringToLong(value, defaultValue);
        }

        public static string IntegerToString(int value)
        {
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        public static long StringToLong(string value, long defaultValue)
        {
            // Check for null or empty strings
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return !long.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var resultValue) ? defaultValue : resultValue;
        }

        public static string LongToString(long value)
        {
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        public static float StringToFloat(string value, float defaultValue)
        {
            return (float)StringToDouble(value, defaultValue);
        }

        public static string FloatToString(float value)
        {
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        public static double StringToDouble(string value, double defaultValue)
        {
            // Check for null or empty strings
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            
            return !double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var resultValue) ? defaultValue : resultValue;
        }

        public static string DoubleToString(double value)
        {
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        public static bool StringToBoolean(string value, bool defaultValue)
        {
            // Process nulls or empty strings
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            // Process single characters
            if (value.Length == 1)
            {
                if( value[0] == '1' || value[0] == 'T' || value[0] == 'Y'
                    || value[0] == 't' || value[0] == 'y')
                    return true;
                if( value[0] == '0' || value[0] == 'F' || value[0] == 'N'
                    || value[0] == 'f' || value[0] == 'n')
                    return false;                
            }

            // Process strings
            value = value.ToUpper();
            if (value.Equals("TRUE") || value.Equals("YES"))
                return true;
            if (value.Equals("FALSE") || value.Equals("NO"))
                return true;

            return defaultValue;
        }

        public static string BooleanToString(bool value)
        {
            return value ? "true" : "false";
        }

        public static DateTime StringToDateTime(string value, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            return !DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var resultValue) ? defaultValue : resultValue;
        }

        public static string DateTimeToString(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static TimeSpan StringToTimeSpan(string value, TimeSpan defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            
            return !TimeSpan.TryParse(value, out var resultValue) ? defaultValue : resultValue;
        }

        public static string TimeSpanToString(TimeSpan value)
        {
            return value.ToString();
        }

    }
}
