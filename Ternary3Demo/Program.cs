using Ternary3;
using Ternary3.Formatting;
using static System.Console;

namespace Ternary3Demo;

public class Ternary3Demo
{
    public static void Main()
    {
        Int32Demos();
        TritDemos();
    }

    private static void Int32Demos()
    {
        int thirteen = 11; // 9 + 3 - 1
        int thirtyseven = 37; // 27 + 9 + 1

        WriteLine($"{thirtyseven} t| {thirteen} = {thirtyseven.TernaryOr(thirteen)} (t| calculates the maximum of each trit)");
        WriteLine($"{thirtyseven.TernaryToString()} t| {thirteen.TernaryToString()} = {thirtyseven.TernaryOr(thirteen).TernaryToString()}");
        WriteLine($"{thirtyseven} t& {thirteen} = {thirtyseven.TernaryAnd(thirteen)} (t& calculates the minimum of each trit)");
        WriteLine($"{thirtyseven.TernaryToString(Base3Format.NumberFormat, 0)} t& {thirteen.TernaryToString(Base3Format.NumberFormat, 0)} = {thirtyseven.TernaryAnd(thirteen).TernaryToString(Base3Format.NumberFormat, 0)}");
        WriteLine($"{thirtyseven} t^ {thirteen} = {thirtyseven.TernaryXor(thirteen)} (t^ adds every trit, but up + up = down and down + down = up)");
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

        WriteLine($"{thirtyseven.TernaryToString(Base3Format.SignFormat, 6)} t^ {thirteen.TernaryToString(Base3Format.SignFormat, 6)} = {thirtyseven.TernaryXor(thirteen).TernaryToString(Base3Format.SignFormat, 6)}");
        WriteLine($"{thirtyseven.TernaryToString(Base27Format.AlphabetEuclidian, 3)} t^ {thirteen.TernaryToString(Base27Format.AlphabetTruncated, 3)} = {thirtyseven.TernaryXor(thirteen).TernaryToString(Base27Format.AlphabetTruncated, 3)}");
    }

    private static void TritDemos()
    {
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