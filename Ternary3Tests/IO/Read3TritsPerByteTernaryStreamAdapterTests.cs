namespace TernaryTests.IO;

using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions.Interfaces;
using System;
using System.IO;
using System.Linq;
using Ternary.IO;

public class Read3TritsPerByteTernaryStreamAdapterTests
{
    [Theory]
    [InlineData(false, "5703AB", "-13,0,13")]
    [InlineData(true, "FC235703AB", "-13,0,13")]
    public void Read_DecodesData(bool expectEncodingHeader, string binaryData, string expectedTernaryData)
    {
        var binaryBytes = Convert.FromHexString(binaryData);
        var memoryStream = new MemoryStream(binaryBytes);
        var ternaryBuffer = new TernaryInt3[3];
        using (var sut = new Read3TritsPerByteTernaryStreamAdapter(memoryStream, expectEncodingHeader))
        {
            sut.Read(ternaryBuffer, 0, 3);
        }
        var actual = string.Join(",", ternaryBuffer.Select(t => ((int)t).ToString()));
        actual.Should().Be(expectedTernaryData);
    }
}
