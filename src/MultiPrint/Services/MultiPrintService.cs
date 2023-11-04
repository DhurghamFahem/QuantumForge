using MultiPrint.Documents;
using MultiPrint.Settings;
using QuestPDF.Fluent;
using System.ComponentModel;

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
            throw new InvalidEnumArgumentException("Cannot generate pdf from non Enumerable data source.");
        GeneratePdf(enumerable, settings);
    }

    public static void GeneratePdf<TModel>(object dataSource, Stream stream, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate pdf from non Enumerable data source.");
        GeneratePdf(enumerable, stream, settings);
    }

    public static void GeneratePdf<TModel>(object dataSource, string filePath, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate pdf from non Enumerable data source.");
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
            throw new InvalidEnumArgumentException("Cannot generate xps from non Enumerable data source.");
        GenerateXps(enumerable, settings);
    }

    public static void GenerateXps<TModel>(object dataSource, Stream stream, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate xps from non Enumerable data source.");
        GenerateXps(enumerable, stream, settings);
    }

    public static void GenerateXps<TModel>(object dataSource, string filePath, MultiPrintPageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate xps from non Enumerable data source.");
        GenerateXps(enumerable, filePath, settings);
    }

    public static void Print<TModel>(IEnumerable<TModel> enumerable, MultiPrintPageSettings? settings = null, string printerName = "") where TModel : class, new()
    {
        var folderPath = Path.GetTempPath();
        var filePath = Path.Combine(folderPath, $"{Guid.NewGuid()}.pdf");
        GeneratePdf(enumerable, filePath, settings);
        if (File.Exists(filePath) == false)
            throw new Exception("File creation failed.");
        Print(filePath, printerName);
    }

    public static void Print<TModel>(object dataSource, MultiPrintPageSettings? settings = null, string printerName = "") where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot print non Enumerable data source.");
        Print(enumerable, settings, printerName);
    }

    private static void Print(string filePath, string printerName)
    {
        var pd = new printdialog
    }
}