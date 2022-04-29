using Ternary3.BuiltInTypes;

namespace Ternary3Tests.Internal;

public class BalancedModuloTests
{
    [Fact]
    public void ModThreePow20()
    {
        var maxTrit20 = 1743392200;
            (maxTrit20).ModThreePow20().Should().Be(maxTrit20);
            (maxTrit20 + 1).ModThreePow20().Should().Be(-maxTrit20);
            (-maxTrit20).ModThreePow20().Should().Be(-maxTrit20);
            (-maxTrit20 - 1).ModThreePow20().Should().Be(maxTrit20);
    }

    [Fact]
    public void ModThreePow19()
    {
        var maxTrit20 = 1743392200;
        var maxTrit19 = 581130733;
        (maxTrit20).ModThreePow19().Should().Be(maxTrit19);
        (maxTrit20 + 1).ModThreePow19().Should().Be(-maxTrit19);
        (-maxTrit20).ModThreePow19().Should().Be(-maxTrit19);
        (-maxTrit20 - 1).ModThreePow19().Should().Be(maxTrit19);
    }

}
