namespace Libiada.Core.Extensions;
﻿
using Libiada.Core.Attributes;
using Libiada.Core.Core;
using Libiada.Core.Exceptions;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
    public static string GetDisplayValue<T>(this T value) where T : struct, Enum
    {
        Type type = typeof(T);

        var fieldInfo = type.GetField(value.ToString());

        var descriptionAttributes = fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

        if (descriptionAttributes == null)
        {
            return string.Empty;
        }

        return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
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
    public static string? GetName<T>(this T value) where T : struct, Enum => Enum.GetName<T>(value);

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
    public static string GetDescription<T>(this T value) where T : struct, Enum
    {
        Type type = value.GetType();

        //if (!type.IsEnum)
        //{
        //    throw new TypeArgumentException("Type argument must be enum.", type);
        //}

        var memberInfo = type.GetMember(value.ToString());
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
    public static TAttribute? GetAttribute<T, TAttribute>(this T value)
        where T : struct, Enum
        where TAttribute : Attribute
    {
        Type type = value.GetType();

        //if (!type.IsEnum)
        //{
        //    throw new TypeArgumentException("Type argument must be enum.", type);
        //}

        var memberInfo = type.GetMember(value.ToString());
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
    public static Link GetLink<T>(this T value) where T : struct, Enum => value.GetAttribute<T, LinkAttribute>().Value;


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
    public static IEnumerable<T> SelectAllWithAttribute<T>(Type attributeType) where T : struct, Enum
    {
        Type type = typeof(T);

        //if (!type.IsEnum)
        //{
        //    throw new TypeArgumentException("Type argument must be enum.", type);
        //}

        if (!attributeType.IsSubclassOf(typeof(Attribute)))
        {
            throw new ArgumentException("The argument must be inherited fron attribute class.", nameof(attributeType));
        }

        return type.GetFields(BindingFlags.Public | BindingFlags.Static)
                   .Where(field => field.IsDefined(attributeType, false))
                   .Select(field => (T)field.GetValue(null));
    }
}
