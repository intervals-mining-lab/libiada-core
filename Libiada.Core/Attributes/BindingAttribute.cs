namespace Libiada.Core.Attributes;

using System;

using Libiada.Core.Core;

/// <summary>
/// Used to set binding value to other enums.
/// </summary>
/// <seealso cref="System.Attribute" />
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
