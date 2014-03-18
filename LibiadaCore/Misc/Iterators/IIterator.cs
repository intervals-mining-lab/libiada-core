namespace LibiadaCore.Misc.Iterators
{
    using LibiadaCore.Core;

    /// <summary>
    /// Interface of chain iterators.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of returned chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    public interface IIterator<out TResult, TSource>
        where TResult : BaseChain, new() where TSource : BaseChain, new()
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
        TResult Current();

        /// <summary>
        /// Returns iterator to the starting position.
        /// Before reading first value 
        /// <see cref="IIterator{TResult, TSource}.Next()"/> 
        /// method should be called.
        /// </summary>
        void Reset();
    }
}