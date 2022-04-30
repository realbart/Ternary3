namespace Ternary3.Formatting;

public interface ITrinaryFormat
{
    char Down { get; }
    char Middle { get; }
    char Up { get; }
    bool Pad { get; }
}