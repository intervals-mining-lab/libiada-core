namespace LibiadaCore.Misc.Iterators
{
    using System;

    using LibiadaCore.Core;

    /// <summary>
    /// Iterator tat moves from the end of chain to its beginning.
    /// Is able to write values into chain.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of returned chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    public class IteratorWritableEnd<TResult, TSource> : IteratorEnd<TResult, TSource>, IWritableIterator<TResult, TSource>   
        where TSource : BaseChain, new() where TResult : BaseChain, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IteratorWritableEnd{TResult,TSource}"/> class.
        /// Iterator returns single element and shifts by one element.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if one or more arguments are invalid.
        /// </exception>
        public IteratorWritableEnd(TSource source) : base(source, 1, 1)
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
            this.Source.Add(value, this.Position);
        }
    }
}