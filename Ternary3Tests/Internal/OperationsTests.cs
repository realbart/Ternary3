namespace Ternary3Tests;
using Ternary3.Internal;

public class OperationsTests
{
    [Fact]
    public void Or()
    {
        Operations.Or(320, 224).Should().Be(332);
        Operations.Or(43046720, 43046721).Should().Be(43046721);
    }

    [Fact]
    public void And()
    {
        Operations.And(320, 224).Should().Be(212);
        Operations.And(43046720, 43046721).Should().Be(43046720);
    }

    [Fact]
    public void Xor()
    {
        Operations.Xor(320, 224).Should().Be(-182);
        Operations.Xor(224, 320).Should().Be(-182);
        Operations.Xor(224, 182).Should().Be(-320);
        Operations.Xor(182, 224).Should().Be(-320);
    }
}
