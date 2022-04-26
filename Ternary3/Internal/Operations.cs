namespace Ternary3.Internal;

using System.Collections.Generic;
using Ternary3.Internal;

internal static partial class Operations
{
    internal static int Rot(IConvertible value) => Rot((int)value);
    internal static int Rot(int value) => value / 3;
    internal static int AntiRot(IConvertible value) => AntiRot((int)value);
    internal static int AntiRot(int value) => value * 3;
    internal static int Not(IConvertible value) => Not((int)value);
    internal static int Not(int value) => -value;

    /// <summary>
    /// Calculates a logical or, expanded to the ternary system.
    /// Each trit in the resulting value has the maximum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) Or UNDUND (225) => UUNUND (332)
    /// </summary>
    internal static int Or(IConvertible first, IConvertible second)
    {
        return Or((int)first, (int)second);
    }

    /// <summary>
    /// Calculates a logical or, expanded to the ternary system.
    /// Each trit in the resulting value has the maximum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) Or UNDUND (225) => UUNUND (332)
    /// </summary>
    internal static int Or(int first, int second)
    {
        if (first > -MaxTrit16 && first < MaxTrit16 && second > -MaxTrit16 && second < MaxTrit16)
        {
            return (((first.ToTritUInt32() ^ DownMask32) | (second.ToTritUInt32() ^ DownMask32)) ^ DownMask32).FromTritUInt32();
        }
        else
        {
            first = RoundTo20Trits(first);
            second = RoundTo20Trits(second);
            return (((first.ToTritUInt64() ^ DownMask64) | (second.ToTritUInt64() ^ DownMask64)) ^ DownMask64).FromTritInt64();
        }
    }

    /// <summary>
    /// Calculates a logical and, expanded to the ternary system.
    /// Each trit in the resulting value has the minimum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) And UNDUND (225) => UNDNDD
    /// </summary>
    internal static int And(IConvertible first, IConvertible second)
    {
        return And((int)first, (int)second);
    }

    /// <summary>
    /// Calculates a logical and, expanded to the ternary system.
    /// Each trit in the resulting value has the minimum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) And UNDUND (225) => UNDNDD
    /// </summary>
    internal static int And(int first, int second)
    {
        if (first > -MaxTrit16 && first < MaxTrit16 && second > -MaxTrit16 && second < MaxTrit16)
        {
            return AndTrits(first.ToTritUInt32(), second.ToTritUInt32()).FromTritUInt32();
        }
        else
        {
            first = RoundTo20Trits(first);
            second = RoundTo20Trits(second);
            return AndTrits(first.ToTritUInt64(), second.ToTritUInt64()).FromTritInt64();
        }
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


    //Performs a tritwise minus
    internal static int XOr(IConvertible first, IConvertible second)
        => Xor((int)first, (int)second);

    /// <summary>
    /// Calculates a logical xor, expanded to the ternary system.
    /// Each trit in the resulting value has the sum of the two source trits.
    /// Example:
    /// UUNNDD (320) XOR UNDUND (225) => DUDUDU
    /// </summary>
    internal static int Xor(int first, int second)
    {
        if (first > -MaxTrit16 && first < MaxTrit16 && second > -MaxTrit16 && second < MaxTrit16)
        {
            var a = first.ToTritUInt32();
            var b = second.ToTritUInt32();
            uint c = XorTrits(a, b);
            return c.FromTritUInt32();
        }
        else
        {
            var a = first.ToTritUInt64();
            var b = second.ToTritUInt64();
            ulong c = XorTrits(a, b);
            return c.FromTritInt64();
        }
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
}