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
        var bytes = MemoryMarshal.Cast<TernaryInt3, byte>(new Span<TernaryInt3>(buffer.ToArray(), offset, count));
        for (var i = 0; i < bytes.Length; i++) bytes[i] = (byte)((bytes[i] << 2) | 0b11);
        binaryStream.Write(bytes);
    }

    ///<inheritdoc/>
    public void Flush(Stream binaryStream)
    {
        binaryStream.Flush();
    }
}