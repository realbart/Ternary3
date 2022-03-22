namespace Ternary3;

public partial struct Int3
{
    private readonly sbyte value;
    internal Int3(sbyte value) => this.value = value;
    public static implicit operator Int3(Tribble value) => new Int3(value.value);
    public static implicit operator Tribble(Int3 value) => new Tribble(value.value);
    public Int3(Trit down, Trit middle, Trit up)
        => value = TribbleOperations.ToValue(down, middle, up);
    public Trio<Trit> Trits => TribbleOperations.ToTrits(value);
}
