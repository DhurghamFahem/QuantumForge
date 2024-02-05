using QuantumForge.Documents;
using QuantumForge.Settings;
using QuestPDF.Fluent;
using System.ComponentModel;
using System.Diagnostics;

namespace MultiPrint.Services;

public class QuantumForgeService
{
    public static byte[] GeneratePdf<TModel>(IEnumerable<TModel> enumerable, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        return accountsDocument.GeneratePdf();
    }

    public static void GeneratePdf<TModel>(IEnumerable<TModel> enumerable, Stream stream, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GeneratePdf(stream);
    }

    public static void GeneratePdf<TModel>(IEnumerable<TModel> enumerable, string filePath, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GeneratePdf(filePath);
    }

    public static byte[] GeneratePdf<TModel>(object dataSource, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate pdf from non Enumerable data source.");
        return GeneratePdf(enumerable, settings);
    }

    public static void GeneratePdf<TModel>(object dataSource, Stream stream, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate pdf from non Enumerable data source.");
        GeneratePdf(enumerable, stream, settings);
    }

    public static void GeneratePdfAndShow<TModel>(object dataSource, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate pdf from non Enumerable data source.");
        var filePath = GetFilePath();
        GeneratePdf(enumerable, filePath, settings);
        if (File.Exists(filePath))
            ViewFile(filePath);
    }

    public static void GeneratePdf<TModel>(object dataSource, string filePath, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate pdf from non Enumerable data source.");
        GeneratePdf(enumerable, filePath, settings);
    }

    public static byte[] GenerateXps<TModel>(IEnumerable<TModel> enumerable, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        return accountsDocument.GenerateXps();
    }

    public static void GenerateXps<TModel>(IEnumerable<TModel> enumerable, Stream stream, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GenerateXps(stream);
    }

    public static void GenerateXps<TModel>(IEnumerable<TModel> enumerable, string filePath, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        var accountsDocument = new EnumerableDocument<TModel>(enumerable, settings);
        accountsDocument.GenerateXps(filePath);
    }

    public static byte[] GenerateXps<TModel>(object dataSource, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {

        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate xps from non Enumerable data source.");
        return GenerateXps(enumerable, settings);
    }

    public static void GenerateXps<TModel>(object dataSource, Stream stream, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate xps from non Enumerable data source.");
        GenerateXps(enumerable, stream, settings);
    }

    public static void GenerateXpsAndShow<TModel>(object dataSource, QuantumForgePageSettings? settings = null) where TModel : class, new()
    {
        if (dataSource is IEnumerable<TModel> enumerable == false)
            throw new InvalidEnumArgumentException("Cannot generate xps from non Enumerable data source.");
        var filePath = GetFilePath();
        GenerateXps(enumerable, filePath, settings);
        if (File.Exists(filePath))
            ViewFile(filePath);
    }

    private static void ViewFile(string filePath)
    {
        if (File.Exists(filePath) == false)
            return;
        var info = new ProcessStartInfo
        {
            FileName = filePath,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            WorkingDirectory = Path.GetTempPath(),
            UseShellExecute = true
        };
        var p = new Process
        {
            StartInfo = info
        };
        p.Start();
    }

    private static string GetFilePath()
    {
        var folderPath = Path.GetTempPath();
        var filePath = Path.Combine(folderPath, $"{Guid.NewGuid()}.pdf");
        return filePath;
    }
}