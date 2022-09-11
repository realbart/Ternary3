namespace Ternary.IO;

/// <summary>
/// Very lightweight encoder without any checks or optimizations.
/// Don't use this in production code.
/// </summary>
public class BytePerTernaryInt3Encoder : IEncoder
{
    private readonly BinartyTernaryEncodingFlags flags;

    /// <summary>
    /// Very lightweight encoder without any checks or optimizations.
    /// Don't use this in production code.
    /// </summary>
    public BytePerTernaryInt3Encoder(BinartyTernaryEncodingFlags flags)
    {
        this.flags = flags;
    }
    /// <inheritdoc/>
    public void Flush(Stream binaryStream) => binaryStream.Flush();

    public void Start(Stream stream)
    {
        if (flags.HasFlag(BinartyTernaryEncodingFlags.Signature))
        {
            stream.WriteByte(FileSignature1);
            stream.WriteByte(FileSignature2);
            stream.WriteByte(FileSignatureBytePerTernaryInt3);
        }
    }

    /// <inheritdoc/>
    public void Write(Stream binaryStream, TernaryInt3[] buffer, int offset, int count)
    {
        for (var i = offset; i < offset + count; i++)
        {
            binaryStream.WriteByte((byte)buffer[i]);
        }
    }
}
