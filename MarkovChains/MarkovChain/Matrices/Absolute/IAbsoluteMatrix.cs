namespace MarkovChains.MarkovChain.Matrices.Absolute
{
    using MarkovChains.MarkovChain.Matrices.Probability;

    /// <summary>
    /// The AbsoluteMatrix interface.
    /// </summary>
    public interface IAbsoluteMatrix
    {
        /// <summary>
        /// Сумма значений элементов данной матрицы
        /// </summary>
        double Count { get; }

        /// <summary>
        /// Добавляем элемент в частотный словарь
        /// </summary>
        /// <param name="arrayToTeach">
        /// The array to teach.
        /// </param>
        /// <returns>
        /// Число которое теперь хранится по данному адресу
        /// </returns>
        double Add(int[] arrayToTeach);

        /// <summary>
        /// Увеличить занчение данной матрицы
        /// </summary>
        void IncValue();

        /// <summary>
        ///  Получить сумму элеметов по данному адресу
        /// </summary>
        /// <param name="arrayOfIndexes">Адрес элементов</param>
        /// <returns>Сумма элементов матрицы с данным адрессом</returns>
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
