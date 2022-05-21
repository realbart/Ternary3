namespace TernaryTests.Internal;

using Ternary.Internal;

public class ParserTests
{

    [Fact]
    public void ToTrits16_ParsesNumber()
    {
        Parser.ToTrits16("++00--").Should().Be(0b101000000101);
        Parser.ToTrits16("00++00--").Should().Be(0b101000000101);
        Parser.ToTrits16("UUMMDD").Should().Be(0b101000000101);
        Parser.ToTrits16("uummdd").Should().Be(0b101000000101);
        Parser.ToTrits16("1100tt").Should().Be(0b101000000101);
        Parser.ToTrits16("1100TT").Should().Be(0b101000000101);
        Parser.ToTrits16("1100TT", 6).Should().Be(0b101000000101);
        Parser.ToTrits16("1111111111111111").Should().Be(0b10101010101010101010101010101010);
        FluentActions.Invoking(() => Parser.ToTrits16("110x0TT")).Should().Throw<FormatException>();
        FluentActions.Invoking(() => Parser.ToTrits16("11111111111111111")).Should().Throw<OverflowException>();
        FluentActions.Invoking(() => Parser.ToTrits16("1100TT", 5)).Should().Throw<OverflowException>();
    }

    [Fact]
    public void ToTrits32_ParsesNumber()
    {
        Parser.ToTrits32("++00--").Should().Be(0b101000000101);
        Parser.ToTrits32("00++00--").Should().Be(0b101000000101);
        Parser.ToTrits32("UUMMDD").Should().Be(0b101000000101);
        Parser.ToTrits32("uummdd").Should().Be(0b101000000101);
        Parser.ToTrits32("1100tt").Should().Be(0b101000000101);
        Parser.ToTrits32("1100TT").Should().Be(0b101000000101);
        Parser.ToTrits32("1100TT", 6).Should().Be(0b101000000101);
        FluentActions.Invoking(() => Parser.ToTrits32("110x0TT")).Should().Throw<FormatException>();
        FluentActions.Invoking(() => Parser.ToTrits32("11111111111111111")).Should().NotThrow<OverflowException>();
        FluentActions.Invoking(() => Parser.ToTrits32("11111111111111111111111111111111")).Should().NotThrow<OverflowException>();
        FluentActions.Invoking(() => Parser.ToTrits32("111111111111111111111111111111111")).Should().Throw<OverflowException>();
        FluentActions.Invoking(() => Parser.ToTrits32("1100TT", 5)).Should().Throw<OverflowException>();
    }

    [Fact]
    public void ToTrits64_ParsesNumber()
    {
        Parser.ToTrits64("++00--").Should().Be((0, 0b101000000101));
        Parser.ToTrits64("00++00--").Should().Be((0, 0b101000000101));
        Parser.ToTrits64("UUMMDD").Should().Be((0, 0b101000000101));
        Parser.ToTrits64("uummdd").Should().Be((0, 0b101000000101));
        Parser.ToTrits64("1100tt").Should().Be((0, 0b101000000101));
        Parser.ToTrits64("1100TT").Should().Be((0, 0b101000000101));
        Parser.ToTrits64("1100TT", 6).Should().Be((0, 0b101000000101));
        Parser.ToTrits64("11111111000000000000000011111111TTTTTTTT00000000TTTTTTTT00000000").Should().Be((0b1010101010101010000000000000000000000000000000001010101010101010u, 0b0101010101010101000000000000000001010101010101010000000000000000u));
        FluentActions.Invoking(() => Parser.ToTrits64("110x0TT")).Should().Throw<FormatException>();
        FluentActions.Invoking(() => Parser.ToTrits64("111111111000000000000000011111111TTTTTTTT00000000TTTTTTTT00000000")).Should().Throw<OverflowException>();
        FluentActions.Invoking(() => Parser.ToTrits64("1100TT", 5)).Should().Throw<OverflowException>();
    }
}
