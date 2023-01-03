namespace Ternary.IO;

/// <summary>
/// Decodes <see cref="TernaryInt3"/>s from <see cref="byte"/>s.
/// </summary>
public interface IDecoder
{
    /// <summary>
    /// Begins decoding from the specified stream.
    /// </summary>
    /// <param name="binaryStream">The stream to decode from.</param>
    /// <param name="expectEncodingHeader">
    /// If set to <c>true</c>, the decoder will verify that the encoding header is present and correct.
    /// If set to <c>false</c>, the decoder will not verify the encoding header and will assume that the data is correctly encoded.
    /// </param>
    void Start(Stream binaryStream, bool expectEncodingHeader);

    /// <summary>
    /// Reads a sequence of <see cref="TernaryInt3"/>s from the specified stream.
    /// </summary>
    /// <param name="binaryStream">The stream to read from.</param>
    /// <param name="buffer">An array of <see cref="TernaryInt3"/>s. When this method returns, the <paramref name="buffer"/> contains the specified sequence of <see cref="TernaryInt3"/>s with the values between <paramref name="offset"/> and (<paramref name="offset"/> + <paramref name="count"/> - 1) replaced by the <see cref="TernaryInt3"/>s read from the current source.</param>
    /// <param name="offset">The zero-based offset in <paramref name="buffer"/> at which to begin storing the data read from the current stream.</param>
    /// <param name="count">The maximum number of <see cref="TernaryInt3"/>s to read.</param>
    /// <returns>The total number of <see cref="TernaryInt3"/>s read into the buffer.</returns>
    int Read(Stream binaryStream, TernaryInt3[] buffer, int offset, int count);
}
