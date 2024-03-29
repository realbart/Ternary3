﻿namespace Ternary.Internal;
internal static class Constants
{
    /// <summary>
    /// "Encoded"
    /// This needs to be a number that doesn't occur in most encoding schemas
    /// so it can be relied on for auto detection.
    /// </summary>
    internal const byte FileSignature1 = 0xfe;
    /// <summary>
    /// "Binary / 3Nary"
    /// This is a pretty randomly chosen number that isn't used by
    /// any known file format yet.
    /// (according to https://en.wikipedia.org/wiki/List_of_file_signatures)
    /// </summary>
    internal const byte FileSignature2 = 0xb3;

    internal const byte FileSignatureBytePerTernaryInt3 = 0x1f;


    internal const int MaxTrit1 = 1;
    internal const int MaxTrit2 = 3 * MaxTrit1 + 1;
    internal const int MaxTrit3 = 3 * MaxTrit2 + 1;
    internal const int MaxTrit4 = 3 * MaxTrit3 + 1;
    internal const int MaxTrit5 = 3 * MaxTrit4 + 1;
    internal const int MaxTrit6 = 3 * MaxTrit5 + 1;
    internal const int MaxTrit7 = 3 * MaxTrit6 + 1;
    internal const int MaxTrit8 = 3 * MaxTrit7 + 1;
    internal const int MaxTrit9 = 3 * MaxTrit8 + 1;
    internal const int MaxTrit10 = 3 * MaxTrit9 + 1;
    internal const int MaxTrit11 = 3 * MaxTrit10 + 1;
    internal const int MaxTrit12 = 3 * MaxTrit11 + 1;
    internal const int MaxTrit13 = 3 * MaxTrit12 + 1;
    internal const int MaxTrit14 = 3 * MaxTrit13 + 1;
    internal const int MaxTrit15 = 3 * MaxTrit14 + 1;
    internal const int MaxTrit16 = 3 * MaxTrit15 + 1;
    internal const int MaxTrit17 = 3 * MaxTrit16 + 1;
    internal const int MaxTrit18 = 3 * MaxTrit17 + 1;
    internal const int MaxTrit19 = 3 * MaxTrit18 + 1;
    internal const int MaxTrit20 = 3 * MaxTrit19 + 1;
    internal const long MaxTrit21 = 3L * MaxTrit20 + 1;
    internal const long MaxTrit22 = 3 * MaxTrit21 + 1;
    internal const long MaxTrit23 = 3 * MaxTrit22 + 1;
    internal const long MaxTrit24 = 3 * MaxTrit23 + 1;
    internal const long MaxTrit25 = 3 * MaxTrit24 + 1;
    internal const long MaxTrit26 = 3 * MaxTrit25 + 1;
    internal const long MaxTrit27 = 3 * MaxTrit26 + 1;
    internal const long MaxTrit28 = 3 * MaxTrit27 + 1;
    internal const long MaxTrit29 = 3 * MaxTrit28 + 1;
    internal const long MaxTrit30 = 3 * MaxTrit29 + 1;
    internal const long MaxTrit31 = 3 * MaxTrit30 + 1;
    internal const long MaxTrit32 = 3 * MaxTrit31 + 1;
    internal const long MaxTrit33 = 3 * MaxTrit32 + 1;
    internal const long MaxTrit34 = 3 * MaxTrit33 + 1;
    internal const long MaxTrit35 = 3 * MaxTrit34 + 1;
    internal const long MaxTrit36 = 3 * MaxTrit35 + 1;
    internal const long MaxTrit37 = 3 * MaxTrit36 + 1;
    internal const long MaxTrit38 = 3 * MaxTrit37 + 1;
    internal const long MaxTrit39 = 3 * MaxTrit38 + 1;
    internal const long MaxTrit40 = 3 * MaxTrit39 + 1;
    internal const int ThreePow0 = 1;
    internal const int ThreePow1 = 3 * ThreePow0;
    internal const int ThreePow2 = 3 * ThreePow1;
    internal const int ThreePow3 = 3 * ThreePow2;
    internal const int ThreePow4 = 3 * ThreePow3;
    internal const int ThreePow5 = 3 * ThreePow4;
    internal const int ThreePow6 = 3 * ThreePow5;
    internal const int ThreePow7 = 3 * ThreePow6;
    internal const int ThreePow8 = 3 * ThreePow7;
    internal const int ThreePow9 = 3 * ThreePow8;
    internal const int ThreePow10 = 3 * ThreePow9;
    internal const int ThreePow11 = 3 * ThreePow10;
    internal const int ThreePow12 = 3 * ThreePow11;
    internal const int ThreePow13 = 3 * ThreePow12;
    internal const int ThreePow14 = 3 * ThreePow13;
    internal const int ThreePow15 = 3 * ThreePow14;
    internal const int ThreePow16 = 3 * ThreePow15;
    internal const int ThreePow17 = 3 * ThreePow16;
    internal const int ThreePow18 = 3 * ThreePow17;
    internal const int ThreePow19 = 3 * ThreePow18;
    internal const uint ThreePow20 = 3u * ThreePow19;
    internal const long ThreePow21 = 3L * ThreePow20;
    internal const long ThreePow22 = 3L * ThreePow21;
    internal const long ThreePow23 = 3L * ThreePow22;
    internal const long ThreePow24 = 3L * ThreePow23;
    internal const long ThreePow25 = 3L * ThreePow24;
    internal const long ThreePow26 = 3L * ThreePow25;
    internal const long ThreePow27 = 3L * ThreePow26;
    internal const long ThreePow28 = 3L * ThreePow27;
    internal const long ThreePow29 = 3L * ThreePow28;
    internal const long ThreePow30 = 3L * ThreePow29;
    internal const long ThreePow31 = 3L * ThreePow30;
    internal const long ThreePow32 = 3L * ThreePow31;
    internal const long ThreePow33 = 3L * ThreePow32;
    internal const long ThreePow34 = 3L * ThreePow33;
    internal const long ThreePow35 = 3L * ThreePow34;
    internal const long ThreePow36 = 3L * ThreePow35;
    internal const long ThreePow37 = 3L * ThreePow36;
    internal const long ThreePow38 = 3L * ThreePow37;
    internal const long ThreePow39 = 3L * ThreePow38;
    internal const ulong ThreePow40 = 3uL * ThreePow39;
    internal const uint UpMask32 = 0b10101010_10101010_10101010_10101010u;
    internal const uint DownMask32 = 0b01010101_01010101_01010101_01010101u;
    internal const ulong UpMask64 = 0b10101010_10101010_10101010_10101010_10101010_10101010_10101010_10101010u;
    internal const ulong DownMask64 = 0b01010101_01010101_01010101_01010101_01010101_01010101_01010101_01010101u;
    internal const uint Trit1Mask = 0b11;
    internal const uint Trit2Mask = 0b100 * Trit1Mask;
    internal const uint Trit3Mask = 0b100 * Trit2Mask;
    internal const uint Trit4Mask = 0b100 * Trit3Mask;
    internal const uint Trit5Mask = 0b100 * Trit4Mask;
    internal const uint Trit6Mask = 0b100 * Trit5Mask;
    internal const uint Trit7Mask = 0b100 * Trit6Mask;
    internal const uint Trit8Mask = 0b100 * Trit7Mask;
    internal const uint Trit9Mask = 0b100 * Trit8Mask;
    internal const uint Trit10Mask = 0b100 * Trit9Mask;
    internal const uint Trit11Mask = 0b100 * Trit10Mask;
    internal const uint Trit12Mask = 0b100 * Trit11Mask;
    internal const uint Trit13Mask = 0b100 * Trit12Mask;
    internal const uint Trit14Mask = 0b100 * Trit13Mask;
    internal const uint Trit15Mask = 0b100 * Trit14Mask;
    internal const uint Trit16Mask = 0b100 * Trit15Mask;
    internal const ulong Trit17Mask = 0b100L * Trit16Mask;
    internal const ulong Trit18Mask = 0b100 * Trit17Mask;
    internal const ulong Trit19Mask = 0b100 * Trit18Mask;
    internal const ulong Trit20Mask = 0b100 * Trit19Mask;
    internal const ulong Trit21Mask = 0b100 * Trit20Mask;
    internal const ulong Trit22Mask = 0b100 * Trit21Mask;
    internal const ulong Trit23Mask = 0b100 * Trit22Mask;
    internal const ulong Trit24Mask = 0b100 * Trit23Mask;
    internal const ulong Trit25Mask = 0b100 * Trit24Mask;
    internal const ulong Trit26Mask = 0b100 * Trit25Mask;
    internal const ulong Trit27Mask = 0b100 * Trit26Mask;
    internal const ulong Trit28Mask = 0b100 * Trit27Mask;
    internal const ulong Trit29Mask = 0b100 * Trit28Mask;
    internal const ulong Trit30Mask = 0b100 * Trit29Mask;
    internal const ulong Trit31Mask = 0b100 * Trit30Mask;
    internal const ulong Trit32Mask = 0b100 * Trit31Mask;
}
