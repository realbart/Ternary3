namespace Ternary3;

public static partial class Extensions
{
    public static IEnumerable<Trit> GetTrits(this int value)
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
        return GetTritsInner();
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

    public static int PerformTrinaryOperation(this int operand, Func<Trit, Trit> operation)
    {
        return operand
            .GetTrits()
            .Select(operation)
            .ToInt32();
    }

    public static int PerformTrinaryOperation(this int operand1, Func<Trit, Trit, Trit> operation, int operand2)
    {
        static IEnumerable<Trit> PerformTrinaryOperationInner(IEnumerator<Trit> enumerator1, IEnumerator<Trit> enumerator2, Func<Trit, Trit, Trit> operation)
        {
            var has1 = enumerator1.MoveNext();
            var has2 = enumerator2.MoveNext();

            while (has1 && has2)
            {
                yield return operation(enumerator1.Current, enumerator2.Current);
                has1 = enumerator1.MoveNext();
                has2 = enumerator2.MoveNext();
            }
            while (has1)
            {
                yield return operation(enumerator1.Current, Trit.Middle);
                has1 = enumerator1.MoveNext();
            }
            while (has2)
            {
                yield return operation(Trit.Middle, enumerator2.Current);
                has2 = enumerator1.MoveNext();
            }
        }
        return PerformTrinaryOperationInner(operand1.GetTrits().GetEnumerator(), operand2.GetTrits().GetEnumerator(), operation).ToInt32();
    }
}
