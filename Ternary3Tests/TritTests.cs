namespace Ternary3Tests;

public class TritTests
{
    [Fact]
    public void ToString_ConvertsTritToString()
    {
        $"{down}{middle}{up}".Should().Be("DownMiddleUp");
    }

    [Fact]
    public void Equality()
    {
        var d1 = down;
        var d2 = down;
        var m1 = middle;
        var m2 = middle;
        var u1 = up;
        var u2 = up;

        d1.Should().Be(d2);
        d2.Should().Be(d1);
        m1.Should().Be(m2);
        m2.Should().Be(m1);
        u1.Should().Be(u2);
        u2.Should().Be(u1);

        (d1 == d2).Should().BeTrue();
        (d2 == d1).Should().BeTrue();
        (m1 == m2).Should().BeTrue();
        (m2 == m1).Should().BeTrue();
        (u1 == u2).Should().BeTrue();
        (u2 == u1).Should().BeTrue();

        u1.Should().NotBe(d1);
        d1.Should().NotBe(u1);
        d1.Should().NotBe(m1);
        m1.Should().NotBe(d1);
        m1.Should().NotBe(u1);
        u1.Should().NotBe(m1);

        (u1 == d1).Should().BeFalse();
        (d1 == u1).Should().BeFalse();
        (d1 == m1).Should().BeFalse();
        (m1 == d1).Should().BeFalse();
        (m1 == u1).Should().BeFalse();
        (d1 == m1).Should().BeFalse();
    }

    [Fact]
    public void Parse_ReturnsTrit()
    {
        trit.Parse("DoWn").Should().Be(down);
        trit.Parse("MiDdLe").Should().Be(middle);
        trit.Parse("uP").Should().Be(up);

        FluentActions.Invoking(() => trit.Parse(default)).Should().Throw<ArgumentNullException>();
        FluentActions.Invoking(() => trit.Parse("True")).Should().Throw<FormatException>();
    }

    [Fact]
    public void TryParse_ReturnsTrit()
    {
        trit.TryParse("DoWn", out var d).Should().BeTrue();
        d.Should().Be(down);
        trit.TryParse("MiDdLe", out var m).Should().BeTrue();
        m.Should().Be(middle);
        trit.TryParse("uP", out var u).Should().BeTrue();
        u.Should().Be(up);

        trit.TryParse(null, out var n).Should().BeFalse();
        trit.TryParse(null, out var t).Should().BeFalse();
    }

    [Fact]
    public void Switch()
    {
        int i = 0;
        int foo() => i++;

        down.Switch(1, 2, 3).Should().Be(1);
        middle.Switch("a", "b", "c").Should().Be("b");
        up.Switch(foo, foo, foo).Should().Be(0);
        i.Should().Be(1);
        void x() => throw new Exception();
        void m() => i = 99;

        middle.Switch(x, m, x);
        i.Should().Be(99);
    }

    [Fact]
    public void UnaryOperators()
    {
        var d = down;
        var m = middle;
        var u = up;
        d++;m++;u++;
        d.Should().Be(middle);
        m.Should().Be(up);
        u.Should().Be(down);
        d--;m--;u--;
        d.Should().Be(down);
        m.Should().Be(middle);
        u.Should().Be(up);
        d = !d; m = !m; u = !u;
        d.Should().Be(up);
        m.Should().Be(middle);
        u.Should().Be(down);
    }
    [Fact]
    public void BinaryOperators()
    {
        (up > up).Should().Be(middle);
        (up > middle).Should().Be(up);
        (up > down).Should().Be(up);
        (middle > up).Should().Be(down);
        (middle > middle).Should().Be(middle);
        (middle > down).Should().Be(up);
        (down > up).Should().Be(down);
        (down > middle).Should().Be(down);
        (down > down).Should().Be(middle);

        (up < up).Should().Be(middle);
        (up < middle).Should().Be(down);
        (up < down).Should().Be(down);
        (middle < up).Should().Be(up);
        (middle < middle).Should().Be(middle);
        (middle < down).Should().Be(down);
        (down < up).Should().Be(up);
        (down < middle).Should().Be(up);
        (down < down).Should().Be(middle);

        (up & up).Should().Be(up);
        (up & middle).Should().Be(middle);
        (up & down).Should().Be(down);
        (middle & up).Should().Be(middle);
        (middle & middle).Should().Be(middle);
        (middle & down).Should().Be(down);
        (down & up).Should().Be(down);
        (down & middle).Should().Be(down);
        (down & down).Should().Be(down);

        (up | up).Should().Be(up);
        (up | middle).Should().Be(up);
        (up | down).Should().Be(up);
        (middle | up).Should().Be(up);
        (middle | middle).Should().Be(middle);
        (middle | down).Should().Be(middle);
        (down | up).Should().Be(up);
        (down | middle).Should().Be(middle);
        (down | down).Should().Be(down);

        (up ^ up).Should().Be(middle);
        (up ^ middle).Should().Be(up);
        (up ^ down).Should().Be(middle);
        (middle ^ up).Should().Be(up);
        (middle ^ middle).Should().Be(middle);
        (middle ^ down).Should().Be(down);
        (down ^ up).Should().Be(middle);
        (down ^ middle).Should().Be(down);
        (down ^ down).Should().Be(middle);
    }

    [Fact]
    public void CastFromBool()
    {
        trit trueTrit = true;
        trueTrit.Should().Be(up);
        
        trit nullTrit = default(bool?);
        nullTrit.Should().Be(middle);

        trit falseTrit = false;
        falseTrit.Should().Be(down);
    }


    [Fact]
    public void CastToBool()
    {
        bool? upBool = up;
        upBool.Should().Be(true);

        bool? middleBool= middle;
        middleBool.Should().BeNull();

        bool? downBool= down;
        downBool.Should().Be(false);
    }
}