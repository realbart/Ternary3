namespace Ternary3.Formatting;

public class TernaryFormat : ITernaryFormat
{
    private readonly string digits;
    private TernaryFormat(string digits) => this.digits = digits;
    public static TernaryFormat LetterFormat { get; } = new TernaryFormat("MDU?");
    public static TernaryFormat SignFormat { get; } = new TernaryFormat("0-+?");
    public static TernaryFormat NumberFormat { get; } = new TernaryFormat("0T1?");
    string ITernaryFormat.Digits => digits;
    public static ITernaryFormat Create(char down, char middle, char up) => new TernaryFormat(new string(new[] { middle, down, up, '?' }));
    public static ITernaryFormat Create(string digits)
    {
        if (digits == null) throw new ArgumentNullException(nameof(digits));
        if (digits.Length != 3) throw new ArgumentException("Need exactly three digits, from -1 to 1",nameof(digits));
        return Create(digits[-1], digits[0], digits[1]);
    }

}
