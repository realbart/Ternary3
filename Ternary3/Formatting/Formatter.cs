namespace Ternary3.Formatting;

internal static class Formatter
{
    private static DefaultFormat defaultFormat = new DefaultFormat();

    public static string FormatTrits(ulong trits, int digits)
    {
        return FormatTrits(trits, defaultFormat, digits);
    }

    internal static string FormatTrits(ulong trits, ITrinaryFormat format, int digits)
    {
        const ulong mask = 0b1100000000000000_0000000000000000_0000000000000000_0000000000000000ul;
        const ulong up = 0b1000000000000000_0000000000000000_0000000000000000_0000000000000000ul;
        const ulong down = 0b0100000000000000_0000000000000000_0000000000000000_0000000000000000ul;
        var pad = format.Pad && digits > 0;
        if (digits <= 0) digits = 32;
        var builder = new StringBuilder();

        trits <<= (64 - (digits << 1));

        for (var i = 0; i < digits; i++)
        {
            builder.Append((trits & mask) switch
            {
                up => format.Up,
                down => format.Down,
                _ => format.Middle
            });
            trits <<= 2;
        }

        return pad ? builder.ToString() : builder.ToString().TrimStart(format.Middle);
    }

    internal static string FormatTrits(uint trits, ITrinaryFormat format, int digits = 16)
    {
        const ulong mask = 0b11000000_00000000_00000000_00000000u;
        const ulong up = 0b10000000_00000000_00000000_00000000u;
        const ulong down = 0b01000000_00000000_00000000_00000000u;

        var builder = new StringBuilder();

        trits <<= (16 - (digits << 1));

        for (var i = 0; i < digits; i++)
        {
            builder.Append((trits & mask) switch
            {
                up => format.Up,
                down => format.Down,
                _ => format.Middle
            });
            trits <<= 2;
        }

        return format.Pad ? builder.ToString() : builder.ToString().TrimStart(format.Middle);
    }
}