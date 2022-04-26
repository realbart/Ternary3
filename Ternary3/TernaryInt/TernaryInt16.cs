namespace Ternary3;
using Ternary3.Formatting;
using Ternary3.Internal;

/// <summary>
/// Represents a 16 trit signed integer
/// </summary>
public partial struct TernaryInt16
{
    private readonly uint trits;

    internal TernaryInt16(uint trits) => this.trits = trits;

    public static explicit operator TernaryInt16(int value) => new TernaryInt16(value.ToTritUInt32());
    public static implicit operator int(TernaryInt16 value) => value.trits.FromTritUInt32();

    /// <summary>
    /// Represents the largest possible value of an <see cref="TernaryInt16"/>:
    /// U_UUU_UUU_UUU_UUU_UUU  This field is constant.
    /// </summary>
    public const int MinValue = -MaxTrit16;

    /// <summary>
    /// Represents the smallest possible value of an <see cref="TernaryInt16"/>:
    /// D_DDD_DDD_DDD_DDD_DDD  This field is constant.
    /// </summary>
    public const int MaxValue = MaxTrit16;

    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using the default formatter.
    /// </summary>
    public override string ToString() => Formatter.FormatTrits(trits, 16);
    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using a custom formatter.
    /// </summary>
    public string ToString(ITernaryFormat format) => Formatter.FormatTrits(trits, format, 16);
}
