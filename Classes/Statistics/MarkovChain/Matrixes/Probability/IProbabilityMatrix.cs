using System.Collections.Generic;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability
{
    ///<summary>
    /// ������������� �������
    ///</summary>
    public interface IProbabilityMatrix
    {
        ///<summary>
        /// ���������� ������������� ������� �� ������ �������
        ///</summary>
        ///<param name="Matrix">������� �� ������� ������������ �����������</param>
        void Fill(IOpenMatrix Matrix);

        ///<summary>
        /// ��������� ������� ������������ �������� �� ������
        ///</summary>
        ///<param name="alphabet"></param>
        ///<param name="Pred">�����</param>
        ///<returns>������ ��� "������� - �����������"</returns>
        Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] Pred);
    }
}