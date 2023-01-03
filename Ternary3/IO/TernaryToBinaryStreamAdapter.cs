namespace Ternary.IO;

using System;
using System.IO;
using System.Threading.Tasks;

/// <summary>
/// Writes ternary data to a binary stream
/// </summary>
public class TernaryToBinaryStreamAdapter : TernaryStream
{
    private readonly Stream binaryStream;
    private readonly IEncoder encoder;
    private bool started = false;

    /// <summary>
    /// Writes ternary data to a binary stream
    /// </summary>
    public TernaryToBinaryStreamAdapter(Stream binaryStream, IEncoder encoder, bool writeEncodingHeader = true)
    {
        if (binaryStream == null) throw new ArgumentNullException(nameof(binaryStream));
        if (!binaryStream.CanWrite) throw new ArgumentException("Cannot write to binary stream", nameof(binaryStream));
        if (encoder == null) throw new ArgumentNullException(nameof(encoder));
        this.binaryStream = binaryStream;
        this.encoder = encoder;
        this.WriteEncodingHeader = writeEncodingHeader;
    }

    /// <summary>
    /// A boolean indicating if a header marking the encoding type should be written to the output stream
    /// </summary>
    public bool WriteEncodingHeader { get; }

    /// <inheritdoc/>
    public override bool CanWrite => binaryStream.CanWrite;

    /// <inheritdoc/>
    public override bool CanRead => false;

    /// <inheritdoc/>
    public override void Flush() => this.encoder.Flush(this.binaryStream);

    /// <inheritdoc/>
    public override int Read(TernaryInt3[] buffer, int offset, int count) => throw new InvalidOperationException("Cannot read from writer");

    /// <inheritdoc/>
    public override void Write(TernaryInt3[] buffer, int offset, int count)
    {
        if (!started)
        {
            this.encoder.Start(this.binaryStream, WriteEncodingHeader);
            started = true;
        }
        this.encoder.Write(this.binaryStream, buffer, offset, count);
    }
}
