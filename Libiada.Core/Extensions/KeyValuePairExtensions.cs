namespace Libiada.Core.Extensions;

using System.Collections.Generic;

/// <summary>
/// Extensions for the KeyValuePair class.
/// </summary>
public static class KeyValuePairExtensions
{
    /// <summary>
    /// Allows deconstruction of KeyValuePair
    /// for example in foreach.
    /// </summary>
    /// <param name="source">
    /// The source.
    /// </param>
    /// <param name="key">
    /// The key.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    /// <typeparam name="TKey">
    /// Key is mapped into Item1.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// Value is mapped into Item2.
    /// </typeparam>
    public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> source, out TKey key, out TValue value)
    {
        key = source.Key;
        value = source.Value;
    }
}
