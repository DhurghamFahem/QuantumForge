namespace MultiPrint.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class MultiPrintCanSumAttribute : Attribute
{
    protected bool CanSumValue { get; set; }
    public virtual bool CanSum => CanSumValue;

    public MultiPrintCanSumAttribute() : this(false)
    {
    }

    public MultiPrintCanSumAttribute(bool canSum)
    {
        CanSumValue = canSum;
    }
}
