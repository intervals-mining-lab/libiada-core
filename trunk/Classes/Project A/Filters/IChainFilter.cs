namespace MarkovCompare
{
    ///<summary>
    /// �������� ������� �����
    ///</summary>
    public interface IChainFilter
    {
        ///<summary>
        /// ���������� ������� �������� ���������� ���������� ����������
        ///</summary>
        ///<param name="building">�����</param>
        ///<returns></returns>
        bool IsValid(string building);
    }
}