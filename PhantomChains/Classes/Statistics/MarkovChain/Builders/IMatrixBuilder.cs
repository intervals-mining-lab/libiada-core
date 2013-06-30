namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    ///<summary>
    /// ��������� ��� ������� �������� ������.
    ///</summary>
    public interface IMatrixBuilder
    {
        /// <summary>
        ///  ������� ������� ������� 
        /// </summary>
        /// <param name="alphabetPower"></param>
        /// <param name="i">����������� ����������� ��������</param>
        /// <returns>������ ������������� � �������� �������� �������</returns>
        object Create(int alphabetPower, int i);
    }
}