namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System.Collections.Generic;

    using LibiadaCore.Core.IntervalsManagers;

    /// <summary>
    /// Абстрактный класс в который вынесен общий 
    /// для всех бинарных калькуляторов 
    /// метод вычисления всех зависимостей цепочки
    /// </summary>
    public abstract class BinaryCalculator : IBinaryCalculator
    {
        /// <summary>
        /// Метод вычисления характеристики для пары элементов.
        /// </summary>
        /// <param name="manager">
        /// Intervals manager.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Значение характеристики
        /// </returns>
        public abstract double Calculate(BinaryIntervalsManager manager, Link link);

        /// <summary>
        /// Метод возвращает полную матрицу характеристик для всех пар элементов цепи.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Квадратная матрица значений характеристики
        /// </returns>
        public List<List<double>> CalculateAll(Chain chain, Link link)
        {
            var result = new List<List<double>>();
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < chain.Alphabet.Cardinality; j++)
                {
                    result[i].Add(this.Calculate(chain.GetRelationIntervalsManager(i + 1, j + 1), link));
                }
            }

            return result;
        }
    }
}