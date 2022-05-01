namespace Ternary3;

using Ternary3.Formatting;
using Ternary3.Internal;

/// <summary>
/// Represents a 32-trit signed integer
/// </summary>
public partial struct TernaryInt32
{
    private readonly ulong trits;

    internal TernaryInt32(ulong trits) => this.trits = trits;

    public static explicit operator TernaryInt32(int value) => new TernaryInt32(value.ToTrits20());
    public static implicit operator int(TernaryInt32 value) => value.trits.From20Trits();

    /// <summary>
    /// Represents the largest possible value of an <see cref="TernaryInt16"/>:
    /// U_UUU_UUU_UUU_UUU_UUU  This field is constant.
    /// </summary>
    public const long MinValue = -MaxTrit32;

    /// <summary>
    /// Represents the smallest possible value of an <see cref="TernaryInt16"/>:
    /// D_DDD_DDD_DDD_DDD_DDD  This field is constant.
    /// </summary>
    public const long MaxValue = MaxTrit32;

    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using the default formatter.
    /// </summary>
    public override string ToString() => Formatter.FormatTrits(trits, 32);
    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using the default formatter.
    /// </summary>
    public string ToString(int numberOfDigits) => Formatter.FormatTrits(trits, numberOfDigits);
    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using a custom formatter.
    /// </summary>
    public string ToString(ITernaryFormat format, int numberOfDigits = 32) => Formatter.FormatTrits(trits, format, numberOfDigits);
    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Tribble (3 trits) using a custom formatter.
    /// </summary>
    public string ToString(IHeptavintimalFormat format, int numberOfDigits = 11) => Formatter.FormatTribbles(trits, format, numberOfDigits);
}