﻿namespace Libiada.Core.Extensions;

/// <summary>
/// Class containing extension methods for string class.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Trims given substring from the end of current string if any.
    /// </summary>
    /// <param name="source">
    /// Current string.
    /// </param>
    /// <param name="value">
    /// Substring to be removed.
    /// </param>
    /// <returns>
    /// Trimmed from the end string as <see cref="string"/>.
    /// </returns>
    public static string TrimEnd(this string source, string value)
    {
        if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(value) || !source.EndsWith(value))
        {
            return source;
        }

        return source.Remove(source.LastIndexOf(value));
    }

    /// <summary>
    /// Gets largest repeating substring
    /// or whole string if there is no repeating substrings.
    /// </summary>
    /// <param name="source">
    /// The source string.
    /// </param>
    /// <returns>
    /// The repeating substring as <see cref="string"/>.
    /// </returns>
    public static string GetLargestRepeatingSubstring(this string source)
    {
        string trimmedSource = source.Trim();
        for (int i = 1; i < trimmedSource.Length; i++)
        {
            string substring = trimmedSource.Substring(0, i);
            string sourceWithoutSubstring = source.Replace(substring, string.Empty);
            if (string.IsNullOrWhiteSpace(sourceWithoutSubstring))
            {
                return substring;
            }
        }

        return source;
    }

    /// <summary>
    /// The is subset of.
    /// </summary>
    /// <param name="first">
    /// The first.
    /// </param>
    /// <param name="second">
    /// The second.
    /// </param>
    /// <returns>
    /// The <see cref="bool"/>.
    /// </returns>
    public static bool IsSubsetOf(this string first, string second)
    {
        string[] words = first.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        return words.All(second.Contains);
    }

    /// <summary>
    /// Converts current string to given enum value.
    /// </summary>
    /// <typeparam name="T">
    /// Enum type.
    /// </typeparam>
    /// <param name="value">
    /// Current value.
    /// </param>
    /// <returns>
    /// Value of the given enum type.
    /// </returns>
    /// <exception cref="System.ArgumentException">
    /// Thrown if invalid string representation of enum value is gprovided.
    /// </exception>
    public static T ToEnum<T>(this string value) where T : struct, IComparable, IFormattable, IConvertible
    {
        ArgumentException.ThrowIfNullOrEmpty(value);

        if (!Enum.TryParse<T>(value, true, out T result))
            throw new ArgumentException($"Invalind enum value. Enum: {typeof(T).FullName}, value: {value}.", nameof(value));

        return result;
    }
}
