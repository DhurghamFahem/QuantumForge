namespace QuantumFroge.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class QuantumFrogeNameAttribute : Attribute
{
    protected string DisplayNameValue { get; set; } = "";
    public virtual string DisplayName => DisplayNameValue;

    public QuantumFrogeNameAttribute() : this(string.Empty)
    {
    }

    public QuantumFrogeNameAttribute(string displayName)
    {
        DisplayNameValue = displayName;
    }
}
