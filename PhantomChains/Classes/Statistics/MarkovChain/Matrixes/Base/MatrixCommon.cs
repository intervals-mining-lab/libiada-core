using PhantomChains.Classes.Statistics.MarkovChain.Builders;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base
{
    ///<summary>
    /// Матрица содержащая в качестве элементов другие матрицы. 
    /// Размерность более 1.
    ///</summary>
    public class MatrixCommon : MatrixBase
    {

        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="powerOfAlphabet">Мощность алфавита</param>
        ///<param name="dimensionality">размерность матрицы</param>
        ///<param name="builder">Правило создания матриц</param>
        public MatrixCommon(int powerOfAlphabet, int dimensionality, IMatrixBuilder builder)
            : base(powerOfAlphabet, dimensionality, builder)
        {
        }

        public override double FrequencyFromObject(int[] indexes)
        {
            if (indexes.Length > 1)
            {
                int[] newIndexes = GetChainLess(indexes);
                return ((MatrixBase)ValueList[indexes[0]]).FrequencyFromObject(newIndexes);
            }
            return ((MatrixBase)ValueList[indexes[0]]).GetValue();
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