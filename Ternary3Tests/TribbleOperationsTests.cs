namespace Ternary3Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TribbleOperationsTests
{
    [Fact]
    public void FromTritInt64()
    {
        long zero = 0b00000000_00000000_00000000_00000000;
        long one = 0b00000000_00000000_00000000_0000010;
        long minusOne = 0b00000000_00000000_00000000_0000001;
        long val320 = 0b00000000_00000000_00000010_1000000101;
        long val224 = 0b00000000_00000000_00000010_0001100001;
        long val332 = 0b00000000_00000000_00000010_1000100001;
        long val212 = 0b00000000_00000000_00000010_0001000101;
        long minus182 = 0b00000000_00000000_00000001_1001100110;
        long val43046720 = 0b00000000_00000000_00000000_00000010_00000000_00000000_00000000_00000001;
        long val43046721 = 0b00000000_00000000_00000000_00000010_00000000_00000000_00000000_00000000;
        TribbleOperations.FromTritInt64(zero).Should().Be(0);
        TribbleOperations.FromTritInt64(one).Should().Be(1);
        TribbleOperations.FromTritInt64(minusOne).Should().Be(-1);
        TribbleOperations.FromTritInt64(val320).Should().Be(320);
        TribbleOperations.FromTritInt64(val224).Should().Be(224);
        TribbleOperations.FromTritInt64(val332).Should().Be(332);

        TribbleOperations.FromTritInt64(val212).Should().Be(212);
        TribbleOperations.FromTritInt64(minus182).Should().Be(-182);

        TribbleOperations.FromTritInt64(val43046720).Should().Be(43046720);
        TribbleOperations.FromTritInt64(val43046721).Should().Be(43046721);
    }

    [Fact]
    public void ToTritInt64()
    {
        int zero = 0b00000000_00000000_00000000_00000000;
        int one = 0b00000000_00000000_00000000_0000010;
        int minusOne = 0b00000000_00000000_00000000_0000001;
        int val320 = 0b00000000_00000000_00000010_1000000101;
        int val224 = 0b00000000_00000000_00000010_0001100001;
        int val332 = 0b00000000_00000000_00000010_1000100001;
        long val43046720 = 0b00000000_00000000_00000000_00000010_00000000_00000000_00000000_00000001;
        long val43046721 = 0b00000000_00000000_00000000_00000010_00000000_00000000_00000000_00000000;
        TribbleOperations.ToTritInt64(0).Should().Be(zero);
        TribbleOperations.ToTritInt64(1).Should().Be(one);
        TribbleOperations.ToTritInt64(-1).Should().Be(minusOne);
        TribbleOperations.ToTritInt64(320).Should().Be(val320);
        TribbleOperations.ToTritInt64(224).Should().Be(val224);
        TribbleOperations.ToTritInt64(332).Should().Be(val332);
        TribbleOperations.ToTritInt64(43046720).Should().Be(val43046720);
        TribbleOperations.ToTritInt64(43046721).Should().Be(val43046721);
    }

    [Fact]
    public void ToTritInt32()
    {
        int zero = 0b00000000_00000000_00000000_00000000;
        int one = 0b00000000_00000000_00000000_0000010;
        int minusOne = 0b00000000_00000000_00000000_0000001;
        int val320 = 0b00000000_00000000_00000010_1000000101;
        int val224 = 0b00000000_00000000_00000010_0001100001;
        int val332 = 0b00000000_00000000_00000010_1000100001;

        TribbleOperations.ToTritInt32(0).Should().Be(zero);
        TribbleOperations.ToTritInt32(1).Should().Be(one);
        TribbleOperations.ToTritInt32(-1).Should().Be(minusOne);
        TribbleOperations.ToTritInt32(320).Should().Be(val320);
        TribbleOperations.ToTritInt32(224).Should().Be(val224);
        TribbleOperations.ToTritInt32(332).Should().Be(val332);
    }

    [Fact]
    public void Or()
    {
        TribbleOperations.Or(320, 224).Should().Be(332);
        TribbleOperations.Or(43046720, 43046721).Should().Be(43046721);
    }

    [Fact]
    public void And()
    {
        TribbleOperations.And(320, 224).Should().Be(212);
        TribbleOperations.And(43046720, 43046721).Should().Be(43046720);
    }

    [Fact]
    public void Xor()
    {
        TribbleOperations.Xor(320, 224).Should().Be(-182);
        TribbleOperations.Xor(224, 320).Should().Be(-182);
        TribbleOperations.Xor(224, 182).Should().Be(-320);
        TribbleOperations.Xor(182, 224).Should().Be(-320);
    }
}
