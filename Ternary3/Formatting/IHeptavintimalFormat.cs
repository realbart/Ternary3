namespace Ternary3.Formatting;

public interface IHeptavintimalFormat
{
    internal string Digits { get; }
}


public class HeptavintimalFormat : IHeptavintimalFormat
{
    private readonly string digits;

    string IHeptavintimalFormat.Digits => digits;

    private HeptavintimalFormat(string digits) => this.digits = digits;


    public static IHeptavintimalFormat Create(string digits)
    {
        if (digits == null) throw new ArgumentNullException(nameof(digits));
        if (digits.Length != 27) throw new ArgumentException("Need exactly 27 digits, from -13 to 13", nameof(digits));
        return new HeptavintimalFormat(digits[0] + digits[26] + digits[1] + "?" + digits[24] + digits[23] + digits[25] + "?" + digits[3] + digits[2] + digits[4] + "?????" + digits[18] + digits[17] + digits[19] + "?" + digits[15] + digits[14] + digits[16] + "?" + digits[21] + digits[20] + digits[22] + "?????" + digits[9] + digits[8] + digits[10] + "?" + digits[6] + digits[5] + digits[7] + "?" + digits[12] + digits[11] + digits[13] + "?????????????????????");
    }

    public static readonly HeptavintimalFormat OrderedAlphabetHeptavintimalFormat = new HeptavintimalFormat("_MN?KJL?POQ?????EDF?BAC?HGI?????VUW?SRT?YXZ?????????????????????");
    public static readonly HeptavintimalFormat OneBasedAlphabetHeptavintimalFormat = new HeptavintimalFormat("_ZA?XWY?CBD?????RQS?ONP?UTV?????IHJ?FEG?LKM?????????????????????");
    public static readonly HeptavintimalFormat NumbersAndLettersHeptavintimalFormat = new HeptavintimalFormat("0Q1?ONP?324?????IHJ?FEG?LKM?????98A?657?CBD?????????????????????");
}