namespace QuantumForge.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class QuantumForgeSummationTextAttribute : Attribute
{
    protected string SummationTextValue { get; set; } = "";
    protected bool ReverseValue { get; set; }
    public virtual string SummationText => SummationTextValue;
    public virtual bool Reverse => ReverseValue;

    public QuantumForgeSummationTextAttribute() : this(string.Empty, false)
    {
    }

    public QuantumForgeSummationTextAttribute(string summationText, bool reverse = false)
    {
        SummationTextValue = summationText;
        ReverseValue = reverse;
    }
}
