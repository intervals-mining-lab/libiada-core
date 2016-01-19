namespace LibiadaCore.Misc.Iterators
{
    using System;

    using LibiadaCore.Core;

    /// <summary>
    /// Iterator that goes from start of the chain and reading one element at a time.
    /// </summary>
    public class IteratorSimpleStart 
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
        /// Initializes a new instance of the <see cref="IteratorSimpleStart"/> class.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <param name="step">
        /// Shift of iterator.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown if one or more arguments are invalid.
        /// </exception>
        public IteratorSimpleStart(AbstractChain source, int step)
        {
            if (source == null || source.GetLength() < 1)
            {
                throw new ArgumentException("Sequence for iteration is null or empty.", "source");
            }

            Length = 1;
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
        public bool Next()
        {
            Position += Step;
            return Position <= MaxPosition;
        }

        /// <summary>
        /// Returns current value of iterator.
        /// </summary>
        /// <returns>
        /// Current subsequence.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if current position is invalid.
        /// </exception>
        public virtual IBaseObject Current()
        {
            if (Position < 0 || Position > MaxPosition)
            {
                throw new InvalidOperationException("Current position is out of bounds");
            }

            return Source[Position];
        }

        /// <summary>
        /// Returns iterator to the starting position.
        /// Before reading first value 
        /// <see cref="IteratorBase.Next()"/> 
        /// method should be called.
        /// </summary>
        public void Reset()
        {
            Position = -Step;
        }
    }
}
