using System.Collections.Generic;

namespace MarkovCompare
{
    /// <summary>
    /// Вычисляет максимум выборки
    /// </summary>
    public class MaxCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// Возвращает максимальное значение выборки
        /// </summary>
        /// <param name="values">Выборка</param>
        /// <returns>Максимум</returns>
        public double Calculate(List<double> values)
        {
            List<double>.Enumerator iter = values.GetEnumerator();
            double max = double.MinValue;
            while (iter.MoveNext())
            {
                if (iter.Current > max)
                    max = iter.Current;
            }
            return max;
        }
    }
}