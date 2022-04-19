namespace Ternary3.TritInt;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Trit16
{
    private uint trits;

    private Trit16(uint trits)
    {
        this.trits = trits;
    }

    public static explicit operator Trit16(int value) => new Trit16(value.ToTritUInt32());

    public static implicit operator int(Trit16 value) => value.trits.FromTritUInt32();
}
