namespace LibiadaCore.Misc.Iterators
{
    using System;

    using LibiadaCore.Core;

    /// <summary>
    /// Iterator tat moves from the end of chain to its beginning.
    /// Is able to write values into chain.
    /// </summary>
    public class IteratorWritableEnd : IteratorEnd, IWritableIterator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IteratorWritableEnd"/> class.
        /// Iterator returns single element and shifts by one element.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if one or more arguments are invalid.
        /// </exception>
        public IteratorWritableEnd(AbstractChain source) : base(source, 1, 1)
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
            Source.Add(value, Position);
        }
    }
}