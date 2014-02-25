namespace PhantomChains.Classes.Statistics.MarkovChain.Matrices.Probability
{
    using System.Collections.Generic;

    using LibiadaCore.Classes.Root;

    using global::PhantomChains.Classes.Statistics.MarkovChain.Matrices.Absolute;

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