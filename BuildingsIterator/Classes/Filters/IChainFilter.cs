namespace BuildingsIterator.Classes.Filters
{
    /// <summary>
    /// �������� ������� �����
    /// </summary>
    public interface IChainFilter
    {
        /// <summary>
        /// ���������� ������� �������� ���������� ���������� ����������
        /// </summary>
        /// <param name="building">
        /// �����
        /// </param>
        /// <returns>
        /// true if chain is valid.
        /// </returns>
        bool IsValid(string building);
    }
}