namespace Ternary3;

internal static class TribbleOperations
{

    /// <summary>
    /// Converts a signed value to three trits. (substract 13 first if you have an unsigned value)
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
        => (sbyte)(down.Switch(-1, 0, 1) | middle.Switch(-3, 0, 3) | up.Switch(-9, 0, 9));

    internal static sbyte Rot(sbyte value)
    {
        var trits = value.ToTrits();
        return ToValue(+trits.Down, +trits.Middle, +trits.Up);
    }

    internal static sbyte AntiRot(sbyte value)
    {
        var trits = value.ToTrits();
        return ToValue(-trits.Down, -trits.Middle, -trits.Up);
    }

    internal static sbyte Not(sbyte value)
    {
        var trits = value.ToTrits();
        return ToValue(!trits.Down, !trits.Middle, !trits.Up);
    }

    internal static sbyte Or(sbyte first, sbyte second)
    {
        var t1 = first.ToTrits();
        var t2 = second.ToTrits();
        return ToValue(t1.Down | t2.Down, t1.Middle | t2.Middle, t1.Up | t2.Up);
    }

    internal static sbyte And(sbyte first, sbyte second)
    {
        var t1 = first.ToTrits();
        var t2 = second.ToTrits();
        return ToValue(t1.Down & t2.Down, t1.Middle & t2.Middle, t1.Up & t2.Up);
    }

    internal static sbyte XOr(sbyte first, sbyte second)
    {
        var t1 = first.ToTrits();
        var t2 = second.ToTrits();
        return ToValue(t1.Down ^ t2.Down, t1.Middle ^ t2.Middle, t1.Up ^ t2.Up);
    }
}