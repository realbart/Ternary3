namespace Ternary3Tests;

using Ternary3;

public class Int32ExtensionsTests
{
    [Fact]
    public void GetTrits()
    {
        0.GetTrits().Should().Equal(new[] { middle });
        1.GetTrits().Should().Equal(new[] { up });
        2.GetTrits().Should().Equal(new[] { down, up });
        (-25).GetTrits().Should().Equal(new[] { down, up, middle, down });
        2147483645.GetTrits().Should().Equal(new[] { down, middle, up, down, up, down, up, up, up, down, down, middle, middle, middle, down, middle, down, down, middle, down, up });
        2147483646.GetTrits().Should().Equal(new[] { middle, middle, up, down, up, down, up, up, up, down, down, middle, middle, middle, down, middle, down, down, middle, down, up });
        2147483647.GetTrits().Should().Equal(new[] { up, middle, up, down, up, down, up, up, up, down, down, middle, middle, middle, down, middle, down, down, middle, down, up });
        (-2147483645).GetTrits().Should().Equal(new[] { up, middle, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down });
        (-2147483646).GetTrits().Should().Equal(new[] { middle, middle, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down });
        (-2147483647).GetTrits().Should().Equal(new[] { down, middle, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down });
        (-2147483648).GetTrits().Should().Equal(new[] { up, down, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down });
    }

    [Fact]
    public void ToInt32()
    {
        new[] { middle }.ToInt32().Should().Be(0);
        new[] { middle, middle, middle }.ToInt32().Should().Be(0);
        new[] { up, middle }.ToInt32().Should().Be(1);
        new[] { down, up, middle, down }.ToInt32().Should().Be(-25);
        new[] { up, middle, up, down, up, down, up, up, up, down, down, middle, middle, middle, down, middle, down, down, middle, down, up }.ToInt32().Should().Be(2147483647);
        new[] { up, down, down, up, down, up, down, down, down, up, up, middle, middle, middle, up, middle, up, up, middle, up, down }.ToInt32().Should().Be(-2147483648);
    }
}
