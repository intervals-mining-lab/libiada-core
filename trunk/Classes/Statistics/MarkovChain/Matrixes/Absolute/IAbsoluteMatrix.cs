using ChainAnalises.Classes.IntervalAnalysis;
using ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Probability;

namespace ChainAnalises.Classes.Statistics.MarkovChain.Matrixes.Absolute
{
    ///<summary>
    ///</summary>
    public interface IAbsoluteMatrix
    {
        /// <summary>
        /// Добавляем элемент в частотный словарь
        /// </summary>
        /// <returns>Число которое теперь хранится по данному адресу</returns>
        double Add(int[] arrayToTeach);

        ///<summary>
        /// Сумма значений элементов данной матрицы
        ///</summary>
        double Count { get; }

        ///<summary>
        /// Увеличить занчение данной матрицы
        ///</summary>
        void IncValue();

        ///<summary>
        /// Получить сумму элеметов по данному адресу
        ///</summary>
        ///<param name="pred">Адрес элементов</param>
        ///<returns>Сумма элементов матрицы с данным адрессом</returns>
        double Sum(int[] arrayOfIndexes);

        IProbabilityMatrix ProbabilityMatrix();
    }
}