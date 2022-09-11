namespace Ternary.IO;

using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// Implements a Ternary Stream that reads or writes tribbles as bytes to/from a binary stream
/// </summary>
public class TernaryBinaryStreamAdapter : TernaryStream
{
    private readonly Stream binaryStream;
    private readonly IEncoder? encoder;
    private readonly IDecoder? decoder;

    /// <summary>
    /// Implements a Ternary Stream that writes tribbles as bytes to a binary stream
    /// </summary>
    public TernaryBinaryStreamAdapter(Stream binaryStream, IEncoder encoder)
    {
        if (binaryStream == null) throw new ArgumentNullException(nameof(binaryStream));
        if (!binaryStream.CanWrite) throw new ArgumentException("Cannot write to binary stream", nameof(binaryStream));
        if (encoder == null) throw new ArgumentNullException(nameof(encoder));
        this.binaryStream = binaryStream;
        this.encoder = encoder;
        this.CanWrite = true;
    }

    /// <summary>
    /// Implements a Ternary Stream that reads tribbles as bytes from a binary stream
    /// </summary>
    public TernaryBinaryStreamAdapter(Stream binaryStream, IDecoder decoder)
    {
        if (binaryStream == null) throw new ArgumentNullException(nameof(binaryStream));
        if (!binaryStream.CanRead) throw new ArgumentException("Cannot read from binary stream", nameof(binaryStream));
        if (decoder == null) throw new ArgumentNullException(nameof(decoder));
        this.binaryStream = binaryStream;
        this.decoder = decoder;
        this.CanRead = true;
    }

    /// <inheritdoc/>
    public override bool CanRead { get; }

    /// <inheritdoc/>
    public override bool CanWrite { get; }

    /// <inheritdoc/>
    public override void Flush()
    {
        if (!CanWrite) throw new InvalidOperationException("Cannot flush a stream you cannot write to");
        encoder!.Flush(binaryStream);
    }

    /// <inheritdoc/>
    public override int Read(TernaryInt3[] buffer, int offset, int count)
    {
        if (!CanRead) throw new InvalidOperationException("Cannot read");
        return decoder!.Read(binaryStream, buffer, offset, count);
    }

    /// <inheritdoc/>
    public override void Write(TernaryInt3[] buffer, int offset, int count)
    {
        if (!CanWrite) throw new InvalidOperationException("Cannot write");
        encoder!.Write(binaryStream, buffer, offset, count);
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        binaryStream.Dispose();
    }

    /// <inheritdoc/>
    public override async ValueTask DisposeAsync(bool disposing)
    {
        await base.DisposeAsync(disposing);
        await binaryStream.DisposeAsync();
    }
}
