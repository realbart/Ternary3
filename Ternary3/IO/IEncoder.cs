namespace Ternary.IO;

/// <summary>
/// Encodes <see cref="TernaryInt3"/>s to <see cref="byte"/>s.
/// </summary>
public interface IEncoder
{
    /// <summary>
    /// Prepares the encoder for encoding <see cref="TernaryInt3"/>s.
    /// </summary>
    /// <param name="binaryStream">The stream to which the encoded <see cref="TernaryInt3"/>s will be written.</param>
    /// <param name="writeEncodingHeader">Indicates whether to write the encoding header to the stream.</param>
    void Start(Stream binaryStream, bool writeEncodingHeader);

    /// <summary>
    /// Encodes a sequence of <see cref="TernaryInt3"/>s to a stream.
    /// </summary>
    /// <param name="binaryStream">The stream to which the encoded <see cref="TernaryInt3"/>s will be written.</param>
    /// <param name="buffer">An array of <see cref="TernaryInt3"/>s to encode.</param>
    /// <param name="offset">The zero-based offset in <paramref name="buffer"/> at which to begin encoding <see cref="TernaryInt3"/>s.</param>
    /// <param name="count">The maximum number of <see cref="TernaryInt3"/>s to encode.</param>
    void Write(Stream binaryStream, TernaryInt3[] buffer, int offset, int count);

    /// <summary>
    /// Flushes any buffered data to the stream.
    /// </summary>
    /// <param name="binaryStream">The stream to which the encoded <see cref="TernaryInt3"/>s will be written.</param>
    void Flush(Stream binaryStream);
}
