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

    public static explicit operator TernaryInt32(int value) => new TernaryInt32(value.ToTritUInt32());
    public static implicit operator int(TernaryInt32 value) => value.trits.FromTritInt64();

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

    /// <summary>
    /// Gets the nth <see cref="Trit"/>, starting with the least significant <see cref="Trit"/>.
    /// </summary>
    /// <param name="index">The index of the <see cref="Trit"/> to return, starting with the least significant</param>
    public Trit this[Index index] => Operations.GetTrit(trits, index);
    public ulong this[Range range] => Operations.GetTrits(trits, range);

    public static TernaryInt32 operator !(TernaryInt32 target) => new TernaryInt32(Operations.NotTrits(target.trits));
    public static TernaryInt32 operator &(TernaryInt32 a, TernaryInt32 b) => new TernaryInt32(Operations.AndTrits(a.trits, b.trits));
    public static TernaryInt32 operator |(TernaryInt32 a, TernaryInt32 b) => new TernaryInt32(Operations.OrTrits(a.trits, b.trits));
    public static TernaryInt32 operator ^(TernaryInt32 a, TernaryInt32 b) => new TernaryInt32(Operations.XorTrits(a.trits, b.trits));
    public static TernaryInt32 operator <<(TernaryInt32 a, int b) => new TernaryInt32(a.trits << (b << 1));
    public static TernaryInt32 operator >>(TernaryInt32 a, int b) => new TernaryInt32(a.trits >> (b << 1));

}