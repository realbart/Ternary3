namespace Ternary.IO;

using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// Decodes quickly using one byte ber TernaryInt4
/// </summary>
public class Read4TritsPerByteTernaryStreamAdapter : TernaryFromBinaryStreamAdapter
{
    int overflowByte;
    int numberOfOverflowBits;

    /// <summary>
    /// Decodes quickly using one byte ber TernaryInt4
    /// </summary>
    public Read4TritsPerByteTernaryStreamAdapter(Stream binaryStream, bool expectEncodingHeader): base(binaryStream, expectEncodingHeader)
    {
    }

    ///<inheritdoc/>
    protected override void StartInner()
    {
        if (!ExpectEncodingHeader) return;
        var encodingHeader = new byte[2];
        var bytesRead = BinaryStream.Read(encodingHeader, 0, 2);
        // If there are not enough bytes available, throw an exception
        if (bytesRead < 2)
        {
            throw new EndOfStreamException("Unexpected end of stream while reading encoding header.");
        }
        var encodingType = (Encoding)(encodingHeader[0] << 8 | encodingHeader[1]);
        if (encodingType != Encoding.FourTritsPerByte)
        {
            throw new InvalidDataException("Invalid encoding header. Expected encoding is FourTritsPerByte.");
        }
    }

    ///<inheritdoc/>
    protected override int ReadInner(TernaryInt3[] buffer, int offset, int count)
    {
        for (var index = 0; index < count; index++) {
            if (numberOfOverflowBits == 6)
            {
                if (TernaryInt3.TryConvert((byte)(overflowByte), out var tribble))
                {
                    buffer[index] = tribble;
                    numberOfOverflowBits = 0;
                    continue;
                }
                throw new InvalidDataException();
            }
            var b = BinaryStream.ReadByte();
            if (b == -1)
            {
                return numberOfOverflowBits == 0 ? index : throw new EndOfStreamException();
            }
            // merge overflow bits with the first bits from b.
            // try parse and add to buffer
            // check if the remaining bits are (padded) ones.
            // set the overflowByte and numberOfOverflowBits
        }
        return count;
    } 
}
