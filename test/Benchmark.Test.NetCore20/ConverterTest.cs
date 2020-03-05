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
            Assert.Equal(123, Converter.StringToLong("123", 0));

            Assert.Equal(-123, Converter.StringToLong("-123", 0));

            Assert.Equal(0, Converter.StringToLong("-123.1545", 0));

            Assert.Equal(9223372036854775807, Converter.StringToLong("9223372036854775807", 0));

            Assert.Equal(-9223372036854775808, Converter.StringToLong("-9223372036854775808", 0));

            Assert.Equal(-9223372036854775808, Converter.StringToLong("-922,3372,0368,5477,5808", 0));
        }

        [Fact]
        public void It_Should_Convert_Long_To_String()
        {
            Assert.Equal("123", Converter.LongToString(123));
        }

        [Fact]
        public void It_Should_Double_To_String()
        {
            Assert.Equal("123.456", Converter.DoubleToString(123.456));
        }

        [Fact]
        public void It_Should_String_To_Double()
        {
            Assert.Equal(0, Converter.StringToDouble(null, 0) );
            Assert.Equal(0, Converter.StringToDouble("ABC", 0));
            Assert.Equal(123.456, Converter.StringToDouble("123.456", 0));
        }

        [Fact]
        public void It_Should_Boolean_To_String()
        {
            Assert.Equal("false", Converter.BooleanToString(false));
            Assert.Equal("true", Converter.BooleanToString(true));
        }
        
        [Fact]
        public void It_Should_String_To_Boolean()
        {
            Assert.False(Converter.StringToBoolean(null, false));
            Assert.True(Converter.StringToBoolean("True", false));
            Assert.True(Converter.StringToBoolean("1", false));
            Assert.True(Converter.StringToBoolean("T", false));
        }

    }
}
