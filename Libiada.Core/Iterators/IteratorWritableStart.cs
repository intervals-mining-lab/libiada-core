namespace Libiada.Core.Iterators;

using Libiada.Core.Core;

/// <summary>
/// Iterator tat moves from the end of chain to its beginning.
/// Is able to write values into chain.
/// </summary>
public class IteratorWritableStart : IteratorStart, IWritableIterator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IteratorWritableStart"/> class.
    /// Iterator returns single element and shifts by one element.
    /// </summary>
    /// <param name="source">
    /// Source chain.
    /// </param>
    public IteratorWritableStart(AbstractChain source) : base(source, 1, 1)
    {
    }

    /// <summary>
    /// Sets a value into current iterator position.
    /// </summary>
    /// <param name="value">
    /// Value to write into current position of iterator.
    /// </param>
    public void WriteValue(IBaseObject value)
    {
        Source.Set(value, Position);
    }
}
