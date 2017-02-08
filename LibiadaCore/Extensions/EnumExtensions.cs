namespace LibiadaCore.Extensions
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using LibiadaCore.Exceptions;

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
                throw new TypeArgumentException("Type argument must be enum.");
            }

            var fieldInfo = type.GetField(value.ToString(CultureInfo.InvariantCulture));

            var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

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
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="TypeArgumentException">
        /// Thrown if type argument is not enum.
        /// </exception>
        public static string GetName<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
        {
            Type type = typeof(T);

            if (!type.IsEnum)
            {
                throw new TypeArgumentException("Type argument must be enum.");
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
                throw new TypeArgumentException("Type argument must be enum.");
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
                throw new TypeArgumentException("Type argument must be enum.");
            }

            var memberInfo = type.GetMember(value.ToString(CultureInfo.InvariantCulture));
            var attributes = memberInfo[0].GetCustomAttributes(typeof(TAttribute), false);
            return (attributes.Length > 0) ? (TAttribute)attributes[0] : null;
        }
    }
}
