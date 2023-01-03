namespace Ternary.IO;

using System;
using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// Encodes quickly using one byte ber TernaryInt3
/// </summary>
public class BytePerTernaryInt3Encoder : IEncoder
{
    ///<inheritdoc/>
    public void Start(Stream binaryStream, bool writeEncodingHeader)
    {
        if (binaryStream is null) throw new ArgumentNullException(nameof(binaryStream));
        if (!writeEncodingHeader) return;
        var marker = unchecked((ushort)Encoding.ThreeTritsPerByte);
        binaryStream.WriteByte((byte)(marker >> 8));
        binaryStream.WriteByte((byte)(marker & 0xff));
    }

    ///<inheritdoc/>
    public void Write(Stream binaryStream, TernaryInt3[] buffer, int offset, int count)
    {
        if (binaryStream is null) throw new ArgumentNullException(nameof(binaryStream));
        if (buffer is null) throw new ArgumentNullException(nameof(buffer));
        var bytes = MemoryMarshal.Cast<TernaryInt3, byte>(new Span<TernaryInt3>(buffer, offset, count));
        binaryStream.Write(bytes);
    }

    ///<inheritdoc/>
    public void Flush(Stream binaryStream)
    {
        binaryStream.Flush();
    }
}

/// <summary>
/// Encodes quickly using one byte ber TernaryInt4
/// </summary>
public class BytePerTernaryInt4Encoder : IEncoder
{
    byte overflowByte;
    byte numberOfOverflowBits;

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
        var totalNumberOfBits = sourceBytes.Length * 3 + numberOfOverflowBits;
        var bytes = new byte[totalNumberOfBits / 8];

        // do some bit magic. shift the numberOfOverflowBits from overflowByte into the result,
        // and then six bits from each sourcebyte.
        // if the end of the bytearrays are reached, store the remaining bits in overflowByte and
        // set the number of bits in numberOfOverflowBits

        binaryStream.Write(bytes, 0, bytes.Length);
    }

    ///<inheritdoc/>
    public void Flush(Stream binaryStream)
    {
        // if numberOfOverflowBits > 0 then pad the overflowByte with ones and write it.
    }
}