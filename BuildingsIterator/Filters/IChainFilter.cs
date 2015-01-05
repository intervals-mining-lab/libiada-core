namespace BuildingsIterator.Filters
{
    /// <summary>
    /// Интерфес фильтра цепей.
    /// </summary>
    public interface IChainFilter
    {
        /// <summary>
        /// Возвращает булевое значение валидности результата фильтрации.
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
