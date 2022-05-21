namespace Ternary;

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
