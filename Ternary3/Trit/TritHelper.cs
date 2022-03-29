namespace Ternary3;

public static partial class TritHelper
{
    private const Trit Down = Trit.Down;
    private const Trit Middle = Trit.Middle;
    private const Trit Up = Trit.Up;

    /// <summary>
    /// Represents the value for -5v
    /// </summary>
    public const string DownString = nameof(Trit.Down);

    /// <summary>
    /// Represents the value for 0v
    /// </summary>
    public const string MiddleString = nameof(Trit.Middle);

    /// <summary>
    /// Represents the value for 5v
    /// </summary>
    public const string UpString = nameof(Trit.Up);

    /// <summary>
    /// Parses a value into a <see cref="Trit"/>
    /// </summary>
    public static Trit Parse(string value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        if (value.Equals(DownString, StringComparison.OrdinalIgnoreCase)) return Down;
        if (value.Equals(MiddleString, StringComparison.OrdinalIgnoreCase)) return Middle;
        if (value.Equals(UpString, StringComparison.OrdinalIgnoreCase)) return Up;
        throw new FormatException("String was not recognized as a valid Trit.");
    }

    /// <summary>
    /// Attempts to parse a value into a <see cref="Trit"/>
    /// </summary>
    public static bool TryParse(string value, out Trit result)
    {
        if (value == null)
        {
            result = default;
            return false;
        }
        if (value.Equals(nameof(Down), StringComparison.OrdinalIgnoreCase))
        {
            result = Down;
            return true;
        }
        if (value.Equals(nameof(Middle), StringComparison.OrdinalIgnoreCase))
        {
            result = Middle;
            return true;
        }
        if (value.Equals(nameof(Up), StringComparison.OrdinalIgnoreCase))
        {
            result = Up;
            return true;
        }
        result = default;
        return false;
    }
}
