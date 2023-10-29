namespace MultiPrint.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class MultiPrintWidthAttribute : Attribute
{
    protected float WidthValue { get; set; }
    public virtual float Width => WidthValue;

    public MultiPrintWidthAttribute() : this(0)
    {
    }

    public MultiPrintWidthAttribute(float width)
    {
        WidthValue = width;
    }
}
