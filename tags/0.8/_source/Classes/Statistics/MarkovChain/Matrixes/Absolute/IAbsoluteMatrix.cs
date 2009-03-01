using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute
{
    ///<summary>
    ///</summary>
    public interface IAbsoluteMatrix
    {
        /// <summary>
        /// ��������� ������� � ��������� �������
        /// </summary>
        /// <returns>����� ������� ������ �������� �� ������� ������</returns>
        double Add(int[] arrayToTeach);

        ///<summary>
        /// ����� �������� ��������� ������ �������
        ///</summary>
        double Count { get; }

        ///<summary>
        /// ��������� �������� ������ �������
        ///</summary>
        void IncValue();

        ///<summary>
        /// �������� ����� �������� �� ������� ������
        ///</summary>
        ///<param name="pred">����� ���������</param>
        ///<returns>����� ��������� ������� � ������ ��������</returns>
        double Sum(int[] arrayOfIndexes);

        IProbabilityMatrix ProbabilityMatrix();
    }
}