namespace Ternary3;

public partial struct Tribble
{
    /// <summary>
    /// The actual numeric value depends on if this is interpreted as an
    /// <see cref="Int3"/> or as an <see cref="UInt3"/>
    /// </summary>
    internal readonly sbyte value;
    internal Tribble(sbyte value) => this.value = value;
    public Tribble(Trit down, Trit middle, Trit up)
        => value = TribbleOperations.ToValue(down, middle, up);
    public Trio<Trit> Trits => TribbleOperations.ToTrits(value);
}
