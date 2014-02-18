namespace LibiadaCore.Classes.Misc.Iterators
{
    using LibiadaCore.Classes.Root;

    /// <summary>
    /// Writable iterators interface.
    /// Length of subsequence and shift of iterator should be equals 1.
    /// </summary>
    /// <typeparam name="TResult">
    /// Type of returned chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    /// <typeparam name="TSource">
    /// Type of source chain (inherits <see cref="BaseChain"/> and has constructor without parameters).
    /// </typeparam>
    public interface IWritableIterator<out TResult, TSource> : IIterator<TResult, TSource> 
        where TResult : BaseChain, new() where TSource : BaseChain, new()
    {

        /// <summary>
        /// Sets a value into current iterator position.
        /// </summary>
        /// <param name="value">
        /// Value to write into current position of iterator.
        /// </param>
        void WriteValue(IBaseObject value);
    }
}