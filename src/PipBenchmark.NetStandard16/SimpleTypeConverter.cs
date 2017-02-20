using System;
using System.Globalization;

namespace PipBenchmark
{
    public class SimpleTypeConverter
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
            if (value == null || value.Length == 0)
            {
                return defaultValue;
            }

            // Set initial values
            int position = 0;
            long resultValue = 0;

            // Check for leading minus
            bool hasMinus = false;
            if (value[position] == '-')
            {
                hasMinus = true;
                position++;
            }

            // Process characters
            while (position < value.Length)
            {
                char currentChar = value[position++];

                if (currentChar >= '0' && currentChar <= '9')
                {
                    // Process digits
                    resultValue = resultValue * 10 + (currentChar - '0');
                }
                else if (currentChar == ',')
                {
                    // Skip thousand separator
                }
                else
                {
                    // Return default value if unexpected symbol found.
                    return defaultValue;
                }
            }

            // Apply minus
            resultValue = hasMinus ? -resultValue : resultValue;

            return resultValue;
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
            if (value == null || value.Length == 0)
            {
                return defaultValue;
            }

            // Set initial values
            int position = 0;
            double resultValue = 0;
            bool hasDecimalPart = false;

            // Check for leading minus
            bool hasMinus = false;
            if (value[position] == '-')
            {
                hasMinus = true;
                position++;
            }

            // Process main part
            while (position < value.Length)
            {
                char currentChar = value[position++];

                if (currentChar >= '0' && currentChar <= '9')
                {
                    // Process digits
                    resultValue = resultValue * 10 + (currentChar - '0');
                }
                else if (currentChar == ',')
                {
                    // Skip thousand separator
                }
                else if (currentChar == '.')
                {
                    hasDecimalPart = true;
                    break;
                }
                else
                {
                    // Return default value if unexpected symbol found.
                    return defaultValue;
                }
            }

            // Process decimal part
            if (hasDecimalPart)
            {
                double decimalPart = 0;
                long scaleDecimalPart = 1;

                while (position < value.Length)
                {
                    char currentChar = value[position++];

                    if (currentChar >= '0' && currentChar <= '9')
                    {
                        // Process digits
                        decimalPart = decimalPart * 10 + (currentChar - '0');
                        scaleDecimalPart *= 10;
                    }
                    else
                    {
                        // Return default value if unexpected symbol found.
                        return defaultValue;
                    }
                }
                resultValue += decimalPart / scaleDecimalPart;
            }

            // Apply minus
            resultValue = hasMinus ? -resultValue : resultValue;

            return resultValue;
        }

        public static string DoubleToString(double value)
        {
            return Convert.ToString(value, CultureInfo.InvariantCulture);
        }

        public static bool StringToBoolean(string value)
        {
            // Process nulls or empty strings
            if (value == null || value.Length == 0)
            {
                return false;
            }

            // Process single characters
            if (value.Length == 1)
            {
                return value[0] == '1' || value[0] == 'T' || value[0] == 'Y'
                    || value[0] == 't' || value[0] == 'y';
            }

            // Process strings
            value = value.ToUpper();
            return value.Equals("TRUE") || value.Equals("YES");
        }

        public static string BooleanToString(bool value)
        {
            return value ? "true" : "false";
        }

        public static DateTime StringToDateTime(string value, DateTime defaultValue)
        {
            int year = 0, month = 0, day = 0;

            if (value == null || value.Length == 0)
            {
                return defaultValue;
            }

            // Check for length
            if (value.Length < 10)
            {
                return defaultValue;
            }

            // Check for date separators
            if (value[4] != '-' || value[7] != '-')
            {
                return defaultValue;
            }

            // Extract year
            year = StringToInteger(value.Substring(0, 4), -1);
            if (year < 0)
            {
                return defaultValue;
            }

            // Extract month
            month = StringToInteger(value.Substring(5, 2), -1);
            if (month < 0 || month > 12)
            {
                return defaultValue;
            }

            // Extract day
            day = StringToInteger(value.Substring(8, 2), -1);
            if (day < 0 || day > 31)
            {
                return defaultValue;
            }

            value = value.Length > 11 ? value.Substring(11) : "";

            DateTime result = new DateTime(year, month, day);

            if (value.Length != 0)
            {
                TimeSpan time = StringToTimeSpan(value, new TimeSpan(Int64.MaxValue));
                if (time.Ticks == Int64.MaxValue)
                {
                    return defaultValue;
                }
                return new DateTime(result.Ticks + time.Ticks);
            }

            return result;
        }

        public static string DateTimeToString(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static TimeSpan StringToTimeSpan(string value, TimeSpan defaultValue)
        {
            int hour = 0, min = 0, sec = 0, millis = 0;

            if (value == null || value.Length == 0)
            {
                return defaultValue;
            }

            // Check for length
            if (value.Length != 8)
            {
                return defaultValue;
            }

            // Check for time separators
            if (value[2] != ':' || value[5] != ':')
            {
                return defaultValue;
            }

            // Extract hour
            hour = StringToInteger(value.Substring(0, 2), -1);
            if (hour < 0 || hour > 23)
            {
                return defaultValue;
            }

            // Extract min
            min = StringToInteger(value.Substring(3, 2), -1);
            if (min < 0 || min > 60)
            {
                return defaultValue;
            }

            // Extract sec
            sec = StringToInteger(value.Substring(6, 2), -1);
            if (min < 0 || min > 60)
            {
                return defaultValue;
            }

            return new TimeSpan(0, hour, min, sec, millis);
        }

        public static string TimeSpanToString(TimeSpan value)
        {
            return value.ToString();
        }

    }
}
