namespace Ternary.IO;

using System;
using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// Encodes quickly using one byte ber TernaryInt3
/// </summary>
public class Write3TritsPerByteTernaryStreamAdapter : TernaryToBinaryStreamAdapter
{
    /// <summary>
    /// Encodes quickly using one byte ber TernaryInt3
    /// </summary>
    public Write3TritsPerByteTernaryStreamAdapter(Stream binaryStream, bool writeEncodingHeader): base(binaryStream, writeEncodingHeader)
    {
    }

    ///<inheritdoc/>
    protected override void StartInner()
    {
        if (!WriteEncodingHeader) return;
        var marker = unchecked((ushort)Encoding.ThreeTritsPerByte);
        BinaryStream.WriteByte((byte)(marker >> 8));
        BinaryStream.WriteByte((byte)(marker & 0xff));
    }

    ///<inheritdoc/>
    protected override void WriteInner(TernaryInt3[] buffer, int offset, int count)
    {
        var bytes = MemoryMarshal.Cast<TernaryInt3, byte>(new Span<TernaryInt3>(buffer.ToArray(), offset, count));
        for (var i = 0; i < bytes.Length; i++) bytes[i] = (byte)((bytes[i] << 2) | 0b11);
        BinaryStream.Write(bytes);
    }
}