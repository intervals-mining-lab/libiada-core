namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    using global::PhantomChains.Classes.Statistics.MarkovChain.Matrices.Absolute;

    /// <summary>
    /// Правило создания матрицы для матрицы абсолютных заначений
    /// </summary>
    public class MatrixBuilder : IMatrixBuilder
    {
        /// <summary>
        /// Создать матрицу.
        /// </summary>
        /// <param name="alphabetCardinality">
        /// Мощность алфавита
        /// </param>
        /// <param name="i">
        /// Размерность матрицы
        /// </param>
        /// <returns>
        /// Элемент матрицы
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