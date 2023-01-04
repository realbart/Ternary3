using System.IO;
using Ternary.IO;

namespace TernaryTests.IO;

public class Read4TritsPerByteTernaryStreamAdapterTests
{
    [Theory]
    [InlineData(false, "5703AB", "-13,0,13")]
    [InlineData(true, "FC245703AB", "-13,0,13")]
    [InlineData(false, "540ABF", "-13,0,13")]
    [InlineData(true, "FC24540ABF", "-13,0,13")]
    public void Read_ShouldReadExpectedData(bool expectEncodingHeader, string binaryData, string expectedTernaryData)
    {
        var binaryBytes = Convert.FromHexString(binaryData);
        var memoryStream = new MemoryStream(binaryBytes);
        var ternaryBuffer = new TernaryInt3[3];
        using (var sut = new Read4TritsPerByteTernaryStreamAdapter(memoryStream, expectEncodingHeader))
        {
            var actual = sut.Read(ternaryBuffer, 0, 100);
            actual.Should().Be(3);
        }
        var actualTernaryData = string.Join(",", ternaryBuffer.Take(3).Select(t => ((int)t).ToString()));
        actualTernaryData.Should().Be(expectedTernaryData);
    }

    [Theory]
    [InlineData(new byte[] { 0xFF })]
    [InlineData(new byte[] { 0xFE })]
    [InlineData(new byte[] { 0xFC })]
    public void Read_ShouldThrowInvalidDataException_WhenInvalidByteIsEncountered(byte[] binaryData)
    {
        var memoryStream = new MemoryStream(binaryData);
        var ternaryBuffer = new TernaryInt3[1];
        using (var sut = new Read4TritsPerByteTernaryStreamAdapter(memoryStream, expectEncodingHeader: false))
        {
            Action action = () => sut.Read(ternaryBuffer, 0, 1);
            action.Should().Throw<InvalidDataException>();
        }
    }

    [Fact]
    public void Read_ShouldThrowEndOfStreamException_WhenEndOfStreamIsReached()
    {
        var memoryStream = new MemoryStream(new byte[] { 0b01010101 });
        var ternaryBuffer = new TernaryInt3[2];
        using (var sut = new Read4TritsPerByteTernaryStreamAdapter(memoryStream, expectEncodingHeader: false))
        {
            Action action = () => sut.Read(ternaryBuffer, 0, 2);
            action.Should().Throw<EndOfStreamException>();
        }
    }
}
