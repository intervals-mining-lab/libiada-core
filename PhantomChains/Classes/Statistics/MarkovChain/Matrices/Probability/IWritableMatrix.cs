namespace PhantomChains.Classes.Statistics.MarkovChain.Matrices.Probability
{
    /// <summary>
    /// Интерыей позволяющие переписывать значение матрицы
    /// </summary>
    public interface IWritableMatrix
    {
        /// <summary>
        /// Занчение матрицы
        /// </summary>
        double Value { get; set;}
    }
}