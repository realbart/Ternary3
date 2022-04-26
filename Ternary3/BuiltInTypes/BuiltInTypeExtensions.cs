namespace Ternary3;

using Ternary3.Internal;

public static partial class BuiltInTypeExtensions
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

    /// <summary>
    /// Calculates a logical and, expanded to the ternary system.
    /// Each trit in the resulting value has the minimum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) And UNDUND (225) => UNDNDD
    /// </summary>
    public static int And(this int operand1, int operand2)
    {
        // small numbers work faster
        if (operand1 > -9842 && operand1 < 9842 && operand2 > -9842 && operand2 < 9842)
        {
            const int downMask = 0b01010101_01010101_01010101_01010101;
            return (((operand1.ToTritUInt32() ^ downMask) & (operand2.ToTritUInt32() ^ downMask)) ^ downMask).FromTritUInt32();
        }
        else
        {
            // Overflow. Throws out of bounds in checked context.
            // 2^32 - 3^20 = 808182895
            if (operand1 > 1743392200) operand1 += 808182895;
            else if (operand1 < -1743392200) operand1 -= 808182895;
            if (operand2 > 1743392200) operand2 += 808182895;
            else if (operand2 < -1743392200) operand2 -= 808182895;
            const long downMask = 0b0101010101010101_0101010101010101_0101010101010101_0101010101010101;
            return (((operand1.ToTritUInt64() ^ downMask) & (operand2.ToTritUInt64() ^ downMask)) ^ downMask).FromTritInt64();
        }
    }

    /// <summary>
    /// Calculates a logical or, expanded to the ternary system.
    /// Each trit in the resulting value has the maximum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) Or UNDUND (225) => UUNUND (332)
    /// </summary>
    public static int Or(this int operand1, int operand2)
    {
        // small numbers work faster
        if (operand1 < 7174453 && operand2 < 7174453 && operand1 > -7174453 && operand2 > -7174453)
        {
            const int downMask = 0b01010101_01010101_01010101_01010101;
            return (((operand1.ToTritUInt32() ^ downMask) | (operand2.ToTritUInt32() ^ downMask)) ^ downMask).FromTritUInt32();
        }
        else
        {
            // Overflow. Throws out of bounds in checked context.
            // 2^32 - 3^20 = 808182895
            if (operand1 > 1743392200) operand1 += 808182895;
            else if (operand1 < -1743392200) operand1 -= 808182895;
            if (operand2 > 1743392200) operand2 += 808182895;
            else if (operand2 < -1743392200) operand2 -= 808182895;
            const long downMask = 0b0101010101010101_0101010101010101_0101010101010101_0101010101010101;
            return (((operand1.ToTritUInt64() ^ downMask) | (operand2.ToTritUInt64() ^ downMask)) ^ downMask).FromTritInt64();
        }
    }

    /// <summary>
    /// Calculates a logical xor, expanded to the ternary system.
    /// Each trit in the resulting value has the sum of the two source trits.
    /// Example:
    /// UUNNDD (320) XOR UNDUND (225) => DUDUDU
    /// </summary>
    public static int Xor(this int operand1, int operand2)
    {
        // small numbers work faster
        if (operand1 < 7174453 && operand2 < 7174453 && operand1 > -7174453 && operand2 > -7174453)
        {
            var a = operand1.ToTritUInt32();
            var b = operand2.ToTritUInt32();
            const int downMask = 0b01010101_01010101_01010101_01010101;
            var a_up = (a >> 1) & downMask;
            var a_down = a & downMask;
            var a_neutral = a_up ^ a_down ^ downMask;
            var b_up = (b >> 1) & downMask;
            var b_down = b & downMask;
            var b_neutral = b_up ^ b_down ^ downMask;
            var c_up = (a_up & b_neutral) | (a_neutral & b_up) | (a_down & b_down);
            var c_down = (a_down & b_neutral) | (a_neutral & b_down) | (a_up & b_up);
            var c = c_up << 1 | c_down;
            return c.FromTritUInt32();
        }
        else
        {
            var a = operand1.ToTritUInt64();
            var b = operand2.ToTritUInt64();
            const long downMask = 0b0101010101010101_0101010101010101_0101010101010101_0101010101010101;
            var a_up = (a >> 1) & downMask;
            var a_down = a & downMask;
            var a_neutral = a_up ^ a_down ^ downMask;
            var b_up = (b >> 1) & downMask;
            var b_down = b & downMask;
            var b_neutral = b_up ^ b_down ^ downMask;
            var c_up = (a_up & b_neutral) | (a_neutral & b_up) | (a_down & b_down);
            var c_down = (a_down & b_neutral) | (a_neutral & b_down) | (a_up & b_up);
            var c = c_up << 1 | c_down;
            return c.FromTritInt64();
        }
    }

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