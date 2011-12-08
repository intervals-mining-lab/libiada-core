using System.Collections.Generic;

namespace MarkovCompare
{
    /// <summary>
    /// Вычисляет миниум выборки
    /// </summary>
    public class MinCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// Вычисляет минимальное значение выборки
        /// </summary>
        /// <param name="values">Выборка</param>
        /// <returns>Минимальное значение</returns>
        public double Calculate(List<double> values)
        {
            List<double>.Enumerator iter = values.GetEnumerator();
            double min = double.MaxValue;
            while (iter.MoveNext())
            {
                if (iter.Current < min)
                    min = iter.Current;
            }
            return min;
        }
    }
}