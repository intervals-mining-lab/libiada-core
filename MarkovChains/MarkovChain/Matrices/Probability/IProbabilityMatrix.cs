namespace MarkovChains.MarkovChain.Matrices.Probability
{
    using System.Collections.Generic;

    using LibiadaCore.Core;

    using MarkovChains.MarkovChain.Matrices.Absolute;

    /// <summary>
    /// Вероятностная матрица
    /// </summary>
    public interface IProbabilityMatrix
    {
        /// <summary>
        /// Заполянить вероятностную матрицу из другой матрицы
        /// </summary>
        /// <param name="matrix">Матрица из которой пересчитваем вероятности</param>
        void Fill(IOpenMatrix matrix);

        /// <summary>
        /// Получение вектора вероятностей лежащего по адресу
        /// </summary>
        /// <param name="alphabet">
        /// The alphabet.
        /// </param>
        /// <param name="pred">
        /// Адрес
        /// </param>
        /// <returns>
        /// Список пар "событие - вероятность"
        /// </returns>
        Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] pred);
    }
}
