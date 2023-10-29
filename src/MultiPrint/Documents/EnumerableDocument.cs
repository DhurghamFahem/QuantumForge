using QuestPDF.Infrastructure;

namespace MultiPrint.Documents;

public class EnumerableDocument<TModel> : BaseDocument<TModel>, IDocument where TModel : class, new()
{
    public EnumerableDocument(IEnumerable<TModel> models)
        : base(models)
    {
    }

    public void Compose(IDocumentContainer container)
    {
    }
}
