namespace Ternary.IO;

using System;
using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// Encodes quickly using one byte ber TernaryInt4
/// </summary>
public class Write4TritsPerByteTernaryStreamAdapter : TernaryToBinaryStreamAdapter
{
    int overflowByte;
    int numberOfOverflowBits;

    /// <summary>
    /// Encodes quickly using one byte ber TernaryInt4
    /// </summary>
    public Write4TritsPerByteTernaryStreamAdapter(Stream binaryStream, bool writeEncodingHeader) : base(binaryStream, writeEncodingHeader)
    {
    }

    ///<inheritdoc/>
    protected override void StartInner()
    {
        numberOfOverflowBits = 0;
        if (!WriteEncodingHeader) return;
        var marker = unchecked((ushort)Encoding.FourTritsPerByte);
        BinaryStream.WriteByte((byte)(marker >> 8));
        BinaryStream.WriteByte((byte)(marker & 0xff));
    }

    ///<inheritdoc/>
    protected override void WriteInner(TernaryInt3[] buffer, int offset, int count)
    {
        if (buffer is null) throw new ArgumentNullException(nameof(buffer));
        var sourceBytes = MemoryMarshal.Cast<TernaryInt3, byte>(buffer.AsSpan(offset, count));
        var bytes = new byte[(sourceBytes.Length * 6 + numberOfOverflowBits) / 8];

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
        BinaryStream.Write(bytes, 0, bytes.Length);
    }

    ///<inheritdoc/>
    public override void Flush()
    {
        if (numberOfOverflowBits == 0) return;
        overflowByte = (overflowByte << (8 - numberOfOverflowBits)) | (0b111111 >> (numberOfOverflowBits - 2));
        BinaryStream.WriteByte((byte)overflowByte);
        numberOfOverflowBits = 0;
    }
}