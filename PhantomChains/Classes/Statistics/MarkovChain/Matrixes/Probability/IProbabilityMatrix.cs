using System.Collections.Generic;
using LibiadaCore.Classes.Root;
using LibiadaCore.Classes.TheoryOfSet;
using PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Absolute;

namespace PhantomChains.Classes.Statistics.MarkovChain.Matrixes.Probability
{
    ///<summary>
    /// Вероятностная матрица
    ///</summary>
    public interface IProbabilityMatrix
    {
        ///<summary>
        /// Заполянить вероятностную матрицу из другой матрицы
        ///</summary>
        ///<param name="matrix">Матрица из которой пересчитваем вероятности</param>
        void Fill(IOpenMatrix matrix);

        ///<summary>
        /// Получение вектора вероятностей лежащего по адресу
        ///</summary>
        ///<param name="alphabet"></param>
        ///<param name="Pred">Адрес</param>
        ///<returns>Список пар "событие - вероятность"</returns>
        Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] Pred);
    }
}