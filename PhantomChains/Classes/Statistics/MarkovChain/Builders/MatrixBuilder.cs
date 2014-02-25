namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    using global::PhantomChains.Classes.Statistics.MarkovChain.Matrices.Absolute;

    /// <summary>
    /// ������� �������� ������� ��� ������� ���������� ���������
    /// </summary>
    public class MatrixBuilder : IMatrixBuilder
    {
        /// <summary>
        /// ������� �������.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// �������� ��������
        /// </param>
        /// <param name="i">
        /// ����������� �������
        /// </param>
        /// <returns>
        /// ������� �������
        /// </returns>
        public object Create(int alphabetCardinality, int i)
        {
            switch (i)
            {
                case 0:
                    return (double)0;
                case 1:
                    return new MatrixRow(alphabetCardinality, i);
                default:
                    return new Matrix(alphabetCardinality, i);
            }
        }
    }
}