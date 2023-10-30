namespace MultiPrint.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class MultiPrintSummationTextAttribute : Attribute
{
    protected string SummationTextValue { get; set; } = "";
    public virtual string SummationText => SummationTextValue;

    public MultiPrintSummationTextAttribute() : this(string.Empty)
    {
    }

    public MultiPrintSummationTextAttribute(string summationText)
    {
        SummationTextValue = summationText;
    }
}
