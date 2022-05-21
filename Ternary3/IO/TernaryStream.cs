namespace Ternary.IO;

/// <summary>
/// Provides a generic view of a sequence of tribbles. This is an abstract class.
/// </summary>
public abstract class TernaryStream: IAsyncDisposable, IDisposable
{
    private bool disposedValue;

    public abstract bool CanRead { get; }
    public abstract bool CanWrite { get; }

    public virtual ValueTask WriteAsync(TernaryInt3[] buffer, int offset, int count, CancellationToken token)
    {
        Write(buffer, offset, count);
        return ValueTask.CompletedTask;
    }
    public abstract void Write(TernaryInt3[] buffer, int offset, int count);
    
    public virtual ValueTask<int> ReadAsync(TernaryInt3[] buffer, int offset, int count, CancellationToken token) 
        => ValueTask.FromResult(Read(buffer, offset, count));
    
    public abstract int Read(TernaryInt3[] buffer, int offset, int count);

    public abstract void Flush();

    public virtual ValueTask FlushAsync(CancellationToken token)
    {
        Flush();
        return ValueTask.CompletedTask;
    }
    public ValueTask FlushAsync() => FlushAsync(default(CancellationToken));

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                Flush();
            }

            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                await FlushAsync();
            }

            disposedValue = true;
        }
    }

    public async ValueTask DisposeAsync()
    {
        // Do not change this code. Put cleanup code in 'DisposeAsync(bool disposing)' method
        await DisposeAsync(disposing: true);
        GC.SuppressFinalize(this);
    }
}