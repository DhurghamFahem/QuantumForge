using MultiPrint.Attributes;
using MultiPrint.DTOs;
using MultiPrint.Settings;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection;

namespace MultiPrint.Documents;

public abstract class BaseDocument<TModel> where TModel : class, new()
{
    protected Dictionary<int, Dictionary<string, object?>> ValueByColumnNameByRowIndex = [];
    protected List<ColumnInfo> ColumnsInfo = [];
    protected readonly IEnumerable<TModel> Models;
    private readonly MultiPrintSettings? _multiPrintSettings;

    public BaseDocument(IEnumerable<TModel> models, MultiPrintSettings? multiPrintSettings = null)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        Models = models;
        _multiPrintSettings = multiPrintSettings;
        if (_multiPrintSettings == null)
            _multiPrintSettings = new MultiPrintSettings();
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

            var columnInfo = new ColumnInfo
            {
                Type = property.PropertyType,
                Name = property.Name,
                DisplayName = nameAttribute == null ? property.Name : nameAttribute.Name,
                Width = widthAttribute == null ? 0 : widthAttribute.Width
            };
            ColumnsInfo.Add(columnInfo);
        }
    }

    void ComposeTable(IContainer container)
    {
        container.Table(table =>
        {
            // step 1
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

            // step 2
            table.Header(header =>
            {
                foreach (var columnInfo in ColumnsInfo)
                {
                    header.Cell().Element(CellStyle).Text(columnInfo.DisplayName);
                }

                IContainer CellStyle(IContainer container)
                {
                    container = container.DefaultTextStyle(x => x.SemiBold());
                    if (_multiPrintSettings != null && _multiPrintSettings.Header != null)
                    {
                        container = container.PaddingBottom(_multiPrintSettings.Header.PaddingBottom ?? 0);
                        container = container.PaddingLeft(_multiPrintSettings.Header.PaddingLeft ?? 0);
                        container = container.PaddingRight(_multiPrintSettings.Header.PaddingRight ?? 0);
                        container = container.PaddingTop(_multiPrintSettings.Header.PaddingTop ?? 0);
                    }

                    return container;
                    //.PaddingBottom(_multiPrintSettings.Header.PaddingBottom)
                    //.BorderBottom(1)
                    //.BorderColor(Colors.Black);
                }
            });

            // step 3
            foreach (var item in Model.Items)
            {
                table.Cell().Element(CellStyle).Text(Model.Items.IndexOf(item) + 1);
                table.Cell().Element(CellStyle).Text(item.Name);
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price}$");
                table.Cell().Element(CellStyle).AlignRight().Text(item.Quantity);
                table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price * item.Quantity}$");

                static IContainer CellStyle(IContainer container)
                {
                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            }
        });
    }
}
