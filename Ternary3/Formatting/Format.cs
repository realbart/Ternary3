namespace Ternary3.Formatting;

public class Format : ITernaryFormat
{
    private Format(char down, char middle, char up, bool pad)
    {
        Down = down;
        Middle = middle;
        Up = up;
        Pad = pad;
    }

    public char Down { get; set; }
    public char Middle { get; set; }
    public char Up { get; set; }
    public bool Pad { get; set; }

    public static Format LetterFormat { get; } = new Format('D', 'M', 'U', true);
    public static Format SignFormat { get; } = new Format('-', '0', '+', false);
    public static Format NumberFormat { get; } = new Format('T', '0', '1', false);
    public static Format Create(char down, char middle, char up, bool pad) => new Format(down, middle, up, pad);

}
