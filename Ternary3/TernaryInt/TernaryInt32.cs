namespace Ternary3;

using Ternary3.Formatting;
using Ternary3.Internal;

/// <summary>
/// Represents a 32 trit signed integer
/// </summary>
public partial struct TernaryInt32
{
    private readonly ulong trits;

    internal TernaryInt32(ulong trits) => this.trits = trits;

    public static implicit operator TernaryInt32(int value) => new TernaryInt32(value.ToTrits20());
    public static explicit operator int(TernaryInt32 value) => value.trits.ToInt32();

    public static explicit operator TernaryInt32(long value) => new TernaryInt32(value.ToTrits32());
    //public static implicit operator long(TernaryInt32 value) => value.trits.ToInt64();

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
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using a custom formatter.
    /// </summary>
    public string ToString(ITernaryFormat format) => Formatter.FormatTrits(trits, format, 32);
}