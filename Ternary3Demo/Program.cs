using Ternary3;

namespace Ternary3Demo;

enum SomeValue : sbyte
{
    d = 0, m = 1, u = 2
}

public class Ternary3Demo
{
    public const sbyte m1 = -1;
    public const sbyte nul = 0;
    public const sbyte een = 1;
    private const SomeValue  sv= SomeValue.u;
    public static void Main()
    {
        var foo = SomeValue.m;
        var bar = SomeValue.u;
        var baz = bar;
        sbyte xxx = -1;
        sbyte yyy = 0;
        sbyte zzz = 1;
        Console.Write(baz);
        Console.Write(foo);
        Console.Write(xxx + yyy + zzz);
        Console.Write(m1 + nul + een);
        Write(sv);
    }

    private static void Write(SomeValue x)
    {
        Console.Write(x.ToString());
    }

}