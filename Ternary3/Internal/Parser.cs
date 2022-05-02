namespace Ternary3.Internal;

using System;

internal static class Parser
{
    internal static (ulong high, ulong low) ToTrits64(ReadOnlySpan<char> s, int digits = 64)
    {
        s = s.Trim();
        if (s.Length > digits) throw new OverflowException("Input string was not in a correct format.");
        if (s.Length <= 32) return (0, ToTrits32(s));
        return (ToTrits32(s[..^32]), ToTrits32(s[^32..]));
    }

    internal static ulong ToTrits32(ReadOnlySpan<char> s, int digits = 32)
    {
        s = s.Trim();
        if (s.Length > digits) throw new OverflowException("Input string was not in a correct format.");
        ulong value = 0;
        foreach (var c in s)
        {
            var index = ("0-++0T110t11MDUUmduu".IndexOf(c) & 0b11);
            if (index == 0b11) throw new FormatException("Input string was not in a correct format.");
            value = (value << 2) | (byte)index;
        }
        return value;
    }

    internal static uint ToTrits16(ReadOnlySpan<char> s, int digits = 16)
    {
        s = s.Trim();
        if (s.Length > digits) throw new OverflowException("Input string was not in a correct format.");
        uint value = 0;
        foreach (var c in s)
        {
            var index = ("0-++0T110t11MDUUmduu".IndexOf(c) & 0b11);
            if (index == 0b11) throw new FormatException("Input string was not in a correct format.");
            value = (value << 2) | (byte)index;
        }
        return value;
    }
}
