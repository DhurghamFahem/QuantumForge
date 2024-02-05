namespace QuantumForge.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class QuantumForgeNameAttribute : Attribute
{
    protected string NameValue { get; set; } = "";
    public virtual string Name => NameValue;

    public QuantumForgeNameAttribute() : this(string.Empty)
    {
    }

    public QuantumForgeNameAttribute(string name)
    {
        NameValue = name;
    }
}
