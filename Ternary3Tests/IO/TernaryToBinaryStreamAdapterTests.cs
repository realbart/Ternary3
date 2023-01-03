using System.IO;
using Ternary.IO;

namespace TernaryTests.IO;

public class TernaryToBinaryStreamAdapterTests
{
    [Theory]
    [InlineData(false, "-13,0,13", "15002A")]
    [InlineData(true, "-13,0,13", "FC2315002A")]
    public void TernaryToBinaryStreamAdapter_BytePerTernaryInt3Encoder_ShouldWriteExpectedData(bool writeEncodingHeader, string ternaryData, string expectedBinaryData)
    {
        var tribbles = ternaryData.Split(",").Select(s=>(TernaryInt3)int.Parse(s)).ToArray();
        var memoryStream = new MemoryStream();
        var encoder = new BytePerTernaryInt3Encoder();
        using (var ternaryStream = new TernaryToBinaryStreamAdapter(memoryStream, encoder, writeEncodingHeader))
        {
            ternaryStream.Write(tribbles,0, tribbles.Length);
        }

        // Assert
        var actual = Convert.ToHexString(memoryStream.ToArray());
        actual.Should().Be(expectedBinaryData);
    }

    [Theory]
    [InlineData(false, "-13,0,13", "540ABF")]
    [InlineData(true, "-13,0,13", "FC24540ABF")]
    public void TernaryToBinaryStreamAdapter_BytePerTernaryInt4Encoder_ShouldWriteExpectedData(bool writeEncodingHeader, string ternaryData, string expectedBinaryData)
    {
        var tribbles = ternaryData.Split(",").Select(s => (TernaryInt3)int.Parse(s)).ToArray();
        var memoryStream = new MemoryStream();
        var encoder = new BytePerTernaryInt4Encoder();
        using (var ternaryStream = new TernaryToBinaryStreamAdapter(memoryStream, encoder, writeEncodingHeader))
        {
            ternaryStream.Write(tribbles, 0, tribbles.Length);
        }

        // Assert
        var actual = Convert.ToHexString(memoryStream.ToArray());
        actual.Should().Be(expectedBinaryData);
    }
}
