using System;
using System.Collections.Generic;
using System.Text;

namespace PipBenchmark.Utilities
{
    public class Random
    {
        private const string AllowStringChars = "ABCDEFGHIGKLMNOPQRSTUVWXYZabcdefghigklmnopqrstuvwxyz -";
        private const int AllowStringCharsLength = 54;

        private System.Random _random = new System.Random();
        private StringBuilder _randomTextBuilder = new StringBuilder(256);

        public Random()
        {
        }

        public List<string> RandomStringList(int minCount, int maxCount, int itemSize)
        {
            List<string> result = new List<string>();
            int count = Math.Max(0, minCount + _random.Next(maxCount - minCount));

            for (int index = 0; index < count; index++)
            {
                result.Add(RandomString(itemSize));
            }

            return result;
        }

        public string RandomString(int size)
        {
            StringBuilder text = new StringBuilder();
            for (int index = 0; index < size; index++)
            {
                text.Append(AllowStringChars[_random.Next(AllowStringChars.Length)]);
            }
            return text.ToString();
        }

        public byte[] RandomByteArray(int size)
        {
            byte[] result = new byte[size];
            for (int index = 0; index < size; index++)
            {
                result[index] = (byte)RandomInteger(0, 256);
            }
            return result;
        }

        public int RandomInteger(int minValue, int maxValue)
        {
            return (int)RandomDouble(minValue, maxValue);
        }

        public double RandomDouble(double minValue, double maxValue)
        {
            return minValue + (double)_random.NextDouble() * (maxValue - minValue);
        }

        public DateTime RandomDateTime()
        {
            return RandomDateTime(2001, 9 * 365);
        }

        public DateTime RandomDateTime(int startYear, double maxDays)
        {
            return new DateTime(startYear, 1, 1).AddDays(_random.NextDouble() * maxDays);
        }

        public TimeSpan RandomTimeSpan()
        {
            return RandomTimeSpan(60);
        }

        public TimeSpan RandomTimeSpan(double maxSeconds)
        {
            return TimeSpan.FromSeconds(_random.NextDouble() * maxSeconds);
        }

        public bool RandomBoolean()
        {
            return RandomInteger(0, 2) == 1;
        }

        public bool Chance(float chances, float maxChances)
        {
            chances = chances >= 0 ? chances : 0;
            maxChances = maxChances >= 0 ? maxChances : 0;
            if (chances == 0 && maxChances == 0)
                return false;

            maxChances = Math.Max(maxChances, chances);
            double start = (maxChances - chances) / 2;
            double end = start + chances;
            double hit = _random.NextDouble() * maxChances;
            return hit >= start && hit <= end;
        }

    }
}
