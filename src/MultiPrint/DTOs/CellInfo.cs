namespace MultiPrint.DTOs;

public class CellInfo
{
    public int RowIndex { get; set; }
    public string ColumnName { get; set; } = "";
    public object? Value { get; set; }
}
