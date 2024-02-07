using QuantumFroge.Settings;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace QuantumFroge.Documents;

internal class EnumerableDocument<TModel> : BaseDocument<TModel>, IDocument where TModel : class, new()
{
    private readonly QuantumFrogePageSettings _multiPrintSettings;
    public EnumerableDocument(IEnumerable<TModel> models, QuantumFrogePageSettings? multiPrintSettings = null)
        : base(models, multiPrintSettings)
    {
        _multiPrintSettings = multiPrintSettings ?? new QuantumFrogePageSettings();
    }

    public void Compose(IDocumentContainer ducoment)
    {
        GenerateColumnsAndValues();
        ducoment.Page(page =>
        {
            if (_multiPrintSettings.RightRoLeft)
                page.ContentFromRightToLeft();
            else page.ContentFromLeftToRight();
            page.DefaultTextStyle(c => c.FontFamily(_multiPrintSettings.FontFamily));
            page.PageColor(_multiPrintSettings.Background);

            if (_multiPrintSettings.IsContinuous)
                page.ContinuousSize(_multiPrintSettings.Width, _multiPrintSettings.Unit);
            else
                page.Size(_multiPrintSettings.Width, _multiPrintSettings.Height, _multiPrintSettings.Unit);
            ComposeHeader(page);
            ComposeTable(page.Content());
            ComposeFooter(page);
        });
    }
}
