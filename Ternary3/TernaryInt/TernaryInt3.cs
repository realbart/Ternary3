namespace Ternary;

using Ternary.Internal;

/// <summary>
/// Represents a 3-trit signed integer.
/// Also known as a tribble
/// </summary>
public struct TernaryInt3 
{
    private byte trits;

    public const sbyte MinValue = -MaxTrit3;
    public const sbyte MaxValue = MaxTrit3;

    internal TernaryInt3(byte trits) => this.trits = trits;

    public static implicit operator TernaryInt3(int value) => new TernaryInt3((byte)value.ToTrits3());
    public static implicit operator sbyte(TernaryInt3 value) => value.trits.From4Trits();
    public static implicit operator int(TernaryInt3 value) => value.trits.From4Trits();
    public static implicit operator long(TernaryInt3 value) => value.trits.From4Trits();
}
