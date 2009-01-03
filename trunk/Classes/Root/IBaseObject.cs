namespace ChainAnalises.Classes.Root
{
    ///<summary>
    ///��������� ���������� ������� ��� ���� (����������� �����) �������� ����������
    ///�������� ��������� ���������� ������� � ������ �� �����.
    ///</summary>
    public interface IBaseObject /*:IXmlSerializable*/
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

        ///<summary>
        ///</summary>
        ///<returns></returns>
     //   object GetDataStruct();
        IBin GetBin();
    }
}