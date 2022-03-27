namespace Ternary3;
 


public partial struct Int3 
{
    /// <summary>
    /// Instantiates an instance of Int3.
    /// </summary>    
    public Int3(Trit downTrit, Trit middleTrit, Trit upTrit)
        => value = TribbleOperations.ToValue(downTrit, middleTrit, upTrit);

    /// <summary>
    /// Returns the <see cref="Trio&lt;&gt;"/> of <see cref="Trit"/>s the  <see cref="Int3"/>  is made up of.
    /// </summary>
    public Trio<Trit> Trits => TribbleOperations.ToTrits(value);
}

 


public partial struct UInt3 
{
    /// <summary>
    /// Instantiates an instance of UInt3.
    /// </summary>    
    public UInt3(Trit downTrit, Trit middleTrit, Trit upTrit)
        => value = TribbleOperations.ToValue(downTrit, middleTrit, upTrit);

    /// <summary>
    /// Returns the <see cref="Trio&lt;&gt;"/> of <see cref="Trit"/>s the  <see cref="UInt3"/>  is made up of.
    /// </summary>
    public Trio<Trit> Trits => TribbleOperations.ToTrits(value);
}

 


public partial struct Tribble 
{
    /// <summary>
    /// Instantiates an instance of Tribble.
    /// </summary>    
    public Tribble(Trit downTrit, Trit middleTrit, Trit upTrit)
        => value = TribbleOperations.ToValue(downTrit, middleTrit, upTrit);

    /// <summary>
    /// Returns the <see cref="Trio&lt;&gt;"/> of <see cref="Trit"/>s the  <see cref="Tribble"/>  is made up of.
    /// </summary>
    public Trio<Trit> Trits => TribbleOperations.ToTrits(value);
}

