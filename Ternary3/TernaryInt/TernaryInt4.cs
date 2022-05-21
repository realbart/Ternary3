namespace Ternary;

using Ternary.Formatting;
using Ternary.Internal;

/// <summary>
/// Represents a 4-trit signed integer.
/// Also known as a tribble
/// </summary>
public struct TernaryInt4
{
    private byte trits;

    /// <summary>
    /// Represents the smallest possible value of an <see cref="TernaryInt4"/>:
    /// UUUU  This field is constant.
    /// </summary>
    public const sbyte MinValue = -MaxTrit4;

    /// <summary>
    /// Represents the largest possible value of an <see cref="TernaryInt4"/>:
    /// DDDD  This field is constant.
    /// </summary>
    public const sbyte MaxValue = MaxTrit4;

    internal TernaryInt4(byte trits) => this.trits = trits;

    public static implicit operator TernaryInt4(int value) => new TernaryInt4((byte)value.ToTrits4());
    public static explicit operator sbyte(TernaryInt4 value) => value.trits.From4Trits();
    public static implicit operator int(TernaryInt4 value) => value.trits.From4Trits();
    public static implicit operator long(TernaryInt4 value) => value.trits.From4Trits();
    public static implicit operator TernaryInt16(TernaryInt4 value) => new TernaryInt16(value.trits);
    public static implicit operator TernaryInt32(TernaryInt4 value) => new TernaryInt32(value.trits);


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

    /// <summary>
    /// Gets the nth trit (zero-based, low first)
    /// </summary>
    public Trit this[int index]
    {
        get
        {
            if (index < 0 || index > 3) throw new ArgumentOutOfRangeException(nameof(index));
            return Operations.GetTrit(trits, index);
        }
    }

    /// <summary>
    /// Gets the nth trit (zero-based, low first)
    /// </summary>
    public Trit this[Index index]
    {
        get
        {
            if (index.Value < 0 || index.Value > 3) throw new ArgumentOutOfRangeException(nameof(index));
            return Operations.GetTrit(trits, index);
        }
    }

    /// <summary>
    /// Gets a range of trits (zero based, low first)
    /// </summary>
    public TernaryInt16 this[Range range] => new TernaryInt16(Operations.GetTrits(trits, range));

    public static TernaryInt16 operator |(TernaryInt4 a, TernaryInt4 b)
        => new TernaryInt16(Operations.OrTrits(a.trits, b.trits));

    public static TernaryInt32 operator |(TernaryInt4 a, int b)
        => new TernaryInt32(Operations.OrTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator |(int a, TernaryInt4 b)
        => new TernaryInt32(Operations.OrTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt16 operator &(TernaryInt4 a, TernaryInt4 b)
        => new TernaryInt16(Operations.AndTrits(a.trits, b.trits));

    public static TernaryInt32 operator &(TernaryInt4 a, int b)
        => new TernaryInt32(Operations.AndTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator &(int a, TernaryInt4 b)
    => new TernaryInt32(Operations.AndTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt16 operator ^(TernaryInt4 a, TernaryInt4 b)
        => new TernaryInt16(Operations.XorTrits(a.trits, b.trits));

    public static TernaryInt32 operator ^(TernaryInt4 a, int b)
        => new TernaryInt32(Operations.XorTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator ^(int a, TernaryInt4 b)
        => new TernaryInt32(Operations.XorTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt16 operator !(TernaryInt4 a)
        => new TernaryInt16(Operations.FlipTrits(a.trits));

    public static TernaryInt16 operator -(TernaryInt4 a)
        => new TernaryInt16(Operations.FlipTrits(a.trits));

    public static TernaryInt16 operator >>(TernaryInt4 a, int shift)
        => new TernaryInt16(Operations.ShiftTrits(a.trits, shift));

    public static TernaryInt16 operator <<(TernaryInt4 a, int shift)
        => new TernaryInt16(Operations.ShiftTrits(a.trits, -shift));
}