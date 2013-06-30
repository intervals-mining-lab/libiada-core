using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability
{
    ///<summary>
    /// ������������� �������
    ///</summary>
    public interface IProbabilityMatrix
    {
        ///<summary>
        /// ���������� ������������� ������� �� ������ �������
        ///</summary>
        ///<param name="matrix">������� �� ������� ������������ �����������</param>
        void Fill(IOpenMatrix matrix);

        ///<summary>
        /// ��������� ������� ������������ �������� �� ������
        ///</summary>
        ///<param name="alphabet"></param>
        ///<param name="Pred">�����</param>
        ///<returns>������ ��� "������� - �����������"</returns>
        Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] Pred);
    }
}