namespace QuantumFroge.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class QuantumFrogeSummationTextAttribute : Attribute
{
    protected string SummationTextValue { get; set; } = "";
    protected bool ReverseValue { get; set; }
    public virtual string SummationText => SummationTextValue;
    public virtual bool Reverse => ReverseValue;

    public QuantumFrogeSummationTextAttribute() : this(string.Empty, false)
    {
    }

    public QuantumFrogeSummationTextAttribute(string summationText, bool reverse = false)
    {
        SummationTextValue = summationText;
        ReverseValue = reverse;
    }
}
