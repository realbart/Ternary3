namespace Ternary3.Formatting;

public class Base3Format : IBase27Format
{
    private readonly string digits;
    private Base3Format(string digits) => this.digits = digits;
    public static Base3Format LetterFormat { get; } = new Base3Format("MDU?");
    public static Base3Format SignFormat { get; } = new Base3Format("0-+?");
    public static Base3Format NumberFormat { get; } = new Base3Format("0i1?");
    string IBase27Format.Digits => digits;
    public static IBase27Format Create(char down, char middle, char up) => new Base3Format(new string(new[] { middle, down, up, '?' }));
    public static IBase27Format Create(string digits)
    {
        if (digits == null) throw new ArgumentNullException(nameof(digits));
        if (digits.Length != 3) throw new ArgumentException("Need exactly three digits, from -1 to 1",nameof(digits));
        return Create(digits[-1], digits[0], digits[1]);
    }

}
