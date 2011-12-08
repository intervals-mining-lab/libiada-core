using System.Collections;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute
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
        int rang{ get;}

        ///<summary>
        /// �������� �������
        ///</summary>
        double Value{ get;}
    }
}