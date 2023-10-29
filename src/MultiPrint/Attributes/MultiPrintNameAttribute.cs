namespace MultiPrint.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class MultiPrintNameAttribute : Attribute
{
    protected string NameValue { get; set; } = "";
    public virtual string Name => NameValue;

    public MultiPrintNameAttribute() : this(string.Empty)
    {
    }

    public MultiPrintNameAttribute(string description)
    {
        NameValue = description;
    }
}
