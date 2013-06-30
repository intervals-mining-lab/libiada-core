using System.Collections;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute
{
    ///<summary>
    /// ��������� ����������� �������� ������ � ���������� ������ ��������
    ///</summary>
    public interface IOpenMatrix
    {
        ///<summary>
        /// ������ ��������� �������
        ///</summary>
        ArrayList ValueList { get;}

        ///<summary>
        /// ����������� �������
        ///</summary>
        int Rank{ get;}

        ///<summary>
        /// �������� �������
        ///</summary>
        double Value{ get;}
    }
}