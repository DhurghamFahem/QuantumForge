namespace QuantumForge.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class QuantumForgeWidthAttribute : Attribute
{
    private float _widthValue;
    protected float WidthValue
    {
        get
        {
            return _widthValue;
        }
        set
        {
            if (value <= 0)
                throw new Exception("Width value cannot be equal or less than ZERO!");
            _widthValue = value;
        }
    }
    public virtual float Width => WidthValue;

    public QuantumForgeWidthAttribute() : this(0)
    {
    }

    public QuantumForgeWidthAttribute(float width)
    {
        WidthValue = width;
    }
}
