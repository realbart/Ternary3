namespace Ternary3;

using System.Diagnostics.CodeAnalysis;

/// <summary>
/// The smallest unit in a trinary system, either balanced (-1, 0, 1) or unbalanced (0, 1, 2)
/// The lowest value is always <see cref="Down"/>, het higest <see cref="Up"/>
/// </summary>
public readonly partial struct Trit
{

    public readonly struct Values
    {
        public static readonly Trit down = Down;
        public static readonly Trit middle = Middle;
        public static readonly Trit up = Up;
    }

    private const sbyte downValue = -1;
    private const sbyte middleValue = 0;
    private const sbyte upValue = 1;
    internal static readonly Trit Down = new(downValue);
    internal static readonly Trit Middle = new(middleValue);
    internal static readonly Trit Up = new(upValue);

    /// <summary>
    /// A struct always uses a minimum of one byte.
    /// </summary>
    private readonly sbyte value;

    private Trit(sbyte value) => this.value = value;

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

    /// <inheritdoc/>
    public override int GetHashCode() => value.GetHashCode();

    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Trit trit && value == trit.value;

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

    /// <inheritdoc />
    public override string ToString() => value switch
    {
        downValue=> DownString,
        middleValue => MiddleString,
        _ => UpString
    };
}
