namespace Ternary.IO;

/// <summary>
/// Very lightweight decoder without any checks or optimizations.
/// Don't use this in production code.
/// </summary>
public class BytePerTernaryInt3Decoder : IDecoder
{
    private readonly BinartyTernaryEncodingFlags flags;


    /// <summary>
    /// Very lightweight decoder without any checks or optimizations.
    /// Don't use this in production code.
    /// </summary>
    public BytePerTernaryInt3Decoder(BinartyTernaryEncodingFlags flags = BinartyTernaryEncodingFlags.None)
    {
        this.flags = flags;
    }
    /// <inheritdoc/>
    public int Read(Stream binaryStream, TernaryInt3[] buffer, int offset, int count)
    {
        for (var i = 0; i < count; i++)
        {
            var @byte = binaryStream.ReadByte();
            if (@byte == -1) return i;
            buffer[i + offset] = (sbyte)@byte;
        }
        return count;
    }

    /// <inheritdoc/>
    public void Start(Stream binaryStream)
    {
    }
}
