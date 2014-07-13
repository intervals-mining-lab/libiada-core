namespace PhantomChains.Statistics.MarkovChain.Matrices.Probability
{
    using System.Collections.Generic;

    using global::PhantomChains.Statistics.MarkovChain.Matrices.Absolute;

    using LibiadaCore.Core;

    /// <summary>
    /// ������������� �������
    /// </summary>
    public interface IProbabilityMatrix
    {
        /// <summary>
        /// ���������� ������������� ������� �� ������ �������
        /// </summary>
        /// <param name="matrix">������� �� ������� ������������ �����������</param>
        void Fill(IOpenMatrix matrix);

        /// <summary>
        /// ��������� ������� ������������ �������� �� ������
        /// </summary>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        /// <param name="pred">
        /// �����
        /// </param>
        /// <returns>
        /// ������ ��� "������� - �����������"
        /// </returns>
        Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] pred);
    }
}