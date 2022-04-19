namespace Ternary3
{
    using System.Collections.Generic;

    public interface ITrio<out T>
    {
        T this[Trit key] { get; }

        IEnumerator<T> GetEnumerator();
    }
}