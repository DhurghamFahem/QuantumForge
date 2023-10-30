using MultiPrint.Attributes;
using MultiPrint.DTOs;
using MultiPrint.Settings;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using System.Reflection;

namespace MultiPrint.Documents;

public abstract class BaseDocument<TModel> where TModel : class, new()
{
    protected Dictionary<int, Dictionary<string, object?>> ValueByColumnNameByRowIndex = [];
    protected List<ColumnInfo> ColumnsInfo = [];
    protected readonly IEnumerable<TModel> Models;
    private readonly MultiPrintPageSettings _multiPrintSettings;

    public BaseDocument(IEnumerable<TModel> models, MultiPrintPageSettings? multiPrintSettings = null)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Models = models;
        _multiPrintSettings = multiPrintSettings ?? new();
    }

    protected void GenerateColumnsAndValues()
    {
        var typeToInspect = typeof(TModel);
        var properties = typeToInspect.GetProperties();
        GenerateColumns(properties);
        GenerateValues(properties);
    }

    private void GenerateValues(PropertyInfo[] properties)
    {
        for (int i = 0; i < Models.Count(); i++)
        {
            if (ValueByColumnNameByRowIndex.ContainsKey(i) == false)
                ValueByColumnNameByRowIndex[i] = [];

            var model = Models.ElementAt(i);
            foreach (var property in properties)
            {
                var value = property.GetValue(model);
                ValueByColumnNameByRowIndex[i][property.Name] = value;
            }
        }
    }

    private void GenerateColumns(PropertyInfo[] properties)
    {
        foreach (var property in properties)
        {
            var nameAttribute = (MultiPrintNameAttribute)Attribute.GetCustomAttribute(property, typeof(MultiPrintNameAttribute))!;
            var widthAttribute = (MultiPrintWidthAttribute)Attribute.GetCustomAttribute(property, typeof(MultiPrintWidthAttribute))!;
            var canSumAttribute = (MultiPrintCanSumAttribute)Attribute.GetCustomAttribute(property, typeof(MultiPrintCanSumAttribute))!;

            var columnInfo = new ColumnInfo
            {
                Type = property.PropertyType,
                Name = property.Name,
                DisplayName = nameAttribute == null ? property.Name : nameAttribute.Name,
                Width = widthAttribute == null ? 0 : widthAttribute.Width,
                CanSum = canSumAttribute != null,
            };
            ColumnsInfo.Add(columnInfo);
        }
    }

    protected void ComposeHeader(PageDescriptor page)
    {
        if (_multiPrintSettings.Header.Value == null)
            return;
        if (_multiPrintSettings.Header.Value is string headerValue)
        {
            if (string.IsNullOrEmpty(headerValue))
                return;
            page.Header().Column(column =>
            {
                var header = SetContainerSettings(column.Item(), _multiPrintSettings.Header.Settings);
                header = header.Height(_multiPrintSettings.Header.Height);
                if (_multiPrintSettings.Header.ShowOnce)
                    header = header.ShowOnce();
                header.Text(headerValue);
            });
        }
    }

    protected void ComposeTable(IContainer container)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                foreach (var columnInfo in ColumnsInfo)
                {
                    if (columnInfo.Width != 0)
                        columns.ConstantColumn(columnInfo.Width);
                    else
                        columns.RelativeColumn();
                }
            });

            table.Header(header =>
            {
                foreach (var columnInfo in ColumnsInfo)
                {
                    header.Cell().Element(CellStyle).Text(columnInfo.DisplayName);
                }

                IContainer CellStyle(IContainer cellContainer)
                {
                    if (_multiPrintSettings is null || _multiPrintSettings.TableHeader is null)
                        return cellContainer;
                    return SetContainerSettings(cellContainer, _multiPrintSettings.TableHeader);
                }
            });

            for (int i = 0; i < Models.Count(); i++)
            {
                foreach (var columnInfo in ColumnsInfo)
                {
                    if (ValueByColumnNameByRowIndex.TryGetValue(i, out var valueByColumnName) && valueByColumnName.TryGetValue(columnInfo.Name, out var value))
                    {
                        value ??= Activator.CreateInstance(columnInfo.Type!);
                        table.Cell().Element(CellStyle).Text(value!.ToString());
                    }
                }

                IContainer CellStyle(IContainer cellContainer)
                {
                    if (_multiPrintSettings is null || _multiPrintSettings.TableContent is null)
                        return cellContainer;
                    return SetContainerSettings(cellContainer, _multiPrintSettings.TableContent);
                }
            }
        });
    }

    protected void ComposeFooter(PageDescriptor page)
    {
        if (_multiPrintSettings.Footer.Value == null)
            return;
        if (_multiPrintSettings.Footer.Value is string headerValue)
        {
            if (string.IsNullOrEmpty(headerValue))
                return;
            page.Header().Column(column =>
            {
                var header = SetContainerSettings(column.Item(), _multiPrintSettings.Header.Settings);
                if (_multiPrintSettings.Header.ShowOnce)
                    header = header.ShowOnce();
            });
        }
    }

    private static IContainer SetContainerSettings(IContainer container, CellSettings settings)
    {
        container = container.DefaultTextStyle(c => settings.TextStyle ?? TextStyle.Default)
            .PaddingBottom(settings.PaddingBottom ?? 0)
            .PaddingLeft(settings.PaddingLeft ?? 0)
            .PaddingRight(settings.PaddingRight ?? 0)
            .PaddingTop(settings.PaddingTop ?? 0)
            .BorderBottom(settings.BorderBottom ?? 0)
            .BorderLeft(settings.BorderLeft ?? 0)
            .BorderRight(settings.BorderRight ?? 0)
            .BorderTop(settings.BorderTop ?? 0)
            .Background(string.IsNullOrEmpty(settings.Background) ? "#fff" : settings.Background)
            .BorderColor(string.IsNullOrEmpty(settings.BorderColor) ? "#000" : settings.BorderColor);

        container = settings.Align switch
        {
            CellSettings.AlignType.Top => container.AlignTop(),
            CellSettings.AlignType.Left => container.AlignLeft(),
            CellSettings.AlignType.Right => container.AlignRight(),
            CellSettings.AlignType.Bottom => container.AlignBottom(),
            _ => container.AlignCenter(),
        };
        return container;
    }
}
