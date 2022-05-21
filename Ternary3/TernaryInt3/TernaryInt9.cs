namespace Ternary;

using Ternary.Formatting;
using Ternary.Internal;

/// <summary>
/// Represents a 9-trit signed integer.
/// Also known as a tryte
/// Operations involving just this type are concatinating to 9 trits.
/// </summary>
public struct TernaryInt9
{
    private uint trits;

    /// <summary>
    /// Represents the smallest value of a <see cref="TernaryInt9"/>. 
    /// DDD_DDD_DDD. This field is a constant.
    /// </summary>
    public const int MinValue = -MaxTrit9;

    /// <summary>
    /// Represents the smallest value of a <see cref="TernaryInt9"/>. 
    /// UUU_UUU_UUU. This field is a constant.
    /// </summary>
    public const int MaxValue = MaxTrit9;

    internal TernaryInt9(uint trits) => this.trits = trits;

    private static TernaryInt9 CreateChecked(uint trits)
        => new TernaryInt9(trits ^ 0b111111_111111_111111);


    public static implicit operator TernaryInt9(int value) => new TernaryInt9(value.ToTrits9());
    public static implicit operator int(TernaryInt9 value) => value.trits.From16Trits();
    public static implicit operator long(TernaryInt9 value) => value.trits.From16Trits();

    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using the default formatter.
    /// </summary>
    public override string ToString() => Formatter.FormatTrits(trits, 0);
    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using a custom formatter.
    /// </summary>
    public string ToString(IBase3Format format, int numberOfDigits = 16) => Formatter.FormatTrits(trits, format, numberOfDigits);
    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Tribble (3 trits) using a custom formatter.
    /// </summary>
    public string ToString(IBase27Format format, int numberOfDigits = 6) => Formatter.FormatTribbles(trits, format, numberOfDigits);

    public static TernaryInt9 operator +(TernaryInt9 a, TernaryInt9 b)
        => CreateChecked(Operations.AddTrits(a.trits, b.trits));

    public static TernaryInt9 operator -(TernaryInt9 a, TernaryInt9 b)
        => CreateChecked(Operations.SubstractTrits(a.trits, b.trits));

    public static TernaryInt9 operator |(TernaryInt9 a, TernaryInt9 b)
        => new TernaryInt9(Operations.OrTrits(a.trits, b.trits));

    public static TernaryInt32 operator |(TernaryInt9 a, int b)
        => new TernaryInt32(Operations.OrTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator |(int a, TernaryInt9 b)
        => new TernaryInt32(Operations.OrTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt9 operator &(TernaryInt9 a, TernaryInt9 b)
        => new TernaryInt9(Operations.AndTrits(a.trits, b.trits));

    public static TernaryInt32 operator &(TernaryInt9 a, int b)
        => new TernaryInt32(Operations.AndTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator &(int a, TernaryInt9 b)
    => new TernaryInt32(Operations.AndTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt9 operator ^(TernaryInt9 a, TernaryInt9 b)
        => new TernaryInt9(Operations.XorTrits(a.trits, b.trits));

    public static TernaryInt32 operator ^(TernaryInt9 a, int b)
        => new TernaryInt32(Operations.XorTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator ^(int a, TernaryInt9 b)
        => new TernaryInt32(Operations.XorTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt9 operator !(TernaryInt9 a)
        => new TernaryInt9(Operations.FlipTrits(a.trits));

    public static TernaryInt9 operator -(TernaryInt9 a)
        => new TernaryInt9(Operations.FlipTrits(a.trits));

    public static TernaryInt9 operator >>(TernaryInt9 a, int shift)
        => CreateChecked(Operations.ShiftTrits(a.trits, shift));

    public static TernaryInt9 operator <<(TernaryInt9 a, int shift)
        => CreateChecked(Operations.ShiftTrits(a.trits, -shift));
}