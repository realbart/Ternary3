namespace Ternary.IO;

[Flags]
public enum BinartyTernaryEncodingFlags
{
    /// <summary>
    /// Don't read or write any signatures.
    /// The code needs to know the encoding scheme.
    /// </summary>
    None = 0x00,
    /// <summary>
    /// Write a signature.
    /// When reading, throw an exception if no signature exists.
    /// </summary>
    Signature = 0x01,
    /// <summary>
    /// When reading, throw an exception if a signature exists.
    /// </summary>
    NoSignature = 0x02
}
