namespace TernaryTests.TernaryInt;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ternary.Formatting;

public class TernaryInt27Tests
{
    [Fact]
    public void MinValue_ReturnsValue()
    {
        var value = (TernaryInt27)TernaryInt27.MinValue;
        value.ToString().Should().Be("DDDDDDDDDDDDDDDDDDDDDDDDDDD");
    }

    [Fact]
    public void MaxValue_ReturnsValue()
    {
        var value = (TernaryInt27)TernaryInt27.MaxValue;
        value.ToString().Should().Be("UUUUUUUUUUUUUUUUUUUUUUUUUUU");
    }

    [Fact]
    public void ToString_FormatsValue()
    {
        var value = (TernaryInt27)2;
        value.ToString(Base3Format.SignFormat, 0).Should().Be("+-");
        value.ToString(Base3Format.NumberFormat, 6).Should().Be("00001T");
        value.ToString(Base3Format.LetterFormat).Should().Be("MMMMMMMMMMMMMMUD");
    }

    [Theory]
    [InlineData(TernaryInt27.MinValue)]
    [InlineData(TernaryInt27.MaxValue)]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(1)]
    public void Parse_ParsesValue(long value)
    {
        var expected = (TernaryInt27)value;
        var txt = expected.ToString();
        var actual = TernaryInt27.Parse(txt);
        expected.Should().Be(actual);
    }
}

