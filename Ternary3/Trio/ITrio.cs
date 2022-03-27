﻿namespace Ternary3
{
    using System.Collections.Generic;

    public interface ITrio<out T> where T : struct
    {
        T this[Trit key] { get; }

        IEnumerator<T> GetEnumerator();
    }
}