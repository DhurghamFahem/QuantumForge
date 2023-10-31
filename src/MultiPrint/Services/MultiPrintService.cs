using MultiPrint.Documents;
using MultiPrint.Settings;
using QuestPDF.Fluent;
using QuestPDF.Previewer;

namespace MultiPrint.Services;

public class MultiPrintService
{
    public static void GeneratePdf<TModel>(IEnumerable<TModel> enumerable, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GeneratePdf();
    }

    public static void GeneratePdf<TModel>(IEnumerable<TModel> enumerable, Stream stream, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GeneratePdf(stream);
    }

    public static void GeneratePdf<TModel>(IEnumerable<TModel> enumerable, string filePath, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GeneratePdf(filePath);
    }

    public static void GeneratePdf<TModel>(object dataSource, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            return;
        GeneratePdf(enumerable, settings);
    }

    public static void GeneratePdf<TModel>(object dataSource, Stream stream, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            return;
        GeneratePdf(enumerable, stream, settings);
    }

    public static void GeneratePdf<TModel>(object dataSource, string filePath, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            return;
        GeneratePdf(enumerable, filePath, settings);
    }

    public static void GenerateXps<TModel>(IEnumerable<TModel> enumerable, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GenerateXps();
    }

    public static void GenerateXps<TModel>(IEnumerable<TModel> enumerable, Stream stream, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GenerateXps(stream);
    }

    public static void GenerateXps<TModel>(IEnumerable<TModel> enumerable, string filePath, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GenerateXps(filePath);
    }

    public static void GenerateXps<TModel>(object dataSource, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            return;
        GenerateXps(enumerable, settings);
    }

    public static void GenerateXps<TModel>(object dataSource, Stream stream, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            return;
        GenerateXps(enumerable, stream, settings);
    }

    public static void GenerateXps<TModel>(object dataSource, string filePath, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            return;
        GenerateXps(enumerable, filePath, settings);
    }
}
