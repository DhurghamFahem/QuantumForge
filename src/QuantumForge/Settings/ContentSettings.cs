using QuestPDF.Infrastructure;

namespace QuantumForge.Settings;

public class ContentSettings
{
    public CellSettings Settings { get; set; } = GetDefaultContentSettings();

    public static CellSettings GetDefaultContentSettings()
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
