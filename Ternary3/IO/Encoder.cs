namespace Ternary3.IO;

using System;
using System.IO;
using System.Threading.Tasks;

public interface IEncoder
{
    internal void Open(Stream stream);
    internal void Write(Trit trit, Stream stream);
    internal void Write(TernaryInt16 trits, Stream stream);
    internal void Write(TernaryInt32 trits, Stream stream);
    internal void Write(TernaryInt64 trits, Stream stream);
    internal Task WriteAsync(Trit trit, Stream stream);
    internal Task WriteAsync(TernaryInt16 trits, Stream stream);
    internal Task WriteAsync(TernaryInt32 trits, Stream stream);
    internal Task WriteAsync(TernaryInt64 trits, Stream stream);
}