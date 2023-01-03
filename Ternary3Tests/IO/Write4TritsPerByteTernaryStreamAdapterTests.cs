using System.IO;
using Ternary.IO;

namespace TernaryTests.IO;

public class Write4TritsPerByteTernaryStreamAdapterTests
{
    [Theory]
    [InlineData(false, "-13,0,13", "540ABF")]
    [InlineData(true, "-13,0,13", "FC24540ABF")]
    public void Write_BytePerTernaryInt4Encoder_ShouldWriteExpectedData(bool writeEncodingHeader, string ternaryData, string expectedBinaryData)
    {
        var tribbles = ternaryData.Split(",").Select(s => (TernaryInt3)int.Parse(s)).ToArray();
        var memoryStream = new MemoryStream();
        using (var sut = new Write4TritsPerByteTernaryStreamAdapter(memoryStream, writeEncodingHeader))
        {
            sut.Write(tribbles, 0, tribbles.Length);
        }
        // Assert
        var actual = Convert.ToHexString(memoryStream.ToArray());
        actual.Should().Be(expectedBinaryData);
    }

    [Theory]
    [InlineData(false, "-13,0,13", "540ABF")]
    [InlineData(true, "-13,0,13", "FC24540ABF")]
    public void Write_WithMultipleWrites_ShouldWriteExpectedData(bool writeEncodingHeader, string ternaryData, string expectedBinaryData)
    {
        var tribbles = ternaryData.Split(",").Select(s => (TernaryInt3)int.Parse(s)).ToArray();
        var memoryStream = new MemoryStream();
        using (var sut = new Write4TritsPerByteTernaryStreamAdapter(memoryStream, writeEncodingHeader))
        {
            foreach (var t in tribbles)
            {
                sut.Write(new[] { t }, 0, 1);
            }
        }

        // Assert
        var actual = Convert.ToHexString(memoryStream.ToArray());
        actual.Should().Be(expectedBinaryData);
    }

    [Theory]
    [InlineData(false, "-13,0,13", "5703AB")]
    [InlineData(true, "-13,0,13", "FC245703AB")]
    public void Write_WithMultipleFlushes_ShouldWriteExpectedData(bool writeEncodingHeader, string ternaryData, string expectedBinaryData)
    {
        var tribbles = ternaryData.Split(",").Select(s => (TernaryInt3)int.Parse(s)).ToArray();
        var memoryStream = new MemoryStream();
        using (var sut = new Write4TritsPerByteTernaryStreamAdapter(memoryStream, writeEncodingHeader))
        {
            foreach (var t in tribbles)
            {
                sut.Write(new[] { t }, 0, 1);
                sut.Flush();
            }
        }

        // Assert
        var actual = Convert.ToHexString(memoryStream.ToArray());
        actual.Should().Be(expectedBinaryData);
    }
}