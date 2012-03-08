using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;

namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    ///<summary>
    /// Правило создания матрицы для матрицы абсолютных заначений
    ///</summary>
    public class MatrixBuilder : IMatrixBuilder
    {
        ///<summary>
        /// Создать матрицу.
        ///</summary>
        ///<param name="powerOfAlphabet">Мощность алфавита</param>
        ///<param name="i">Размерность матрицы</param>
        ///<returns>Элемент матрицы</returns>
        public object Create(int powerOfAlphabet, int i)
        {
            switch (i)
            {
                case 0:
                    return (double) 0;
                case 1:
                    return new MatrixRow(powerOfAlphabet, i);
                default:
                    return new Matrix(powerOfAlphabet, i);
            }
        }
    }
}