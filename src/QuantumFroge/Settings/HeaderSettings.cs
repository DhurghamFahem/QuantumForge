using QuestPDF.Infrastructure;

namespace QuantumFroge.Settings;

public class HeaderSettings
{
    public object? Value { get; set; }
    public float Height { get; set; } = 60;
    public bool ShowOnce { get; set; }
    public CellSettings Settings { get; set; } = GetDefaultSettings();

    public static CellSettings GetDefaultSettings()
    {
        return new CellSettings
        {
            TextStyle = TextStyle.Default,
            BorderBottom = 0,
            BorderLeft = 0,
            BorderRight = 0,
            BorderTop = 0,
            BorderColor = "#000000",
            PaddingBottom = 5,
            PaddingLeft = 5,
            PaddingRight = 5,
            PaddingTop = 5,
        };
    }
}
