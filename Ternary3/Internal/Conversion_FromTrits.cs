namespace Ternary3.Internal;

internal static partial class Conversion
{
    /// <summary>
    /// Converts an integer value from a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 01 = down, 00 is middle, 10 is up.
    /// This way, the actual value is limited to 64 trits.
    /// However, long have values between -9223372036854775808 and 9223372036854775807.
    /// The long value is limited to 40 trits, having values between -6078832729528464400 and 6078832729528464400
    /// </summary>
    /// <param name="value">The value to convert. No check is done to ensure the correct format.</param>
    internal static long ToInt64(this (ulong high, ulong low) value)
    {
        return (
            ((long)(value.low >> 1) & 1) - (long)(value.low & 1)
            + 3L * ((long)((value.low >> 3) & 1) - (long)((value.low >> 2) & 1))
            + 9L * ((long)((value.low >> 5) & 1) - (long)((value.low >> 4) & 1))
            + 27L * ((long)((value.low >> 7) & 1) - (long)((value.low >> 6) & 1))
            + 81L * ((long)((value.low >> 9) & 1) - (long)((value.low >> 8) & 1))
            + 243L * ((long)((value.low >> 11) & 1) - (long)((value.low >> 10) & 1))
            + 729L * ((long)((value.low >> 13) & 1) - (long)((value.low >> 12) & 1))
            + 2187L * ((long)((value.low >> 15) & 1) - (long)((value.low >> 14) & 1))
            + 6561L * ((long)((value.low >> 17) & 1) - (long)((value.low >> 16) & 1))
            + 19683L * ((long)((value.low >> 19) & 1) - (long)((value.low >> 18) & 1))
            + 59049L * ((long)((value.low >> 21) & 1) - (long)((value.low >> 20) & 1))
            + 177147L * ((long)((value.low >> 23) & 1) - (long)((value.low >> 22) & 1))
            + 531441L * ((long)((value.low >> 25) & 1) - (long)((value.low >> 24) & 1))
            + 1594323L * ((long)((value.low >> 27) & 1) - (long)((value.low >> 26) & 1))
            + 4782969L * ((long)((value.low >> 29) & 1) - (long)((value.low >> 28) & 1))
            + 14348907L * ((long)((value.low >> 31) & 1) - (long)((value.low >> 30) & 1))
            + 43046721L * ((long)((value.low >> 33) & 1) - (long)((value.low >> 32) & 1))
            + 129140163L * ((long)((value.low >> 35) & 1) - (long)((value.low >> 34) & 1))
            + 387420489L * ((long)((value.low >> 37) & 1) - (long)((value.low >> 36) & 1))
            + 1162261467L * ((long)((value.low >> 39) & 1) - (long)((value.low >> 38) & 1))
            + 3486784401L * ((long)((value.low >> 41) & 1) - (long)((value.low >> 40) & 1))
            + 10460353203L * ((long)((value.low >> 43) & 1) - (long)((value.low >> 42) & 1))
            + 31381059609L * ((long)((value.low >> 45) & 1) - (long)((value.low >> 44) & 1))
            + 94143178827L * ((long)((value.low >> 47) & 1) - (long)((value.low >> 46) & 1))
            + 282429536481L * ((long)((value.low >> 49) & 1) - (long)((value.low >> 48) & 1))
            + 847288609443L * ((long)((value.low >> 51) & 1) - (long)((value.low >> 50) & 1))
            + 2541865828329L * ((long)((value.low >> 53) & 1) - (long)((value.low >> 52) & 1))
            + 7625597484987L * ((long)((value.low >> 55) & 1) - (long)((value.low >> 54) & 1))
            + 22876792454961L * ((long)((value.low >> 57) & 1) - (long)((value.low >> 56) & 1))
            + 68630377364883L * ((long)((value.low >> 59) & 1) - (long)((value.low >> 58) & 1))
            + 205891132094649L * ((long)((value.low >> 61) & 1) - (long)((value.low >> 60) & 1))
            + 617673396283947L * ((long)((value.low >> 63) & 1) - (long)((value.low >> 62) & 1))
            + 1853020188851841L * ((long)(value.high >> 1) & 1) - (long)(value.high & 1)
            + 5559060566555523L * ((long)((value.high >> 1) & 1) - (long)((value.high >> 2) & 1))
            + 16677181699666569L * ((long)((value.high >> 3) & 1) - (long)((value.high >> 4) & 1))
            + 50031545098999707L * ((long)((value.high >> 5) & 1) - (long)((value.high >> 6) & 1))
            + 150094635296999121L * ((long)((value.high >> 7) & 1) - (long)((value.high >> 8) & 1))
            + 450283905890997363L * ((long)((value.high >> 9) & 1) - (long)((value.high >> 10) & 1))
            + 1350851717672992089L * ((long)((value.high >> 11) & 1) - (long)((value.high >> 12) & 1))
            + 4052555153018976267L * ((long)((value.high >> 13) & 1) - (long)((value.high >> 14) & 1))
        );
    }

    /// <summary>
    /// Converts an integer value from a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 01 = down, 00 is middle, 10 is up.
    /// This way, the actual value is limited to 20 trits.
    /// </summary>
    /// <param name="value">The value to convert. No check is done to ensure the correct format.</param>
    internal static int ToInt32(this ulong value)
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
            + 3486784401 * ((int)((value >> 41) & 1) - (int)((value >> 40) & 1))
            + 10460353203 * ((int)((value >> 43) & 1) - (int)((value >> 42) & 1))
            + 31381059609 * ((int)((value >> 45) & 1) - (int)((value >> 44) & 1))
            + 94143178827 * ((int)((value >> 47) & 1) - (int)((value >> 46) & 1))
            + 282429536481 * ((int)((value >> 49) & 1) - (int)((value >> 48) & 1))
            + 847288609443 * ((int)((value >> 51) & 1) - (int)((value >> 50) & 1))
            + 2541865828329 * ((int)((value >> 53) & 1) - (int)((value >> 52) & 1))
            + 7625597484987 * ((int)((value >> 55) & 1) - (int)((value >> 54) & 1))
            + 22876792454961 * ((int)((value >> 57) & 1) - (int)((value >> 56) & 1))
            + 68630377364883 * ((int)((value >> 59) & 1) - (int)((value >> 58) & 1))
            + 205891132094649 * ((int)((value >> 61) & 1) - (int)((value >> 60) & 1))
            + 617673396283947 * ((int)((value >> 63) & 1) - (int)((value >> 62) & 1))
        );
    }

    /// <summary>
    /// Converts an integer value from a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 01 = down, 00 is middle, 10 is up.
    /// This way, the actual value is limited to 9 trits.
    /// </summary>
    /// <param name="value">The value to convert. No check is done to ensure the correct format.</param>
    internal static int ToInt32(this uint value)
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
