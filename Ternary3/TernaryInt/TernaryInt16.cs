namespace Ternary3;
using Ternary3.Formatting;
using Ternary3.Internal;
using Ternary3.TernaryInt;

/// <summary>
/// Represents a 16-trit signed integer
/// </summary>
public partial struct TernaryInt16
{
    private readonly uint trits;

    internal TernaryInt16(uint trits) => this.trits = trits;

    public static implicit operator TernaryInt16(int value) => new TernaryInt16(value.ToTrits16());
    public static implicit operator int(TernaryInt16 value) => value.trits.From16Trits();
    public static implicit operator long(TernaryInt16 value) => value.trits.From16Trits();

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
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using the default formatter.
    /// </summary>
    public string ToString(int numberOfDigits) => Formatter.FormatTrits(trits, numberOfDigits);
    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using a custom formatter.
    /// </summary>
    public string ToString(IBase3Format format, int numberOfDigits = 16) => Formatter.FormatTrits(trits, format, numberOfDigits);
    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Tribble (3 trits) using a custom formatter.
    /// </summary>
    public string ToString(IBase27Format format, int numberOfDigits = 6) => Formatter.FormatTribbles(trits, format, numberOfDigits);

    /// <summary>
    ///  Converts the <see cref="Span{T}"/> representation of a value to a <see cref="TernaryInt16"/> instance.
    /// </summary>
    public static TernaryInt16 Parse(ReadOnlySpan<char> s) => new TernaryInt16(Parser.ToTrits16(s));

    /// <summary>
    ///  Converts the <see cref="string"/> representation of a value to a <see cref="TernaryInt16"/> instance.
    /// </summary>
    public static TernaryInt16 Parse(string s) => Parse(s.AsSpan());

}
