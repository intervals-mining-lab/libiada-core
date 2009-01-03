using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Builders
{
    ///<summary>
    /// Интерфейс для правила создания матриц.
    ///</summary>
    public interface IMatrixBuilder
    {
        ///<summary>
        /// Создает элемент матрицы 
        ///</summary>
        ///<param name="alph">Алфавит используемый в случае создания матриц в качетсве элементов</param>
        ///<param name="i">Размерность создавемого элемента</param>
        ///<returns>Объект присваеваемый в качетсве элемента матрице</returns>
        object Create(int powerOfAlphabet, int i);
    }
}