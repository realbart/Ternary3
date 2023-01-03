namespace Ternary.IO;

using System.IO;

/// <summary>
/// Decodes quickly using one byte ber TernaryInt3
/// </summary>
public class BytePerTernaryInt3Decoder : IDecoder
{
    ///<inheritdoc/>
    public void Start(Stream binaryStream, bool expectEncodingHeader)
    {
        if (!expectEncodingHeader) return;
        var encodingHeader = new byte[2];
        var bytesRead = binaryStream.Read(encodingHeader, 0, 2);
        // If there are not enough bytes available, throw an exception
        if (bytesRead < 2)
        {
            throw new EndOfStreamException("Unexpected end of stream while reading encoding header.");
        }
        var encodingType = (Encoding)(encodingHeader[0] << 8 | encodingHeader[1]);
        if (encodingType != Encoding.ThreeTritsPerByte)
        {
            throw new InvalidDataException("Invalid encoding header. Expected encoding is ThreeTritsPerByte.");
        }
    }

    ///<inheritdoc/>
    public int Read(Stream binaryStream, TernaryInt3[] buffer, int offset, int count)
    {
        var read = 0;
        while (read < count)
        {
            var b = binaryStream.ReadByte();
            if (b < 0) break;
            if (TernaryInt3.TryConvert((byte)((b ^ 0b11) << 6 | b >> 2), out var tribble))
            {
                buffer[offset + read] = tribble;
                read++;
            }
            else
            {
                throw new InvalidDataException($"Invalid byte value {b} encountered while decoding ternary data.");
            }
        }
        return read;
    }
}
