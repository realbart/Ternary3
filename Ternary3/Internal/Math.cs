namespace Ternary.Internal;
internal static class Math
{
    internal static int ThreePow(int exp)
    {
        var result = 1;
        var @base = 3;
        while (exp > 0)
        {
            if ((exp & 1) != 0)
            {
                result *= @base;
            }
            exp >>= 1;
            @base *= @base;
        }
        return result;
    }

    internal static long ThreePow(long exp)
    {
        var result = 1l;
        var @base = 3l;
        while (exp > 0)
        {
            if ((exp & 1) != 0)
            {
                result *= @base;
            }
            exp >>= 1;
            @base *= @base;
        }
        return result;
    }
}
