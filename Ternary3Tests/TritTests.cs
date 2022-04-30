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
        TritHelper.Parse("DoWn").Should().Be(down);
        TritHelper.Parse("MiDdLe").Should().Be(middle);
        TritHelper.Parse("uP").Should().Be(up);

        FluentActions.Invoking(() => TritHelper.Parse(default)).Should().Throw<ArgumentNullException>();
        FluentActions.Invoking(() => TritHelper.Parse("True")).Should().Throw<FormatException>();
    }

    [Fact]
    public void TryParse_ReturnsTrit()
    {
        TritHelper.TryParse("DoWn", out var d).Should().BeTrue();
        d.Should().Be(down);
        TritHelper.TryParse("MiDdLe", out var m).Should().BeTrue();
        m.Should().Be(middle);
        TritHelper.TryParse("uP", out var u).Should().BeTrue();
        u.Should().Be(up);

        TritHelper.TryParse(null, out var n).Should().BeFalse();
        TritHelper.TryParse(null, out var t).Should().BeFalse();
    }

    [Fact]
    public void Switch()
    {
        int i = 0;
        int foo() => ++i;

        down.Switch(1, 2, 3).Should().Be(1);
        middle.Switch("a", "b", "c").Should().Be("b");
        up.Switch(foo, foo, foo).Should().Be(1);
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
        d = d.Cycle(); m = m.Cycle(); u = u.Cycle();
        d.Should().Be(middle);
        m.Should().Be(up);
        u.Should().Be(down);
        d = d.AntiCycle(); m = m.AntiCycle(); u = u.AntiCycle();
        d.Should().Be(down);
        m.Should().Be(middle);
        u.Should().Be(up);
        d = d.Not(); m = m.Not(); u = u.Not();
        d.Should().Be(up);
        m.Should().Be(middle);
        u.Should().Be(down);
    }
    [Fact]
    public void BinaryOperators()
    {
        (up.Compare(up)).Should().Be(middle);
        (up.Compare(middle)).Should().Be(up);
        (up.Compare(down)).Should().Be(up);
        (middle.Compare(up)).Should().Be(down);
        (middle.Compare(middle)).Should().Be(middle);
        (middle.Compare(down)).Should().Be(up);
        (down.Compare(up)).Should().Be(down);
        (down.Compare(middle)).Should().Be(down);
        (down.Compare(down)).Should().Be(middle);

        (up.And(up)).Should().Be(up);
        (up.And(middle)).Should().Be(middle);
        (up.And(down)).Should().Be(down);
        (middle.And(up)).Should().Be(middle);
        (middle.And(middle)).Should().Be(middle);
        (middle.And(down)).Should().Be(down);
        (down.And(up)).Should().Be(down);
        (down.And(middle)).Should().Be(down);
        (down.And(down)).Should().Be(down);

        (up.Or(up)).Should().Be(up);
        (up.Or(middle)).Should().Be(up);
        (up.Or(down)).Should().Be(up);
        (middle.Or(up)).Should().Be(up);
        (middle.Or(middle)).Should().Be(middle);
        (middle.Or(down)).Should().Be(middle);
        (down.Or(up)).Should().Be(up);
        (down.Or(middle)).Should().Be(middle);
        (down.Or(down)).Should().Be(down);

        (up.Xor(up)).Should().Be(down);
        (up.Xor(middle)).Should().Be(up);
        (up.Xor(down)).Should().Be(middle);
        (middle.Xor(up)).Should().Be(up);
        (middle.Xor(middle)).Should().Be(middle);
        (middle.Xor(down)).Should().Be(down);
        (down.Xor(up)).Should().Be(middle);
        (down.Xor(middle)).Should().Be(down);
        (down.Xor(down)).Should().Be(up);
    }

    [Fact]
    public void CastFromBool()
    {
        trit trueTrit = true.ToTrit();
        trueTrit.Should().Be(up);

        trit nullTrit = default(bool?).ToTrit();
        nullTrit.Should().Be(middle);

        trit falseTrit = false.ToTrit();
        falseTrit.Should().Be(down);
    }


    [Fact]
    public void CastToBool()
    {
        bool? upBool = up.ToNullableBoolean();
        upBool.Should().Be(true);

        bool? middleBool = middle.ToNullableBoolean();
        middleBool.Should().BeNull();

        bool? downBool = down.ToNullableBoolean();
        downBool.Should().Be(false);
    }
}