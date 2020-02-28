using PipBenchmark.Utilities;
using System;
using Xunit;

namespace Benchmark.Test.NetCore20
{
    public class ConverterTest
    {
        [Fact]
        public void It_Should_Convert_String_To_Long()
        {
            long x = Converter.StringToLong("123", 0);
            Assert.Equal(123, x);

            x = Converter.StringToLong("-123", 0);
            Assert.Equal(-123, x);

            x = Converter.StringToLong("-123.1545", 0);
            Assert.Equal(0, x);

            // x = Converter.StringToLong("9999999999999999999999999999999999999", 0);
            // Assert.Equal(0, x);

            x = Converter.StringToLong("9223372036854775807", 0);
            Assert.Equal(9223372036854775807, x);

            x = Converter.StringToLong("-9223372036854775808", 0);
            Assert.Equal(-9223372036854775808, x);

            x = Converter.StringToLong("-922,3372,0368,5477,5808", 0);
            Assert.Equal(-9223372036854775808, x);
        }
    }
}
