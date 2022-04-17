namespace Ternary3;

internal static partial class TribbleOperations
{
    /// <summary>
    /// Very quickly converts an integer value from a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 01 = down, 00 is middle, 10 is up.
    /// This way, the actual value is limited to 20 trits.
    /// </summary>
    /// <param name="value">The value to convert. No check is done to ensure the correct format.</param>
    internal static int FromTritInt64(this long value)
    {
        return (int)(
            ((value >> 1) & 1) - (value & 1)
            + 3 * (((value >> 3) & 1) - ((value >> 2) & 1))
            + 9 * (((value >> 5) & 1) - ((value >> 4) & 1))
            + 27 * (((value >> 7) & 1) - ((value >> 6) & 1))
            + 81 * (((value >> 9) & 1) - ((value >> 8) & 1))
            + 243 * (((value >> 11) & 1) - ((value >> 10) & 1))
            + 729 * (((value >> 13) & 1) - ((value >> 12) & 1))
            + 2187 * (((value >> 15) & 1) - ((value >> 14) & 1))
            + 6561 * (((value >> 17) & 1) - ((value >> 16) & 1))
            + 19683 * (((value >> 19) & 1) - ((value >> 18) & 1))
            + 59049 * (((value >> 21) & 1) - ((value >> 20) & 1))
            + 177147 * (((value >> 23) & 1) - ((value >> 22) & 1))
            + 531441 * (((value >> 25) & 1) - ((value >> 24) & 1))
            + 1594323 * (((value >> 27) & 1) - ((value >> 26) & 1))
            + 4782969 * (((value >> 29) & 1) - ((value >> 28) & 1))
            + 14348907 * (((value >> 31) & 1) - ((value >> 30) & 1))
            + 43046721 * (((value >> 33) & 1) - ((value >> 32) & 1))
            + 129140163 * (((value >> 35) & 1) - ((value >> 34) & 1))
            + 387420489 * (((value >> 37) & 1) - ((value >> 36) & 1))
            + 1162261467 * (((value >> 39) & 1) - ((value >> 38) & 1))
            + -808182895 * (((value >> 41) & 1) - ((value >> 40) & 1))
            + 1870418611 * (((value >> 43) & 1) - ((value >> 42) & 1))
            + 1316288537 * (((value >> 45) & 1) - ((value >> 44) & 1))
            + -346101685 * (((value >> 47) & 1) - ((value >> 46) & 1))
            + -1038305055 * (((value >> 49) & 1) - ((value >> 48) & 1))
            + 1180052131 * (((value >> 51) & 1) - ((value >> 50) & 1))
            + -754810903 * (((value >> 53) & 1) - ((value >> 52) & 1))
            + 2030534587 * (((value >> 55) & 1) - ((value >> 54) & 1))
            + 1796636465 * (((value >> 57) & 1) - ((value >> 56) & 1))
            + 1094942099 * (((value >> 59) & 1) - ((value >> 58) & 1))
            + -1010140999 * (((value >> 61) & 1) - ((value >> 60) & 1))
            + 1264544299 * (((value >> 63) & 1) - ((value >> 62) & 1))
        );
    }

        /// <summary>
    /// Very quickly converts an integer value from a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 01 = down, 00 is middle, 10 is up.
    /// This way, the actual value is limited to 9 trits.
    /// </summary>
    /// <param name="value">The value to convert. No check is done to ensure the correct format.</param>
    internal static int FromTritInt32(this int value)
    {
        return ((value >> 1) & 1) - (value & 1)
            + 3 * (((value >> 3) & 1) - ((value >> 2) & 1))
            + 9 * (((value >> 5) & 1) - ((value >> 4) & 1))
            + 27 * (((value >> 7) & 1) - ((value >> 6) & 1))
            + 81 * (((value >> 9) & 1) - ((value >> 8) & 1))
            + 243 * (((value >> 11) & 1) - ((value >> 10) & 1))
            + 729 * (((value >> 13) & 1) - ((value >> 12) & 1))
            + 2187 * (((value >> 15) & 1) - ((value >> 14) & 1))
            + 6561 * (((value >> 17) & 1) - ((value >> 16) & 1))
            + 19683 * (((value >> 19) & 1) - ((value >> 18) & 1))
            + 59049 * (((value >> 21) & 1) - ((value >> 20) & 1))
            + 177147 * (((value >> 23) & 1) - ((value >> 22) & 1))
            + 531441 * (((value >> 25) & 1) - ((value >> 24) & 1))
            + 1594323 * (((value >> 27) & 1) - ((value >> 26) & 1))
            + 4782969 * (((value >> 29) & 1) - ((value >> 28) & 1))
            + 14348907 * (((value >> 31) & 1) - ((value >> 30) & 1));
    }
}
