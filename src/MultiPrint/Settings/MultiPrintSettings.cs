using QuestPDF.Infrastructure;

namespace MultiPrint.Settings;

public class MultiPrintSettings
{
    public HeaderSettings? Header { get; set; } = GetDefaultHeaderSettings();
    public HeaderSettings? Content { get; set; }
    public HeaderSettings? Footer { get; set; }


    public static HeaderSettings GetDefaultHeaderSettings()
    {
        return new HeaderSettings
        {
            TextStyle = TextStyle.Default,
            BorderBottom = 1,
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
