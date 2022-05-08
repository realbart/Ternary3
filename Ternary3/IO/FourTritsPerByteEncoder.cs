namespace Ternary3.IO;

using System.IO;
using System.Threading.Tasks;

internal class FourTritsPerByteEncoder : IEncoder
{
    private int bitsInLastByte;
    private byte[] buffer;   

    void IEncoder.Open(Stream stream)
    {
        // write marker bytes
    }

    void IEncoder.Write(Trit trit, Stream stream)
    {
        throw new NotImplementedException();
    }

    void IEncoder.Write(TernaryInt16 trits, Stream stream)
    {
        throw new NotImplementedException();
    }

    void IEncoder.Write(TernaryInt32 trits, Stream stream)
    {
        throw new NotImplementedException();
    }

    void IEncoder.Write(TernaryInt64 trits, Stream stream)
    {
        throw new NotImplementedException();
    }

    Task IEncoder.WriteAsync(Trit trit, Stream stream)
    {
        throw new NotImplementedException();
    }

    Task IEncoder.WriteAsync(TernaryInt16 trits, Stream stream)
    {
        throw new NotImplementedException();
    }

    Task IEncoder.WriteAsync(TernaryInt32 trits, Stream stream)
    {
        throw new NotImplementedException();
    }

    Task IEncoder.WriteAsync(TernaryInt64 trits, Stream stream)
    {
        throw new NotImplementedException();
    }
}
