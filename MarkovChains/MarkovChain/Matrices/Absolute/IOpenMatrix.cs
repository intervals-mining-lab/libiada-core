namespace MarkovChains.MarkovChain.Matrices.Absolute
{
    using System.Collections;

    /// <summary>
    /// Интерфейс позволяющий получить доступ к внутренным данным матрицыю
    /// </summary>
    public interface IOpenMatrix
    {
        /// <summary>
        /// Список элементов матрицы
        /// </summary>
        ArrayList ValueList { get; }

        /// <summary>
        /// Размерность матрицы
        /// </summary>
        int Rank { get; }

        /// <summary>
        /// Значение матрицы
        /// </summary>
        double Value { get; }
    }
}