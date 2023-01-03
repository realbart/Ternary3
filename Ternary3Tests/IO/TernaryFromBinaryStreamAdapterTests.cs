﻿namespace TernaryTests.IO;

using System;
using System.IO;
using System.Linq;
using Ternary.IO;

public class TernaryFromBinaryStreamAdapterTests
{
    [Theory]
    [InlineData(false, "15002A", "-13,0,13")]
    [InlineData(true, "FC2315002A", "-13,0,13")]
    public void TernaryFromBinaryStreamAdapter_Read_ShouldReadExpectedData(bool expectEncodingHeader, string binaryData, string expectedTernaryData)
    {
        var binaryBytes = Convert.FromHexString(binaryData);
        var memoryStream = new MemoryStream(binaryBytes);
        var decoder = new BytePerTernaryInt3Decoder();
        var ternaryBuffer = new TernaryInt3[3];
        using (var binaryStream = new TernaryFromBinaryStreamAdapter(memoryStream, decoder, expectEncodingHeader))
        {
            binaryStream.Read(ternaryBuffer, 0, 3);
        }

        var actual = string.Join(",", ternaryBuffer.Select(t => ((int)t).ToString()));
        actual.Should().Be(expectedTernaryData);
    }
}
