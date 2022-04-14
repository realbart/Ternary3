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
            const int fullMask = 0b111111111111_111111111111111;
            const int neutralMask = 0b010010010010_010010010010010;
            const int upMask = 0b100100100100_100100100100100;
            var tritLong = first.ToTritInt32() | second.ToTritInt32();
            var ups = tritLong & upMask;
            var neutrals = tritLong & neutralMask;
            tritLong &= fullMask ^ ups >> 1 ^ (neutrals >> 1 | ups >> 2);
            return tritLong.FromTritInt32();
        }
        else
        {
            // Overflow. Throws out of bounds in checked context.
            // 2^32 - 3^20 = 808182895
            if (first > 1743392200) first += 808182895;
            else if (first < -1743392200) first -= 808182895;
            if (second > 1743392200) second += 808182895;
            else if (second < -1743392200) second -= 808182895;
            const long fullMask = 0b111111111111111_111111111111111_111111111111111_111111111111111;
            const long neutralMask = 0b0100100100100_100100100100100_100100100100100_10010010010010010;
            const long upMask = 0b100100100100100_100100100100100_100100100100100_100100100100100;
            var tritLong = first.ToTritInt64() | second.ToTritInt64();
            var ups = tritLong & upMask;
            var neutrals = tritLong & neutralMask;
            tritLong &= fullMask ^ ups >> 1 ^ (neutrals >> 1 | ups >> 2);
            return tritLong.FromTritInt64();
        }
    }

    internal static sbyte And(sbyte first, sbyte second)
    {
        var t1 = first.ToTrits();
        var t2 = second.ToTrits();
        return ToValue(t1.Down.And(t2.Down), t1.Middle.And(t2.Middle), t1.Up.And(t2.Up));
    }

    internal static sbyte XOr(sbyte first, sbyte second)
    {
        var t1 = first.ToTrits();
        var t2 = second.ToTrits();
        return ToValue(t1.Down.XOr(t2.Down), t1.Middle.XOr(t2.Middle), t1.Up.XOr(t2.Up));
    }
}