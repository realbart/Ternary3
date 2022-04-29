namespace Ternary3Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ternary3.Internal;

public class ConversionTests
{
    [Fact]
    public void FromTritInt64()
    {
        ulong zero = 0b00000000_00000000_00000000_00000000;
        ulong one = 0b00000000_00000000_00000000_0000010;
        ulong minusOne = 0b00000000_00000000_00000000_0000001;
        ulong val320 = 0b00000000_00000000_00000010_1000000101;
        ulong val224 = 0b00000000_00000000_00000010_0001100001;
        ulong val332 = 0b00000000_00000000_00000010_1000100001;
        ulong val212 = 0b00000000_00000000_00000010_0001000101;
        ulong minus182 = 0b00000000_00000000_00000001_1001100110;
        ulong val43046720 = 0b00000000_00000000_00000000_00000010_00000000_00000000_00000000_00000001;
        ulong val43046721 = 0b00000000_00000000_00000000_00000010_00000000_00000000_00000000_00000000;
        Conversion.ToInt32(zero).Should().Be(0);
        Conversion.ToInt32(one).Should().Be(1);
        Conversion.ToInt32(minusOne).Should().Be(-1);
        Conversion.ToInt32(val320).Should().Be(320);
        Conversion.ToInt32(val224).Should().Be(224);
        Conversion.ToInt32(val332).Should().Be(332);
        Conversion.ToInt32(val212).Should().Be(212);
        Conversion.ToInt32(minus182).Should().Be(-182);
        Conversion.ToInt32(val43046720).Should().Be(43046720);
        Conversion.ToInt32(val43046721).Should().Be(43046721);
    }

    [Fact]
    public void ToTritInt64()
    {
        uint zero = 0b00000000_00000000_00000000_00000000;
        uint one = 0b00000000_00000000_00000000_0000010;
        uint minusOne = 0b00000000_00000000_00000000_0000001;
        uint val320 = 0b00000000_00000000_00000010_1000000101;
        uint val224 = 0b00000000_00000000_00000010_0001100001;
        uint val332 = 0b00000000_00000000_00000010_1000100001;
        ulong val43046720 = 0b00000000_00000000_00000000_00000010_00000000_00000000_00000000_00000001;
        ulong val43046721 = 0b00000000_00000000_00000000_00000010_00000000_00000000_00000000_00000000;
        Conversion.ToTrits20(0).Should().Be(zero);
        Conversion.ToTrits20(1).Should().Be(one);
        Conversion.ToTrits20(-1).Should().Be(minusOne);
        Conversion.ToTrits20(320).Should().Be(val320);
        Conversion.ToTrits20(224).Should().Be(val224);
        Conversion.ToTrits20(332).Should().Be(val332);
        Conversion.ToTrits20(43046720).Should().Be(val43046720);
        Conversion.ToTrits20(43046721).Should().Be(val43046721);
    }

    [Fact]
    public void ToTritUInt32()
    {
        uint zero = 0b00000000_00000000_00000000_00000000;
        uint one = 0b00000000_00000000_00000000_0000010;
        uint minusOne = 0b00000000_00000000_00000000_0000001;
        uint val320 = 0b00000000_00000000_00000010_1000000101;
        uint val224 = 0b00000000_00000000_00000010_0001100001;
        uint val332 = 0b00000000_00000000_00000010_1000100001;

        Conversion.ToTrits16(0).Should().Be(zero);
        Conversion.ToTrits16(1).Should().Be(one);
        Conversion.ToTrits16(-1).Should().Be(minusOne);
        Conversion.ToTrits16(320).Should().Be(val320);
        Conversion.ToTrits16(224).Should().Be(val224);
        Conversion.ToTrits16(332).Should().Be(val332);
    }
}
