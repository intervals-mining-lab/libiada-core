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
        ///<param name="alphabetPower">Мощность алфавита</param>
        ///<param name="i">Размерность матрицы</param>
        ///<returns>Элемент матрицы</returns>
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