namespace Ternary3.IO;

using System;
using System.Collections.Generic;

internal class TernaryStreamWriter : IDisposable
{
    private bool disposedValue;

    public Stream Stream { get; }
    public IEncoder encoder { get; }

    private Queue<Trit> queue { get; } = new Queue<Trit>();
    public TernaryStreamWriter(Stream stream, IEncoder encoder)
    {
        if (stream == null) throw new ArgumentNullException(nameof(stream));
        if (!stream.CanWrite) throw new ArgumentException("Cannot write to stream");
        if (encoder == null) throw new ArgumentNullException(nameof(encoder));
        Stream = stream;
        this.encoder = encoder;
        this.encoder.Open(Stream);
    }

    public void Write(Trit trit) => encoder.Write(trit, Stream);

    public void Write(TernaryInt16 trits) => encoder.Write(trits, Stream);

    public void Write(TernaryInt32 trits) => encoder.Write(trits, Stream);

    public void Write(TernaryInt64 trits) => encoder.Write(trits, Stream);

    public async Task WriteAsync(Trit trit) => await encoder.WriteAsync(trit, Stream);

    public async Task WriteAsync(TernaryInt16 trits) => await encoder.WriteAsync(trits, Stream);

    public async Task WriteAsync(TernaryInt32 trits) => await encoder.WriteAsync(trits, Stream);

    public async Task WriteAsync(TernaryInt64 trits) => await encoder.WriteAsync(trits, Stream);

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                (encoder as IDisposable)?.Dispose();
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
