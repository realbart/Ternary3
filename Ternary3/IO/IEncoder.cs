namespace Ternary.IO;

/// <summary>
/// Encodes <see cref="TernaryInt3"/>s to <see cref="byte"/>s.
/// </summary>
public interface IEncoder
{
    void Start(Stream stream);
    void Write(Stream binaryStream, TernaryInt3[] buffer, int offset, int count);
    void Flush(Stream binaryStream);
}
