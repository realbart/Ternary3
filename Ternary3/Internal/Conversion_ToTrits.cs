﻿using Ternary.BuiltInTypes;

namespace Ternary.Internal;

internal static partial class Conversion
{
    internal static byte ToTrits1UInt8(this int value) 
        => (byte)SetTrit1(value.ModThreePow1(), 0u);

    internal static byte ToTrits2UInt8(this int value) 
        => (byte)SetTrit2(value.ModThreePow2(), 0u);

    internal static byte ToTrits3UInt8(this int value) 
        => (byte)SetTrit3(value.ModThreePow3(), 0u);

    internal static byte ToTrits4UInt8(this int value) 
        => (byte)SetTrit4(value.ModThreePow4(), 0u);

    internal static ushort ToTrits1UInt16(this int value) 
        => (ushort)SetTrit1(value.ModThreePow1(), 0u);

    internal static ushort ToTrits2UInt16(this int value) 
        => (ushort)SetTrit2(value.ModThreePow2(), 0u);

    internal static ushort ToTrits3UInt16(this int value) 
        => (ushort)SetTrit3(value.ModThreePow3(), 0u);

    internal static ushort ToTrits4UInt16(this int value) 
        => (ushort)SetTrit4(value.ModThreePow4(), 0u);

    internal static ushort ToTrits5UInt16(this int value) 
        => (ushort)SetTrit5(value.ModThreePow5(), 0u);

    internal static ushort ToTrits6UInt16(this int value) 
        => (ushort)SetTrit6(value.ModThreePow6(), 0u);

    internal static ushort ToTrits7UInt16(this int value) 
        => (ushort)SetTrit7(value.ModThreePow7(), 0u);

    internal static ushort ToTrits8UInt16(this int value) 
        => (ushort)SetTrit8(value.ModThreePow8(), 0u);

    internal static uint ToTrits1(this int value) 
        => SetTrit1(value.ModThreePow1(), 0u);

    internal static uint ToTrits2(this int value) 
        => SetTrit2(value.ModThreePow2(), 0u);

    internal static uint ToTrits3(this int value) 
        => SetTrit3(value.ModThreePow3(), 0u);

    internal static uint ToTrits4(this int value) 
        => SetTrit4(value.ModThreePow4(), 0u);

    internal static uint ToTrits5(this int value) 
        => SetTrit5(value.ModThreePow5(), 0u);

    internal static uint ToTrits6(this int value) 
        => SetTrit6(value.ModThreePow6(), 0u);

    internal static uint ToTrits7(this int value) 
        => SetTrit7(value.ModThreePow7(), 0u);

    internal static uint ToTrits8(this int value) 
        => SetTrit8(value.ModThreePow8(), 0u);

    internal static uint ToTrits9(this int value) 
        => SetTrit9(value.ModThreePow9(), 0u);

    internal static uint ToTrits10(this int value) 
        => SetTrit10(value.ModThreePow10(), 0u);

    internal static uint ToTrits11(this int value) 
        => SetTrit11(value.ModThreePow11(), 0u);

    internal static uint ToTrits12(this int value) 
        => SetTrit12(value.ModThreePow12(), 0u);

    internal static uint ToTrits13(this int value) 
        => SetTrit13(value.ModThreePow13(), 0u);

    internal static uint ToTrits14(this int value) 
        => SetTrit14(value.ModThreePow14(), 0u);

    internal static uint ToTrits15(this int value) 
        => SetTrit15(value.ModThreePow15(), 0u);

    internal static uint ToTrits16(this int value) 
        => SetTrit16(value.ModThreePow16(), 0u);

    internal static ulong ToTrits17(this int value) 
        => SetTrit17(value.ModThreePow17(), 0ul);

    internal static ulong ToTrits18(this int value) 
        => SetTrit18(value.ModThreePow18(), 0ul);

    internal static ulong ToTrits19(this int value) 
        => SetTrit19(value.ModThreePow19(), 0ul);

    internal static ulong ToTrits20(this int value) 
        => SetTrit20(value.ModThreePow20(), 0ul);

    internal static ulong ToTrits21(this long value) 
        => SetTrit21(value.ModThreePow21(), 0ul);

    internal static ulong ToTrits22(this long value) 
        => SetTrit22(value.ModThreePow22(), 0ul);

    internal static ulong ToTrits23(this long value) 
        => SetTrit23(value.ModThreePow23(), 0ul);

