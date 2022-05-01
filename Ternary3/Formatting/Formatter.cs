namespace Ternary3.Formatting;

internal static class Formatter
{
    public static string FormatTrits(ulong trits, int digits)
    {
        return FormatTrits(trits, Base3Format.LetterFormat, digits);
    }

    internal static string FormatTrits(ulong trits, IBase3Format format, int numberOfDigits)
    {
        var trim = numberOfDigits == 0;
        if (numberOfDigits <= 0) numberOfDigits = 32;
        var digits = format.Digits;
        Span<char> buffer = stackalloc char[numberOfDigits];
        if (trim)
        {
            for (var i = numberOfDigits - 1; i >= 0; i--)
            {
                buffer[i] = digits[(int)(trits & 0b11)];
                trits >>= 2;
                if (trits == 0) return new string(buffer[i..]);
            }
        }
        else
        {
            for (var i = numberOfDigits - 1; i >= 0; i--)
            {
                buffer[i] = digits[(int)(trits & 0b11)];
                trits >>= 2;
            }
        }
        return new string(buffer);
    }

    internal static string FormatTrits(uint trits, IBase3Format format, int numberOfDigits)
    {
        var trim = numberOfDigits == 0;
        if (numberOfDigits <= 0) numberOfDigits = 16;
        var digits = format.Digits;
        Span<char> buffer = stackalloc char[numberOfDigits];
        if (trim)
        {
            for (var i = numberOfDigits - 1; i >= 0; i--)
            {
                buffer[i] = digits[(int)(trits & 0b11)];
                trits >>= 2;
                if (trits == 0) return new string(buffer[i..]);
            }
        }
        else
        {
            for (var i = numberOfDigits - 1; i >= 0; i--)
            {
                buffer[i] = digits[(int)(trits & 0b11)];
                trits >>= 2;
            }
        }
        return new string(buffer);
    }

    internal static string FormatTribbles(ulong trits, IBase27Format format, int numberOfDigits)
    {
        var trim = numberOfDigits == 0;
        if (numberOfDigits <= 0) numberOfDigits = 11;
        var digits = format.Digits;
        Span<char> buffer = stackalloc char[numberOfDigits];
        if (trim)
        {
            for (var i = numberOfDigits - 1; i >= 0; i--)
            {
                buffer[i] = digits[(int)(trits & 0b111111)];
                trits >>= 6;
                if (trits == 0) return new string(buffer[i..]);
            }
        }
        else
        {
            for (var i = numberOfDigits - 1; i >= 0; i--)
            {
                buffer[i] = digits[(int)(trits & 0b111111)];
                trits >>= 6;
            }
        }
        return new string(buffer);
    }

    internal static string FormatTribbles(uint trits, IBase27Format format, int numberOfDigits)
    {
        var trim = numberOfDigits == 0;
        if (numberOfDigits <= 0) numberOfDigits = 6;
        var digits = format.Digits;
        Span<char> buffer = stackalloc char[numberOfDigits];
        if (trim)
        {
            for (var i = numberOfDigits - 1; i >= 0; i--)
            {
                buffer[i] = digits[(int)(trits & 0b111111)];
                trits >>= 6;
                if (trits == 0) return new string(buffer[i..]);
            }
        }
        else
        {
            for (var i = numberOfDigits - 1; i >= 0; i--)
            {
                buffer[i] = digits[(int)(trits & 0b111111)];
                trits >>= 6;
            }
        }
        return new string(buffer);
    }
}