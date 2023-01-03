namespace Ternary.IO;

using System;
using System.IO;

/// <summary>
/// Reads ternary data from a binary stream
/// </summary>
public class TernaryFromBinaryStreamAdapter : TernaryStream
{
    private bool started;
    private readonly Stream binaryStream;
    private readonly IDecoder decoder;

    /// <summary>
    /// Reads ternary data from a binary stream
    /// </summary>
    public TernaryFromBinaryStreamAdapter(Stream binaryStream, IDecoder decoder, bool expectEncodingHeader)
    {
        if (binaryStream == null) throw new ArgumentNullException(nameof(binaryStream));
        if (!binaryStream.CanRead) throw new ArgumentException("Cannot read from binary stream", nameof(binaryStream));
        if (decoder == null) throw new ArgumentNullException(nameof(decoder));

        this.binaryStream = binaryStream;
        this.decoder = decoder;
        ExpectEncodingHeader = expectEncodingHeader;
    }

    /// <inheritdoc/>
    public override bool CanRead => this.binaryStream.CanRead;

    /// <inheritdoc/>
    public override bool CanWrite => false;

    /// <summary>
    /// A boolean indicating if a header marking the encoding type should be read from the output stream
    /// </summary>
    public bool ExpectEncodingHeader { get; }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            this.binaryStream.Dispose();
            base.Dispose(disposing);
        }
    }

    /// <inheritdoc/>
    public override void Flush() => throw new InvalidOperationException("Cannot flush reader");

    /// <inheritdoc/>
    public override int Read(TernaryInt3[] buffer, int offset, int count)
    {
        if (!started)
        {
            this.decoder.Start(this.binaryStream, ExpectEncodingHeader);
            started = true;
        }
        return this.decoder.Read(this.binaryStream, buffer, offset, count);
    }

    /// <inheritdoc/>
    public override void Write(TernaryInt3[] buffer, int offset, int count) => throw new InvalidOperationException("Cannot write to reader.");
}
