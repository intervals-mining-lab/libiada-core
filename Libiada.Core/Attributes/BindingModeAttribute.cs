namespace Libiada.Core.Attributes;

using System;

using Libiada.Core.Core;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class BindingModeAttribute : Attribute
{
    public readonly BindingMode Value;

    public BindingModeAttribute(BindingMode value)
    {
        if (!Enum.IsDefined<BindingMode>(value))
        {
            throw new ArgumentException("Binding mode attribute value is not valid binding mode", nameof(value));
        }

        Value = value;
    }
}
