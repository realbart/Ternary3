namespace Ternary3;

internal static partial class TribbleOperations
{
    /// <summary>
    /// Very quickly converts an integer value to a long form that makes performing trit operations easy.
    /// The longer form uses two bits form one trit: 01 = down, 00 is middle, 10 is up.
    /// This way, the actual value is limited to 20 trits, between -1743392200 and 1743392200.
    /// </summary>
    /// <param name="value">The value to convert. Make sure this is between -1743392200 and 1743392200</param>
    internal static long ToTritInt64(this int value)
    {
        long target = 0;

        if (value > 581130733)
        {
            value -= 1162261467;
            target |= 549755813888;
        }
        else if (value < -581130733)
        {
            value += 1162261467;
            target |= 274877906944;
        }
        if (value > 193710244)
        {
            value -= 387420489;
            target |= 137438953472;
        }
        else if (value < -193710244)
        {
            value += 387420489;
            target |= 68719476736;
        }
        if (value > 64570081)
        {
            value -= 129140163;
            target |= 34359738368;
        }
        else if (value < -64570081)
        {
            value += 129140163;
            target |= 17179869184;
        }
        if (value > 21523360)
        {
            value -= 43046721;
            target |= 8589934592;
        }
        else if (value < -21523360)
        {
            value += 43046721;
            target |= 4294967296;
        }
        if (value > 7174453)
        {
            value -= 14348907;
            target |= 2147483648;
        }
        else if (value < -7174453)
        {
            value += 14348907;
            target |= 1073741824;
        }
        if (value > 2391484)
        {
            value -= 4782969;
            target |= 536870912;
        }
        else if (value < -2391484)
        {
            value += 4782969;
            target |= 268435456;
        }
        if (value > 797161)
        {
            value -= 1594323;
            target |= 134217728;
        }
        else if (value < -797161)
        {
            value += 1594323;
            target |= 67108864;
        }
        if (value > 265720)
        {
            value -= 531441;
            target |= 33554432;
        }
        else if (value < -265720)
        {
            value += 531441;
            target |= 16777216;
        }
        if (value > 88573)
        {
            value -= 177147;
            target |= 8388608;
        }
        else if (value < -88573)
        {
            value += 177147;
            target |= 4194304;
        }
        if (value > 29524)
        {
            value -= 59049;
            target |= 2097152;
        }
        else if (value < -29524)
        {
            value += 59049;
            target |= 1048576;
        }
        if (value > 9841)
        {
            value -= 19683;
            target |= 524288;
        }
        else if (value < -9841)
        {
            value += 19683;
            target |= 262144;
        }
        if (value > 3280)
        {
            value -= 6561;
            target |= 131072;
        }
        else if (value < -3280)
        {
            value += 6561;
            target |= 65536;
        }
        if (value > 1093)
        {
            value -= 2187;
            target |= 32768;
        }
        else if (value < -1093)
        {
            value += 2187;
            target |= 16384;
        }
        if (value > 364)
        {
            value -= 729;
            target |= 8192;
        }
        else if (value < -364)
        {
            value += 729;
            target |= 4096;
        }
        if (value > 121)
        {
            value -= 243;
            target |= 2048;
        }
        else if (value < -121)
        {
            value += 243;
            target |= 1024;
        }
        if (value > 40)
        {
            value -= 81;
            target |= 512;
        }
        else if (value < -40)
        {
            value += 81;
            target |= 256;
        }
        if (value > 13)
        {
            value -= 27;
            target |= 128;
        }
        else if (value < -13)
        {
            value += 27;
            target |= 64;
        }
        if (value > 4)
        {
            value -= 9;
            target |= 32;
        }
        else if (value < -4)
        {
            value += 9;
            target |= 16;
        }
        if (value > 1)
        {
            value -= 3;
            target |= 8;
        }
        else if (value < -1)
        {
            value += 3;
            target |= 4;
        }
        if (value > 0)
        {
            target |= 2;
        }
        else if (value < 0)
        {
            target |= 1;
        }

        return target;
    }
    /// <summary>
    /// Very quickly converts an integer value to a long form that makes performing trit operations easy.
    /// The longer form uses three bits form one trit: 01 = down, 00 is middle, 10 is up.
    /// This way, the actual value is limited to 16 trits, between -5230176601 and 5230176601.
    /// </summary>
    /// <param name="value">The value to convert. Make sure this is between -5230176601 and 5230176601</param>
    internal static int ToTritInt32(this int value)
    {
        var target = 0;

        if (value > 1743392200)
        {
            value = value + 808182895;
        }
        else if (value < -1743392200)
        {
            value = value - 808182895;
        }
        if (value > 581130733)
        {
            value = value + 985222182 + int.MaxValue;
        }
        else if (value < -581130733)
        {
            value = value - 985222182 - int.MaxValue;
        }
        if (value > 193710244)
        {
            value = value + 1760063160 + int.MaxValue;
        }
        else if (value < -193710244)
        {
            value = value - 1760063160 - int.MaxValue;
        }
        if (value > 64570081)
        {
            value = value + 2018343486 + int.MaxValue;
        }
        else if (value < -64570081)
        {
            value = value - 2018343486 - int.MaxValue;
        }
        if (value > 21523360)
        {
            value = value + 2104436928 + int.MaxValue;
        }
        else if (value < -21523360)
        {
            value = value - 2104436928 - int.MaxValue;
        }
        if (value > 7174453)
        {
            value -= 14348907;
            target |= -2147483648;
        }
        else if (value < -7174453)
        {
            value += 14348907;
            target |= 1073741824;
        }
        if (value > 2391484)
        {
            value -= 4782969;
            target |= 536870912;
        }
        else if (value < -2391484)
        {
            value += 4782969;
            target |= 268435456;
        }
        if (value > 797161)
        {
            value -= 1594323;
            target |= 134217728;
        }
        else if (value < -797161)
        {
            value += 1594323;
            target |= 67108864;
        }
        if (value > 265720)
        {
            value -= 531441;
            target |= 33554432;
        }
        else if (value < -265720)
        {
            value += 531441;
            target |= 16777216;
        }
        if (value > 88573)
        {
            value -= 177147;
            target |= 8388608;
        }
        else if (value < -88573)
        {
            value += 177147;
            target |= 4194304;
        }
        if (value > 29524)
        {
            value -= 59049;
            target |= 2097152;
        }
        else if (value < -29524)
        {
            value += 59049;
            target |= 1048576;
        }
        if (value > 9841)
        {
            value -= 19683;
            target |= 524288;
        }
        else if (value < -9841)
        {
            value += 19683;
            target |= 262144;
        }
        if (value > 3280)
        {
            value -= 6561;
            target |= 131072;
        }
        else if (value < -3280)
        {
            value += 6561;
            target |= 65536;
        }
        if (value > 1093)
        {
            value -= 2187;
            target |= 32768;
        }
        else if (value < -1093)
        {
            value += 2187;
            target |= 16384;
        }
        if (value > 364)
        {
            value -= 729;
            target |= 8192;
        }
        else if (value < -364)
        {
            value += 729;
            target |= 4096;
        }
        if (value > 121)
        {
            value -= 243;
            target |= 2048;
        }
        else if (value < -121)
        {
            value += 243;
            target |= 1024;
        }
        if (value > 40)
        {
            value -= 81;
            target |= 512;
        }
        else if (value < -40)
        {
            value += 81;
            target |= 256;
        }
        if (value > 13)
        {
            value -= 27;
            target |= 128;
        }
        else if (value < -13)
        {
            value += 27;
            target |= 64;
        }
        if (value > 4)
        {
            value -= 9;
            target |= 32;
        }
        else if (value < -4)
        {
            value += 9;
            target |= 16;
        }
        if (value > 1)
        {
            value -= 3;
            target |= 8;
        }
        else if (value < -1)
        {
            value += 3;
            target |= 4;
        }
        if (value > 0)
        {
            target |= 2;
        }
        else if (value < 0)
        {
            target |= 1;
        }
        return target;
    }
}
