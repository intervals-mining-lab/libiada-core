namespace Libiada.Core.Attributes;

using System;

using Libiada.Core.Core;

/// <summary>
/// Used to set link value to other enums.
/// </summary>
/// <seealso cref="System.Attribute" />
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class LinkAttribute : Attribute
{
    public readonly Link Value;

    public LinkAttribute(Link value)
    {
        if (!Enum.IsDefined<Link>(value))
        {
            throw new ArgumentException("Link attribute value is not valid link", nameof(value));
        }

        Value = value;
    }
}
