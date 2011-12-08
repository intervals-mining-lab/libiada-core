using ChainAnalises.Classes.Root;

namespace ChainAnalises.Classes.Root
{
    ///<summary>
    /// ��������� Bin �������, ������������� �����
    /// Soap �������� � ������������� �������� ����������.
    ///</summary>
    public interface IBin
    {
        ///<summary>
        /// ������ �� Bin ������� �������������� ��� ������ ����������.
        ///</summary>
        ///<returns></returns>
        IBaseObject GetInstance();
    }
}