namespace LibiadaCore.Misc.Iterators
{
    using LibiadaCore.Core;

    /// <summary>
    /// Interface of chain iterators.
    /// </summary>
    public interface IIterator
    {
        /// <summary>
        /// Moves iterator to the next position.
        /// </summary>
        /// <returns>
        /// Returns false if end of the chain is reached. Otherwise returns true.
        /// </returns>
        bool Next();

        /// <summary>
        /// Returns current value of iterator.
        /// </summary>
        /// <returns>
        /// Current subsequence.
        /// </returns>
        AbstractChain Current();

        /// <summary>
        /// Returns iterator to the starting position.
        /// Before reading first value 
        /// <see cref="IIterator.Next()"/> 
        /// method should be called.
        /// </summary>
        void Reset();
    }
}
