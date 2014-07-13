namespace LibiadaCore.Misc.Iterators
{
    using System;

    using LibiadaCore.Core;

    /// <summary>
    /// Iterator that goes from start of the chain.
    /// </summary>
    public class IteratorStart : IteratorBase
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
        public IteratorStart(AbstractChain source, int length, int step) : base(source, length, step)
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
            this.Position += this.Step;
            return this.Position <= this.MaxPosition;
        }

        /// <summary>
        /// Returns iterator to the starting position.
        /// Before reading first value 
        /// <see cref="IteratorBase.Next()"/> 
        /// method should be called.
        /// </summary>
        public override void Reset()
        {
            this.Position = -this.Step;
        }
    }
}