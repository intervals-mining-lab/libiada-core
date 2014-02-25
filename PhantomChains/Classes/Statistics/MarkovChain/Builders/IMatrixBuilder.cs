namespace PhantomChains.Classes.Statistics.MarkovChain.Builders
{
    /// <summary>
    /// Интерфейс для правила создания матриц.
    /// </summary>
    public interface IMatrixBuilder
    {
        /// <summary>
        ///  Создает элемент матрицы 
        /// </summary>
        /// <param name="alphabetCardinality">
        /// Alphabet cardinality.
        /// </param>
        /// <param name="i">
        /// Размерность создавемого элемента
        /// </param>
        /// <returns>
        /// Объект присваеваемый в качетсве элемента матрице
        /// </returns>
        object Create(int alphabetCardinality, int i);
    }
}