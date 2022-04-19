namespace Ternary3.Internal;

internal static partial class Conversion
{
    /// <summary>
    /// Very quickly converts an integer value from a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 01 = down, 00 is middle, 10 is up.
    /// This way, the actual value is limited to 20 trits.
    /// </summary>
    /// <param name="value">The value to convert. No check is done to ensure the correct format.</param>
    internal static int FromTritInt64(this ulong value)
    {
        return (int)(
            (int)((value >> 1) & 1) - (int)(value & 1)
            + 3 * ((int)((value >> 3) & 1) - (int)((value >> 2) & 1))
            + 9 * ((int)((value >> 5) & 1) - (int)((value >> 4) & 1))
            + 27 * ((int)((value >> 7) & 1) - (int)((value >> 6) & 1))
            + 81 * ((int)((value >> 9) & 1) - (int)((value >> 8) & 1))
            + 243 * ((int)((value >> 11) & 1) - (int)((value >> 10) & 1))
            + 729 * ((int)((value >> 13) & 1) - (int)((value >> 12) & 1))
            + 2187 * ((int)((value >> 15) & 1) - (int)((value >> 14) & 1))
            + 6561 * ((int)((value >> 17) & 1) - (int)((value >> 16) & 1))
            + 19683 * ((int)((value >> 19) & 1) - (int)((value >> 18) & 1))
            + 59049 * ((int)((value >> 21) & 1) - (int)((value >> 20) & 1))
            + 177147 * ((int)((value >> 23) & 1) - (int)((value >> 22) & 1))
            + 531441 * ((int)((value >> 25) & 1) - (int)((value >> 24) & 1))
            + 1594323 * ((int)((value >> 27) & 1) - (int)((value >> 26) & 1))
            + 4782969 * ((int)((value >> 29) & 1) - (int)((value >> 28) & 1))
            + 14348907 * ((int)((value >> 31) & 1) - (int)((value >> 30) & 1))
            + 43046721 * ((int)((value >> 33) & 1) - (int)((value >> 32) & 1))
            + 129140163 * ((int)((value >> 35) & 1) - (int)((value >> 34) & 1))
            + 387420489 * ((int)((value >> 37) & 1) - (int)((value >> 36) & 1))
            + 1162261467 * ((int)((value >> 39) & 1) - (int)((value >> 38) & 1))
            + -808182895 * ((int)((value >> 41) & 1) - (int)((value >> 40) & 1))
            + 1870418611 * ((int)((value >> 43) & 1) - (int)((value >> 42) & 1))
            + 1316288537 * ((int)((value >> 45) & 1) - (int)((value >> 44) & 1))
            + -346101685 * ((int)((value >> 47) & 1) - (int)((value >> 46) & 1))
            + -1038305055 * ((int)((value >> 49) & 1) - (int)((value >> 48) & 1))
            + 1180052131 * ((int)((value >> 51) & 1) - (int)((value >> 50) & 1))
            + -754810903 * ((int)((value >> 53) & 1) - (int)((value >> 52) & 1))
            + 2030534587 * ((int)((value >> 55) & 1) - (int)((value >> 54) & 1))
            + 1796636465 * ((int)((value >> 57) & 1) - (int)((value >> 56) & 1))
            + 1094942099 * ((int)((value >> 59) & 1) - (int)((value >> 58) & 1))
            + -1010140999 * ((int)((value >> 61) & 1) - (int)((value >> 60) & 1))
            + 1264544299 * ((int)((value >> 63) & 1) - (int)((value >> 62) & 1))
        );
    }

        /// <summary>
    /// Very quickly converts an integer value from a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 01 = down, 00 is middle, 10 is up.
    /// This way, the actual value is limited to 9 trits.
    /// </summary>
    /// <param name="value">The value to convert. No check is done to ensure the correct format.</param>
    internal static int FromTritUInt32(this uint value)
    {
        return (int)((value >> 1) & 1) - (int)(value & 1)
            + 3 * ((int)((value >> 3) & 1) - (int)((value >> 2) & 1))
            + 9 * ((int)((value >> 5) & 1) - (int)((value >> 4) & 1))
            + 27 * ((int)((value >> 7) & 1) - (int)((value >> 6) & 1))
            + 81 * ((int)((value >> 9) & 1) - (int)((value >> 8) & 1))
            + 243 * ((int)((value >> 11) & 1) - (int)((value >> 10) & 1))
            + 729 * ((int)((value >> 13) & 1) - (int)((value >> 12) & 1))
            + 2187 * ((int)((value >> 15) & 1) - (int)((value >> 14) & 1))
            + 6561 * ((int)((value >> 17) & 1) - (int)((value >> 16) & 1))
            + 19683 * ((int)((value >> 19) & 1) - (int)((value >> 18) & 1))
            + 59049 * ((int)((value >> 21) & 1) - (int)((value >> 20) & 1))
            + 177147 * ((int)((value >> 23) & 1) - (int)((value >> 22) & 1))
            + 531441 * ((int)((value >> 25) & 1) - (int)((value >> 24) & 1))
            + 1594323 * ((int)((value >> 27) & 1) - (int)((value >> 26) & 1))
            + 4782969 * ((int)((value >> 29) & 1) - (int)((value >> 28) & 1))
            + 14348907 * ((int)((value >> 31) & 1) - (int)((value >> 30) & 1));
    }
}
