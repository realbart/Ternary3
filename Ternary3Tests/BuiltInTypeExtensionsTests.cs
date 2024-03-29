﻿namespace TernaryTests;

using Ternary;
using Ternary.Internal;

public class BuiltInTypeExtensionsTests
{
    [Fact]
    public void GetTrits()
    {
        //0.GetTrits().Should().Equal(new[] { middle });
        //1.GetTrits().Should().Equal(new[] { up });
        //2.GetTrits().Should().Equal(new[] { down, up });
        //(-25).GetTrits().Should().Equal(new[] { down, up, middle, down });
        //2147483645.GetTrits().Should().Equal(new[] { down, middle, up, down, up, down, up, up, up, down, down, middle, middle, middle, down, middle, down, down, middle, down, up });
        //2147483646.GetTrits().Should().Equal(new[] { middle, middle, up, down, up, down, up, up, up, down, down, middle, middle, middle, down, middle, down, down, middle, down, up });
        //2147483647.GetTrits().Should().Equal(new[] { up, middle, up, down, up, down, up, up, up, down, down, middle, middle, middle, down, middle, down, down, middle, down, up });
        //(-2147483645).GetTrits().Should().Equal(new[] { up, middle, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down });
        //(-2147483646).GetTrits().Should().Equal(new[] { middle, middle, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down });
        //(-2147483647).GetTrits().Should().Equal(new[] { down, middle, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down });
        //(-2147483648).GetTrits().Should().Equal(new[] { up, down, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down });
    }

    [Fact]
    public void ToInt32()
    {
        //new[] { middle }.ToInt32().Should().Be(0);
        //new[] { middle, middle, middle }.ToInt32().Should().Be(0);
        //new[] { up, middle }.ToInt32().Should().Be(1);
        //new[] { down, up, middle, down }.ToInt32().Should().Be(-25);
        //new[] { up, middle, up, down, up, down, up, up, up, down, down, middle, middle, middle, down, middle, down, down, middle, down, up }.ToInt32().Should().Be(-1339300754); // not int.MaxValue
        //new[] { up, down, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down }.ToInt32().Should().Be(1339300753); // not int.MinValue
    }

    [Fact]
    public void Switch()
    {
        bool? f = false;
        bool? n = null;
        bool? t = true;

        f.Switch(1, 2, 3).Should().Be(1);
        n.Switch(1, 2, 3).Should().Be(2);
        t.Switch(1, 2, 3).Should().Be(3);

        f.Switch(() => "a", "b", default(string)).Should().Be("a");
        n.Switch(() => "a", "b", default(string)).Should().Be("b");
        t.Switch(() => "a", "b", default(string)).Should().Be(null);

        int count = 0;
        f.Switch(() => count += 1, () => count += 2, () => count += 4);
        count.Should().Be(1);
        n.Switch(() => count += 1, () => count += 2, () => count += 4);
        count.Should().Be(3);
        t.Switch(() => count += 1, () => count += 2, () => count += 4);
        count.Should().Be(7);
    }

    [Fact]
    public void PerformTernaryOperation()
    {
        //int i = 12345;
        //var result =i.PerformTernaryOperation(trit => trit.Switch(up, middle, down));
        //result.Should().Be(-12345);
    }

    [Fact]
    public void Max()
    {
        //new[] { up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up }
        //    .ToInt32()
        //    .Should().Be(1743392200);
        //new[] { up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up, up }
        //    .ToInt32()
        //    .Should().Be(1743392200);
        //new[] { down, down, down, down, down, down, down, down, down, down, down, down, down, down, down, down, down, down, down, down, up }
        //    .ToInt32()
        //    .Should().Be(-1743392200);
    }

    [Fact]
    public void Or()
    {
        224.TernaryOr(320).Should().Be(332);
        320.TernaryOr(224).Should().Be(332);
        332.TernaryOr(224).Should().Be(332);
        320.TernaryOr(332).Should().Be(332);
        BuiltInTypeExtensions.TernaryOr(320, 224).Should().Be(332);
        BuiltInTypeExtensions.TernaryOr(43046720, 43046721).Should().Be(43046721);
    }

    [Fact]
    public void And()
    {
        BuiltInTypeExtensions.TernaryAnd(320, 224).Should().Be(212);
        BuiltInTypeExtensions.TernaryAnd(43046720, 43046721).Should().Be(43046720);
    }

    [Fact]
    public void Xor()
    {
        BuiltInTypeExtensions.TernaryXor(320, 224).Should().Be(-182);
        BuiltInTypeExtensions.TernaryXor(224, 320).Should().Be(-182);
        BuiltInTypeExtensions.TernaryXor(224, 182).Should().Be(-320);
        BuiltInTypeExtensions.TernaryXor(182, 224).Should().Be(-320);
    }
}
