namespace LibiadaCore.Classes.Root
{
    ///<summary>
    ///��������� ���������� ������� ��� ���� (����������� �����) �������� ����������
    ///�������� ��������� ���������� ������� � ������ �� �����.
    /// ����� ������� ������ ��������� ������ ���������.
    ///</summary>
    public interface IBaseObject
    {
        ///<summary>
        /// ����� ������������ �������
        ///</summary>
        ///<returns>����� ������� �������</returns>
        IBaseObject Clone();

        ///<summary>
        /// ����� ����������� ��������� ���������������
        ///</summary>
        ///<param name="obj">������ c ������� ���������� �������� �� ���������������</param>
        ///<returns>True ���� ������� ������������, ����� false</returns>
        bool Equals(object obj);
    }
}