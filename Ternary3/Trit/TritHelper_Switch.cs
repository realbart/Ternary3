using System;

namespace Ternary;

public static partial class TritHelper
{
    /// <summary>
    /// Performs on of three actions, based on the <see cref="Trit"/> value
    /// </summary>
    public static void Switch(this Trit value, Action? delegateDown, Action? delegateMiddle, Action? delegateUp)
    {
        switch (value)
        {
            case Down: delegateDown?.Invoke(); return;
            case Middle: delegateMiddle?.Invoke(); return;
            default: delegateUp?.Invoke(); return;
        }
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this Trit value, Func<TOut> delegateDown, Func<TOut> delegateMiddle, Func<TOut> delegateUp)
    {
        return value switch
        {
            Down => delegateDown(),
            Middle => delegateMiddle(),
            _ => delegateUp()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this Trit value, TOut valueDown, Func<TOut> delegateMiddle, Func<TOut> delegateUp)
    {
        return value switch
        {
            Down => valueDown,
            Middle => delegateMiddle(),
            _ => delegateUp()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this Trit value, Func<TOut> delegateDown, TOut valueMiddle, Func<TOut> delegateUp)
    {
        return value switch
        {
            Down => delegateDown(),
            Middle => valueMiddle,
            _ => delegateUp()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this Trit value, TOut valueDown, TOut valueMiddle, Func<TOut> delegateUp)
    {
        return value switch
        {
            Down => valueDown,
            Middle => valueMiddle,
            _ => delegateUp()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this Trit value, Func<TOut> delegateDown, Func<TOut> delegateMiddle, TOut valueUp)
    {
        return value switch
        {
            Down => delegateDown(),
            Middle => delegateMiddle(),
            _ => valueUp
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this Trit value, TOut valueDown, Func<TOut> delegateMiddle, TOut valueUp)
    {
        return value switch
        {
            Down => valueDown,
            Middle => delegateMiddle(),
            _ => valueUp
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this Trit value, Func<TOut> delegateDown, TOut valueMiddle, TOut valueUp)
    {
        return value switch
        {
            Down => delegateDown(),
            Middle => valueMiddle,
            _ => valueUp
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this Trit value, TOut valueDown, TOut valueMiddle, TOut valueUp)
    {
        return value switch
        {
            Down => valueDown,
            Middle => valueMiddle,
            _ => valueUp
        };
    }
}