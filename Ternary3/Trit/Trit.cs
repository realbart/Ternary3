namespace Ternary3;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

/// <summary>
/// The smallest unit in a trinary system, either balanced (-1, 0, 1) or unbalanced (0, 1, 2)
/// The lowest value is always <see cref="Down"/>, het higest <see cref="Up"/>
/// </summary>
public enum Trit : sbyte
{
    /// <summary>
    /// The value representing a negative current
    /// </summary>
    Down = -1,
    /// <summary>
    /// The value representing a neutral value
    /// </summary>
    Middle = 0,
    /// <summary>
    /// The value representing a positive current
    /// </summary>
    Up = 1
}

public static class TritValues
{
    /// <summary>
    /// The value representing a negative current
    /// </summary>
    public const Trit down = Trit.Down;
    /// <summary>
    /// The value representing a neutral value
    /// </summary>
    public const Trit middle = Trit.Middle;
    /// <summary>
    /// The value representing a positive current
    /// </summary>
    public const Trit up = Trit.Up;
}

public static partial class TritHelper
{
    private const Trit Down = Trit.Down;
    private const Trit Middle = Trit.Middle;
    private const Trit Up = Trit.Up;

    /// <summary>
    /// Represents the value for -5v
    /// </summary>
    public const string DownString = "Down";

    /// <summary>
    /// Represents the value for 0v
    /// </summary>
    public const string MiddleString = "Middle";

    /// <summary>
    /// Represents the value for 5v
    /// </summary>
    public const string UpString = "Up";

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
