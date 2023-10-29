using QuestPDF.Infrastructure;

namespace MultiPrint.Settings;

public class HeaderSettings
{
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
}
