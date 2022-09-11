using System.IO;
using Ternary.IO;

namespace TernaryTests.IO
{
    public class TernaryBinaryStreamAdapterTests
    {
        [Fact]
        public void Write_WritesBytes()
        {
            var stream = new MemoryStream();
            var encoder = new BytePerTernaryInt3Encoder(BinartyTernaryEncodingFlags.Signature);

            var buffer = new TernaryInt3[] { -13, 0, 13 };
            using (var sut = new TernaryBinaryStreamAdapter(stream, (IEncoder)encoder))
            {
                sut.Write(buffer, 0, 3);
            }
            var actual = stream.ToArray();
            actual.Should().BeEquivalentTo(new byte[] { 243, 0, 13 });
        }

        [Fact]
        public void Read_ReadsBytes()
        {
            var stream = new MemoryStream(new byte[] {243, 0, 13});
            var encoder = new BytePerTernaryInt3Decoder();
            var buffer = new TernaryInt3[3];
            using (var sut = new TernaryBinaryStreamAdapter(stream, (IDecoder)encoder))
            {
                sut.Read(buffer, 0, 3);
            }
            buffer.Should().BeEquivalentTo(new TernaryInt3[] { -13, 0, 13 });
        }
    }
}
