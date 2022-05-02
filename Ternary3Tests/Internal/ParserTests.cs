namespace Ternary3Tests.Internal;

using Ternary3.Internal;

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
        Parser.ToTrits16("1100TT",6).Should().Be(0b101000000101);
        FluentActions.Invoking(() => Parser.ToTrits16("110x0TT")).Should().Throw<FormatException>();
        FluentActions.Invoking(() => Parser.ToTrits16("11111111111111111")).Should().Throw<OverflowException>();
        FluentActions.Invoking(() => Parser.ToTrits16("1100TT", 5)).Should().Throw<OverflowException>();
    }
}
