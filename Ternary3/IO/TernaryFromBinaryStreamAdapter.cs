namespace Ternary.IO;

/// <summary>
/// Encodes <see cref="TernaryInt3"/>s to <see cref="byte"/>s.
/// </summary>
public abstract class TernaryFromBinaryStreamAdapter : TernaryStream
{
    private bool started;
    /// <summary>
    /// The inner binary stream the data is read from.
    /// </summary>
    protected readonly Stream BinaryStream;

    /// <summary>
    /// boolean indicating the headers should be read on first read.
    /// </summary>
    public bool ExpectEncodingHeader { get; }

    /// <summary>
    /// Encodes <see cref="TernaryInt3"/>s to <see cref="byte"/>s.
    /// </summary>
    protected TernaryFromBinaryStreamAdapter(Stream binaryStream, bool expectEncodingHeader)
    {
        this.BinaryStream = binaryStream;
        this.ExpectEncodingHeader = expectEncodingHeader;
    }

    ///<inheritdoc/>
    public override bool CanRead => BinaryStream.CanRead;

    /// <summary>
    /// Prepares the decoder for decodeing <see cref="TernaryInt3"/>s.
    /// </summary>
    protected abstract void StartInner();

    /// <summary>
    /// Decpdes a sequence of <see cref="TernaryInt3"/>s from  a stream.
    /// </summary>
    protected abstract int ReadInner(TernaryInt3[] buffer, int offset, int count);

    ///<inheritDoc/>
    public override int Read(TernaryInt3[] buffer, int offset, int count)
    {
        if (buffer is null) throw new ArgumentNullException(nameof(buffer));
        if (!started)
        {
            started = true;
            StartInner();
        }
        return ReadInner(buffer, offset, count);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        BinaryStream.Dispose();
    }
}
