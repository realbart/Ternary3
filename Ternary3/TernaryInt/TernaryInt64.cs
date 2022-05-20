namespace Ternary3;
using Ternary3.Internal;

/// <summary>
/// Represents a 64-trit signed integer
/// </summary>
public partial struct TernaryInt64
{
    internal readonly (ulong high, ulong low) trits;

    public TernaryInt64((ulong high, ulong low) trits) => this.trits = trits;

    public static explicit operator TernaryInt64(long value) => new TernaryInt64(value.ToTrits40());
    public static implicit operator long(TernaryInt64 value) => value.trits.From40Trits();

    /// <summary>
    ///  Converts the <see cref="Span{T}"/> representation of a value to a <see cref="TernaryInt16"/> instance.
    /// </summary>
    public static TernaryInt64 Parse(ReadOnlySpan<char> s) => new TernaryInt64(Parser.ToTrits64(s));

    /// <summary>
    ///  Converts the <see cref="string"/> representation of a value to a <see cref="TernaryInt16"/> instance.
    /// </summary>
    public static TernaryInt64 Parse(string s) => Parse(s.AsSpan());
}