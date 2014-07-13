namespace LibiadaCore.Misc.Iterators
{
    using System;

    using LibiadaCore.Core;

    /// <summary>
    /// Abstract chain iterator.
    /// </summary>
    public abstract class IteratorBase: IIterator
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
                throw new ArgumentException("Недопустимые значения аргументов итератора.");
            }

            this.Length = length;
            this.Step = step;
            this.Source = source;
            this.MaxPosition = this.Source.GetLength() - this.Length; 
            this.Reset();
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
            if (this.Position < 0 || this.Position > this.MaxPosition)
            {
                throw new InvalidOperationException("Текущая позиция итератора находится за пределами допустимого диапазона");
            }

            var result = new BaseChain();
            result.ClearAndSetNewLength(this.Length);

            for (int i = 0; i < this.Length; i++)
            {
                result[i] = this.Source[this.Position + i];
            }

            return result;
        }

        /// <summary>
        /// Returns iterator to the starting position.
        /// Before reading first value 
        /// <see cref="IteratorBase{TResult, TSource}.Next()"/> 
        /// method should be called.
        /// </summary>
        public abstract void Reset();
    }
}