namespace BuildingsIterator.Filters
{
    /// <summary>
    /// �������� ������� �����.
    /// </summary>
    public interface IChainFilter
    {
        /// <summary>
        /// ���������� ������� �������� ���������� ���������� ����������.
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
