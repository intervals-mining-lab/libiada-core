namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability
{
    ///<summary>
    /// Интерыей позволяющие переписывать значение матрицы
    ///</summary>
    public interface IWritebleMatrix
    {
        ///<summary>
        /// Занчение матрицы
        ///</summary>
        double Value { get; set;}
    }
}