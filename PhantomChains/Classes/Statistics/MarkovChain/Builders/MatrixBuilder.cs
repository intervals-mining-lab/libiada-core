using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;

namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    ///<summary>
    /// ������� �������� ������� ��� ������� ���������� ���������
    ///</summary>
    public class MatrixBuilder : IMatrixBuilder
    {
        ///<summary>
        /// ������� �������.
        ///</summary>
        ///<param name="alphabetPower">�������� ��������</param>
        ///<param name="i">����������� �������</param>
        ///<returns>������� �������</returns>
        public object Create(int alphabetPower, int i)
        {
            switch (i)
            {
                case 0:
                    return (double) 0;
                case 1:
                    return new MatrixRow(alphabetPower, i);
                default:
                    return new Matrix(alphabetPower, i);
            }
        }
    }
}