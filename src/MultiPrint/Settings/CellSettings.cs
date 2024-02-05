using QuestPDF.Infrastructure;

namespace QuantumForge.Settings;

public class CellSettings
{
    public enum AlignType
    {
        Center,
        Top,
        Left,
        Right,
        Bottom
    }
    public TextStyle? TextStyle { get; set; }
    public float? PaddingTop { get; set; }
    public float? PaddingLeft { get; set; }
    public float? PaddingRight { get; set; }
    public float? PaddingBottom { get; set; }

    public float? BorderTop { get; set; }
    public float? BorderLeft { get; set; }
    public float? BorderRight { get; set; }
    public float? BorderBottom { get; set; }

    public string? BorderColor { get; set; }
    public string? Background { get; set; }
    public AlignType Align { get; set; } = CellSettings.AlignType.Center;
}
