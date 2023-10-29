using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace MultiPrint.Services;

public class MultiPrintService
{
    private readonly IDocument _document;
    public MultiPrintService(IDocument document)
    {
        _document = document;
        _document.ShowInPreviewer();
    }

    public void Print<T>(IEnumerable<T> enumerable) where T : class
    {

    }
}
