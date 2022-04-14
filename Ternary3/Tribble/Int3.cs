namespace Ternary3;

public partial struct Int3
{
    private readonly sbyte value;
    internal Int3(sbyte value) => this.value = value;
    public static explicit operator Int3(int value) => new(value.SignedModulo27());
    public static explicit operator Int3(long value) => new(value.SignedModulo27());

    public static implicit operator Int3(Tribble value) => new(value.value);
    public static implicit operator Tribble(Int3 value) => new(value.value);

    public static implicit operator sbyte(Int3 value) => value.value;
    public static implicit operator short(Int3 value) => value.value;
    public static implicit operator int(Int3 value) => value.value;
    public static implicit operator long(Int3 value) => value.value;

    public static int operator +(Int3 a, Int3 b) => a.value + b.value;
    public static int operator -(Int3 a, Int3 b) => a.value - b.value;
    public static int operator *(Int3 a, Int3 b) => a.value * b.value;
    public static int operator /(Int3 a, Int3 b) => a.value / b.value;

    public override string ToString() => value.ToString();
}
