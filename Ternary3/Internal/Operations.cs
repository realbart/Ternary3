namespace Ternary3.Internal;

using System.Collections.Generic;
using Ternary3.Internal;

internal static partial class Operations
{
    public static uint ShiftTrits(uint a, int b)
        => b > 0 ? a >> (b << 1) : a << (-b << 1);

    public static ulong ShiftTrits(ulong a, int b)
        => b > 0 ? a >> (b << 1) : a << (-b << 1);

    internal static uint AndTrits(uint a, uint b)
        => ((a ^ DownMask32) & (b ^ DownMask32)) ^ DownMask32;

    internal static ulong AndTrits(ulong a, ulong b)
        => ((a ^ DownMask64) & (b ^ DownMask64)) ^ DownMask64;

    internal static uint OrTrits(uint a, uint b)
        => ((a ^ DownMask32) | (b ^ DownMask32)) ^ DownMask32;

    internal static ulong OrTrits(ulong a, ulong b)
        => ((a ^ DownMask64) | (b ^ DownMask64)) ^ DownMask64;

    internal static uint FlipTrits(uint trits)
        => ((trits & DownMask32) << 1) | ((trits >> 1) & DownMask32);

    internal static ulong FlipTrits(ulong trits)
        => ((trits & DownMask64) << 1) | ((trits >> 1) & DownMask64);

    internal static Trit GetTrit (uint trit) => (trit & 3) switch
    {
        0 => Trit.Middle,
        2 => Trit.Up,
        _ => Trit.Down
    };

    internal static Trit GetTrit(ulong trit) => (trit & 3) switch
    {
        0 => Trit.Middle,
        2 => Trit.Up,
        _ => Trit.Down
    };

    internal static Trit GetTrit(uint trits, int index) => GetTrit(trits >> (index << 1));
    internal static Trit GetTrit(uint trits, Index index) => GetTrit(trits, index, 16);
    internal static Trit GetTrit(uint trits, Index index, int length) => GetTrit(trits, index.GetOffset(length));
    internal static Trit GetTrit(ulong trits, int index) => GetTrit(trits >> (index << 1));
    internal static Trit GetTrit(ulong trits, Index index) => GetTrit(trits, index, 32);
    internal static Trit GetTrit(ulong trits, Index index, int length) => GetTrit(trits, index.GetOffset(length));

    /// <summary>
    /// Performs an Xor (<see cref="Trit"/>wise addition) on two 16-<see cref="Trit"/> values
    /// </summary>
    /// <param name="a">The first trit-value (2 bits per trit)</param>
    /// <param name="b">The second trit-value (2 bits per trit)</param>
    internal static ulong XorTrits(ulong a, ulong b)
    {
        var a_up = (a >> 1) & DownMask64;
        var a_down = a & DownMask64;
        var a_neutral = a_up ^ a_down ^ DownMask64;
        var b_up = (b >> 1) & DownMask64;
        var b_down = b & DownMask64;
        var b_neutral = b_up ^ b_down ^ DownMask64;
        var c_up = (a_up & b_neutral) | (a_neutral & b_up) | (a_down & b_down);
        var c_down = (a_down & b_neutral) | (a_neutral & b_down) | (a_up & b_up);
        var c = c_up << 1 | c_down;
        return c;
    }

    /// <summary>
    /// Performs an Xor (<see cref="Trit"/>wise addition) on two 16-<see cref="Trit"/> values
    /// </summary>
    /// <param name="a">The first trit-value (2 bits per trit)</param>
    /// <param name="b">The second trit-value (2 bits per trit)</param>
    internal static uint XorTrits(uint a, uint b)
    {
        var a_up = (a >> 1) & DownMask32;
        var a_down = a & DownMask32;
        var a_neutral = a_up ^ a_down ^ DownMask32;
        var b_up = (b >> 1) & DownMask32;
        var b_down = b & DownMask32;
        var b_neutral = b_up ^ b_down ^ DownMask32;
        var c_up = (a_up & b_neutral) | (a_neutral & b_up) | (a_down & b_down);
        var c_down = (a_down & b_neutral) | (a_neutral & b_down) | (a_up & b_up);
        var c = c_up << 1 | c_down;
        return c;
    }
}