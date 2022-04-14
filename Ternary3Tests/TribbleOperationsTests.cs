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
        long zero = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_010___010_010_010_010_010;
        long one = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_010___010_010_010_010_100;
        long minusOne = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_010___010_010_010_010_001;
        long val320 = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_100___100_010_010_001_001;
        long val224 = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_100___010_001_100_010_001;
        long val332 = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_100___100_010_100_010_001;
        TribbleOperations.FromTritInt64(zero).Should().Be(0);
        TribbleOperations.FromTritInt64(one).Should().Be(1);
        TribbleOperations.FromTritInt64(minusOne).Should().Be(-1);
        TribbleOperations.FromTritInt64(val320).Should().Be(320);
        TribbleOperations.FromTritInt64(val224).Should().Be(224);
        TribbleOperations.FromTritInt64(val332).Should().Be(332);
    }

    [Fact]
    public void ToTritInt64()
    {
        long zero = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_010___010_010_010_010_010;
        long one = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_010___010_010_010_010_100;
        long minusOne = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_010___010_010_010_010_001;
        long val320 = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_100___100_010_010_001_001;
        long val224 = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_100___010_001_100_010_001;
        long val332 = 0b010_010_010_010_010___010_010_010_010_010___010_010_010_010_100___100_010_100_010_001;
        long val9841 = 0b010_010_010_010_010___010_010_010_010_010___010_100_100_100_100___100_100_100_100_100;
        long minus9841 = 0b010_010_010_010_010___010_010_010_010_010___010_001_001_001_001___001_001_001_001_001;
        TribbleOperations.ToTritInt64(0).Should().Be(zero);
        TribbleOperations.ToTritInt64(1).Should().Be(one);
        TribbleOperations.ToTritInt64(-1).Should().Be(minusOne);
        TribbleOperations.ToTritInt64(320).Should().Be(val320);
        TribbleOperations.ToTritInt64(224).Should().Be(val224);
        TribbleOperations.ToTritInt64(332).Should().Be(val332);
        TribbleOperations.ToTritInt64(9841).Should().Be(val9841);
        TribbleOperations.ToTritInt64(-9841).Should().Be(minus9841);
    }

    [Fact]
    public void ToTritInt32()
    {
        int zero = 0b010_010_010_010___010_010_010_010_010;
        int one = 0b010_010_010_010___010_010_010_010_100;
        int minusOne = 0b010_010_010_010___010_010_010_010_001;
        int val320 = 0b010_010_010_100___100_010_010_001_001;
        int val224 = 0b010_010_010_100___010_001_100_010_001;
        int val332 = 0b010_010_010_100___100_010_100_010_001;
        int val9841 = 0b100_100_100_100___100_100_100_100_100;
        int minus9841 = 0b001_001_001_001___001_001_001_001_001;
        TribbleOperations.ToTritInt32(0).Should().Be(zero);
        TribbleOperations.ToTritInt32(1).Should().Be(one);
        TribbleOperations.ToTritInt32(-1).Should().Be(minusOne);
        TribbleOperations.ToTritInt32(320).Should().Be(val320);
        TribbleOperations.ToTritInt32(224).Should().Be(val224);
        TribbleOperations.ToTritInt32(332).Should().Be(val332);
        TribbleOperations.ToTritInt32(9841).Should().Be(val9841);
        TribbleOperations.ToTritInt32(-9841).Should().Be(minus9841);
    }

    [Fact]
    public void Or()
    {
        // UUNNDD (320) Or UNDUND (225) => UUNUND (332)
        TribbleOperations.Or(320, 224).Should().Be(332);
    }
}
