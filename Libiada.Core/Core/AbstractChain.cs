namespace Libiada.Core.Core;

using System.Text;

using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The abstract chain.
/// </summary>
public abstract class AbstractChain : IBaseObject
{
    /// <summary>
    /// Indexer. Returns element by index.
    /// </summary>
    /// <param name="index">
    /// Index of element.
    /// </param>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public IBaseObject this[int index]
    {
        get => Get(index);

        set => Set(value, index);
    }

    /// <summary>
    /// The length of the sequence.
    /// </summary>
    public abstract int Length { get; }

    /// <summary>
    /// Sets or replaces element in specified position.
    /// </summary>
    /// <param name="item">
    /// Element to set.
    /// </param>
    /// <param name="index">
    /// Position in sequence.
    /// </param>
    public abstract void Set(IBaseObject item, int index);

    /// <summary>
    /// Gets element by index.
    /// Inner implementation of indexer.
    /// </summary>
    /// <param name="index">
    /// Index of element.
    /// </param>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public abstract IBaseObject Get(int index);

    /// <summary>
    /// Removes element from given position.
    /// </summary>
    /// <param name="index">
    /// Index of deleted element.
    /// </param>
    public abstract void RemoveAt(int index);

    /// <summary>
    /// Removes element from given position.
    /// </summary>
    /// <param name="index">
    /// Index of deleted element.
    /// </param>
    public abstract void DeleteAt(int index);

    /// <summary>
    /// Deletes chain (order and alphabet) and creates new empty chain with given length.
    /// </summary>
    /// <param name="length">
    /// New chain length.
    /// </param>
    public abstract void ClearAndSetNewLength(int length);

    /// <summary>
    /// Creates clone of this chain.
    /// </summary>
    /// <returns>
    /// The <see cref="IBaseObject"/>.
    /// </returns>
    public abstract IBaseObject Clone();

    /// <summary>
    /// Converts chain to string.
    /// Empty positions are filled with <see cref="NullValue"/> ('-' symbol).
    /// </summary>
    /// <returns>
    /// The <see cref="string"/>.
    /// </returns>
    public new string ToString()
    {
        return ToString(string.Empty);
    }

    /// <summary>
    /// Converts sequence to string.
    /// </summary>
    /// <param name="delimiter">
    /// Delimiter added between elements.
    /// </param>
    /// <returns>
    /// Sequence as <see cref="string"/>.
    /// </returns>
    public string ToString(string delimiter)
    {
        var length = Length;

        var builder = new StringBuilder(length * 2);

        for (int i = 0; i < length; i++)
        {
            builder.Append(this[i]);
            builder.Append(delimiter);
        }

        return builder.ToString(0, builder.Length - delimiter.Length);
    }

    /// <summary>
    /// Converts sequence to array.
    /// </summary>
    /// <returns>
    /// Sequence as <see cref="T:IBaseObject[]"/>.
    /// </returns>
    public IBaseObject[] ToArray()
    {
        var length = Length;
        var result = new IBaseObject[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = this[i];
        }

        return result;
    }

    /// <summary>
    /// Converts sequence to array.
    /// </summary>
    /// <returns>
    /// Sequence as <see cref="T:IBaseObject[]"/>.
    /// </returns>
    public List<IBaseObject> ToList()
    {
        var length = Length;
        var result = new List<IBaseObject>(length);

        for (int i = 0; i < length; i++)
        {
            result.Add(this[i]);
        }

        return result;
    }
}
