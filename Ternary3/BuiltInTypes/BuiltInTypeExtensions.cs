namespace Ternary3;

using Ternary3.BuiltInTypes;
using Ternary3.Formatting;
using Ternary3.Internal;

public static partial class BuiltInTypeExtensions
{

    /// <summary>
    /// Calculates a logical and, expanded to the ternary system.
    /// Each trit in the resulting value has the minimum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) And UNDUND (225) => UNDNDD
    /// </summary>
    public static int TernaryAnd(IConvertible first, IConvertible second) => TernaryAnd((int)first, (int)second);

    /// <summary>
    /// Calculates a logical and, expanded to the ternary system.
    /// Each trit in the resulting value has the minimum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) And UNDUND (225) => UNDNDD
    /// </summary>
    public static int TernaryAnd(this int first, int second)
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
    public static int TernaryOr(this IConvertible first, IConvertible second) => TernaryOr((int)first, (int)second);

    /// <summary>
    /// Calculates a logical or, expanded to the ternary system.
    /// Each trit in the resulting value has the maximum value of corresponding trits
    /// in the source value. Example:
    /// UUNNDD (320) Or UNDUND (225) => UUNUND (332)
    /// </summary>
    public static int TernaryOr(this int first, int second)
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
    public static int TernaryXor(this IConvertible first, IConvertible second) => TernaryXor((int)first, (int)second);

    /// <summary>
    /// Calculates a logical xor, expanded to the ternary system.
    /// Each trit in the resulting value has the sum of the two source trits.
    /// Example:
    /// UUNNDD (320) XOR UNDUND (225) => DUDUDU
    /// </summary>
    public static int TernaryXor(this int first, int second)
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

    /// <summary>
    /// Flips the trits
    /// Example:
    /// !UUNNDD (320) = DDNNUU (-320)
    /// </summary>
    /// <param name="operand"></param>
    /// <returns></returns>
    public static int TernaryNot(this int operand) => -operand.ModThreePow20();


    /// <summary>
    /// Compares two values and returns neutral if they are equal, up if the first is bigger, down if the second is bigger.
    /// </summary>
    public static Trit TernaryCompare(this int operand1, int operand2)
    {
        if (operand1 == operand2) return Trit.Middle;
        return operand1 > operand2 ? Trit.Up : Trit.Down;
    }

    public static string TernaryToString(this int target, int trits=20) => Formatter.FormatTrits(target.ToTrits20(), trits);
    public static string TernaryToString(this int target, ITernaryFormat format, int trits = 20) => Formatter.FormatTrits(target.ToTrits20(), format, trits);
    public static string TernaryToString(this int target, IHeptavintimalFormat format, int tribbles = 7) => Formatter.FormatTribbles(target.ToTrits20(), format, tribbles);
}