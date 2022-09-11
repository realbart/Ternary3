using System.Collections;

namespace Ternary.IO;

internal sealed class ByteEnumerator : IEnumerator<byte>
{
    private readonly Stream stream;
    private byte? current;

    public ByteEnumerator(Stream stream) => this.stream = stream;

    public byte Current => current ?? throw new InvalidOperationException("No Current Value");

    object IEnumerator.Current => Current;

    void IDisposable.Dispose() => stream?.Dispose();

    public bool MoveNext()
    {
        var read = stream.ReadByte();
        if (read<0)
        {
            current = null;
            return false;
        }
        current = (byte)read;
        return true;
    }

    public void Reset() => throw new InvalidOperationException();
}