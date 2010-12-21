using System.Collections.Generic;
using ChainAnalises.Classes.Root;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute;
using ChainAnalises.Classes.TheoryOfSet;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability
{
    ///<summary>
    /// Вероятностная матрица
    ///</summary>
    public interface IProbabilityMatrix
    {
        ///<summary>
        /// Заполянить вероятностную матрицу из другой матрицы
        ///</summary>
        ///<param name="Matrix">Матрица из которой пересчитваем вероятности</param>
        void Fill(IOpenMatrix Matrix);

        ///<summary>
        /// Получение вектора вероятностей лежащего по адресу
        ///</summary>
        ///<param name="alphabet"></param>
        ///<param name="Pred">Адрес</param>
        ///<returns>Список пар "событие - вероятность"</returns>
        Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] Pred);
    }
}