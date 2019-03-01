namespace LibiadaCore.Iterators
{
    using LibiadaCore.Core;

    /// <summary>
    /// Writable iterators interface.
    /// Length of subsequence and shift of iterator should be equals 1.
    /// </summary>
    public interface IWritableIterator : IIterator
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
