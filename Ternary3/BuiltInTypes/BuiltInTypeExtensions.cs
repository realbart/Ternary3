namespace Ternary;

using Ternary.BuiltInTypes;
using Ternary.Formatting;
using Ternary.Internal;

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
    /// Shifts a number of trits to the right / towards the lower value
    /// </summary>
    /// <param name="operand">The target integer, viewed as maximal 20 trits</param>
    /// <param name="numberOfTrits">The number of trits to shift, negative shifts to the left</param>
    public static int TernaryShift(this int operand, int numberOfTrits)
        => numberOfTrits switch
        {
            0 => operand.ModThreePow20(),
            > 19 => 0,
            > 0 => operand / Math.ThreePow(numberOfTrits),
            -1 => operand.ModThreePow19() * ThreePow1,
            -2 => operand.ModThreePow18() * ThreePow2,
            -3 => operand.ModThreePow17() * ThreePow3,
            -4 => operand.ModThreePow16() * ThreePow4,
            -5 => operand.ModThreePow15() * ThreePow5,
            -6 => operand.ModThreePow14() * ThreePow6,
            -7 => operand.ModThreePow13() * ThreePow7,
            -8 => operand.ModThreePow12() * ThreePow8,
            -9 => operand.ModThreePow11() * ThreePow9,
            -10 => operand.ModThreePow10() * ThreePow10,
            -11 => operand.ModThreePow9() * ThreePow11,
            -12 => operand.ModThreePow8() * ThreePow12,
            -13 => operand.ModThreePow7() * ThreePow13,
            -14 => operand.ModThreePow6() * ThreePow14,
            -15 => operand.ModThreePow5() * ThreePow15,
            -16 => operand.ModThreePow4() * ThreePow16,
            -17 => operand.ModThreePow3() * ThreePow17,
            -18 => operand.ModThreePow2() * ThreePow18,
            -19 => operand.ModThreePow1() * ThreePow19,
            _ => 0
        };

    /// <summary>
    /// Shifts a number of trits to the right / towards the lower value
    /// </summary>
    /// <param name="operand">The target integer, viewed as maximal 20 trits</param>
    /// <param name="numberOfTrits">The number of trits to shift, negative shifts to the left</param>
    public static long TernaryShift(this long operand, int numberOfTrits)
        => numberOfTrits switch
        {
            0 => operand.ModThreePow40(),
            > 39 => 0,
            > 0 => operand / Math.ThreePow(numberOfTrits),
            -1 => operand.ModThreePow39() * ThreePow1,
            -2 => operand.ModThreePow38() * ThreePow2,
            -3 => operand.ModThreePow37() * ThreePow3,
            -4 => operand.ModThreePow36() * ThreePow4,
            -5 => operand.ModThreePow35() * ThreePow5,
            -6 => operand.ModThreePow34() * ThreePow6,
            -7 => operand.ModThreePow33() * ThreePow7,
            -8 => operand.ModThreePow32() * ThreePow8,
            -9 => operand.ModThreePow31() * ThreePow9,
            -10 => operand.ModThreePow30() * ThreePow10,
            -11 => operand.ModThreePow29() * ThreePow11,
            -12 => operand.ModThreePow28() * ThreePow12,
            -13 => operand.ModThreePow27() * ThreePow13,
            -14 => operand.ModThreePow26() * ThreePow14,
            -15 => operand.ModThreePow25() * ThreePow15,
            -16 => operand.ModThreePow24() * ThreePow16,
            -17 => operand.ModThreePow23() * ThreePow17,
            -18 => operand.ModThreePow22() * ThreePow18,
            -19 => operand.ModThreePow21() * ThreePow19,
            -20 => operand.ModThreePow20() * ThreePow20,
            -21 => operand.ModThreePow19() * ThreePow21,
            -22 => operand.ModThreePow18() * ThreePow22,
            -23 => operand.ModThreePow17() * ThreePow23,
            -24 => operand.ModThreePow16() * ThreePow24,
            -25 => operand.ModThreePow15() * ThreePow25,
            -26 => operand.ModThreePow14() * ThreePow26,
            -27 => operand.ModThreePow13() * ThreePow27,
            -28 => operand.ModThreePow12() * ThreePow28,
            -29 => operand.ModThreePow11() * ThreePow29,
            -30 => operand.ModThreePow10() * ThreePow30,
            -31 => operand.ModThreePow9() * ThreePow31,
            -32 => operand.ModThreePow8() * ThreePow32,
            -33 => operand.ModThreePow7() * ThreePow33,
            -34 => operand.ModThreePow6() * ThreePow34,
            -35 => operand.ModThreePow5() * ThreePow35,
            -36 => operand.ModThreePow4() * ThreePow36,
            -37 => operand.ModThreePow3() * ThreePow37,
            -38 => operand.ModThreePow2() * ThreePow38,
            -39 => operand.ModThreePow1() * ThreePow39,
            _ => 0
        };


    /// <summary>
    /// Compares two values and returns neutral if they are equal, up if the first is bigger, down if the second is bigger.
    /// </summary>
    public static Trit TernaryCompare(this int operand1, int operand2)
    {
        if (operand1 == operand2) return Trit.Middle;
        return operand1 > operand2 ? Trit.Up : Trit.Down;
    }

    public static string TernaryToString(this int target, int trits = 20) => Formatter.FormatTrits(target.ToTrits20(), trits);
    public static string TernaryToString(this int target, IBase3Format format, int trits = 20) => Formatter.FormatTrits(target.ToTrits20(), format, trits);
    public static string TernaryToString(this int target, IBase27Format format, int tribbles = 7) => Formatter.FormatTribbles(target.ToTrits20(), format, tribbles);
}