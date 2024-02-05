namespace QuantumForge.DTOs;

internal class ColumnInfo
{
    public string Name { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public Type? Type { get; set; }
    public float Width { get; set; }
    public bool CanSum { get; set; }
    public string SummationText { get; set; } = "";
    public bool ReverseSummationText { get; set; }
}
