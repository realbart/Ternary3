namespace Ternary.IO;

/// <summary>
/// Encodes <see cref="TernaryInt3"/>s to <see cref="byte"/>s.
/// </summary>
public abstract class TernaryToBinaryStreamAdapter : TernaryStream
{
    private bool started;
    /// <summary>
    /// The inner binary stream the data is written to.
    /// </summary>
    protected readonly Stream BinaryStream;

    /// <summary>
    /// boolean indicating the headers should be written on first write.
    /// </summary>
    public bool WriteEncodingHeader { get; }

    /// <summary>
    /// Encodes <see cref="TernaryInt3"/>s to <see cref="byte"/>s.
    /// </summary>
    protected TernaryToBinaryStreamAdapter(Stream binaryStream, bool shouldWriteHeaders)
    {
        this.BinaryStream = binaryStream;
        this.WriteEncodingHeader = shouldWriteHeaders;
    }

    ///<inheritdoc/>
    public override bool CanWrite => BinaryStream.CanWrite;

    /// <summary>
    /// Prepares the encoder for encoding <see cref="TernaryInt3"/>s.
    /// </summary>
    protected abstract void StartInner();

    /// <summary>
    /// Encodes a sequence of <see cref="TernaryInt3"/>s to a stream.
    /// </summary>
    /// <param name="buffer">An array of <see cref="TernaryInt3"/>s to encode.</param>
    /// <param name="offset">The zero-based offset in <paramref name="buffer"/> at which to begin encoding <see cref="TernaryInt3"/>s.</param>
    /// <param name="count">The maximum number of <see cref="TernaryInt3"/>s to encode.</param>
    /// 
    protected abstract void WriteInner(TernaryInt3[] buffer, int offset, int count);

    ///<inheritDoc/>
    public override void Write(TernaryInt3[] buffer, int offset, int count)
    {
        if (buffer is null) throw new ArgumentNullException(nameof(buffer));
        if (!started)
        {
            started = true;
            StartInner();
        }
        WriteInner(buffer, offset, count);
    }

    ///<inheritdoc/>
    public override void Flush()
    {
        base.Flush();
        BinaryStream.Flush();
    }
}
