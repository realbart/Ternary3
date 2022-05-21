using Ternary;
using Ternary.Formatting;
using static System.Console;

namespace Ternary3Demo;

public static class Ternary3Demo
{
    public static void Main()
    {
        //Int32Demos();
        //TritDemos();
        TernaryInt16Demos();
        //TernaryInt32Demos();
    }

    private static void TernaryInt16Demos()
    {
        WriteLine(nameof(TernaryInt16Demos));
        var eleven = (TernaryInt16)11;
        var thirtyseven = TernaryInt16.Parse("uumu");
        WriteLine(thirtyseven);
        WriteLine($"{thirtyseven} t| {eleven} = {thirtyseven | eleven}");
        WriteLine($"{thirtyseven} t& {eleven} = {thirtyseven & eleven}");
        WriteLine($"{thirtyseven} t& {eleven} = {thirtyseven & 11}");
        WriteLine($"{37} t& {eleven} = {37 & eleven}");
        WriteLine($"{thirtyseven} t^ {eleven} = {thirtyseven ^ eleven}");
        WriteLine($"{thirtyseven} << 2 = {thirtyseven << 2}");
        WriteLine($"{thirtyseven} >> 2 = {thirtyseven >> 2}");
        WriteLine($"t!{thirtyseven} {!thirtyseven}");
        WriteLine($"t-{thirtyseven} {-thirtyseven}");
        WriteLine($"{thirtyseven} + {eleven} = {thirtyseven + eleven}");
        WriteLine($"{thirtyseven} - {eleven} = {thirtyseven - eleven}");
    }

    private static void TernaryInt32Demos()
    {
        WriteLine(nameof(TernaryInt32Demos));
        var eleven = (TernaryInt32)11;
        var thirtyseven = TernaryInt32.Parse("uumu");
        WriteLine(thirtyseven);
        WriteLine($"{thirtyseven} t| {eleven} = {thirtyseven | eleven}");
        WriteLine($"{thirtyseven} t& {eleven} = {thirtyseven & eleven}");
        WriteLine($"{thirtyseven} t& {eleven} = {thirtyseven & 11}");
        WriteLine($"{thirtyseven} t& {eleven} = {37 & eleven}");
        WriteLine($"{thirtyseven} t^ {eleven} = {thirtyseven ^ eleven}");
        WriteLine($"{thirtyseven} << 2 = {thirtyseven << 2}");
        WriteLine($"{thirtyseven} >> 2 = {thirtyseven >> 2}");
        WriteLine($"t!{thirtyseven} {!thirtyseven}");
        WriteLine($"t-{thirtyseven} {-thirtyseven}");
    }

    private static void Int32Demos()
    {
        WriteLine(nameof(Int32Demos));

        int eleven = 11; // 9 + 3 - 1
        int thirtyseven = 37; // 27 + 9 + 1

        WriteLine($"{thirtyseven} t| {eleven} = {thirtyseven.TernaryOr(eleven)} (t| calculates the maximum of each trit)");
        WriteLine($"{thirtyseven.TernaryToString()} t| {eleven.TernaryToString()} = {thirtyseven.TernaryOr(eleven).TernaryToString()}");
        WriteLine($"{thirtyseven} t& {eleven} = {thirtyseven.TernaryAnd(eleven)} (t& calculates the minimum of each trit)");
        WriteLine($"{thirtyseven.TernaryToString(Base3Format.NumberFormat, 0)} t& {eleven.TernaryToString(Base3Format.NumberFormat, 0)} = {thirtyseven.TernaryAnd(eleven).TernaryToString(Base3Format.NumberFormat, 0)}");
        WriteLine($"{thirtyseven} t^ {eleven} = {thirtyseven.TernaryXor(eleven)} (t^ adds every trit, but up + up = down and down + down = up)");
        WriteLine($"{thirtyseven.TernaryToString()} t^ {eleven.TernaryToString()} = {thirtyseven.TernaryXor(eleven).TernaryToString()} (t^ adds every trit, but up + up = down and down + down = up)");
        WriteLine($"{thirtyseven} t<< {13} = {thirtyseven.TernaryShift(-13)} (t<< shifts trits to the left, so mmmmmd << 2 becomes mmmdmm)");
        WriteLine($"{thirtyseven.TernaryToString()} t<< {13} = {thirtyseven.TernaryShift(-13).TernaryToString()}");
        WriteLine($"{thirtyseven} t>> {2} = {thirtyseven.TernaryShift(2)} (t<< shifts trits to the right, so mmmdud >> 1 becomes mmmmdu)");
        WriteLine($"{thirtyseven.TernaryToString()} t>> {2} = {thirtyseven.TernaryShift(2).TernaryToString()}");
        var format = Base27Format.Create("AaBbCcDdEeFfGgHhIiJjKkLlMm?");
        for (var i = -15; i <= 15; i++)
        {

            WriteLine($"{i.TernaryToString(6)} = "
                + $"{i.TernaryToString(Base27Format.AlphabetEuclidian, 0)} "
                + $"{i.TernaryToString(Base27Format.AlphabetShifted, 0)} "
                + $"{i.TernaryToString(Base27Format.AlphabetTruncated, 0)} "
                + $"{i.TernaryToString(Base27Format.AlphanumericEuclidian, 0)} "
                + $"{i.TernaryToString(Base27Format.AlphanumericShifted, 0)} "
                + $"{i.TernaryToString(Base27Format.AlphanumericTruncated, 0)} "
                + $"{i.TernaryToString(format, 0)} ({i})"
                );
        }

        WriteLine($"{thirtyseven.TernaryToString(Base3Format.SignFormat, 6)} t^ {eleven.TernaryToString(Base3Format.SignFormat, 6)} = {thirtyseven.TernaryXor(eleven).TernaryToString(Base3Format.SignFormat, 6)}");
        WriteLine($"{thirtyseven.TernaryToString(Base27Format.AlphabetEuclidian, 3)} t^ {eleven.TernaryToString(Base27Format.AlphabetTruncated, 3)} = {thirtyseven.TernaryXor(eleven).TernaryToString(Base27Format.AlphabetTruncated, 3)}");
    }

    private static void TritDemos()
    {
        WriteLine(nameof(TritDemos));

        WriteLine(up.Or(down)); // writes 'Up', because a ternary or calculates the maximum value of the two trits
        WriteLine(up.And(down)); // writes 'Down', because a ternary and calculates the minimum value of the two trits
        WriteLine(up.Xor(down)); // writes 'Middle', because a ternary xor calculates the sum of the two trits
        WriteLine(middle.Cycle()); // writes 'Up'
        WriteLine(middle.AntiCycle()); // writes 'Down'
        WriteLine(down.AntiCycle()); // writes 'Up'
        WriteLine(down.Compare(down)); // writes 'Middle': the values are equal
        WriteLine(up.Compare(down)); // writes 'Up': the first value is bigger
        WriteLine(middle.Compare(up)); // writes 'Down': the first value is smaller

        var tritValue = TritHelper.Parse("Middle");
        WriteLine(tritValue); // writes 'Middle'
        WriteLine((int)tritValue); // writes '0'
        WriteLine(tritValue.ToNullableBoolean()); // writes nothing; down, middle and up translate to false, null, true.
        WriteLine(false.ToTrit()); // writes 'Down'

        WriteLine("Enter a valid Trit value (Down, Middle or Up)");
        var myTrit = ReadLine();
        if (TritHelper.TryParse(myTrit, out var tVal))
        {
            WriteLine($"This value is sometimes written as {tVal.Switch("-", "0", "+")}");
        }
    }
}