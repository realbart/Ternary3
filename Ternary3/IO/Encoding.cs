namespace Ternary.IO;


internal enum Encoding
{
    /// <summary>
    /// When reading, Looks at the first two bytes of a stream to determine if the excoding is described there.
    /// The first two bytes are used to see if they match up with FourTritsPerByte or FiveTritsPerByte.
    /// If neither, an exception is thrown. If both, FiveTritsPerByte is assumed.
    /// When writing, FiveTritsPerByte-encoding is used.
    /// </summary>
    Auto = 0,

    /// <summary>
    /// Binary Encoded Trinary/Trits; two bits per trit. 01 = down, 00 = middle, 10 = up.
    /// The final byte is padded with ones.
    /// No BE3-marker code is used.
    /// </summary>
    FourTritsPerByteSilent = 1,

    /// <summary>
    /// Binary Encoded Trinary/Trits; five trits per byte. 0 = ddddd, 242 = uuuuu.
    /// The final byte is padded with m-values.
    /// No BE3-marker code is used.
    /// </summary>
    FiveTritsPerByteSilent = 2,

    /// <summary>
    /// Binary Encoded Trinary/Trits; two bits per trit. 01 = down, 00 = middle, 10 = up.
    /// The Final byte is padded with ones.
    /// When writing, the BE3-marker FC24 is written as the first two file bytes
    /// </summary>
    FourTritsPerByte = 0xfc24,
    /// <summary>
    /// Binary Encoded Trinary/Trits; five trits per byte. 0 = ddddd, 242 = uuuuu.
    /// At the end of the file 243 = dd - 252 = uu 253 = d, 254 = m, 255 = u.
    /// When writing, the BE3-marker FC25 is written as the first two file bytes
    /// </summary>
    FiveTritsPerByte = 0xfc25,
}
