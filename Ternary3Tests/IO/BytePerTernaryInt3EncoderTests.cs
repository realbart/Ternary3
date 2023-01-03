using System.IO;
using Ternary.IO;

namespace TernaryTests.IO;

public class BytePerTernaryInt3EncoderTests
{
    [Theory]
    [InlineData(false, "-13,0,13", "5703AB")]
    [InlineData(true, "-13,0,13", "FC235703AB")]
    public void TernaryToBinaryStreamAdapter_BytePerTernaryInt3Encoder_ShouldWriteExpectedData(bool writeEncodingHeader, string ternaryData, string expectedBinaryData)
    {
        var tribbles = ternaryData.Split(",").Select(s => (TernaryInt3)int.Parse(s)).ToArray();
        var memoryStream = new MemoryStream();
        var encoder = new BytePerTernaryInt3Encoder();
        using (var ternaryStream = new TernaryToBinaryStreamAdapter(memoryStream, encoder, writeEncodingHeader))
        {
            ternaryStream.Write(tribbles, 0, tribbles.Length);
        }

        // Assert
        var actual = Convert.ToHexString(memoryStream.ToArray());
        actual.Should().Be(expectedBinaryData);
    }

    [Theory]
    [InlineData(false, "-13,12,-11,10,-9,8,-7,6,-5,4,-3,2,-1,0")]
    [InlineData(true, "-13,12,-11,10,-9,8,-7,6,-5,4,-3,2,-1,0")]
    [InlineData(false, "-13,12,-11,10,-9,8,-7,6,-5,4,-3,2,-1")]
    [InlineData(true, "-13,12,-11,10,-9,8,-7,6,-5,4,-3,2,-1")]
    public void TernaryToBinaryStreamAdapter_BytePerTernaryInt3Encoder_ShouldEncodeAndDecodeCorrectly(bool writeEncodingHeader, string ternaryData)
    {
        // Arrange
        var tribbles = ternaryData.Split(",").Select(s => (TernaryInt3)int.Parse(s)).ToArray();
        var memoryStream = new MemoryStream();
        var encoder = new BytePerTernaryInt3Encoder();
        var decoder = new BytePerTernaryInt3Decoder();

        // Act
        using (var ternaryStream = new TernaryToBinaryStreamAdapter(memoryStream, encoder, writeEncodingHeader))
        {
            ternaryStream.Write(tribbles, 0, tribbles.Length);
        }
        memoryStream.Position = 0;
        var decodedTribbles = new TernaryInt3[tribbles.Length];
        using (var ternaryStream = new TernaryFromBinaryStreamAdapter(memoryStream, decoder, writeEncodingHeader))
        {
            ternaryStream.Read(decodedTribbles, 0, decodedTribbles.Length);
        }

        // Assert
        decodedTribbles.Should().BeEquivalentTo(tribbles);
    }
}

public class BytePerTernaryInt4EncoderTests
{
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