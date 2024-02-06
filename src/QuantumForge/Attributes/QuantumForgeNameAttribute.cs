namespace QuantumForge.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class QuantumForgeNameAttribute : Attribute
{
    protected string DisplayNameValue { get; set; } = "";
    public virtual string DisplayName => DisplayNameValue;

    public QuantumForgeNameAttribute() : this(string.Empty)
    {
    }

    public QuantumForgeNameAttribute(string displayName)
    {
        DisplayNameValue = displayName;
    }
}
