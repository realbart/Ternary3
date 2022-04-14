namespace Ternary3;

internal static partial class TribbleOperations
{
    /// <summary>
    /// Very quickly converts an integer value to a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 001 = down, 010 is middle, 100 is up.
    /// This way, the actual value is limited to 20 trits, between -1743392200 and 1743392200.
    /// </summary>
    /// <param name="value">The value to convert. Make sure this is between -1743392200 and 1743392200</param>
    internal static long ToTritInt64(this int value)
    {
        if (value > -9842 && value < 9842) return ToTritInt32(value) + 329406144135036928;
        long target = 0;

        if (value > 581130733)
        {
            value -= 1162261467;
            target |= 576460752303423488;
        }
        else if (value < -581130733)
        {
            value += 1162261467;
            target |= 144115188075855872;
        }
        else
        {
            target |= 288230376151711744;
        }
        if (value > 193710244)
        {
            value -= 387420489;
            target |= 72057594037927936;
        }
        else if (value < -193710244)
        {
            value += 387420489;
            target |= 18014398509481984;
        }
        else
        {
            target |= 36028797018963968;
        }
        if (value > 64570081)
        {
            value -= 129140163;
            target |= 9007199254740992;
        }
        else if (value < -64570081)
        {
            value += 129140163;
            target |= 2251799813685248;
        }
        else
        {
            target |= 4503599627370496;
        }
        if (value > 21523360)
        {
            value -= 43046721;
            target |= 1125899906842624;
        }
        else if (value < -21523360)
        {
            value += 43046721;
            target |= 281474976710656;
        }
        else
        {
            target |= 562949953421312;
        }
        if (value > 7174453)
        {
            value -= 14348907;
            target |= 140737488355328;
        }
        else if (value < -7174453)
        {
            value += 14348907;
            target |= 35184372088832;
        }
        else
        {
            target |= 70368744177664;
        }
        if (value > 2391484)
        {
            value -= 4782969;
            target |= 17592186044416;
        }
        else if (value < -2391484)
        {
            value += 4782969;
            target |= 4398046511104;
        }
        else
        {
            target |= 8796093022208;
        }
        if (value > 797161)
        {
            value -= 1594323;
            target |= 2199023255552;
        }
        else if (value < -797161)
        {
            value += 1594323;
            target |= 549755813888;
        }
        else
        {
            target |= 1099511627776;
        }
        if (value > 265720)
        {
            value -= 531441;
            target |= 274877906944;
        }
        else if (value < -265720)
        {
            value += 531441;
            target |= 68719476736;
        }
        else
        {
            target |= 137438953472;
        }
        if (value > 88573)
        {
            value -= 177147;
            target |= 34359738368;
        }
        else if (value < -88573)
        {
            value += 177147;
            target |= 8589934592;
        }
        else
        {
            target |= 17179869184;
        }
        if (value > 29524)
        {
            value -= 59049;
            target |= 4294967296;
        }
        else if (value < -29524)
        {
            value += 59049;
            target |= 1073741824;
        }
        else
        {
            target |= 2147483648;
        }
        if (value > 9841)
        {
            value -= 19683;
            target |= 536870912;
        }
        else if (value < -9841)
        {
            value += 19683;
            target |= 134217728;
        }
        else
        {
            target |= 268435456;
        }
        if (value > 3280)
        {
            value -= 6561;
            target |= 67108864;
        }
        else if (value < -3280)
        {
            value += 6561;
            target |= 16777216;
        }
        else
        {
            target |= 33554432;
        }
        if (value > 1093)
        {
            value -= 2187;
            target |= 8388608;
        }
        else if (value < -1093)
        {
            value += 2187;
            target |= 2097152;
        }
        else
        {
            target |= 4194304;
        }
        if (value > 364)
        {
            value -= 729;
            target |= 1048576;
        }
        else if (value < -364)
        {
            value += 729;
            target |= 262144;
        }
        else
        {
            target |= 524288;
        }
        if (value > 121)
        {
            value -= 243;
            target |= 131072;
        }
        else if (value < -121)
        {
            value += 243;
            target |= 32768;
        }
        else
        {
            target |= 65536;
        }
        if (value > 40)
        {
            value -= 81;
            target |= 16384;
        }
        else if (value < -40)
        {
            value += 81;
            target |= 4096;
        }
        else
        {
            target |= 8192;
        }
        if (value > 13)
        {
            value -= 27;
            target |= 2048;
        }
        else if (value < -13)
        {
            value += 27;
            target |= 512;
        }
        else
        {
            target |= 1024;
        }
        if (value > 4)
        {
            value -= 9;
            target |= 256;
        }
        else if (value < -4)
        {
            value += 9;
            target |= 64;
        }
        else
        {
            target |= 128;
        }
        if (value > 1)
        {
            value -= 3;
            target |= 32;
        }
        else if (value < -1)
        {
            value += 3;
            target |= 8;
        }
        else
        {
            target |= 16;
        }
        if (value > 0)
        {
            target |= 4;
        }
        else if (value < 0)
        {
            target |= 1;
        }
        else
        {
            target |= 2;
        }

        return target;
    }
    /// <summary>
    /// Very quickly converts an integer value to a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 001 = down, 010 is middle, 100 is up.
    /// This way, the actual value is limited to 9 trits, between -9841 and 9841.
    /// </summary>
    /// <param name="value">The value to convert. Make sure this is between -9841 and 9841</param>
    internal static int ToTritInt32(this int value)
    {
        var target = 0;

        if (value > 3280)
        {
            value -= 6561;
            target |= 67108864;
        }
        else if (value < -3280)
        {
            value += 6561;
            target |= 16777216;
        }
        else
        {
            target |= 33554432;
        }
        if (value > 1093)
        {
            value -= 2187;
            target |= 8388608;
        }
        else if (value < -1093)
        {
            value += 2187;
            target |= 2097152;
        }
        else
        {
            target |= 4194304;
        }
        if (value > 364)
        {
            value -= 729;
            target |= 1048576;
        }
        else if (value < -364)
        {
            value += 729;
            target |= 262144;
        }
        else
        {
            target |= 524288;
        }
        if (value > 121)
        {
            value -= 243;
            target |= 131072;
        }
        else if (value < -121)
        {
            value += 243;
            target |= 32768;
        }
        else
        {
            target |= 65536;
        }
        if (value > 40)
        {
            value -= 81;
            target |= 16384;
        }
        else if (value < -40)
        {
            value += 81;
            target |= 4096;
        }
        else
        {
            target |= 8192;
        }
        if (value > 13)
        {
            value -= 27;
            target |= 2048;
        }
        else if (value < -13)
        {
            value += 27;
            target |= 512;
        }
        else
        {
            target |= 1024;
        }
        if (value > 4)
        {
            value -= 9;
            target |= 256;
        }
        else if (value < -4)
        {
            value += 9;
            target |= 64;
        }
        else
        {
            target |= 128;
        }
        if (value > 1)
        {
            value -= 3;
            target |= 32;
        }
        else if (value < -1)
        {
            value += 3;
            target |= 8;
        }
        else
        {
            target |= 16;
        }
        if (value > 0)
        {
            target |= 4;
        }
        else if (value < 0)
        {
            target |= 1;
        }
        else
        {
            target |= 2;
        }

        return target;
    }
}
