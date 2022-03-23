using System;

namespace Ternary3;

public partial struct Trit
{
    /// <summary>
    /// Performs on of three actions, based on the <see cref="Trit"/> value
    /// </summary>
    public void Switch(Action? delegateDown, Action? delegateMiddle, Action? delegateUp)
    {
        switch (value__)
        {
            case downValue: delegateDown?.Invoke(); return;
            case middleValue: delegateMiddle?.Invoke(); return;
            default: delegateUp?.Invoke(); return;
        }
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public TOut Switch<TOut>(Func<TOut> delegateDown, Func<TOut> delegateMiddle, Func<TOut> delegateUp)
    {
        return value__ switch
        {
            downValue => delegateDown(),
            middleValue => delegateMiddle(),
            _ => delegateUp()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public TOut Switch<TOut>(TOut valueDown, Func<TOut> delegateMiddle, Func<TOut> delegateUp)
    {
        return value__ switch
        {
            downValue => valueDown,
            middleValue => delegateMiddle(),
            _ => delegateUp()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public TOut Switch<TOut>(Func<TOut> delegateDown, TOut valueMiddle, Func<TOut> delegateUp)
    {
        return value__ switch
        {
            downValue => delegateDown(),
            middleValue => valueMiddle,
            _ => delegateUp()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public TOut Switch<TOut>(TOut valueDown, TOut valueMiddle, Func<TOut> delegateUp)
    {
        return value__ switch
        {
            downValue => valueDown,
            middleValue => valueMiddle,
            _ => delegateUp()
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public TOut Switch<TOut>(Func<TOut> delegateDown, Func<TOut> delegateMiddle, TOut valueUp)
    {
        return value__ switch
        {
            downValue => delegateDown(),
            middleValue => delegateMiddle(),
            _ => valueUp
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public TOut Switch<TOut>(TOut valueDown, Func<TOut> delegateMiddle, TOut valueUp)
    {
        return value__ switch
        {
            downValue => valueDown,
            middleValue => delegateMiddle(),
            _ => valueUp
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public TOut Switch<TOut>(Func<TOut> delegateDown, TOut valueMiddle, TOut valueUp)
    {
        return value__ switch
        {
            downValue => delegateDown(),
            middleValue => valueMiddle,
            _ => valueUp
        };
    }
    /// <summary>
    /// Returns on of three values, based on the <see cref="Trit"/> value
    /// </summary>
    public TOut Switch<TOut>(TOut valueDown, TOut valueMiddle, TOut valueUp)
    {
        return value__ switch
        {
            downValue => valueDown,
            middleValue => valueMiddle,
            _ => valueUp
        };
    }
}