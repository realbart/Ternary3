namespace Ternary3;

internal static partial class TribbleOperations
{
    /// <summary>
    /// Very quickly converts an integer value from a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 001 = down, 010 is middle, 100 is up.
    /// This way, the actual value is limited to 20 trits.
    /// </summary>
    /// <param name="value">The value to convert. No check is done to ensure the correct format.</param>
    internal static int FromTritInt64(this long value)
    {
        return (int)(
            ((value >> 2) & 1) - (value & 1)
            + 3 * (((value >> 5) & 1) - ((value >> 3) & 1))
            + 9 * (((value >> 8) & 1) - ((value >> 6) & 1))
            + 27 * (((value >> 11) & 1) - ((value >> 9) & 1))
            + 81 * (((value >> 14) & 1) - ((value >> 12) & 1))
            + 243 * (((value >> 17) & 1) - ((value >> 15) & 1))
            + 729 * (((value >> 20) & 1) - ((value >> 18) & 1))
            + 2187 * (((value >> 23) & 1) - ((value >> 21) & 1))
            + 6561 * (((value >> 26) & 1) - ((value >> 24) & 1))
            + 19683 * (((value >> 29) & 1) - ((value >> 27) & 1))
            + 59049 * (((value >> 32) & 1) - ((value >> 30) & 1))
            + 177147 * (((value >> 35) & 1) - ((value >> 33) & 1))
            + 531441 * (((value >> 38) & 1) - ((value >> 36) & 1))
            + 1594323 * (((value >> 41) & 1) - ((value >> 39) & 1))
            + 4782969 * (((value >> 44) & 1) - ((value >> 42) & 1))
            + 14348907 * (((value >> 47) & 1) - ((value >> 45) & 1))
            + 43046721 * (((value >> 50) & 1) - ((value >> 48) & 1))
            + 129140163 * (((value >> 53) & 1) - ((value >> 51) & 1))
            + 387420489 * (((value >> 56) & 1) - ((value >> 54) & 1))
            + 1162261467 * (((value >> 59) & 1) - ((value >> 57) & 1))
            + -808182895 * (((value >> 62) & 1) - ((value >> 60) & 1))
        );
    }

        /// <summary>
    /// Very quickly converts an integer value from a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 001 = down, 010 is middle, 100 is up.
    /// This way, the actual value is limited to 9 trits.
    /// </summary>
    /// <param name="value">The value to convert. No check is done to ensure the correct format.</param>
    internal static int FromTritInt32(this int value)
    {
        return ((value >> 2) & 1) - (value & 1)
            + 3 * (((value >> 5) & 1) - ((value >> 3) & 1))
            + 9 * (((value >> 8) & 1) - ((value >> 6) & 1))
            + 27 * (((value >> 11) & 1) - ((value >> 9) & 1))
            + 81 * (((value >> 14) & 1) - ((value >> 12) & 1))
            + 243 * (((value >> 17) & 1) - ((value >> 15) & 1))
            + 729 * (((value >> 20) & 1) - ((value >> 18) & 1))
            + 2187 * (((value >> 23) & 1) - ((value >> 21) & 1))
            + 6561 * (((value >> 26) & 1) - ((value >> 24) & 1))
            + 19683 * (((value >> 29) & 1) - ((value >> 27) & 1));
    }
}
