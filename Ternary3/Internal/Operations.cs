namespace Ternary3.Internal;

using System.Collections.Generic;
using Ternary3.Internal;

internal static partial class Operations
{
    internal static int RoundTo20Trits(int value)
    {
        // Overflow. Throws out of bounds in checked context.
        // 2^32 - 3^20 = 808182895
        if (value > MaxTrit20) value += 808182895;
        else if (value < -MaxTrit20) value -= 808182895;
        return value;
    }

    internal static long RoundTo40Trits(long value)
    {
        // Overflow. Throws out of bounds in checked context.
        // 2^64 - 3^40 = 6289078614652622815
        if (value > MaxTrit40) value += 6289078614652622815;
        else if (value < -MaxTrit40) value -= 6289078614652622815;
        return value;
    }

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