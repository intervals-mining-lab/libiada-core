namespace LibiadaCore.Misc.SpaceReorganizers
{
    using System;

    using LibiadaCore.Core;
    using LibiadaCore.Misc.Iterators;

    /// <summary>
    /// The null cycle space reorganizer.
    /// </summary>
    public class NullCycleSpaceReorganizer : SpaceReorganizer
    {
        // TODO: проверить, нужен ли вообще этот класс и делает ли он то что заявлено.

        /// <summary>
        /// Markov chain level.
        /// </summary>
        private readonly int level;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullCycleSpaceReorganizer"/> class.
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
        /// <see cref="AbstractChain"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if level is less than 0. 
        /// </exception>
        public override AbstractChain Reorganize(AbstractChain source)
        {
            if (level < 0)
            {
                throw new InvalidOperationException("Markov chain level can't be less than 0");
            }

            if (level == 0)
            {
                return source;
            }

            var result = new BaseChain();
            result.ClearAndSetNewLength(source.GetLength() + level);
            for (int i = 0; i < source.GetLength(); i++)
            {
                result[i] = source[i];
            }

            var iterator = new IteratorStart(source, level, 1);
            iterator.Reset();
            iterator.Next();
            AbstractChain addition = iterator.Current();
            for (int i = 0; i < addition.GetLength(); i++)
            {
                result[source.GetLength() + i] = addition[i];
            }

            return result;
        }
    }
}