    internal static ulong ToTrits24(this long value) 
        => SetTrit24(value.ModThreePow24(), 0ul);

    internal static ulong ToTrits25(this long value) 
        => SetTrit25(value.ModThreePow25(), 0ul);

    internal static ulong ToTrits26(this long value) 
        => SetTrit26(value.ModThreePow26(), 0ul);

    internal static ulong ToTrits27(this long value) 
        => SetTrit27(value.ModThreePow27(), 0ul);

    internal static ulong ToTrits28(this long value) 
        => SetTrit28(value.ModThreePow28(), 0ul);

    internal static ulong ToTrits29(this long value) 
        => SetTrit29(value.ModThreePow29(), 0ul);

    internal static ulong ToTrits30(this long value) 
        => SetTrit30(value.ModThreePow30(), 0ul);

    internal static ulong ToTrits31(this long value) 
        => SetTrit31(value.ModThreePow31(), 0ul);

    internal static ulong ToTrits32(this long value) 
        => SetTrit32(value.ModThreePow32(), 0ul);

    internal static (ulong high, ulong low) ToTrits64(this long value) => 
        (
            SetTrit32(value.ModThreePow32(), 0ul),
            SetTrit32(value / MaxTrit32, 0ul)
        );

    internal static (ulong high, ulong low) ToTrits40(this long value) => 
        (
            SetTrit32(value.ModThreePow32(), 0ul),
            SetTrit8((value / MaxTrit32).ModThreePow8(), 0u)
        );

    private static uint SetTrit1(int value, uint target)
        => value switch
        {
            -MaxTrit1 => target | (Trit1Mask & DownMask32),
            MaxTrit1 => target | (Trit1Mask & UpMask32),
            _ => target
        };

    private static uint SetTrit2(int value, uint target)
        => value switch
        {
            (< -MaxTrit1) => SetTrit1(value + ThreePow1, target) | (Trit2Mask & DownMask32),
            (> MaxTrit1) => SetTrit1(value - ThreePow1, target) | (Trit2Mask & UpMask32),
            _ => SetTrit1(value, target)
        };

    private static uint SetTrit3(int value, uint target)
        => value switch
        {
            (< -MaxTrit2) => SetTrit2(value + ThreePow2, target) | (Trit3Mask & DownMask32),
            (> MaxTrit2) => SetTrit2(value - ThreePow2, target) | (Trit3Mask & UpMask32),
            _ => SetTrit2(value, target)
        };

    private static uint SetTrit4(int value, uint target)
        => value switch
        {
            (< -MaxTrit3) => SetTrit3(value + ThreePow3, target) | (Trit4Mask & DownMask32),
            (> MaxTrit3) => SetTrit3(value - ThreePow3, target) | (Trit4Mask & UpMask32),
            _ => SetTrit3(value, target)
        };

    private static uint SetTrit5(int value, uint target)
        => value switch
        {
            (< -MaxTrit4) => SetTrit4(value + ThreePow4, target) | (Trit5Mask & DownMask32),
            (> MaxTrit4) => SetTrit4(value - ThreePow4, target) | (Trit5Mask & UpMask32),
            _ => SetTrit4(value, target)
        };

    private static uint SetTrit6(int value, uint target)
        => value switch
        {
            (< -MaxTrit5) => SetTrit5(value + ThreePow5, target) | (Trit6Mask & DownMask32),
            (> MaxTrit5) => SetTrit5(value - ThreePow5, target) | (Trit6Mask & UpMask32),
            _ => SetTrit5(value, target)
        };

    private static uint SetTrit7(int value, uint target)
        => value switch
        {
            (< -MaxTrit6) => SetTrit6(value + ThreePow6, target) | (Trit7Mask & DownMask32),
            (> MaxTrit6) => SetTrit6(value - ThreePow6, target) | (Trit7Mask & UpMask32),
            _ => SetTrit6(value, target)
        };

    private static uint SetTrit8(int value, uint target)
        => value switch
        {
            (< -MaxTrit7) => SetTrit7(value + ThreePow7, target) | (Trit8Mask & DownMask32),
            (> MaxTrit7) => SetTrit7(value - ThreePow7, target) | (Trit8Mask & UpMask32),
            _ => SetTrit7(value, target)
        };

