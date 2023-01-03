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
            sut.Read(ternaryBuffer, 0, 3);
        }
        var actual = string.Join(",", ternaryBuffer.Select(t => ((int)t).ToString()));
        actual.Should().Be(expectedTernaryData);
    }
}
