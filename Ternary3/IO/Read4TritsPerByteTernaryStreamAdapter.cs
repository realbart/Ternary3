namespace Ternary.IO;

using System.IO;

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
        var destinationIndex = offset;
        while (count-- > 0)
        {
            int b;
            if (numberOfOverflowBits > 0)
            {
                b = BinaryStream.ReadByte();
                if (b == -1) break;
                buffer[destinationIndex++] = (TernaryInt3)((overflowByte << (8 - numberOfOverflowBits)) | (b >> numberOfOverflowBits));
                overflowByte = b;
                numberOfOverflowBits = (numberOfOverflowBits + 6) % 8;
            }
            else
            {
                b = BinaryStream.ReadByte();
                if (b == -1) break;
                buffer[destinationIndex++] = (TernaryInt3)(b >> 2);
                overflowByte = b;
                numberOfOverflowBits = (numberOfOverflowBits + 6) % 8;
            }
        }
        return destinationIndex - offset;
    }
}
