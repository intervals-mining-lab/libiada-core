namespace PhantomChains.Statistics.MarkovChain.Matrices.Absolute
{
    using global::PhantomChains.Statistics.MarkovChain.Matrices.Probability;

    /// <summary>
    /// The AbsoluteMatrix interface.
    /// </summary>
    public interface IAbsoluteMatrix
    {
        /// <summary>
        /// ����� �������� ��������� ������ �������
        /// </summary>
        double Count { get; }

        /// <summary>
        /// ��������� ������� � ��������� �������
        /// </summary>
        /// <param name="arrayToTeach">
        /// The array to teach.
        /// </param>
        /// <returns>
        /// ����� ������� ������ �������� �� ������� ������
        /// </returns>
        double Add(int[] arrayToTeach);

        /// <summary>
        /// ��������� �������� ������ �������
        /// </summary>
        void IncValue();

        /// <summary>
        ///  �������� ����� �������� �� ������� ������
        /// </summary>
        /// <param name="arrayOfIndexes">����� ���������</param>
        /// <returns>����� ��������� ������� � ������ ��������</returns>
        double Sum(int[] arrayOfIndexes);

        /// <summary>
        /// The probability matrix.
        /// </summary>
        /// <returns>
        /// The <see cref="IProbabilityMatrix"/>.
        /// </returns>
        IProbabilityMatrix ProbabilityMatrix();
    }
}