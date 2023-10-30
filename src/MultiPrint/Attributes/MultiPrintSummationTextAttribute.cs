namespace MultiPrint.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class MultiPrintSummationTextAttribute : Attribute
{
    protected string SummationTextValue { get; set; } = "";
    protected bool ReverseValue { get; set; }
    public virtual string SummationText => SummationTextValue;
    public virtual bool Reverse => ReverseValue;

    public MultiPrintSummationTextAttribute() : this(string.Empty, false)
    {
    }

    public MultiPrintSummationTextAttribute(string summationText, bool reverse = false)
    {
        SummationTextValue = summationText;
        ReverseValue = reverse;
    }
}
