namespace Ternary3;

public partial struct UInt3
{
    private const sbyte offset = 13;
    /// <summary>
    /// Actually, the value offsetted by 13
    /// </summary>
    private readonly sbyte value;
    internal UInt3(sbyte offsettedValue) => this.value = offsettedValue;
    public static explicit operator UInt3(int value) => new(value.UnsignedModulo27Minus13());
    public static explicit operator UInt3(long value) => new(value.UnsignedModulo27Minus13());

    public static implicit operator UInt3(Tribble value) => new(value.value);
    public static implicit operator Tribble(UInt3 value) => new(value.value);

    public static implicit operator sbyte(UInt3 value) => (sbyte)(value.value + offset);
    public static implicit operator short(UInt3 value) => (short)(value.value + offset);
    public static implicit operator int(UInt3 value) => value.value + offset;
    public static implicit operator long(UInt3 value) => value.value + offset;

    public static implicit operator byte(UInt3 value) => (byte)(value.value + offset);
    public static implicit operator ushort(UInt3 value) => (ushort)(value.value + offset);
    public static implicit operator uint(UInt3 value) => (uint)(value.value + offset);
    public static implicit operator ulong(UInt3 value) => (ulong)(value.value + offset);

    public static UInt3 operator +(UInt3 a, UInt3 b)
    {
        var sum = (sbyte)(a.value + b.value + offset);
        if (sum > offset) sum -= 27;
        return new UInt3(sum);
    }

    public static UInt3 operator -(UInt3 a, UInt3 b)
    {
        var sum = (sbyte)(a.value - b.value - offset);
        if (sum < -offset) sum += 27;
        return new UInt3(sum);
    }

    public override string ToString() => (value + offset).ToString();
}
