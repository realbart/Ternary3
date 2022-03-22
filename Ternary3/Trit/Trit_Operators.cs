namespace Ternary3;


public readonly partial struct Trit
{
    // Note:
    // You cannot add or substract trits without knowing if which state maps to zero.


    /// <summary>
    /// Determines equality.
    /// </summary>
    public static bool operator ==(Trit trit1, Trit trit2) => trit1.Equals(trit2);
    /// <summary>
    /// Determines inequality.
    /// </summary>
    public static bool operator !=(Trit trit1, Trit trit2) => !trit1.Equals(trit2);

    /// <summary>
    /// Cycles the <see cref="Trit"/> value.
    /// </summary>
    public static Trit operator ++(Trit trit) => trit.Switch(Middle, Up, Down);

    /// <summary>
    /// Anti-cycles the <see cref="Trit"/> value.
    /// </summary>
    public static Trit operator --(Trit trit) => trit.Switch(Up, Down, Middle);

    /// <summary>
    /// Turns the Trit upside down.
    /// </summary>
    public static Trit operator !(Trit trit) => trit.Switch(Up, Middle, Down);

    /// <summary>
    /// Compares two trits.
    /// Returns a <see cref="Trit"/> showing if the first value is bigger than, equal to or smaller than the second.
    /// </summary>
    public static Trit operator >(Trit trit1, Trit trit2)
    {
        if (trit1.value == trit2.value) return Middle;
        return trit1.value > trit2.value ? Up : Down;
    }

    /// <summary>
    /// Compares two trits.
    /// Returns a <see cref="Trit"/> showing if the first value is smaller than, equal to or bigger than the second.
    /// </summary>
    public static Trit operator <(Trit trit1, Trit trit2)
    {
        if (trit1.value == trit2.value) return Middle;
        return trit1.value < trit2.value ? Up : Down;
    }

    /// <summary>
    /// Determines the lowest of two trits
    /// </summary>
    public static Trit operator &(Trit trit1, Trit trit2) => trit1.value > trit2.value ? trit2 : trit1;

    /// <summary>
    /// Selects the highest of two trits
    /// </summary>
    public static Trit operator |(Trit trit1, Trit trit2) => trit1.value < trit2.value ? trit2 : trit1;

    /// <summary>
    /// Performs an exclusive or: only returns a value other than <see cref="Middle"/> 
    /// if one of the values is <see cref="Middle"/> and the other isn't
    /// </summary>
    public static Trit operator ^(Trit trit1, Trit trit2)
    {
        if (trit1.value == middleValue) return trit2;
        if (trit2.value == middleValue) return trit1;
        return middle;
    }
}
