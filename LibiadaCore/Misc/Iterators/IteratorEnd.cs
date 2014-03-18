namespace LibiadaCore.Misc.Iterators
{
    using System;

    using LibiadaCore.Core;

    /// <summary>
    /// Iterator that moves from the end of chain to its beginning.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of returned chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    public class IteratorEnd<TResult, TSource> : IteratorBase<TResult, TSource> 
        where TSource : BaseChain, new() where TResult : BaseChain, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IteratorEnd{TResult,TSource}"/> class.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <param name="length">
        /// Length of subsequence.
        /// </param>
        /// <param name="step">
        /// Shift of iterator.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if one or more arguments are invalid.
        /// </exception>
        public IteratorEnd(TSource source, int length, int step) : base(source, length, step)
        {
        }

        /// <summary>
        /// Moves iterator to the next position.
        /// </summary>
        /// <returns>
        /// Returns false if end of the chain is reached. Otherwise returns true.
        /// </returns>
        public override bool Next()
        {
            this.Position -= this.Step;
            return this.Position >= 0;
        }

        /// <summary>
        /// Returns iterator to the starting position.
        /// Before reading first value 
        /// <see cref="IteratorEnd{TResult, TSource}.Next()"/> 
        /// method should be called.
        /// </summary>
        public override void Reset()
        {
            this.Position = this.Source.Length - this.Length + this.Step;
        }
    }
}