using System;
using PhantomChains.Classes.Statistics.MarkovChain.Builders;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Base
{
    ///<summary>
    /// Матрица-строка содержит вещетвенные числа в качестве элементов. 
    /// Размерность = 1.
    ///</summary>
    public class MatrixRowCommon:MatrixBase
    {
        ///<summary>
        /// Конструктор
        ///</summary>
        ///<param name="powerOfAlphabet">Мощность алфавита</param>
        ///<param name="dimensionality">размерность матрицы</param>
        ///<param name="builder">Правило создания матриц</param>
        public MatrixRowCommon(int powerOfAlphabet, int dimensionality, IMatrixBuilder builder)
            : base(powerOfAlphabet, dimensionality, builder)
        {
        }

        public override double FrequencyFromObject(int[] indexes)
        {
            if (indexes == null)
            {
                throw new Exception("Ошибка адресации");
            }
            return (double) ValueList[indexes[0]];
        }
    }
}