namespace Ternary3;

using Ternary3.Internal;

/// <summary>
/// Represents a 4-trit signed integer.
/// Also known as a tribble
/// </summary>
public struct TernaryInt4
{
    private byte trits;

    public const sbyte MinValue = -MaxTrit3;
    public const sbyte MaxValue = MaxTrit3;

    internal TernaryInt4(byte trits) => this.trits = trits;

    public static implicit operator TernaryInt4(int value) => new TernaryInt4((byte)value.ToTrits4());
    public static implicit operator sbyte(TernaryInt4 value) => value.trits.From4Trits();
    public static implicit operator int(TernaryInt4 value) => value.trits.From4Trits();
    public static implicit operator long(TernaryInt4 value) => value.trits.From4Trits();
}
