using System.CodeDom.Compiler;

namespace Ternary.BuiltInTypes;

[GeneratedCode("t4","1.0,0,0")]
public static class BlancedModulo
{
    /// <summary>
    /// Performs a balanced modulo 3↑1 = 3
    /// Returns a value between -1 and 1
    /// </summary>
    public static int ModThreePow1(this int value)
    {
        if (-MaxTrit1 <= value && value <= MaxTrit1) return value;
        return (value = ModThreePow2(value)) switch
        {
            (< -MaxTrit1) => value + ThreePow1,
            (> MaxTrit1) => value - ThreePow1,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑1 = 3
    /// Returns a value between -1 and 1
    /// </summary>
    public static int ModThreePow1(this long value)
    {
        if (-MaxTrit1 <= value && value <= MaxTrit1) return (int)value;
        var v =  ModThreePow2(value);
        return (v) switch
        {
            (< -MaxTrit1) => v + ThreePow1,
            (> MaxTrit1) => v - ThreePow1,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑2 = 9
    /// Returns a value between -4 and 4
    /// </summary>
    public static int ModThreePow2(this int value)
    {
        if (-MaxTrit2 <= value && value <= MaxTrit2) return value;
        return (value = ModThreePow3(value)) switch
        {
            (< -MaxTrit2) => value + ThreePow2,
            (> MaxTrit2) => value - ThreePow2,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑2 = 9
    /// Returns a value between -4 and 4
    /// </summary>
    public static int ModThreePow2(this long value)
    {
        if (-MaxTrit2 <= value && value <= MaxTrit2) return (int)value;
        var v =  ModThreePow3(value);
        return (v) switch
        {
            (< -MaxTrit2) => v + ThreePow2,
            (> MaxTrit2) => v - ThreePow2,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑3 = 27
    /// Returns a value between -13 and 13
    /// </summary>
    public static int ModThreePow3(this int value)
    {
        if (-MaxTrit3 <= value && value <= MaxTrit3) return value;
        return (value = ModThreePow4(value)) switch
        {
            (< -MaxTrit3) => value + ThreePow3,
            (> MaxTrit3) => value - ThreePow3,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑3 = 27
    /// Returns a value between -13 and 13
    /// </summary>
    public static int ModThreePow3(this long value)
    {
        if (-MaxTrit3 <= value && value <= MaxTrit3) return (int)value;
        var v =  ModThreePow4(value);
        return (v) switch
        {
            (< -MaxTrit3) => v + ThreePow3,
            (> MaxTrit3) => v - ThreePow3,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑4 = 81
    /// Returns a value between -40 and 40
    /// </summary>
    public static int ModThreePow4(this int value)
    {
        if (-MaxTrit4 <= value && value <= MaxTrit4) return value;
        return (value = ModThreePow5(value)) switch
        {
            (< -MaxTrit4) => value + ThreePow4,
            (> MaxTrit4) => value - ThreePow4,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑4 = 81
    /// Returns a value between -40 and 40
    /// </summary>
    public static int ModThreePow4(this long value)
    {
        if (-MaxTrit4 <= value && value <= MaxTrit4) return (int)value;
        var v =  ModThreePow5(value);
        return (v) switch
        {
            (< -MaxTrit4) => v + ThreePow4,
            (> MaxTrit4) => v - ThreePow4,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑5 = 243
    /// Returns a value between -121 and 121
    /// </summary>
    public static int ModThreePow5(this int value)
    {
        if (-MaxTrit5 <= value && value <= MaxTrit5) return value;
        return (value = ModThreePow6(value)) switch
        {
            (< -MaxTrit5) => value + ThreePow5,
            (> MaxTrit5) => value - ThreePow5,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑5 = 243
    /// Returns a value between -121 and 121
    /// </summary>
    public static int ModThreePow5(this long value)
    {
        if (-MaxTrit5 <= value && value <= MaxTrit5) return (int)value;
        var v =  ModThreePow6(value);
        return (v) switch
        {
            (< -MaxTrit5) => v + ThreePow5,
            (> MaxTrit5) => v - ThreePow5,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑6 = 729
    /// Returns a value between -364 and 364
    /// </summary>
    public static int ModThreePow6(this int value)
    {
        if (-MaxTrit6 <= value && value <= MaxTrit6) return value;
        return (value = ModThreePow7(value)) switch
        {
            (< -MaxTrit6) => value + ThreePow6,
            (> MaxTrit6) => value - ThreePow6,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑6 = 729
    /// Returns a value between -364 and 364
    /// </summary>
    public static int ModThreePow6(this long value)
    {
        if (-MaxTrit6 <= value && value <= MaxTrit6) return (int)value;
        var v =  ModThreePow7(value);
        return (v) switch
        {
            (< -MaxTrit6) => v + ThreePow6,
            (> MaxTrit6) => v - ThreePow6,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑7 = 2187
    /// Returns a value between -1093 and 1093
    /// </summary>
    public static int ModThreePow7(this int value)
    {
        if (-MaxTrit7 <= value && value <= MaxTrit7) return value;
        return (value = ModThreePow8(value)) switch
        {
            (< -MaxTrit7) => value + ThreePow7,
            (> MaxTrit7) => value - ThreePow7,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑7 = 2187
    /// Returns a value between -1093 and 1093
    /// </summary>
    public static int ModThreePow7(this long value)
    {
        if (-MaxTrit7 <= value && value <= MaxTrit7) return (int)value;
        var v =  ModThreePow8(value);
        return (v) switch
        {
            (< -MaxTrit7) => v + ThreePow7,
            (> MaxTrit7) => v - ThreePow7,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑8 = 6561
    /// Returns a value between -3280 and 3280
    /// </summary>
    public static int ModThreePow8(this int value)
    {
        if (-MaxTrit8 <= value && value <= MaxTrit8) return value;
        return (value = ModThreePow9(value)) switch
        {
            (< -MaxTrit8) => value + ThreePow8,
            (> MaxTrit8) => value - ThreePow8,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑8 = 6561
    /// Returns a value between -3280 and 3280
    /// </summary>
    public static int ModThreePow8(this long value)
    {
        if (-MaxTrit8 <= value && value <= MaxTrit8) return (int)value;
        var v =  ModThreePow9(value);
        return (v) switch
        {
            (< -MaxTrit8) => v + ThreePow8,
            (> MaxTrit8) => v - ThreePow8,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑9 = 19683
    /// Returns a value between -9841 and 9841
    /// </summary>
    public static int ModThreePow9(this int value)
    {
        if (-MaxTrit9 <= value && value <= MaxTrit9) return value;
        return (value = ModThreePow10(value)) switch
        {
            (< -MaxTrit9) => value + ThreePow9,
            (> MaxTrit9) => value - ThreePow9,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑9 = 19683
    /// Returns a value between -9841 and 9841
    /// </summary>
    public static int ModThreePow9(this long value)
    {
        if (-MaxTrit9 <= value && value <= MaxTrit9) return (int)value;
        var v =  ModThreePow10(value);
        return (v) switch
        {
            (< -MaxTrit9) => v + ThreePow9,
            (> MaxTrit9) => v - ThreePow9,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑10 = 59049
    /// Returns a value between -29524 and 29524
    /// </summary>
    public static int ModThreePow10(this int value)
    {
        if (-MaxTrit10 <= value && value <= MaxTrit10) return value;
        return (value = ModThreePow11(value)) switch
        {
            (< -MaxTrit10) => value + ThreePow10,
            (> MaxTrit10) => value - ThreePow10,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑10 = 59049
    /// Returns a value between -29524 and 29524
    /// </summary>
    public static int ModThreePow10(this long value)
    {
        if (-MaxTrit10 <= value && value <= MaxTrit10) return (int)value;
        var v =  ModThreePow11(value);
        return (v) switch
        {
            (< -MaxTrit10) => v + ThreePow10,
            (> MaxTrit10) => v - ThreePow10,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑11 = 177147
    /// Returns a value between -88573 and 88573
    /// </summary>
    public static int ModThreePow11(this int value)
    {
        if (-MaxTrit11 <= value && value <= MaxTrit11) return value;
        return (value = ModThreePow12(value)) switch
        {
            (< -MaxTrit11) => value + ThreePow11,
            (> MaxTrit11) => value - ThreePow11,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑11 = 177147
    /// Returns a value between -88573 and 88573
    /// </summary>
    public static int ModThreePow11(this long value)
    {
        if (-MaxTrit11 <= value && value <= MaxTrit11) return (int)value;
        var v =  ModThreePow12(value);
        return (v) switch
        {
            (< -MaxTrit11) => v + ThreePow11,
            (> MaxTrit11) => v - ThreePow11,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑12 = 531441
    /// Returns a value between -265720 and 265720
    /// </summary>
    public static int ModThreePow12(this int value)
    {
        if (-MaxTrit12 <= value && value <= MaxTrit12) return value;
        return (value = ModThreePow13(value)) switch
        {
            (< -MaxTrit12) => value + ThreePow12,
            (> MaxTrit12) => value - ThreePow12,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑12 = 531441
    /// Returns a value between -265720 and 265720
    /// </summary>
    public static int ModThreePow12(this long value)
    {
        if (-MaxTrit12 <= value && value <= MaxTrit12) return (int)value;
        var v =  ModThreePow13(value);
        return (v) switch
        {
            (< -MaxTrit12) => v + ThreePow12,
            (> MaxTrit12) => v - ThreePow12,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑13 = 1594323
    /// Returns a value between -797161 and 797161
    /// </summary>
    public static int ModThreePow13(this int value)
    {
        if (-MaxTrit13 <= value && value <= MaxTrit13) return value;
        return (value = ModThreePow14(value)) switch
        {
            (< -MaxTrit13) => value + ThreePow13,
            (> MaxTrit13) => value - ThreePow13,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑13 = 1594323
    /// Returns a value between -797161 and 797161
    /// </summary>
    public static int ModThreePow13(this long value)
    {
        if (-MaxTrit13 <= value && value <= MaxTrit13) return (int)value;
        var v =  ModThreePow14(value);
        return (v) switch
        {
            (< -MaxTrit13) => v + ThreePow13,
            (> MaxTrit13) => v - ThreePow13,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑14 = 4782969
    /// Returns a value between -2391484 and 2391484
    /// </summary>
    public static int ModThreePow14(this int value)
    {
        if (-MaxTrit14 <= value && value <= MaxTrit14) return value;
        return (value = ModThreePow15(value)) switch
        {
            (< -MaxTrit14) => value + ThreePow14,
            (> MaxTrit14) => value - ThreePow14,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑14 = 4782969
    /// Returns a value between -2391484 and 2391484
    /// </summary>
    public static int ModThreePow14(this long value)
    {
        if (-MaxTrit14 <= value && value <= MaxTrit14) return (int)value;
        var v =  ModThreePow15(value);
        return (v) switch
        {
            (< -MaxTrit14) => v + ThreePow14,
            (> MaxTrit14) => v - ThreePow14,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑15 = 14348907
    /// Returns a value between -7174453 and 7174453
    /// </summary>
    public static int ModThreePow15(this int value)
    {
        if (-MaxTrit15 <= value && value <= MaxTrit15) return value;
        return (value = ModThreePow16(value)) switch
        {
            (< -MaxTrit15) => value + ThreePow15,
            (> MaxTrit15) => value - ThreePow15,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑15 = 14348907
    /// Returns a value between -7174453 and 7174453
    /// </summary>
    public static int ModThreePow15(this long value)
    {
        if (-MaxTrit15 <= value && value <= MaxTrit15) return (int)value;
        var v =  ModThreePow16(value);
        return (v) switch
        {
            (< -MaxTrit15) => v + ThreePow15,
            (> MaxTrit15) => v - ThreePow15,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑16 = 43046721
    /// Returns a value between -21523360 and 21523360
    /// </summary>
    public static int ModThreePow16(this int value)
    {
        if (-MaxTrit16 <= value && value <= MaxTrit16) return value;
        return (value = ModThreePow17(value)) switch
        {
            (< -MaxTrit16) => value + ThreePow16,
            (> MaxTrit16) => value - ThreePow16,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑16 = 43046721
    /// Returns a value between -21523360 and 21523360
    /// </summary>
    public static int ModThreePow16(this long value)
    {
        if (-MaxTrit16 <= value && value <= MaxTrit16) return (int)value;
        var v =  ModThreePow17(value);
        return (v) switch
        {
            (< -MaxTrit16) => v + ThreePow16,
            (> MaxTrit16) => v - ThreePow16,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑17 = 129140163
    /// Returns a value between -64570081 and 64570081
    /// </summary>
    public static int ModThreePow17(this int value)
    {
        if (-MaxTrit17 <= value && value <= MaxTrit17) return value;
        return (value = ModThreePow18(value)) switch
        {
            (< -MaxTrit17) => value + ThreePow17,
            (> MaxTrit17) => value - ThreePow17,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑17 = 129140163
    /// Returns a value between -64570081 and 64570081
    /// </summary>
    public static int ModThreePow17(this long value)
    {
        if (-MaxTrit17 <= value && value <= MaxTrit17) return (int)value;
        var v =  ModThreePow18(value);
        return (v) switch
        {
            (< -MaxTrit17) => v + ThreePow17,
            (> MaxTrit17) => v - ThreePow17,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑18 = 387420489
    /// Returns a value between -193710244 and 193710244
    /// </summary>
    public static int ModThreePow18(this int value)
    {
        if (-MaxTrit18 <= value && value <= MaxTrit18) return value;
        return (value = ModThreePow19(value)) switch
        {
            (< -MaxTrit18) => value + ThreePow18,
            (> MaxTrit18) => value - ThreePow18,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑18 = 387420489
    /// Returns a value between -193710244 and 193710244
    /// </summary>
    public static int ModThreePow18(this long value)
    {
        if (-MaxTrit18 <= value && value <= MaxTrit18) return (int)value;
        var v =  ModThreePow19(value);
        return (v) switch
        {
            (< -MaxTrit18) => v + ThreePow18,
            (> MaxTrit18) => v - ThreePow18,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑19 = 1162261467
    /// Returns a value between -581130733 and 581130733
    /// </summary>
    public static int ModThreePow19(this int value)
    {
        if (-MaxTrit19 <= value && value <= MaxTrit19) return value;
        return (value = ModThreePow20(value)) switch
        {
            (< -MaxTrit19) => value + ThreePow19,
            (> MaxTrit19) => value - ThreePow19,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑19 = 1162261467
    /// Returns a value between -581130733 and 581130733
    /// </summary>
    public static int ModThreePow19(this long value)
    {
        if (-MaxTrit19 <= value && value <= MaxTrit19) return (int)value;
        var v =  ModThreePow20(value);
        return (v) switch
        {
            (< -MaxTrit19) => v + ThreePow19,
            (> MaxTrit19) => v - ThreePow19,
            _ => v
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑20 = 3486784401
    /// Returns a value between -1743392200 and 1743392200
    /// </summary>
    public static int ModThreePow20(this int value)
    {
        const int Overflow =  (int)(uint.MaxValue - ThreePow20 + 1);
        return value switch
        {
            (< -MaxTrit20) => value - Overflow, 
            (> MaxTrit20) => value + Overflow,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑20 = 3486784401
    /// Returns a value between -1743392200 and 1743392200
    /// </summary>
    public static int ModThreePow20(this long value)
    {
        return (value = ModThreePow21(value)) switch
        {
            (< -MaxTrit20) => (int)(value - ThreePow20),
            (> MaxTrit20) => (int)(value + ThreePow20),
            _ => (int)value
        };
    }


    /// <summary>
    /// Performs a balanced modulo 3↑21 = 10460353203
    /// Returns a value between -5230176601 and 5230176601
    /// </summary>
    public static long ModThreePow21(this long value)
    {
        if (-MaxTrit21 <= value && value <= MaxTrit21) return value;
        return (value = ModThreePow22(value)) switch
        {
            (< -MaxTrit21) => value + ThreePow21,
            (> MaxTrit21) => value - ThreePow21,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑22 = 31381059609
    /// Returns a value between -15690529804 and 15690529804
    /// </summary>
    public static long ModThreePow22(this long value)
    {
        if (-MaxTrit22 <= value && value <= MaxTrit22) return value;
        return (value = ModThreePow23(value)) switch
        {
            (< -MaxTrit22) => value + ThreePow22,
            (> MaxTrit22) => value - ThreePow22,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑23 = 94143178827
    /// Returns a value between -47071589413 and 47071589413
    /// </summary>
    public static long ModThreePow23(this long value)
    {
        if (-MaxTrit23 <= value && value <= MaxTrit23) return value;
        return (value = ModThreePow24(value)) switch
        {
            (< -MaxTrit23) => value + ThreePow23,
            (> MaxTrit23) => value - ThreePow23,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑24 = 282429536481
    /// Returns a value between -141214768240 and 141214768240
    /// </summary>
    public static long ModThreePow24(this long value)
    {
        if (-MaxTrit24 <= value && value <= MaxTrit24) return value;
        return (value = ModThreePow25(value)) switch
        {
            (< -MaxTrit24) => value + ThreePow24,
            (> MaxTrit24) => value - ThreePow24,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑25 = 847288609443
    /// Returns a value between -423644304721 and 423644304721
    /// </summary>
    public static long ModThreePow25(this long value)
    {
        if (-MaxTrit25 <= value && value <= MaxTrit25) return value;
        return (value = ModThreePow26(value)) switch
        {
            (< -MaxTrit25) => value + ThreePow25,
            (> MaxTrit25) => value - ThreePow25,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑26 = 2541865828329
    /// Returns a value between -1270932914164 and 1270932914164
    /// </summary>
    public static long ModThreePow26(this long value)
    {
        if (-MaxTrit26 <= value && value <= MaxTrit26) return value;
        return (value = ModThreePow27(value)) switch
        {
            (< -MaxTrit26) => value + ThreePow26,
            (> MaxTrit26) => value - ThreePow26,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑27 = 7625597484987
    /// Returns a value between -3812798742493 and 3812798742493
    /// </summary>
    public static long ModThreePow27(this long value)
    {
        if (-MaxTrit27 <= value && value <= MaxTrit27) return value;
        return (value = ModThreePow28(value)) switch
        {
            (< -MaxTrit27) => value + ThreePow27,
            (> MaxTrit27) => value - ThreePow27,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑28 = 22876792454961
    /// Returns a value between -11438396227480 and 11438396227480
    /// </summary>
    public static long ModThreePow28(this long value)
    {
        if (-MaxTrit28 <= value && value <= MaxTrit28) return value;
        return (value = ModThreePow29(value)) switch
        {
            (< -MaxTrit28) => value + ThreePow28,
            (> MaxTrit28) => value - ThreePow28,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑29 = 68630377364883
    /// Returns a value between -34315188682441 and 34315188682441
    /// </summary>
    public static long ModThreePow29(this long value)
    {
        if (-MaxTrit29 <= value && value <= MaxTrit29) return value;
        return (value = ModThreePow30(value)) switch
        {
            (< -MaxTrit29) => value + ThreePow29,
            (> MaxTrit29) => value - ThreePow29,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑30 = 205891132094649
    /// Returns a value between -102945566047324 and 102945566047324
    /// </summary>
    public static long ModThreePow30(this long value)
    {
        if (-MaxTrit30 <= value && value <= MaxTrit30) return value;
        return (value = ModThreePow31(value)) switch
        {
            (< -MaxTrit30) => value + ThreePow30,
            (> MaxTrit30) => value - ThreePow30,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑31 = 617673396283947
    /// Returns a value between -308836698141973 and 308836698141973
    /// </summary>
    public static long ModThreePow31(this long value)
    {
        if (-MaxTrit31 <= value && value <= MaxTrit31) return value;
        return (value = ModThreePow32(value)) switch
        {
            (< -MaxTrit31) => value + ThreePow31,
            (> MaxTrit31) => value - ThreePow31,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑32 = 1.85302018885184E+15
    /// Returns a value between -926510094425920 and 926510094425920
    /// </summary>
    public static long ModThreePow32(this long value)
    {
        if (-MaxTrit32 <= value && value <= MaxTrit32) return value;
        return (value = ModThreePow33(value)) switch
        {
            (< -MaxTrit32) => value + ThreePow32,
            (> MaxTrit32) => value - ThreePow32,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑33 = 5.55906056655552E+15
    /// Returns a value between -2.77953028327776E+15 and 2.77953028327776E+15
    /// </summary>
    public static long ModThreePow33(this long value)
    {
        if (-MaxTrit33 <= value && value <= MaxTrit33) return value;
        return (value = ModThreePow34(value)) switch
        {
            (< -MaxTrit33) => value + ThreePow33,
            (> MaxTrit33) => value - ThreePow33,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑34 = 1.66771816996666E+16
    /// Returns a value between -8.33859084983328E+15 and 8.33859084983328E+15
    /// </summary>
    public static long ModThreePow34(this long value)
    {
        if (-MaxTrit34 <= value && value <= MaxTrit34) return value;
        return (value = ModThreePow35(value)) switch
        {
            (< -MaxTrit34) => value + ThreePow34,
            (> MaxTrit34) => value - ThreePow34,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑35 = 5.00315450989997E+16
    /// Returns a value between -2.50157725494999E+16 and 2.50157725494999E+16
    /// </summary>
    public static long ModThreePow35(this long value)
    {
        if (-MaxTrit35 <= value && value <= MaxTrit35) return value;
        return (value = ModThreePow36(value)) switch
        {
            (< -MaxTrit35) => value + ThreePow35,
            (> MaxTrit35) => value - ThreePow35,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑36 = 1.50094635296999E+17
    /// Returns a value between -7.50473176484996E+16 and 7.50473176484996E+16
    /// </summary>
    public static long ModThreePow36(this long value)
    {
        if (-MaxTrit36 <= value && value <= MaxTrit36) return value;
        return (value = ModThreePow37(value)) switch
        {
            (< -MaxTrit36) => value + ThreePow36,
            (> MaxTrit36) => value - ThreePow36,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑37 = 4.50283905890997E+17
    /// Returns a value between -2.25141952945499E+17 and 2.25141952945499E+17
    /// </summary>
    public static long ModThreePow37(this long value)
    {
        if (-MaxTrit37 <= value && value <= MaxTrit37) return value;
        return (value = ModThreePow38(value)) switch
        {
            (< -MaxTrit37) => value + ThreePow37,
            (> MaxTrit37) => value - ThreePow37,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑38 = 1.35085171767299E+18
    /// Returns a value between -6.75425858836496E+17 and 6.75425858836496E+17
    /// </summary>
    public static long ModThreePow38(this long value)
    {
        if (-MaxTrit38 <= value && value <= MaxTrit38) return value;
        return (value = ModThreePow39(value)) switch
        {
            (< -MaxTrit38) => value + ThreePow38,
            (> MaxTrit38) => value - ThreePow38,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑39 = 4.05255515301898E+18
    /// Returns a value between -2.02627757650949E+18 and 2.02627757650949E+18
    /// </summary>
    public static long ModThreePow39(this long value)
    {
        if (-MaxTrit39 <= value && value <= MaxTrit39) return value;
        return (value = ModThreePow40(value)) switch
        {
            (< -MaxTrit39) => value + ThreePow39,
            (> MaxTrit39) => value - ThreePow39,
            _ => value
        };
    }

    /// <summary>
    /// Performs a balanced modulo 3↑40 = 1.21576654590569E+19
    /// Returns a value between -6.07883272952846E+18 and 6.07883272952846E+18
    /// </summary>
    public static long ModThreePow40(this long value)
    {
        const long Overflow = (long)(ulong.MaxValue - ThreePow40);
        if (value > MaxTrit40) value += Overflow;
        else if (value < -MaxTrit40) value -= Overflow;
        return value;
    }
}