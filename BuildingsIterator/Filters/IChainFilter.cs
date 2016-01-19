namespace BuildingsIterator.Filters
{
    /// <summary>
    /// Interface of sequences filter.
    /// </summary>
    public interface IChainFilter
    {
        /// <summary>
        /// Checks if building fits the filtering criteria.
        /// </summary>
        /// <param name="building">
        /// Building to check.
        /// </param>
        /// <returns>
        /// True if chain is valid.
        /// </returns>
        bool IsValid(string building);
    }
}
