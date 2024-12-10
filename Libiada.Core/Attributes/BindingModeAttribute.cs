namespace Libiada.Core.Attributes;

using System;

using Libiada.Core.Core;

/// <summary>
/// Used to set binding mode value to other enums.
/// </summary>
/// <seealso cref="System.Attribute" />
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
