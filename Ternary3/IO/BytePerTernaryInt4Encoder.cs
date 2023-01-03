namespace Ternary.IO;

using System;
using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// Encodes quickly using one byte ber TernaryInt4
/// </summary>
public class BytePerTernaryInt4Encoder : IEncoder
{
    int overflowByte;
    int numberOfOverflowBits;

    ///<inheritdoc/>
    public void Start(Stream binaryStream, bool writeEncodingHeader)
    {
        if (binaryStream is null) throw new ArgumentNullException(nameof(binaryStream));
        if (!writeEncodingHeader) return;
        numberOfOverflowBits = 0;
        var marker = unchecked((ushort)Encoding.FourTritsPerByte);
        binaryStream.WriteByte((byte)(marker >> 8));
        binaryStream.WriteByte((byte)(marker & 0xff));
    }

    ///<inheritdoc/>
    public void Write(Stream binaryStream, TernaryInt3[] buffer, int offset, int count)
    {
        if (binaryStream is null) throw new ArgumentNullException(nameof(binaryStream));
        if (buffer is null) throw new ArgumentNullException(nameof(buffer));
        var sourceBytes = MemoryMarshal.Cast<TernaryInt3, byte>(buffer.AsSpan(offset, count));
        var bytes = new byte[(sourceBytes.Length * 6 + numberOfOverflowBits)/8];

        var byteIndex = 0;
        for (int i = 0; i < sourceBytes.Length; i++)
        {
            if (numberOfOverflowBits != 0)
            {
                bytes[byteIndex++] = (byte)((overflowByte << (8 - numberOfOverflowBits)) | (sourceBytes[i] >> (numberOfOverflowBits - 2)));
            }
            overflowByte = sourceBytes[i];
            numberOfOverflowBits = (numberOfOverflowBits + 6) % 8;
        }
        binaryStream.Write(bytes, 0, bytes.Length);
    }

    ///<inheritdoc/>
    public void Flush(Stream binaryStream)
    {
        if (numberOfOverflowBits == 0) return;
        overflowByte = (overflowByte << (8 - numberOfOverflowBits)) | (0b111111 >> (numberOfOverflowBits - 2));
        binaryStream.WriteByte((byte)overflowByte);
        numberOfOverflowBits = 0;
        overflowByte = 0;
    }
}