    private static uint SetTrit9(int value, uint target)
        => value switch
        {
            (< -MaxTrit8) => SetTrit8(value + ThreePow8, target) | (Trit9Mask & DownMask32),
            (> MaxTrit8) => SetTrit8(value - ThreePow8, target) | (Trit9Mask & UpMask32),
            _ => SetTrit8(value, target)
        };

    private static uint SetTrit10(int value, uint target)
        => value switch
        {
            (< -MaxTrit9) => SetTrit9(value + ThreePow9, target) | (Trit10Mask & DownMask32),
            (> MaxTrit9) => SetTrit9(value - ThreePow9, target) | (Trit10Mask & UpMask32),
            _ => SetTrit9(value, target)
        };

    private static uint SetTrit11(int value, uint target)
        => value switch
        {
            (< -MaxTrit10) => SetTrit10(value + ThreePow10, target) | (Trit11Mask & DownMask32),
            (> MaxTrit10) => SetTrit10(value - ThreePow10, target) | (Trit11Mask & UpMask32),
            _ => SetTrit10(value, target)
        };

    private static uint SetTrit12(int value, uint target)
        => value switch
        {
            (< -MaxTrit11) => SetTrit11(value + ThreePow11, target) | (Trit12Mask & DownMask32),
            (> MaxTrit11) => SetTrit11(value - ThreePow11, target) | (Trit12Mask & UpMask32),
            _ => SetTrit11(value, target)
        };

    private static uint SetTrit13(int value, uint target)
        => value switch
        {
            (< -MaxTrit12) => SetTrit12(value + ThreePow12, target) | (Trit13Mask & DownMask32),
            (> MaxTrit12) => SetTrit12(value - ThreePow12, target) | (Trit13Mask & UpMask32),
            _ => SetTrit12(value, target)
        };

    private static uint SetTrit14(int value, uint target)
        => value switch
        {
            (< -MaxTrit13) => SetTrit13(value + ThreePow13, target) | (Trit14Mask & DownMask32),
            (> MaxTrit13) => SetTrit13(value - ThreePow13, target) | (Trit14Mask & UpMask32),
            _ => SetTrit13(value, target)
        };

    private static uint SetTrit15(int value, uint target)
        => value switch
        {
            (< -MaxTrit14) => SetTrit14(value + ThreePow14, target) | (Trit15Mask & DownMask32),
            (> MaxTrit14) => SetTrit14(value - ThreePow14, target) | (Trit15Mask & UpMask32),
            _ => SetTrit14(value, target)
        };

    private static uint SetTrit16(int value, uint target)
        => value switch
        {
            (< -MaxTrit15) => SetTrit15(value + ThreePow15, target) | (Trit16Mask & DownMask32),
            (> MaxTrit15) => SetTrit15(value - ThreePow15, target) | (Trit16Mask & UpMask32),
            _ => SetTrit15(value, target)
        };

    private static ulong SetTrit17(int value, ulong target)
        => value switch
        {
            (< -MaxTrit16) => SetTrit16(value + ThreePow16, (uint)target) | (Trit17Mask & DownMask64),
            (> MaxTrit16) => SetTrit16(value - ThreePow16, (uint)target) | (Trit17Mask & UpMask64),
            _ => SetTrit16(value, (uint)target)
        };

    private static ulong SetTrit18(int value, ulong target)
        => value switch
        {
            (< -MaxTrit17) => SetTrit17(value + ThreePow17, target) | (Trit18Mask & DownMask64),
            (> MaxTrit17) => SetTrit17(value - ThreePow17, target) | (Trit18Mask & UpMask64),
            _ => SetTrit17(value, target)
        };

    private static ulong SetTrit19(int value, ulong target)
        => value switch
        {
            (< -MaxTrit18) => SetTrit18(value + ThreePow18, target) | (Trit19Mask & DownMask64),
            (> MaxTrit18) => SetTrit18(value - ThreePow18, target) | (Trit19Mask & UpMask64),
            _ => SetTrit18(value, target)
        };

    private static ulong SetTrit20(int value, ulong target)
        => value switch
        {
            (< -MaxTrit19) => SetTrit19(value + ThreePow19, target) | (Trit20Mask & DownMask64),
            (> MaxTrit19) => SetTrit19(value - ThreePow19, target) | (Trit20Mask & UpMask64),
            _ => SetTrit19(value, target)
        };

