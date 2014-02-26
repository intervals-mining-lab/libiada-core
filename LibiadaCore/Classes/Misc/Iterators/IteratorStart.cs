namespace LibiadaCore.Classes.Misc.Iterators
{
    using System;

    using Root;

    /// <summary>
    /// Iterator that goes from start of the chain.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of returned chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    public class IteratorStart<TResult, TSource> : IteratorBase<TResult, TSource>
        where TSource : BaseChain, new() where TResult : BaseChain, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IteratorStart{TResult,TSource}"/> class.
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
        public IteratorStart(TSource source, int length, int step) : base(source, length, step)
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
            Position += Step;
            return Position <= MaxPosition;
        }

        /// <summary>
        /// Returns iterator to the starting position.
        /// Before reading first value 
        /// <see cref="IteratorBase{TResult, TSource}.Next()"/> 
        /// method should be called.
        /// </summary>
        public override void Reset()
        {
            Position = -Step;
        }
    }
}