using System.Collections;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute
{
    ///<summary>
    /// Интерфейс позволяющий получить доступ к внутренным данным матрицыю
    ///</summary>
    public interface IOpenMatrix
    {
        ///<summary>
        /// Список элементов матрицы
        ///</summary>
        ArrayList ValueList { get;}

        ///<summary>
        /// Размерность матрицы
        ///</summary>
        int rang{ get;}

        ///<summary>
        /// Значение матрицы
        ///</summary>
        double Value{ get;}
    }
}