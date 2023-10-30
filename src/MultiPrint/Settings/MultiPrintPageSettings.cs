using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace MultiPrint.Settings;

public class MultiPrintPageSettings
{
    public float Width { get; set; } = PageSizes.A4.Width;
    public float Height { get; set; } = PageSizes.A4.Height;
    public Unit Unit { get; set; } = Unit.Point;
    public bool IsContinuous { get; set; }
    public bool RightRoLeft { get; set; }
    public string FontFamily { get; set; } = "Cairo";
    public CellSettings TableHeader { get; set; } = GetDefaultTableHeaderSettings();
    public CellSettings TableContent { get; set; } = GetDefaultTableContentSettings();
    public CellSettings TableFooter { get; set; } = GetDefaultTableFooterSettings();
    public HeaderSettings Header { get; set; } = new();
    public FooterSettings Footer { get; set; } = new();


    public static CellSettings GetDefaultTableHeaderSettings()
    {
        return new CellSettings
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

    public static CellSettings GetDefaultTableContentSettings()
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

    public static CellSettings GetDefaultTableFooterSettings()
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
