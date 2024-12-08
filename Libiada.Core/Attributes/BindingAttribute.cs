namespace Libiada.Core.Attributes;

using System;

using Libiada.Core.Core;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class BindingAttribute : Attribute
{
    public readonly Binding Value;

    public BindingAttribute(Binding value)
    {
        if (!Enum.IsDefined<Binding>(value))
        {
            throw new ArgumentException("Binding attribute value is not valid binding", nameof(value));
        }

        Value = value;
    }
}
