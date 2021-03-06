namespace Ternary.IO;

/// <summary>
/// Decodes <see cref="TernaryInt3"/>s from <see cref="byte"/>s.
/// </summary>
public interface IDecoder
{
    void Start(Stream binaryStream);
    int Read(Stream binaryStream, TernaryInt3[] buffer, int offset, int count);
}
