namespace Ternary3.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static partial class Conversion
{
    internal static int From2Trits(this uint target)
        => target switch
        {
            0 => 0,
            2 => 1,
            9 => 2,
            8 => 3,
            10 => 4,
            1 => -1,
            6 => -2,
            4 => -3,
            _ => -4
        };

    internal static int From4Trits(this uint target)
        => target switch
        {
            0 => 0,
            <= 0xF => From2Trits(target),
            _ => ThreePow2 * From2Trits(target >> 0x4) + From2Trits(target & 0xF)
        };

    internal static int From8Trits(this uint target)
        => target switch
        {
            0 => 0,
            <= 0xFF => From4Trits(target),
            _ => ThreePow4 * From4Trits(target >> 0x8) + From4Trits(target & 0xFF)
        };

    internal static int From16Trits(this uint target)
        => target switch
        {
            0 => 0,
            <= 0xFFFF => From8Trits(target),
            _ => ThreePow8 * From8Trits(target >> 0x10) + From8Trits(target & 0xFFFF)
        };

    internal static long From32Trits(this ulong target)
        => target switch
        {
            0 => 0,
            <= 0xFFFFFFFF => From16Trits((uint)target),
            _ => ThreePow16 * (long)From16Trits((uint)(target >> 0x20)) + From16Trits((uint)target & 0xFFFFFFFF)
        };

    internal static int From20Trits(this ulong target)
        => target switch
        {
            0 => 0,
            <= 0xFFFFFFFF => From16Trits((uint)target),
            _ => ThreePow16 * From16Trits((uint)(target >> 0x20) & 0xF) + From16Trits((uint)target & 0xFFFFFFFF)
        };

    internal static long From40Trits(this (ulong high, ulong low) target)
        => target.high == 0
            ? From32Trits(target.low)
            : ThreePow32 * From32Trits(target.high & 0xFF) + From32Trits(target.low);
}