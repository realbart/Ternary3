namespace Ternary3;

using System.Collections;

public static partial class Extensions
{
    public const int TritsPerInt32 = 20;
    public const int TritsPerInt64 = 40;
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

    private static IEnumerable<Trit> GetTrits(this int value, int digits)
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
        while (digits-- > 0)
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

    public static int ToInt32(this IEnumerable<Trit> trits)
    {
        var factor = 1;
        var total = 0;
        foreach (var t in trits.Take(TritsPerInt32))
        {
            total += t.Switch(-factor, 0, factor);
            factor *= 3;
        }
        return total;
    }

    public static int PerformTrinaryOperation(this int operand, Func<Trit, Trit> operation)
    {
        return operand
            .GetTrits(TritsPerInt32)
            .Select(operation)
            .ToInt32();
    }

    public static int PerformTrinaryOperation(this int operand1, Func<Trit, Trit, Trit> operation, int operand2)
    {
        static IEnumerable<Trit> PerformTrinaryOperationInner(IEnumerator<Trit> enumerator1, IEnumerator<Trit> enumerator2, Func<Trit, Trit, Trit> operation)
        {
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                yield return operation(enumerator1.Current, enumerator2.Current);
            }
        }
        return PerformTrinaryOperationInner(
            operand1.GetTrits(TritsPerInt32).GetEnumerator(),
            operand2.GetTrits(TritsPerInt32).GetEnumerator(),
            operation)
            .ToInt32();
    }

    public static int And(this int operand1, int operand2)
        => PerformTrinaryOperation(operand1, TritHelper.And, operand2);

    public static int Or(this int operand1, int operand2)
        => PerformTrinaryOperation(operand1, TritHelper.Or, operand2);

    public static int XOr(this int operand1, int operand2)
        => PerformTrinaryOperation(operand1, TritHelper.XOr, operand2);

    public static int Flip(this int operand) => -operand;

    public static int Cycle(this int operand)
        => PerformTrinaryOperation(operand, TritHelper.Cycle);

    public static int AntiCycle(this int operand)
        => PerformTrinaryOperation(operand, TritHelper.AntiCycle);

    public static Trit Compare(this int operand1, int operand2)
    {
        if (operand1 == operand2) return Trit.Middle;
        return operand1 > operand2 ? Trit.Up : Trit.Down;
    }
}