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

    internal static Trit GetTrit(uint trit) => (trit & 3) switch
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

    internal static uint GetTrits(uint trits, Range range) => GetTrits(trits, range, 16);
    internal static uint GetTrits(uint trits, Range range, int totalTrits)
    {
        (var offset, var length) = range.GetOffsetAndLength(totalTrits);
        var shift = 32 - (length << 1);
        return trits << (shift - offset << 1) >> (shift);
    }
    internal static ulong GetTrits(ulong trits, Range range) => GetTrits(trits, range, 32);
    internal static ulong GetTrits(ulong trits, Range range, int totalTrits)
    {
        (var offset, var length) = range.GetOffsetAndLength(totalTrits);
        var shift = 64 - (length << 1);
        return trits << (shift - offset << 1) >> (shift);
    }


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

    /// <summary>
    /// Performs an addition on two numbers in their <see cref="Trit"/> representation
    /// </summary>
    public static uint AddTrits(uint a, uint b)
    {
        a ^= ((a & UpMask32) ^ UpMask32) >> 1;
        b ^= ((b & UpMask32) ^ UpMask32) >> 1;
        return AddTrits_Inner(a, b);
    }

    /// <summary>
    /// Performs a substraction on two numbers in their <see cref="Trit"/> representation
    /// </summary>
    public static uint SubstractTrits(uint a, uint b)
    {
        a ^= ((a & UpMask32) ^ UpMask32) >> 1;
        var bup = b & UpMask32;
        b ^= (((b & DownMask32) << 1) ^ bup) | (bup >> 1);
        return AddTrits_Inner(a, b);
    }

    private static uint AddTrits_Inner(uint a, uint b)
    {
        uint result = 0;
        uint rest = 1;
        for (var i = 0; i < 16; i++)
        {
            result >>= 2;
            var p = a & 0b11;
            var q = b & 0b11;
            var sum = p + q + rest + 1;
            switch (sum % 3)
            {
                case 2:
                    result |= 0b01000000_00000000_0000000_00000000;
                    break;
                case 0:
                    result |= 0b10000000_00000000_0000000_00000000;
                    break;
            }
            rest = sum / 3;
            a >>= 2;
            b >>= 2;
        }
        return result;
    }

    /// <summary>
    /// Performs an addition on two numbers in their <see cref="Trit"/> representation
    /// </summary>
    public static ulong AddTrits(ulong a, ulong b)
    {
        a ^= ((a & UpMask64) ^ UpMask64) >> 1;
        b ^= ((b & UpMask64) ^ UpMask64) >> 1;
        return AddTrits_Inner(a, b);
    }

    /// <summary>
    /// Performs a substraction on two numbers in their <see cref="Trit"/> representation
    /// </summary>
    public static ulong SubstractTrits(ulong a, ulong b)
    {
        a ^= ((a & UpMask64) ^ UpMask64) >> 1;
        var bup = b & UpMask64;
        b ^= (((b & DownMask64) << 1) ^ bup) | (bup >> 1);
        return AddTrits_Inner(a, b);
    }

    private static ulong AddTrits_Inner(ulong a, ulong b)
    {
        ulong result = 0;
        ulong rest = 1;
        for (var i = 0; i < 16; i++)
        {
            result >>= 2;
            var p = a & 0b11;
            var q = b & 0b11;
            var sum = p + q + rest + 1;
            switch (sum % 3)
            {
                case 2:
                    result |= 0b01000000_00000000_0000000_00000000__0000000_00000000_0000000_00000000;
                    break;
                case 0:
                    result |= 0b10000000_00000000_0000000_00000000__0000000_00000000_0000000_00000000;
                    break;
            }
            rest = sum / 3;
            a >>= 2;
            b >>= 2;
        }
        return result;
    }


}