namespace Ternary3Tests;

using Ternary3;

public class ModuloTests
{
    [Fact]
    public void UnsignedModulo27Int32()
    {
        0.UnsignedModulo27Minus13().Should().Be(-13);
        1.UnsignedModulo27Minus13().Should().Be(-12);
        26.UnsignedModulo27Minus13().Should().Be(13);
        27.UnsignedModulo27Minus13().Should().Be(-13);
        28.UnsignedModulo27Minus13().Should().Be(-12);
        (-1).UnsignedModulo27Minus13().Should().Be(13);
        (-26).UnsignedModulo27Minus13().Should().Be(-12);
        (-27).UnsignedModulo27Minus13().Should().Be(-13);
        2147483636.UnsignedModulo27Minus13().Should().Be(13);
        2147483637.UnsignedModulo27Minus13().Should().Be(-13);
        2147483638.UnsignedModulo27Minus13().Should().Be(-12);
        2147483647.UnsignedModulo27Minus13().Should().Be(-3);
        (-2147483636).UnsignedModulo27Minus13().Should().Be(-12);
        (-2147483637).UnsignedModulo27Minus13().Should().Be(-13);
        (-2147483638).UnsignedModulo27Minus13().Should().Be(13);
        (-2147483647).UnsignedModulo27Minus13().Should().Be(4);
    }

    public void UnsignedModulo27Int64()
    {
        0L.UnsignedModulo27Minus13().Should().Be(0);
        1L.UnsignedModulo27Minus13().Should().Be(1);
        26L.UnsignedModulo27Minus13().Should().Be(26);
        27L.UnsignedModulo27Minus13().Should().Be(0);
        28L.UnsignedModulo27Minus13().Should().Be(1);
        (-1L).UnsignedModulo27Minus13().Should().Be(26);
        (-26L).UnsignedModulo27Minus13().Should().Be(1);
        (-27L).UnsignedModulo27Minus13().Should().Be(0);
        2147483636L.UnsignedModulo27Minus13().Should().Be(26);
        2147483637L.UnsignedModulo27Minus13().Should().Be(0);
        2147483638L.UnsignedModulo27Minus13().Should().Be(1);
        2147483647L.UnsignedModulo27Minus13().Should().Be(10);
        (-2147483636L).UnsignedModulo27Minus13().Should().Be(1);
        (-2147483637L).UnsignedModulo27Minus13().Should().Be(0);
        (-2147483638L).UnsignedModulo27Minus13().Should().Be(26);
        (-2147483647L).UnsignedModulo27Minus13().Should().Be(17);
        9223372036854775781.UnsignedModulo27Minus13().Should().Be(26);
        9223372036854775782.UnsignedModulo27Minus13().Should().Be(0);
        9223372036854775783.UnsignedModulo27Minus13().Should().Be(1);
        9223372036854775807.UnsignedModulo27Minus13().Should().Be(25);
        (-9223372036854775781).UnsignedModulo27Minus13().Should().Be(1);
        (-9223372036854775782).UnsignedModulo27Minus13().Should().Be(0);
        (-9223372036854775783).UnsignedModulo27Minus13().Should().Be(26);
        (-9223372036854775807).UnsignedModulo27Minus13().Should().Be(2);
    }

    [Fact]
    public void SignedModulo27Int32()
    {
        0.SignedModulo27().Should().Be(0);
        1.SignedModulo27().Should().Be(1);
        12.SignedModulo27().Should().Be(12);
        13.SignedModulo27().Should().Be(13);
        14.SignedModulo27().Should().Be(-13);
        (-1).SignedModulo27().Should().Be(-1);
        (-12).SignedModulo27().Should().Be(-12);
        (-13).SignedModulo27().Should().Be(-13);
        (-14).SignedModulo27().Should().Be(13);
        2147483636.SignedModulo27().Should().Be(-1);
        2147483637.SignedModulo27().Should().Be(0);
        2147483638.SignedModulo27().Should().Be(1);
        2147483647.SignedModulo27().Should().Be(10);
        (-2147483636).SignedModulo27().Should().Be(1);
        (-2147483637).SignedModulo27().Should().Be(0);
        (-2147483638).SignedModulo27().Should().Be(-1);
        (-2147483647).SignedModulo27().Should().Be(-10);
    }

    [Fact]
    public void SignedModulo27Int64()
    {
        0L.SignedModulo27().Should().Be(0);
        1L.SignedModulo27().Should().Be(1);
        12L.SignedModulo27().Should().Be(12);
        13L.SignedModulo27().Should().Be(13);
        14L.SignedModulo27().Should().Be(-13);
        (-1L).SignedModulo27().Should().Be(-1);
        (-12L).SignedModulo27().Should().Be(-12);
        (-13L).SignedModulo27().Should().Be(-13);
        (-14L).SignedModulo27().Should().Be(13);
        2147483636L.SignedModulo27().Should().Be(-1);
        2147483637L.SignedModulo27().Should().Be(0);
        2147483638L.SignedModulo27().Should().Be(1);
        2147483647L.SignedModulo27().Should().Be(10);
        (-2147483636L).SignedModulo27().Should().Be(1);
        (-2147483637L).SignedModulo27().Should().Be(0);
        (-2147483638L).SignedModulo27().Should().Be(-1);
        (-2147483647L).SignedModulo27().Should().Be(-10);
        9223372036854775781.SignedModulo27().Should().Be(-1);
        9223372036854775782.SignedModulo27().Should().Be(0);
        9223372036854775783.SignedModulo27().Should().Be(1);
        9223372036854775807.SignedModulo27().Should().Be(-2);
        (-9223372036854775781).SignedModulo27().Should().Be(1);
        (-9223372036854775782).SignedModulo27().Should().Be(0);
        (-9223372036854775783).SignedModulo27().Should().Be(-1);
        (-9223372036854775807).SignedModulo27().Should().Be(2);
    }
}

