namespace TernaryTests.TernaryInt;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TernaryInt3Test
{
    [Fact]
    public void TernaryInt3_TryConvert_ShouldReturnTrueForValidValues()
    {
        var validValues = new byte[] {
            0b00000000,
            0b00000001,
            0b00000010,
            0b00000100,
            0b00000101,
            0b00000110,
            0b00001000,
            0b00001001,
            0b00001010,
            0b00010000,
            0b00010001,
            0b00010010,
            0b00010100,
            0b00010101,
            0b00010110,
            0b00011000,
            0b00011001,
            0b00011010,
            0b00100000,
            0b00100001,
            0b00100010,
            0b00100100,
            0b00100101,
            0b00100110,
            0b00101000,
            0b00101001,
            0b00101010
        };

        // iterating through all possible values requires this do..while construction. for won't work.
        byte i = 0;
        do
        {
            bool success = TernaryInt3.TryConvert(i, out var _);
            validValues.Contains(i).Should().Be(success, $"{i} returned{success}");
        } while (i++ > 0);
    }
}