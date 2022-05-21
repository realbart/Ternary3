using System.CodeDom.Compiler;

namespace Ternary;

[GeneratedCode("t4","1.0,0,0")]
public static partial class BuiltInTypeExtensions
{
    /// <summary>
    /// Performs on of three actions, based on the <see cref="Trit"/> value
    /// </summary>
    public static void Switch(this bool? value, Action? delegateDown, Action? delegateMiddle, Action? delegateUp)
    {
        switch (value)
        {
            case false: delegateDown?.Invoke(); return;
            case true: delegateUp?.Invoke(); return;
            default: delegateMiddle?.Invoke(); return;
        }
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this bool? value, Func<TOut> delegateDown, Func<TOut> delegateMiddle, Func<TOut> delegateUp)
    {
        return value switch
        {
            false => delegateDown(),
            true => delegateUp(),
            _ => delegateMiddle()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this bool? value, TOut valueDown, Func<TOut> delegateMiddle, Func<TOut> delegateUp)
    {
        return value switch
        {
            false => valueDown,
            true => delegateUp(),
            _ => delegateMiddle()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this bool? value, Func<TOut> delegateDown, TOut valueMiddle, Func<TOut> delegateUp)
    {
        return value switch
        {
            false => delegateDown(),
            true => delegateUp(),
            _ => valueMiddle
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this bool? value, TOut valueDown, TOut valueMiddle, Func<TOut> delegateUp)
    {
        return value switch
        {
            false => valueDown,
            true => delegateUp(),
            _ => valueMiddle
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this bool? value, Func<TOut> delegateDown, Func<TOut> delegateMiddle, TOut valueUp)
    {
        return value switch
        {
            false => delegateDown(),
            true => valueUp,
            _ => delegateMiddle()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this bool? value, TOut valueDown, Func<TOut> delegateMiddle, TOut valueUp)
    {
        return value switch
        {
            false => valueDown,
            true => valueUp,
            _ => delegateMiddle()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this bool? value, Func<TOut> delegateDown, TOut valueMiddle, TOut valueUp)
    {
        return value switch
        {
            false => delegateDown(),
            true => valueUp,
            _ => valueMiddle
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public static TOut Switch<TOut>(this bool? value, TOut valueDown, TOut valueMiddle, TOut valueUp)
    {
        return value switch
        {
            false => valueDown,
            true => valueUp,
            _ => valueMiddle
        };
    }
}