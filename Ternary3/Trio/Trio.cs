namespace Ternary3;
using System.Collections;
using System.Collections.Generic;

public struct Trio<T> : IEnumerable<T>, ITrio<T>
{
    public Trio(T down, T middle, T up)
    {
        Down = down;
        Middle = middle;
        Up = up;
    }

    public readonly T Down;
    public readonly T Middle;
    public readonly T Up;

    public T this[Trit key] => key.Switch(Down, Middle, Up);

    /// <inheritdoc/>
    public IEnumerator<T> GetEnumerator()
    {
        yield return Down;
        yield return Middle;
        yield return Up;
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <inheritdoc/>
    public override string ToString() => $"{Down} - {Middle} - {Up}";
}
