namespace Ternary3;

/// <summary>
/// In C# division and modulo is round toward zero.
/// These versions round the same way for positive and negative numbers.
/// </summary>
internal static class Modulo
{
    // These methods can be performance-optimized by pre-calculating a lot of values 
    // and doing some smart bitshifts: x % 3 == (x&lt;&lt;2) % 3.
    // Note when refactoring: always make sure values near
    // the miniumum and maximum values keep working

    // todo: rewrite to throw System.OverflowException in checked mode.
    // note: catch and rethrow to make sure the overflow occurs in the Tribble.

    private const int biggestMultipleOf27ThatFitsInInt32 = 2147483637;
    private const int biggestMultipleOf3ThatFitsInInt64 = 2147483646;
    private const long biggestMultipleOf27ThatFitsInInt64 = 9223372036854775782;

    /// <summary>
    /// Using Euclidean division, the output value is between 0 and 27
    /// </summary>
    public static sbyte UnsignedModulo27Minus13(this int value)
    {
        if (value < 0) value += biggestMultipleOf27ThatFitsInInt32;
        if (value < 0) return (sbyte)(value + 14);
        return (sbyte)(value % 27 - 13);
    }

    /// <summary>
    /// Using Euclidean division, the output value is between 0 and 27
    /// </summary>
    public static sbyte UnsignedModulo27Minus13(this long value)
    {
        if (value < 0) value += biggestMultipleOf27ThatFitsInInt64;
        if (value < 0) return (sbyte)(value + 27);
        return (sbyte)(value % 27 - 13);
    }

    /// <summary>
    /// Using rounding division, the output value is between -13 and 13
    /// </summary>
    public static sbyte SignedModulo27(this int value)
    {
        if (value < -13) value += biggestMultipleOf27ThatFitsInInt32;
        if (value > 54) value -= 54;
        return (sbyte)((value + 40) % 27 - 13);
    }

    /// <summary>
    /// Using rounding division, the output value is between -13 and 13
    /// </summary>

    public static sbyte SignedModulo27(this long value)
    {
        if (value < -13) value += biggestMultipleOf27ThatFitsInInt64;
        if (value > 54) value -= 54;
        return (sbyte)((value + 40) % 27 - 13);
    }

    /// <summary>
    /// Using rounding division, the output value is between -1 and 1
    /// </summary>
    public static sbyte SignedModulo3(this int value)
    {
        if (value < -1) value += biggestMultipleOf3ThatFitsInInt64;
        if (value > 6) value -= 6;
        return (sbyte)((value + 1) % 3 - 1);
    }
}
