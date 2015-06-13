namespace LibiadaCore.Misc.Iterators
{
    using System;

    using LibiadaCore.Core;

    /// <summary>
    /// Abstract chain iterator.
    /// </summary>
    public abstract class IteratorBase : IIterator
    {
        /// <summary>
        /// Length of subsequence.
        /// </summary>
        protected readonly int Length;

        /// <summary>
        /// Shift of iterator.
        /// </summary>
        protected readonly int Step;

        /// <summary>
        /// Source chain.
        /// </summary>
        protected readonly AbstractChain Source;

        /// <summary>
        /// Initializes a new instance of the <see cref="IteratorBase"/> class.
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
        public IteratorBase(AbstractChain source, int length, int step)
        {
            if (source == null || length <= 0 || source.GetLength() < length)
            {
                throw new ArgumentException("Iterator arguments are invalid.");
            }

            Length = length;
            Step = step;
            Source = source;
            MaxPosition = Source.GetLength() - Length; 
            Reset();
        }

        /// <summary>
        /// Gets or sets current position of iterator.
        /// </summary>
        public int Position { get; protected set; }

        /// <summary>
        /// Gets max position of iterator.
        /// </summary>
        protected int MaxPosition { get; private set; }

        /// <summary>
        /// Moves iterator to the next position.
        /// </summary>
        /// <returns>
        /// Returns false if end of the chain is reached. Otherwise returns true.
        /// </returns>
        public abstract bool Next();

        /// <summary>
        /// Returns current value of iterator.
        /// </summary>
        /// <returns>
        /// Current subsequence.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if current position is invalid.
        /// </exception>
        public virtual AbstractChain Current()
        {
            if (Position < 0 || Position > MaxPosition)
            {
                throw new InvalidOperationException("Iterator position is out of range.");
            }

            var result = new BaseChain();
            result.ClearAndSetNewLength(Length);

            for (int i = 0; i < Length; i++)
            {
                result[i] = Source[Position + i];
            }

            return result;
        }

        /// <summary>
        /// Returns iterator to the starting position.
        /// Before reading first value 
        /// <see cref="IteratorBase.Next()"/> 
        /// method should be called.
        /// </summary>
        public abstract void Reset();
    }
}
