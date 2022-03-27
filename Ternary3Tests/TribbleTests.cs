namespace Ternary3Tests;

using Ternary3;

public class TribbleTests
{
}

public class Int3Tests
{
    [Fact]
    public void CreateExpectedValue()
    {
        ((int)new Int3(down, down, down)).Should().Be(-13);
        ((int)new Int3(middle, down, down)).Should().Be(-12);
        ((int)new Int3(up, down, down)).Should().Be(-11);
        ((int)new Int3(down, middle, down)).Should().Be(-10);
        ((int)new Int3(middle, middle, down)).Should().Be(-9);
        ((int)new Int3(up, middle, down)).Should().Be(-8);
        ((int)new Int3(down, up, down)).Should().Be(-7);
        ((int)new Int3(middle, up, down)).Should().Be(-6);
        ((int)new Int3(up, up, down)).Should().Be(-5);
        ((int)new Int3(down, down, middle)).Should().Be(-4);
        ((int)new Int3(middle, down, middle)).Should().Be(-3);
        ((int)new Int3(up, down, middle)).Should().Be(-2);
        ((int)new Int3(down, middle, middle)).Should().Be(-1);
        ((int)new Int3(middle, middle, middle)).Should().Be(0);
        ((int)new Int3(up, middle, middle)).Should().Be(1);
        ((int)new Int3(down, up, middle)).Should().Be(2);
        ((int)new Int3(middle, up, middle)).Should().Be(3);
        ((int)new Int3(up, up, middle)).Should().Be(4);
        ((int)new Int3(down, down, up)).Should().Be(5);
        ((int)new Int3(middle, down, up)).Should().Be(6);
        ((int)new Int3(up, down, up)).Should().Be(7);
        ((int)new Int3(down, middle, up)).Should().Be(8);
        ((int)new Int3(middle, middle, up)).Should().Be(9);
        ((int)new Int3(up, middle, up)).Should().Be(10);
        ((int)new Int3(down, up, up)).Should().Be(11);
        ((int)new Int3(middle, up, up)).Should().Be(12);
        ((int)new Int3(up, up, up)).Should().Be(13);
    }

    [Fact]
    public void Cast()
    {
        ((int)(Int3)0).Should().Be(0);
        ((int)(Int3)(-1)).Should().Be(-1);
        ((int)(Int3)1).Should().Be(1);
        ((int)(Int3)(-14)).Should().Be(13);
        ((int)(Int3)14).Should().Be(-13);
        ((int)(Int3)2147483647).Should().Be(10);
        ((int)(Int3)(-2147483647)).Should().Be(-10);
    }

    [Fact]
    public void Add()
    {
        var val0 = (Int3)0;
        var val5 = (Int3)5;
        var valMinus5 = (Int3)(-5);
        var val13 = (Int3)13;
        var valMinus13 = (Int3)(-13);
        ((int)(val0 + val0)).Should().Be(0);
        ((int)(val5 + val5)).Should().Be(10);
        ((int)(valMinus5 + valMinus5)).Should().Be(-10);
        ((int)(val13 + val13)).Should().Be(-1);
        ((int)(valMinus13 + valMinus13)).Should().Be(1);
    }

    [Fact]
    public void Substract()
    {
        var val0 = (Int3)0;
        var val5 = (Int3)5;
        var valMinus5 = (Int3)(-5);
        var val13 = (Int3)13;
        var valMinus13 = (Int3)(-13);
        ((int)(val0 - val0)).Should().Be(0);
        ((int)(val5 - valMinus5)).Should().Be(10);
        ((int)(valMinus5 - val5)).Should().Be(-10);
        ((int)(val13 - valMinus13)).Should().Be(-1);
        ((int)(valMinus13 - val13)).Should().Be(1);
    }
}

public class UInt3Tests
{
    [Fact]
    public void CreateExpectedValue()
    {
        ((int)new UInt3(down, down, down)).Should().Be(0);
        ((int)new UInt3(middle, down, down)).Should().Be(1);
        ((int)new UInt3(up, down, down)).Should().Be(2);
        ((int)new UInt3(down, middle, down)).Should().Be(3);
        ((int)new UInt3(middle, middle, down)).Should().Be(4);
        ((int)new UInt3(up, middle, down)).Should().Be(5);
        ((int)new UInt3(down, up, down)).Should().Be(6);
        ((int)new UInt3(middle, up, down)).Should().Be(7);
        ((int)new UInt3(up, up, down)).Should().Be(8);
        ((int)new UInt3(down, down, middle)).Should().Be(9);
        ((int)new UInt3(middle, down, middle)).Should().Be(10);
        ((int)new UInt3(up, down, middle)).Should().Be(11);
        ((int)new UInt3(down, middle, middle)).Should().Be(12);
        ((int)new UInt3(middle, middle, middle)).Should().Be(13);
        ((int)new UInt3(up, middle, middle)).Should().Be(14);
        ((int)new UInt3(down, up, middle)).Should().Be(15);
        ((int)new UInt3(middle, up, middle)).Should().Be(16);
        ((int)new UInt3(up, up, middle)).Should().Be(17);
        ((int)new UInt3(down, down, up)).Should().Be(18);
        ((int)new UInt3(middle, down, up)).Should().Be(19);
        ((int)new UInt3(up, down, up)).Should().Be(20);
        ((int)new UInt3(down, middle, up)).Should().Be(21);
        ((int)new UInt3(middle, middle, up)).Should().Be(22);
        ((int)new UInt3(up, middle, up)).Should().Be(23);
        ((int)new UInt3(down, up, up)).Should().Be(24);
        ((int)new UInt3(middle, up, up)).Should().Be(25);
        ((int)new UInt3(up, up, up)).Should().Be(26);
    }

    [Fact]
    public void Cast()
    {
        ((int)(UInt3)0).Should().Be(0);
        ((int)(UInt3)(-1)).Should().Be(26);
        ((int)(UInt3)1).Should().Be(1);
        ((int)(UInt3)(-14)).Should().Be(13);
        ((int)(UInt3)14).Should().Be(14);
        ((int)(UInt3)2147483647).Should().Be(10);
        ((int)(UInt3)(-2147483636)).Should().Be(1);
        ((int)(UInt3)(-2147483637)).Should().Be(0);
        ((int)(UInt3)(-2147483638)).Should().Be(26);
        ((int)(UInt3)(-2147483647)).Should().Be(17);
    }

    [Fact]
    public void Add()
    {
        var val0 = (UInt3)0;
        var val5 = (UInt3)5;
        var val13 = (UInt3)13;
        var val26 = (UInt3)26;
        ((int)(val0 + val0)).Should().Be(0);
        ((int)(val5 + val5)).Should().Be(10);
        ((int)(val13 + val13)).Should().Be(26);
        ((int)(val26 + val26)).Should().Be(25);
    }

    [Fact]
    public void Substract()
    {
        var val0 = (UInt3)0;
        var val5 = (UInt3)5;
        var val13 = (UInt3)13;
        var val26 = (UInt3)26;
        ((int)(val0 - val0)).Should().Be(0);
        ((int)(val5 - val5)).Should().Be(0);
        ((int)(val26 - val13)).Should().Be(13);
        ((int)(val13 - val26)).Should().Be(14);
    }
}