namespace Ternary3.Formatting;

public class Base27Format : IBase27Format
{
    private readonly string digits;

    string IBase27Format.Digits => digits;

    private Base27Format(string digits) => this.digits = digits;


    public static IBase27Format Create(string digits)
    {
        if (digits == null) throw new ArgumentNullException(nameof(digits));
        if (digits.Length != 27) throw new ArgumentException("Need exactly 27 digits, from -13 to 13", nameof(digits));
        return new Base27Format(digits[0] + digits[26] + digits[1] + "?" + digits[24] + digits[23] + digits[25] + "?" + digits[3] + digits[2] + digits[4] + "?????" + digits[18] + digits[17] + digits[19] + "?" + digits[15] + digits[14] + digits[16] + "?" + digits[21] + digits[20] + digits[22] + "?????" + digits[9] + digits[8] + digits[10] + "?" + digits[6] + digits[5] + digits[7] + "?" + digits[12] + digits[11] + digits[13] + "?????????????????????");
    }

    /// <summary>
    /// Format that uses _ for zero, A-N for -13 to -1 and M-Z for 1-13
    /// </summary>
    public static readonly Base27Format Base27AlphabetOrderedFormat = new Base27Format("_MN?KJL?POQ?????EDF?BAC?HGI?????VUW?SRT?YXZ?????????????????????");

    /// <summary>
    /// Format that uses _ for zero, A-N for 1 to 13 and M-Z for -13 to -1
    /// </summary>
    public static readonly Base27Format Base27AlphabetModuloFormat = new Base27Format("_ZA?XWY?CBD?????RQS?ONP?UTV?????IHJ?FEG?LKM?????????????????????");
    
    /// <summary>
    /// Format that uses _ for zero, A-N for 1 to 13 and M-Z for -1 to -13
    /// </summary>
    public static readonly Base27Format Base27AlphabetAbsoluteFormat = new Base27Format("_NA?PQO?CBD?????VWU?onp?STR?????IHJ?FEG?LKM?????????????????????");
    
    /// <summary>
    /// Format that uses 0 to D for 0 to 13 and E to Q for -13 to -1
    /// </summary>
    public static readonly Base27Format Base27NumbersAndLettersFormat = new Base27Format("0Q1?ONP?324?????IHJ?FEG?LKM?????98A?657?CBD?????????????????????");
}