namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    /// <summary>
    /// ��������� ��� ������� �������� ������.
    /// </summary>
    public interface IMatrixBuilder
    {
        /// <summary>
        ///  ������� ������� ������� 
        /// </summary>
        /// <param name="alphabetCardinality">
        /// Alphabet cardinality.
        /// </param>
        /// <param name="i">
        /// ����������� ����������� ��������
        /// </param>
        /// <returns>
        /// ������ ������������� � �������� �������� �������
        /// </returns>
        object Create(int alphabetCardinality, int i);
    }
}