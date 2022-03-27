namespace Ternary3;

using System.Reflection;

public static class Extensions
{
    public static Trit[] GetTrits(this int value)
    {
        IEnumerable<Trit> GetTritsInner()
        {
            Trit up;
            Trit down;
            if (value < 0)
            {
                value = -value;
                up = Trit.Down;
                down = Trit.Up;
            }
            else
            {
                up = Trit.Up;
                down = Trit.Down;
            }
            while (value != 0)
            {
                switch ((byte)(value % 3))
                {
                    case 0:
                        yield return Trit.Middle;
                        value /= 3;
                        break;
                    case 1:
                        yield return up;
                        value /= 3;
                        break;
                    case 2:
                        yield return down;
                        value = (value + 1) / 3;
                        break;
                }
            }
        }

        if (value == 0) return new[] { Trit.Middle };
        if (value == int.MinValue) return new[] { Trit.Up, Trit.Down, Trit.Down, Trit.Up, Trit.Down, Trit.Up, Trit.Down, Trit.Down, Trit.Down, Trit.Up, Trit.Up, Trit.Middle, Trit.Middle, Trit.Middle, Trit.Up, Trit.Middle, Trit.Up, Trit.Up, Trit.Middle, Trit.Up, Trit.Down };
        return GetTritsInner().ToArray();
    }

    public static int ToInt32(this IEnumerable<Trit> trits)
    {
        var factor = 1;
        var total = 0;
        foreach (var t in trits)
        {
            total += t.Switch(-factor, 0, factor);
            factor *= 3;
        }
        return total;
    }
}
