namespace Ternary3;

public partial struct UInt3
{
    /// <summary>
    /// Actually, the value offsetted by 13
    /// </summary>
    private readonly sbyte value;
    internal UInt3(sbyte offsettedValue) => this.value = offsettedValue;
    public static implicit operator UInt3(Tribble value) => new UInt3(value.value);
    public static implicit operator Tribble(UInt3 value) => new Tribble(value.value);
    public UInt3(Trit down, Trit middle, Trit up)
        => value = TribbleOperations.ToValue(down, middle, up);
    public Trio<Trit> Trits => TribbleOperations.ToTrits(value);

}
