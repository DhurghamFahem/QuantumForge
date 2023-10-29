namespace MultiPrint.DTOs;

public class ColumnInfo
{
    public string Name { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public Type? Type { get; set; }
    public float Width { get; set; }
}
