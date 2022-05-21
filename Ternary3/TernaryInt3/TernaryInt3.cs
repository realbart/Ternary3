namespace Ternary;

using Ternary.Formatting;
using Ternary.Internal;


/// <summary>
/// Represents a 3-trit signed integer.
/// Also known as a tribble
/// Operations involving just this type are concatinating to 3 trits.
/// </summary>
public struct TernaryInt3
{
    private byte trits;

    /// <summary>
    /// Represents the smallest value of a <see cref="TernaryInt3"/>. 
    /// DDD. This field is a constant.
    /// </summary>
    public const sbyte MinValue = -MaxTrit3;

    /// <summary>
    /// Represents the smallest value of a <see cref="TernaryInt3"/>. 
    /// UUU. This field is a constant.
    /// </summary>
    public const sbyte MaxValue = MaxTrit3;

    internal TernaryInt3(byte trits) => this.trits = (byte)(trits ^ 0b111111);
    internal TernaryInt3(uint trits) : this((byte)trits) { }

    private static TernaryInt3 CreateChecked(uint trits)
        => new TernaryInt3((byte)(trits ^ 0b111111));

    public static implicit operator TernaryInt3(int value) => new TernaryInt3((byte)(value.ToTrits3()));
    public static implicit operator sbyte(TernaryInt3 value) => value.trits.From4Trits();
    public static implicit operator int(TernaryInt3 value) => value.trits.From4Trits();
    public static implicit operator long(TernaryInt3 value) => value.trits.From4Trits();

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
    public static TernaryInt3 Parse(ReadOnlySpan<char> s) => new TernaryInt3(Parser.ToTrits16(s, 3));

    /// <summary>
    ///  Converts the <see cref="string"/> representation of a value to a <see cref="TernaryInt16"/> instance.
    /// </summary>
    public static TernaryInt3 Parse(string s) => Parse(s.AsSpan());

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
    public Trit this[Index index] => Operations.GetTrit(trits, index, 3);

    /// <summary>
    /// Gets a range of trits (zero based, low first)
    /// </summary>
    public TernaryInt3 this[Range range] => new TernaryInt3(Operations.GetTrits(trits, range, 3));

    public static TernaryInt3 operator +(TernaryInt3 a, TernaryInt3 b)
        => CreateChecked(Operations.AddTrits(a.trits, b.trits));

    public static TernaryInt3 operator -(TernaryInt3 a, TernaryInt3 b)
        => CreateChecked(Operations.SubstractTrits(a.trits, b.trits));

    public static TernaryInt3 operator |(TernaryInt3 a, TernaryInt3 b)
        => new TernaryInt3(Operations.OrTrits(a.trits, b.trits));

    public static TernaryInt32 operator |(TernaryInt3 a, int b)
        => new TernaryInt32(Operations.OrTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator |(int a, TernaryInt3 b)
        => new TernaryInt32(Operations.OrTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt3 operator &(TernaryInt3 a, TernaryInt3 b)
        => new TernaryInt3(Operations.AndTrits(a.trits, b.trits));

    public static TernaryInt32 operator &(TernaryInt3 a, int b)
        => new TernaryInt32(Operations.AndTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator &(int a, TernaryInt3 b)
    => new TernaryInt32(Operations.AndTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt3 operator ^(TernaryInt3 a, TernaryInt3 b)
        => new TernaryInt3(Operations.XorTrits(a.trits, b.trits));

    public static TernaryInt32 operator ^(TernaryInt3 a, int b)
        => new TernaryInt32(Operations.XorTrits(a.trits, Conversion.ToTrits20(b)));

    public static TernaryInt32 operator ^(int a, TernaryInt3 b)
        => new TernaryInt32(Operations.XorTrits(Conversion.ToTrits20(a), b.trits));

    public static TernaryInt3 operator !(TernaryInt3 a)
        => new TernaryInt3(Operations.FlipTrits(a.trits));

    public static TernaryInt3 operator -(TernaryInt3 a)
        => new TernaryInt3(Operations.FlipTrits(a.trits));

    public static TernaryInt3 operator >>(TernaryInt3 a, int shift)
        => CreateChecked(Operations.ShiftTrits(a.trits, shift));

    public static TernaryInt3 operator <<(TernaryInt3 a, int shift)
        => CreateChecked(Operations.ShiftTrits(a.trits, -shift));
}