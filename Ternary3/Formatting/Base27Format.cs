﻿namespace Ternary.Formatting;

public class Base27Format : IBase27Format
{
    private readonly string digits;

    string IBase27Format.Digits => digits;

    private Base27Format(string digits) => this.digits = digits;


    public static IBase27Format Create(string digits)
    {
        if (digits == null) throw new ArgumentNullException(nameof(digits));
        if (digits.Length != 27) throw new ArgumentException("Need exactly 27 digits, from -13 to 13", nameof(digits));
        return new Base27Format(string.Concat(digits[13] , digits[12] , digits[14] , "?" , digits[10] , digits[9] , digits[11] , "?" , digits[16] , digits[15] , digits[17] , "?????" , digits[4] , digits[3] , digits[5] , "?" , digits[1] , digits[0] , digits[2] , "?" , digits[7] , digits[6] , digits[8] , "?????" , digits[22] , digits[21] , digits[23] , "?" , digits[19] , digits[18] , digits[20] , "?" , digits[25] , digits[24] , digits[26] , "????????????????????"));
    }

    /// <summary>
    /// Format that uses _ for zero, A-N for -13 to -1 and M-Z for 1-13
    /// </summary>
    public static readonly IBase27Format AlphabetShifted = new Base27Format(".mn?kjl?poq?????edf?bac?hgi?????vuw?srt?yxz?????????????????????");

    /// <summary>
    /// Format that uses _ for zero, A-N for 1 to 13 and M-Z for -13 to -1
    /// </summary>
    public static readonly IBase27Format AlphabetEuclidian = new Base27Format(".za?xwy?cbd?????rqs?onp?utv?????ihj?feg?lkm?????????????????????");

    /// <summary>
    /// Format that uses _ for zero, A-N for 1 to 13 and M-Z for -1 to -13
    /// </summary>
    public static readonly IBase27Format AlphabetTruncated = new Base27Format(".na?pqo?cbd?????vwu?onp?str?????ihj?feg?lkm?????????????????????");

    /// <summary>
    /// Format that uses 0 to Z for -13 to 13, omitting I, J, L, O, Q, S, U, W, Y
    /// </summary>
    public static readonly IBase27Format AlphanumericShifted = new Base27Format("dce?a9b?gfh?????435?102?768?????rpt?mkn?yvz?????????????????????");


    /// <summary>
    /// Format that uses 0 to D for 0 to 13 and E to Z for -13 to -1, omitting I, J, L, O, Q, S, U, W, Y
    /// </summary>
    public static readonly IBase27Format AlphanumericEuclidian = new Base27Format("0z1?vty?324?????khm?feg?pnr?????98a?657?cbd?????????????????????");

    /// <summary>
    /// Format that uses 0 to D for 0 to 13 and E to Z for -1 to -13, omitting I, J, L, O, Q, S, U, W, Y
    /// </summary>
    public static readonly IBase27Format AlphanumericTruncated = new Base27Format("0e1?ghf?324?????rtp?yzv?mnk?????98a?657?cbd?????????????????????");
}
