# Ternary3

Ternary3 is a library that makes performing balanced ternary operations on integer values.
It contains:

1. A **Trit** type representing the smalles unit in a ternary system, having a value of up (+1), middle (0) or down (-1)
The Trit value type has a number of methods mathimatical ternary operations (Ternary And, Ternary Or, Ternary Xor, Ternarry Not, Cycle and Anticycle)

2. Value types represemting Ternary numbers consisting of a number of trits: TernaryInt16, TernaryInt32, TernaryInt64. Trit operations can also be performed on these value types.

3. Extension methods on default framework value types to facilitate performing trit operations on these numbers as well. Note that performing trit operations on binary numbers involves converting them from binary to trinary and back. If you need to perform multiple ternary operations in sequence, consider using the Ternary value types.

====

## Ternary3.Trit

Ternary3.Trit is the smallest unit in a ternary system. It is implemented as am enum, with a signed byte as its underlying value. The reason for using an enum instead of a custom struct, is to facilitate the use of these trit values as constants.

The actual operations are implemented as extension methods.

Some examples code:

```
using Ternary3;
using static Ternary3.TritValues;
using static System.Console;

const value = up; // Ternary3.TritValues.up is a constant containing the value of Ternary3.Trit.Up

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
```

## Ternary3.BuiltInTypes

The Ternary3.BuiltInTypes namespace contains various methods and extension methods that can be used to perform ternary operations on built in integer types.

## Ternary integer types

The Ternary integer types use an in-memory trit representation that uses two bits per trit. This representation makes it possible to perform trit-operations extremely fast. In a true ternary system you'd expect types consisting of 3, 9, 27 or even 81 trits, but since the actual values get stored in integer values, these types would waste more memory than neccesary.

At this time, the available types are:

* Ternary3.TernaryInt16 with values from -21,523,360 to 21,523,360
* Ternary3.TernaryInt32 with values from -926,510,094,425,920 to 926,510,094,425,920
* Ternary3.TernaryInt64 with values from  -1,716,841,910,146,256,242,328,924,544,640 and 1,716,841,910,146,256,242,328,924,544,640

