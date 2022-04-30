namespace Ternary3;

using Ternary3.BuiltInTypes;
using Ternary3.Internal;

public static partial class BuiltInTypeExtensions
{

    /// <summary>
    /// Calculates a logical and, expanded to the ternary system.
    /// Each trit in the resulting value has the minimum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) And UNDUND (225) => UNDNDD
    /// </summary>
    public static int TrinaryAnd(IConvertible first, IConvertible second) => TrinaryAnd((int)first, (int)second);

    /// <summary>
    /// Calculates a logical and, expanded to the ternary system.
    /// Each trit in the resulting value has the minimum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) And UNDUND (225) => UNDNDD
    /// </summary>
    public static int TrinaryAnd(this int first, int second)
    {
        if (first > -MaxTrit16 && first < MaxTrit16 && second > -MaxTrit16 && second < MaxTrit16)
        {
            return Operations.AndTrits(first.ToTrits16(), second.ToTrits16()).From16Trits();
        }
        else
        {
            first = first.ModThreePow20();
            second = second.ModThreePow20();
            return Operations.AndTrits(first.ToTrits20(), second.ToTrits20()).From20Trits();
        }
    }

    /// <summary>
    /// Calculates a logical or, expanded to the ternary system.
    /// Each trit in the resulting value has the maximum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) Or UNDUND (225) => UUNUND (332)
    /// </summary>
    public static int TrinaryOr(this IConvertible first, IConvertible second) => TrinaryOr((int)first, (int)second);

    /// <summary>
    /// Calculates a logical or, expanded to the ternary system.
    /// Each trit in the resulting value has the maximum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) Or UNDUND (225) => UUNUND (332)
    /// </summary>
    public static int TrinaryOr(this int first, int second)
    {
        if (first > -MaxTrit16 && first < MaxTrit16 && second > -MaxTrit16 && second < MaxTrit16)
        {
            return Operations.OrTrits(first.ToTrits16(), second.ToTrits16()).From16Trits();
        }
        else
        {
            first = first.ModThreePow20();
            second = second.ModThreePow20();
            return Operations.OrTrits(first.ToTrits20(), second.ToTrits20()).From20Trits();
        }
    }

    /// <summary>
    /// Calculates a logical xor, expanded to the ternary system.
    /// Each trit in the resulting value has the sum of the two source trits.
    /// Example:
    /// UUNNDD (320) XOR UNDUND (225) => DUDUDU
    /// </summary>
    public static int TrinaryXor(this IConvertible first, IConvertible second) => TrinaryXor((int)first, (int)second);

    /// <summary>
    /// Calculates a logical xor, expanded to the ternary system.
    /// Each trit in the resulting value has the sum of the two source trits.
    /// Example:
    /// UUNNDD (320) XOR UNDUND (225) => DUDUDU
    /// </summary>
    public static int TrinaryXor(this int first, int second)
    {
        if (first > -MaxTrit16 && first < MaxTrit16 && second > -MaxTrit16 && second < MaxTrit16)
        {
            return Operations.XorTrits(first.ToTrits16(), second.ToTrits16()).From16Trits();
        }
        else
        {
            first = first.ModThreePow20();
            second = second.ModThreePow20();
            return Operations.XorTrits(first.ToTrits20(), second.ToTrits20()).From20Trits();
        }
    }

    public static int Flip(this int operand) => -operand.ModThreePow20();


    public static Trit Compare(this int operand1, int operand2)
    {
        if (operand1 == operand2) return Trit.Middle;
        return operand1 > operand2 ? Trit.Up : Trit.Down;
    }
}