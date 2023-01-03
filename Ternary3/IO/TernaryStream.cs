namespace Ternary.IO;

/// <summary>
/// Provides a generic view of a sequence of tribbles. This is an abstract class.
/// </summary>
public abstract class TernaryStream : IAsyncDisposable, IDisposable
{
    private bool forwarding = false;
    private readonly object lockObj = new object();
    private bool alreadyDisposed;

    /// <summary>
    /// Indicates if you can read from this stream.
    /// </summary>
    public virtual bool CanRead => false;

    /// <summary>
    /// Indicates if you can write to this stream.
    /// </summary>
    public virtual bool CanWrite => false;

    /// <summary>
    /// Writes to the stream.
    /// </summary>
    public virtual ValueTask WriteAsync(TernaryInt3[] buffer, int offset, int count)
        => WriteAsync(buffer, offset, count, CancellationToken.None);

    /// <summary>
    /// Writes to the stream.
    /// </summary>
    public virtual ValueTask WriteAsync(TernaryInt3[] buffer, int offset, int count, CancellationToken token)
    {
        if (!CanWrite) throw new InvalidOperationException("This is not a writable stream.");
        if (token.IsCancellationRequested) return ValueTask.CompletedTask;
        if (!forwarding) lock (lockObj)
            {
                forwarding = true;
                Write(buffer, offset, count);
                forwarding = false;
            }
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Writes to the stream.
    /// </summary>
    public virtual void Write(TernaryInt3[] buffer, int offset, int count)
    {
        if (!CanWrite) throw new InvalidOperationException("This is not a writable stream.");
        if (!forwarding) lock (lockObj)
            {
                forwarding = true;
                WriteAsync(buffer, offset, count, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                forwarding = false;
            }
    }

    /// <summary>
    /// Reads from the stream.
    /// </summary>
    public ValueTask<int> ReadAsync(TernaryInt3[] buffer, int offset, int count)
        => ReadAsync(buffer, offset, count, CancellationToken.None);

    /// <summary>
    /// Reads from the stream.
    /// </summary>
    public virtual ValueTask<int> ReadAsync(TernaryInt3[] buffer, int offset, int count, CancellationToken token)
    {
        if (!CanRead) throw new InvalidOperationException("This is not a readable stream.");
        if (token.IsCancellationRequested) return ValueTask.FromResult(0);
        if (!forwarding) lock (lockObj)
            {
                forwarding = true;
                var read = Read(buffer, offset, count);
                forwarding = false;
                return ValueTask.FromResult(read);
            }
        return ValueTask.FromResult(0);
    }

    /// <summary>
    /// Reads from the stream.
    /// </summary>
    public virtual int Read(TernaryInt3[] buffer, int offset, int count)
    {
        if (!CanRead) throw new InvalidOperationException("This is not a readable stream.");
        if (!forwarding) lock (lockObj)
            {
                forwarding = true;
                var read = ReadAsync(buffer, offset, count, CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                forwarding = false;
                return read;
            }
        return 0;
    }

    /// <summary>
    /// Flushes all data currently in the stream
    /// </summary>
    public virtual void Flush()
    {
        if (!forwarding) lock (lockObj)
            {
                forwarding = true;
                FlushAsync(CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();
                forwarding = false;
            }
    }

    /// <summary>
    /// Flushes all data currently in the stream
    /// </summary>
    public virtual ValueTask FlushAsync(CancellationToken token)
    {
        if (token.IsCancellationRequested) return ValueTask.CompletedTask;
        if (!forwarding) lock (lockObj)
            {
                forwarding = true;
                Flush();
                forwarding = false;
            }
        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Flushes all data currently in the stream
    /// </summary>
    public ValueTask FlushAsync() => FlushAsync(CancellationToken.None);

    /// <summary>
    /// Disposes the stream.
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (alreadyDisposed) return;
        if (CanWrite) Flush();
        if (!disposing) return;
        alreadyDisposed = true;
    }

    /// <summary>
    /// Disposes the stream.
    /// </summary>
    protected async virtual ValueTask DisposeAsync(bool disposing)
    {
        if (alreadyDisposed) return;
        if (CanWrite) await FlushAsync();
        if (!disposing) return;
        alreadyDisposed = true;
    }

    ///<inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    ///<inheritdoc/>
    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        await DisposeAsync(disposing: true);
        GC.SuppressFinalize(this);
    }

    ~TernaryStream()
    {
        Dispose(false);
    }
}