namespace Ternary3;


public static partial class TritHelper
{
    // Note:
    // You cannot add or substract trits without knowing if which state maps to zero.

    /// <summary>
    /// Cycles the <see cref="Trit"/> value.
    /// </summary>
    public static Trit Cycle(this Trit trit) => trit.Switch(Middle, Up, Down);

    /// <summary>
    /// Anti-cycles the <see cref="Trit"/> value.
    /// </summary>
    public static Trit AntiCycle(this Trit trit) => trit.Switch(Up, Down, Middle);

    /// <summary>
    /// Turns the Trit upside down.
    /// </summary>
    public static Trit Flip(this Trit trit) => trit.Switch(Up, Middle, Down);

    /// <summary>
    /// Compares two trits.
    /// Returns a <see cref="Trit"/> showing if the first value is bigger than, equal to or smaller than the second.
    /// </summary>
    public static Trit Compare(this Trit trit1, Trit trit2)
    {
        if (trit1 == trit2) return Middle;
        return trit1 > trit2 ? Up : Down;
    }

    /// <summary>
    /// Determines the lowest of two trits
    /// </summary>
    public static Trit And(this Trit trit1, Trit trit2) => trit1 > trit2 ? trit2 : trit1;

    /// <summary>
    /// Selects the highest of two trits
    /// </summary>
    public static Trit Or(this Trit trit1, Trit trit2) => trit1 < trit2 ? trit2 : trit1;

    /// <summary>
    /// Performs an exclusive or: only returns a value other than <see cref="Middle"/> 
    /// if one of the values is <see cref="Middle"/> and the other isn't
    /// </summary>
    public static Trit XOr(this Trit trit1, Trit trit2)
    {
        if (trit1 == Middle) return trit2;
        if (trit2 == Middle) return trit1;
        return Middle;
    }

    /// <summary>
    /// Converts a nullable boolean to a trit
    /// </summary>
    public static Trit ToTrit(this bool? boolean)
    {
        if (boolean.HasValue) return boolean.Value ? Up : Down;
        return Middle;
    }

    /// <summary>
    /// Converts a boolean to a trit
    /// </summary>
    public static Trit ToTrit(this bool boolean)
    {
        return boolean ? Up : Down;
    }

    /// <summary>
    /// Converts a trit to a nullable boolean
    /// </summary>
    /// <param name="trit"></param>
    public static bool? ToNullableBoolean(this Trit trit) => trit.Switch(false, default(bool?), true);
}
