namespace LibiadaCore.Misc.SpaceReorganizers
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Misc.Iterators;

    /// <summary>
    /// The null cycle space reorganizer.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of result chain.
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain.
    /// </typeparam>
    public class NullCycleSpaceReorganizer<TResult, TSource> : SpaceReorganizer<TResult, TSource> where TResult : BaseChain, new() where TSource : BaseChain, new()
    {
        // TODO: проверить, нужен ли вообще этот класс и делает ли он то что заявлено.

        /// <summary>
        /// Markov chain level.
        /// </summary>
        private readonly int level;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullCycleSpaceReorganizer{TResult,TSource}"/> class.
        /// </summary>
        /// <param name="level">
        /// Level of markov chain.
        /// </param>
        public NullCycleSpaceReorganizer(int level)
        {
            this.level = level;
        }

        /// <summary>
        /// Reorganizes source chain.
        /// </summary>
        /// <param name="source">
        /// Source chain.
        /// </param>
        /// <returns>
        /// <see cref="TResult"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if level is less than 0. 
        /// </exception>
        public override TResult Reorganize(TSource source)
        {
            if (this.level < 0)
            {
                throw new InvalidOperationException("Markov chain level can't be less than 0");
            }

            if (this.level == 0)
            {
                return (TResult)((BaseChain)source);
            }

            var result = new TResult();
            result.ClearAndSetNewLength(source.Length + this.level);
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = source[i];
            }

            var iterator = new IteratorStart<TResult, TSource>(source, this.level, 1);
            iterator.Reset();
            iterator.Next();
            TResult addition = iterator.Current();
            for (int i = 0; i < addition.Length; i++)
            {
                result[source.Length + i] = addition[i];
            }

            return result;
        }
    }
}