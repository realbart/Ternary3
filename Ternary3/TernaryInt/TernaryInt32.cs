namespace Ternary3;
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
    public const long MinValue = -926510094425920; // -Pow(3,32)/2

    /// <summary>
    /// Represents the smallest possible value of an <see cref="TernaryInt16"/>:
    /// D_DDD_DDD_DDD_DDD_DDD  This field is constant.
    /// </summary>
    public const long MaxValue = 926510094425920; // Pow(3,32)/2
}