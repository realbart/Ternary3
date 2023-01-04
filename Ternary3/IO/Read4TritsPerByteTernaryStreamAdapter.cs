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
    public Read4TritsPerByteTernaryStreamAdapter(Stream binaryStream, bool expectEncodingHeader) : base(binaryStream, expectEncodingHeader)
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
        for (var index = 0; index < count; index++)
        {
            if (numberOfOverflowBits == 6)
            {
                if (!TernaryInt3.TryConvert((byte)(overflowByte), out buffer[index]))
                    throw new InvalidDataException("The input stream contained a value that could not be converted to aTernaryInt3");
                numberOfOverflowBits = 0;
                continue;
            }
            var b = BinaryStream.ReadByte();
            if (b == -1) return numberOfOverflowBits == 0 ? index : throw new EndOfStreamException("The input stream ended with an incomplete TernaryInt3");
            overflowByte = ((b >> (numberOfOverflowBits + 2)) | (overflowByte << (6 - numberOfOverflowBits))) & 0b111111;
            if (!TernaryInt3.TryConvert((byte)overflowByte, out buffer[index]))
                throw new InvalidDataException("The input stream contained a value that could not be converted to aTernaryInt3");
            numberOfOverflowBits += 2;
            overflowByte = b;
            var padbits = 0b111111 << numberOfOverflowBits >> 6;
            if ((overflowByte & padbits) == padbits) numberOfOverflowBits = 0;
        }
        return count;
    }
}
