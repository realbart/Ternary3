namespace Ternary;

using Ternary.Formatting;
using Ternary.Internal;

/// <summary>
/// Represents a 27-trit signed integer.
/// Also known as a tryte.
/// Operations involving just this type are concatinating to 27 trits.
/// </summary>
public struct TernaryInt27
{
    private ulong trits;

    /// <summary>
    /// Represents the smallest value of a <see cref="TernaryInt27"/>. 
    /// DDDDDDDDD_DDDDDDDDD_DDDDDDDDD. This field is a constant.
    /// </summary>
    public const long MinValue = -MaxTrit27;

    /// <summary>
    /// Represents the biggest value of a <see cref="TernaryInt27"/>. 
    /// UUUUUUUUU_UUUUUUUUU_UUUUUUUUU. This field is a constant.
    /// </summary>
    public const long MaxValue = MaxTrit27;

    internal TernaryInt27(ulong trits) => this.trits = trits;

    private static TernaryInt27 CreateChecked(ulong trits)
        => new TernaryInt27(trits & 0b111111_111111_111111__111111_111111_111111__111111_111111_111111);

    public static implicit operator TernaryInt27(int value) => new TernaryInt27(value.ToTrits20());
    public static implicit operator TernaryInt27(long value) => new TernaryInt27(value.ToTrits27());
    public static implicit operator long(TernaryInt27 value) => value.trits.From32Trits();

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

    /// <summary>
    ///  Converts the <see cref="Span{T}"/> representation of a value to a <see cref="TernaryInt16"/> instance.
    /// </summary>
    public static TernaryInt27 Parse(ReadOnlySpan<char> s) => new TernaryInt27(Parser.ToTrits32(s, 27));

    /// <summary>
    ///  Converts the <see cref="string"/> representation of a value to a <see cref="TernaryInt16"/> instance.
    /// </summary>
    public static TernaryInt27 Parse(string s) => Parse(s.AsSpan());

    /// <summary>
    /// Gets the nth trit (zero-based, low first)
    /// </summary>
    public Trit this[int index]
    {
        get
        {
            if (index < 0 || index >= 27) throw new ArgumentOutOfRangeException(nameof(index));
            return Operations.GetTrit(trits, index);
        }
    }

    /// <summary>
    /// Gets the nth trit (zero-based, low first)
    /// </summary>
    public Trit this[Index index] => Operations.GetTrit(trits, index, 27);

    /// <summary>
    /// Gets a range of trits (zero based, low first)
    /// </summary>
    public TernaryInt27 this[Range range] => new TernaryInt27(Operations.GetTrits(trits, range, 27));

    public static TernaryInt27 operator +(TernaryInt27 a, TernaryInt27 b)
        => CreateChecked(Operations.AddTrits(a.trits, b.trits));

    public static TernaryInt27 operator -(TernaryInt27 a, TernaryInt27 b)
        => CreateChecked(Operations.SubstractTrits(a.trits, b.trits));

    public static TernaryInt27 operator |(TernaryInt27 a, TernaryInt27 b)
        => new TernaryInt27(Operations.OrTrits(a.trits, b.trits));

    public static TernaryInt32 operator |(TernaryInt27 a, int b)
        => new TernaryInt32(Operations.OrTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator |(int a, TernaryInt27 b)
        => new TernaryInt32(Operations.OrTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt27 operator &(TernaryInt27 a, TernaryInt27 b)
        => new TernaryInt27(Operations.AndTrits(a.trits, b.trits));

    public static TernaryInt32 operator &(TernaryInt27 a, int b)
        => new TernaryInt32(Operations.AndTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator &(int a, TernaryInt27 b)
    => new TernaryInt32(Operations.AndTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt27 operator ^(TernaryInt27 a, TernaryInt27 b)
        => new TernaryInt27(Operations.XorTrits(a.trits, b.trits));

    public static TernaryInt32 operator ^(TernaryInt27 a, int b)
        => new TernaryInt32(Operations.XorTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator ^(int a, TernaryInt27 b)
        => new TernaryInt32(Operations.XorTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt27 operator !(TernaryInt27 a)
        => new TernaryInt27(Operations.FlipTrits(a.trits));

    public static TernaryInt27 operator -(TernaryInt27 a)
        => new TernaryInt27(Operations.FlipTrits(a.trits));

    public static TernaryInt27 operator >>(TernaryInt27 a, int shift)
        => CreateChecked(Operations.ShiftTrits(a.trits, shift));

    public static TernaryInt27 operator <<(TernaryInt27 a, int shift)
        => CreateChecked(Operations.ShiftTrits(a.trits, -shift));
}