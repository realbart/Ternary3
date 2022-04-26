namespace Ternary3.Internal;

using System.Collections.Generic;
using Ternary3.Internal;

internal static partial class Operations
{
    public static int Modulo16Trits(int value) => 0;
    public static int Modulo19Trits(int value) => 0;
    public static int Modulo20Trits(int value) => 0;


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
        // small numbers work faster
        if (first > -9842 && first < 9842 && second > -9842 && second < 9842)
        {
            const int downMask = 0b01010101_01010101_01010101_01010101;
            return (((first.ToTritUInt32() ^ downMask) | (second.ToTritUInt32() ^ downMask)) ^ downMask).FromTritUInt32();
        }
        else
        {
            // Overflow. Throws out of bounds in checked context.
            // 2^32 - 3^20 = 808182895
            if (first > 1743392200) first += 808182895;
            else if (first < -1743392200) first -= 808182895;
            if (second > 1743392200) second += 808182895;
            else if (second < -1743392200) second -= 808182895;
            const long downMask = 0b0101010101010101_0101010101010101_0101010101010101_0101010101010101;
            return (((first.ToTritInt64() ^ downMask) | (second.ToTritInt64() ^ downMask)) ^ downMask).FromTritInt64();
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
        // small numbers work faster
        if (first > -9842 && first < 9842 && second > -9842 && second < 9842)
        {
            const int downMask = 0b01010101_01010101_01010101_01010101;
            return (((first.ToTritUInt32() ^ downMask) & (second.ToTritUInt32() ^ downMask)) ^ downMask).FromTritUInt32();
        }
        else
        {
            // Overflow. Throws out of bounds in checked context.
            // 2^32 - 3^20 = 808182895
            if (first > 1743392200) first += 808182895;
            else if (first < -1743392200) first -= 808182895;
            if (second > 1743392200) second += 808182895;
            else if (second < -1743392200) second -= 808182895;
            const long downMask = 0b0101010101010101_0101010101010101_0101010101010101_0101010101010101;
            return (((first.ToTritInt64() ^ downMask) & (second.ToTritInt64() ^ downMask)) ^ downMask).FromTritInt64();
        }
    }

    /// <summary>
    /// Calculates a logical xor, expanded to the ternary system.
    /// Each trit in the resulting value has the sum of the two source trits.
    /// Example:
    /// UUNNDD (320) XOR UNDUND (225) => DUDUDU
    /// </summary>
    internal static int Xor(int first, int second)
    {
        if (first > -9842 && first < 9842 && second > -9842 && second < 9842)
        {
            var a = first.ToTritUInt32();
            var b = second.ToTritUInt32();
            const int downMask = 0b01010101_01010101_01010101_01010101;
            var a_up = (a >> 1) & downMask;
            var a_down = a & downMask;
            var a_neutral = a_up ^ a_down ^ downMask;
            var b_up = (b >> 1) & downMask;
            var b_down = b & downMask;
            var b_neutral = b_up ^ b_down ^ downMask;
            var c_up = (a_up & b_neutral) | (a_neutral & b_up) | (a_down & b_down);
            var c_down = (a_down & b_neutral) | (a_neutral & b_down) | (a_up & b_up);
            var c = c_up << 1 | c_down;
            return c.FromTritUInt32();
        }
        else
        {
            var a = first.ToTritInt64();
            var b = second.ToTritInt64();
            const long downMask = 0b0101010101010101_0101010101010101_0101010101010101_0101010101010101;
            var a_up = (a >> 1) & downMask;
            var a_down = a & downMask;
            var a_neutral = a_up ^ a_down ^ downMask;
            var b_up = (b >> 1) & downMask;
            var b_down = b & downMask;
            var b_neutral = b_up ^ b_down ^ downMask;
            var c_up = (a_up & b_neutral) | (a_neutral & b_up) | (a_down & b_down);
            var c_down = (a_down & b_neutral) | (a_neutral & b_down) | (a_up & b_up);
            var c = c_up << 1 | c_down;
            return c.FromTritInt64();
        }
    }

    //Performs a tritwise minus
    internal static int XOr(IConvertible first, IConvertible second)
    {
        return Xor((int)first, (int)second);
    }
}