    private static ulong SetTrit21(long value, ulong target)
        => value switch
        {
            (< -MaxTrit20) => SetTrit20((int)(value + ThreePow20), target) | (Trit21Mask & DownMask64),
            (> MaxTrit20) => SetTrit20((int)(value - ThreePow20), target) | (Trit21Mask & UpMask64),
            _ => SetTrit20((int)value, target)
        };

    private static ulong SetTrit22(long value, ulong target)
        => value switch
        {
            (< -MaxTrit21) => SetTrit21(value + ThreePow21, target) | (Trit22Mask & DownMask64),
            (> MaxTrit21) => SetTrit21(value - ThreePow21, target) | (Trit22Mask & UpMask64),
            _ => SetTrit21(value, target)
        };

    private static ulong SetTrit23(long value, ulong target)
        => value switch
        {
            (< -MaxTrit22) => SetTrit22(value + ThreePow22, target) | (Trit23Mask & DownMask64),
            (> MaxTrit22) => SetTrit22(value - ThreePow22, target) | (Trit23Mask & UpMask64),
            _ => SetTrit22(value, target)
        };

    private static ulong SetTrit24(long value, ulong target)
        => value switch
        {
            (< -MaxTrit23) => SetTrit23(value + ThreePow23, target) | (Trit24Mask & DownMask64),
            (> MaxTrit23) => SetTrit23(value - ThreePow23, target) | (Trit24Mask & UpMask64),
            _ => SetTrit23(value, target)
        };

    private static ulong SetTrit25(long value, ulong target)
        => value switch
        {
            (< -MaxTrit24) => SetTrit24(value + ThreePow24, target) | (Trit25Mask & DownMask64),
            (> MaxTrit24) => SetTrit24(value - ThreePow24, target) | (Trit25Mask & UpMask64),
            _ => SetTrit24(value, target)
        };

    private static ulong SetTrit26(long value, ulong target)
        => value switch
        {
            (< -MaxTrit25) => SetTrit25(value + ThreePow25, target) | (Trit26Mask & DownMask64),
            (> MaxTrit25) => SetTrit25(value - ThreePow25, target) | (Trit26Mask & UpMask64),
            _ => SetTrit25(value, target)
        };

    private static ulong SetTrit27(long value, ulong target)
        => value switch
        {
            (< -MaxTrit26) => SetTrit26(value + ThreePow26, target) | (Trit27Mask & DownMask64),
            (> MaxTrit26) => SetTrit26(value - ThreePow26, target) | (Trit27Mask & UpMask64),
            _ => SetTrit26(value, target)
        };

    private static ulong SetTrit28(long value, ulong target)
        => value switch
        {
            (< -MaxTrit27) => SetTrit27(value + ThreePow27, target) | (Trit28Mask & DownMask64),
            (> MaxTrit27) => SetTrit27(value - ThreePow27, target) | (Trit28Mask & UpMask64),
            _ => SetTrit27(value, target)
        };

    private static ulong SetTrit29(long value, ulong target)
        => value switch
        {
            (< -MaxTrit28) => SetTrit28(value + ThreePow28, target) | (Trit29Mask & DownMask64),
            (> MaxTrit28) => SetTrit28(value - ThreePow28, target) | (Trit29Mask & UpMask64),
            _ => SetTrit28(value, target)
        };

    private static ulong SetTrit30(long value, ulong target)
        => value switch
        {
            (< -MaxTrit29) => SetTrit29(value + ThreePow29, target) | (Trit30Mask & DownMask64),
            (> MaxTrit29) => SetTrit29(value - ThreePow29, target) | (Trit30Mask & UpMask64),
            _ => SetTrit29(value, target)
        };

    private static ulong SetTrit31(long value, ulong target)
        => value switch
        {
            (< -MaxTrit30) => SetTrit30(value + ThreePow30, target) | (Trit31Mask & DownMask64),
            (> MaxTrit30) => SetTrit30(value - ThreePow30, target) | (Trit31Mask & UpMask64),
            _ => SetTrit30(value, target)
        };

    private static ulong SetTrit32(long value, ulong target)
        => value switch
        {
            (< -MaxTrit31) => SetTrit31(value + ThreePow31, target) | (Trit32Mask & DownMask64),
            (> MaxTrit31) => SetTrit31(value - ThreePow31, target) | (Trit32Mask & UpMask64),
            _ => SetTrit31(value, target)
        };

}
