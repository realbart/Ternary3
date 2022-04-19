namespace Ternary3;

using System.Collections.Generic;

internal static partial class TribbleOperations
{
    /// <summary>
    /// Converts a signed value to a <see cref="Trio&lt;Trit&gt;"/>. (substract 13 first if you have an unsigned value)
    /// </summary>
    /// <remarks>
    /// Explicitly written out for performance reasons.
    /// The value is assumed to always be between -13 and 13.
    /// </remarks>
    internal static Trio<Trit> ToTrits(this sbyte value)
    {
        var m = Trit.Down;
        var u = Trit.Down;

        if (value >= 5)
        {
            value -= 5;
            u = Trit.Up;
        }
        else if (value >= -4)
        {
            value -= -4;
            u = Trit.Middle;
        }
        if (value >= -7)
        {
            value -= -7;
            m = Trit.Up;
        }
        else if (value >= -10)
        {
            value -= -10;
            m = Trit.Middle;
        }
        var d = value switch
        {
            -11 => Trit.Up,
            -12 => Trit.Middle,
            _ => Trit.Down
        };
        return new Trio<Trit>(d, m, u);
    }

    /// <summary>
    /// Convert three trits to the signed value. (substract 13 to get the signed value)
    /// </summary>
    /// <remarks>
    /// explicitly written out for performance reasons.
    /// </remarks>
    internal static sbyte ToValue(Trit down, Trit middle, Trit up)
        => (sbyte)(down.Switch(-1, 0, 1) + middle.Switch(-3, 0, 3) + up.Switch(-9, 0, 9));

    internal static sbyte Rot(sbyte value)
    {
        var trits = value.ToTrits();
        return ToValue(trits.Down.Cycle(), trits.Middle.Cycle(), trits.Up.Cycle());
    }

    internal static sbyte AntiRot(sbyte value)
    {
        var trits = value.ToTrits();
        return ToValue(trits.Down.AntiCycle(), trits.Middle.AntiCycle(), trits.Up.AntiCycle());
    }

    internal static int Not(sbyte value) => -value;

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