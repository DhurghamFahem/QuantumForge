using MultiPrint.Settings;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace MultiPrint.Documents;

public class EnumerableDocument<TModel> : BaseDocument<TModel>, IDocument where TModel : class, new()
{
    private readonly MultiPrintPageSettings _multiPrintSettings;
    public EnumerableDocument(IEnumerable<TModel> models, MultiPrintPageSettings? multiPrintSettings = null)
        : base(models, multiPrintSettings)
    {
        _multiPrintSettings = multiPrintSettings ?? new MultiPrintPageSettings();
    }

    public void Compose(IDocumentContainer ducoment)
    {
        GenerateColumnsAndValues();
        ducoment.Page(page =>
        {
            page.DefaultTextStyle(c => c.FontFamily(_multiPrintSettings.FontFamily));
            if (_multiPrintSettings.IsContinuous)
                page.ContinuousSize(_multiPrintSettings.Width, _multiPrintSettings.Unit);
            else
                page.Size(_multiPrintSettings.Width, _multiPrintSettings.Height, _multiPrintSettings.Unit);
            ComposeHeader(page);
            ComposeTable(page.Content());
        });
    }
}
