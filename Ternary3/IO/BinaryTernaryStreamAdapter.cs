namespace Ternary.IO;

using System;
using System.IO;

/// <summary>
/// Implements a Binary Stream that reads or writes bytes as tribbles to/from a binary stream
/// </summary>
public class BinaryTernaryStreamAdapter : Stream
{
    private readonly TernaryStream ternaryStream;
    private readonly IDecoder? decoder;
    private readonly IEncoder? encoder;

    public BinaryTernaryStreamAdapter(TernaryStream ternaryStream, IEncoder encoder)
    {
        if (ternaryStream == null) throw new ArgumentNullException(nameof(ternaryStream));
        if (!ternaryStream.CanRead) throw new ArgumentException("Cannot read from ternary stream", nameof(ternaryStream));
        if (encoder == null) throw new ArgumentNullException(nameof(encoder));
        this.ternaryStream = ternaryStream;
        this.encoder = encoder;
        this.CanRead = true;
    }

    public BinaryTernaryStreamAdapter(TernaryStream ternaryStream, IDecoder decoder)
    {
        if (ternaryStream == null) throw new ArgumentNullException(nameof(ternaryStream));
        if (!ternaryStream.CanWrite) throw new ArgumentException("Cannot write to ternary stream", nameof(ternaryStream));
        if (decoder == null) throw new ArgumentNullException(nameof(decoder));
        this.ternaryStream = ternaryStream;
        this.decoder = decoder;
        this.CanWrite = true;
    }

    public override bool CanRead { get; }

    public override bool CanSeek => false;

    public override bool CanWrite { get; }

    public override long Length => throw new NotImplementedException();

    public override long Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override void Flush()
    {
        if (!CanWrite) throw new InvalidOperationException("Cannot flush a stream you cannot write to");
        throw new NotImplementedException();
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        if (!CanRead) throw new InvalidOperationException("Cannot read");
        throw new NotImplementedException();
    }

    public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();

    public override void SetLength(long value) => throw new NotImplementedException();

    public override void Write(byte[] buffer, int offset, int count)
    {
        if (!CanWrite) throw new InvalidOperationException("Cannot write");
        throw new NotImplementedException();
    }
}
