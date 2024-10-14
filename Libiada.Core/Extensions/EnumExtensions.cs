namespace Libiada.Core.Extensions;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;

using Libiada.Core.Attributes;
using Libiada.Core.Core;
using Libiada.Core.Exceptions;

/// <summary>
/// The enum helper.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Gets enum display name.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <typeparam name="T">
    /// Enum type.
    /// </typeparam>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public static string GetDisplayValue<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
    {
        Type type = typeof(T);

        if (!type.IsEnum)
        {
            throw new TypeArgumentException("Type argument must be enum.", type);
        }

        var fieldInfo = type.GetField(value.ToString(CultureInfo.InvariantCulture));

        var descriptionAttributes = fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

        if (descriptionAttributes == null)
        {
            return string.Empty;
        }

        return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Gets enum name as in code.
    /// </summary>
    /// <param name="value">
    /// The nature.
    /// </param>
    /// <typeparam name="T">
    /// Enum type.
    /// </typeparam>
    /// <returns>
    /// The <see cref="string"/> or <see langword="null"/> if value is not found.
    /// </returns>
    /// <exception cref="TypeArgumentException">
    /// Thrown if type argument is not enum.
    /// </exception>
    public static string? GetName<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
    {
        Type type = typeof(T);

        if (!type.IsEnum)
        {
            throw new TypeArgumentException("Type argument must be enum.", type);
        }

        return Enum.GetName(type, value);
    }

    /// <summary>
    /// Gets description attribute of the given enum value.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <typeparam name="T">
    /// Enum type.
    /// </typeparam>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public static string GetDescription<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
    {
        Type type = value.GetType();

        if (!type.IsEnum)
        {
            throw new TypeArgumentException("Type argument must be enum.", type);
        }

        var memberInfo = type.GetMember(value.ToString(CultureInfo.InvariantCulture));
        var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
        return ((DescriptionAttribute)attributes[0]).Description;
    }

    /// <summary>
    /// The get attribute.
    /// </summary>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <typeparam name="T">
    /// Enum type
    /// </typeparam>
    /// <typeparam name="TAttribute">
    /// Attribute type.
    /// </typeparam>
    /// <returns>
    /// The <see cref="TAttribute"/>.
    /// </returns>
    public static TAttribute GetAttribute<T, TAttribute>(this T value)
        where T : struct, IComparable, IFormattable, IConvertible
        where TAttribute : Attribute
    {
        Type type = value.GetType();

        if (!type.IsEnum)
        {
            throw new TypeArgumentException("Type argument must be enum.", type);
        }

        var memberInfo = type.GetMember(value.ToString(CultureInfo.InvariantCulture));
        var attributes = memberInfo[0].GetCustomAttributes(typeof(TAttribute), false);
        return (attributes.Length > 0) ? (TAttribute)attributes[0] : null;
    }

    /// <summary>
    /// Gets link attribute value for given enum value.
    /// </summary>
    /// <typeparam name="T">
    /// Enum with link attribute.
    /// </typeparam>
    /// <param name="value">
    /// Enum value.
    /// </param>
    /// <returns>
    /// Link attribute value as <see cref="Link"/>
    /// </returns>
    public static Link GetLink<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
    {
        return value.GetAttribute<T, LinkAttribute>().Value;
    }

    /// <summary>
    /// Converts given enum type values into array.
    /// </summary>
    /// <typeparam name="T">
    /// Enum type.
    /// </typeparam>
    /// <returns>
    /// The <see cref="T:T[]"/>.
    /// </returns>
    /// <exception cref="TypeArgumentException">
    /// Thrown if type argument is not enum.
    /// </exception>
    public static T[] ToArray<T>() where T : struct, IComparable, IFormattable, IConvertible
    {
        Type type = typeof(T);

        if (!type.IsEnum)
        {
            throw new TypeArgumentException("Type argument must be enum.", type);
        }

        return (T[])Enum.GetValues(type);
    }

    /// <summary>
    /// Extracts all enum values having given attribute.
    /// </summary>
    /// <typeparam name="T">
    /// Enum to analyze.
    /// </typeparam>
    /// <param name="attributeType">
    /// Type of attribute enum values must have.
    /// </param>
    /// <returns></returns>
    public static IEnumerable<T> SelectAllWithAttribute<T>(Type attributeType) where T : struct, IComparable, IFormattable, IConvertible
    {
        Type type = typeof(T);

        if (!type.IsEnum)
        {
            throw new TypeArgumentException("Type argument must be enum.", type);
        }

        if (!attributeType.IsSubclassOf(typeof(Attribute)))
        {
            throw new ArgumentException("The argument must be inherited fron attribute class.", nameof(attributeType));
        }

        return type.GetFields(BindingFlags.Public | BindingFlags.Static)
                   .Where(field => field.IsDefined(attributeType, false))
                   .Select(field => (T)field.GetValue(null));
    }
}
