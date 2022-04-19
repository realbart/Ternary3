namespace Ternary3.Formatting;

public interface ITernaryFormat
{
    char Down { get; }
    char Middle { get; }
    char Up { get; }
    bool Pad { get; }
}