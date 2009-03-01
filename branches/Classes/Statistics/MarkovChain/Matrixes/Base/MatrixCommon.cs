using ChainAnalises.Classes.AuxiliaryClasses.DataManipulators.Iterators;
using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain.Builders;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Base;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Base
{
    ///<summary>
    /// ������� ���������� � �������� ��������� ������ �������. 
    /// ����������� ����� 1.
    ///</summary>
    public class MatrixCommon : MatrixBase
    {

        ///<summary>
        /// �����������
        ///</summary>
        ///<param name="alphabet">������� �� ������� ������������ �������</param>
        ///<param name="razmernost">����������� �������</param>
        ///<param name="builder">������� �������� ������</param>
        public MatrixCommon(int powerOfAlphabet, int razmernost, IMatrixBuilder builder)
            : base(powerOfAlphabet, razmernost, builder)
        {
        }

        public override double FrequencyFromObject(int[] indexes)
        {
            if (indexes.Length > 1)
            {
                int[] newIndexes = GetChainLess(indexes);
                return ((MatrixBase)ValueList[indexes[0]]).FrequencyFromObject(newIndexes);
            }else
            {
                return ((MatrixBase)ValueList[indexes[0]]).GetValue();
            }
        }

        protected int[] GetChainLess(int[] indexes)
        {
            int[] newIndexes = new int[indexes.Length - 1];
            for (int i = 0; i < indexes.Length - 1; i++)
            {
                newIndexes[i] = indexes[i + 1];
            }
            return newIndexes;
        }
    }
}