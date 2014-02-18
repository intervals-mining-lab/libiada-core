namespace LibiadaCore.Classes.Misc.Iterators
{
    using System;

    using LibiadaCore.Classes.Root;

    /// <summary>
    /// Abstract chain iterator.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of returned chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    public abstract class IteratorBase<TResult, TSource> : IIterator<TResult, TSource> 
        where TResult : BaseChain, new() where TSource : BaseChain, new()
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
        protected readonly TSource Source;

        /// <summary>
        /// Initializes a new instance of the <see cref="IteratorBase{TResult,TSource}"/> class.
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
        public IteratorBase(TSource source, int length, int step)
        {
            if (source == null || length <= 0 || source.Length < length)
            {
                throw new ArgumentException("Недопустимые значения аргументов итератора.");
            }

            Length = length;
            Step = step;
            Source = source;
            MaxPosition = Source.Length - Length; 
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
        public virtual TResult Current()
        {
            if (Position < 0 || Position > MaxPosition)
            {
                throw new InvalidOperationException("Текущая позиция итератора находится за пределами допустимого диапазона");
            }

            var result = new TResult();
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
        /// <see cref="IteratorBase{TResult, TSource}.Next()"/> 
        /// method should be called.
        /// </summary>
        public abstract void Reset();
    }
}