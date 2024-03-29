﻿namespace Ternary;

using Ternary.Formatting;
using Ternary.Internal;

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
    /// DDDDDDDD_DDDDDDDD_DDDDDDDD_DDDDDDDD. This field is constant.
    /// </summary>
    public const long MinValue = -MaxTrit32;

    /// <summary>
    /// Represents the smallest possible value of an <see cref="TernaryInt16"/>:
    /// UUUUUUUU_UUUUUUUU_UUUUUUUU_UUUUUUUU. This field is constant.
    /// </summary>
    public const long MaxValue = MaxTrit32;

    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using the default formatter.
    /// </summary>
    public override string ToString() => Formatter.FormatTrits(trits, 0);

    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Trit using a custom formatter.
    /// </summary>
    public string ToString(IBase3Format format, int numberOfDigits = 32) => Formatter.FormatTrits(trits, format, numberOfDigits);

    /// <summary>
    /// Formats the <see cref="TernaryInt16"/> one character per Tribble (3 trits) using a custom formatter.
    /// </summary>
    public string ToString(IBase27Format format, int numberOfDigits = 11) => Formatter.FormatTribbles(trits, format, numberOfDigits);

    /// <summary>
    ///  Converts the <see cref="Span{T}"/> representation of a value to a <see cref="TernaryInt16"/> instance.
    /// </summary>
    public static TernaryInt32 Parse(ReadOnlySpan<char> s) => new TernaryInt32(Parser.ToTrits32(s));

    /// <summary>
    ///  Converts the <see cref="string"/> representation of a value to a <see cref="TernaryInt16"/> instance.
    /// </summary>
    public static TernaryInt32 Parse(string s) => Parse(s.AsSpan());

    /// <summary>
    /// Gets the nth trit (zero-based, low first)
    /// </summary>
    public Trit this[int index]
    {
        get
        {
            if (index < 0 || index >= 32) throw new ArgumentOutOfRangeException(nameof(index));
            return Operations.GetTrit(trits, index);
        }
    }

    /// <summary>
    /// Gets the nth trit (zero-based, low first)
    /// </summary>
    public Trit this[Index index] => Operations.GetTrit(trits, index, 32);

    /// <summary>
    /// Gets a range of trits (zero based, low first)
    /// </summary>
    public TernaryInt32 this[Range range] => new TernaryInt32(Operations.GetTrits(trits, range, 32));

    public static TernaryInt32 operator +(TernaryInt32 a, TernaryInt32 b)
    => new TernaryInt32(Operations.AddTrits(a.trits, b.trits));

    public static TernaryInt32 operator -(TernaryInt32 a, TernaryInt32 b)
    => new TernaryInt32(Operations.SubstractTrits(a.trits, b.trits));

    public static TernaryInt32 operator |(TernaryInt32 a, TernaryInt32 b)
    => new TernaryInt32(Operations.OrTrits(a.trits, b.trits));

    public static TernaryInt32 operator |(TernaryInt32 a, int b)
        => new TernaryInt32(Operations.OrTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator |(int a, TernaryInt32 b)
        => new TernaryInt32(Operations.OrTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt32 operator &(TernaryInt32 a, TernaryInt32 b)
        => new TernaryInt32(Operations.AndTrits(a.trits, b.trits));

    public static TernaryInt32 operator &(TernaryInt32 a, int b)
        => new TernaryInt32(Operations.AndTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator &(int a, TernaryInt32 b)
    => new TernaryInt32(Operations.AndTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt32 operator ^(TernaryInt32 a, TernaryInt32 b)
        => new TernaryInt32(Operations.XorTrits(a.trits, b.trits));

    public static TernaryInt32 operator ^(TernaryInt32 a, int b)
        => new TernaryInt32(Operations.XorTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator ^(int a, TernaryInt32 b)
        => new TernaryInt32(Operations.XorTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt32 operator !(TernaryInt32 a)
        => new TernaryInt32(Operations.FlipTrits(a.trits));

    public static TernaryInt32 operator -(TernaryInt32 a)
        => new TernaryInt32(Operations.FlipTrits(a.trits));

    public static TernaryInt32 operator >>(TernaryInt32 a, int shift)
        => new TernaryInt32(Operations.ShiftTrits(a.trits, shift));

    public static TernaryInt32 operator <<(TernaryInt32 a, int shift)
        => new TernaryInt32(Operations.ShiftTrits(a.trits, -shift));
}