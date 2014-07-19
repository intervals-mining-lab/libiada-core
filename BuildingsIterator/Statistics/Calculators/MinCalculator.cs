namespace BuildingsIterator.Statistics.Calculators
{
    using System.Collections.Generic;

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
            List<double>.Enumerator iterator = values.GetEnumerator();
            double min = double.MaxValue;
            while (iterator.MoveNext())
            {
                if (iterator.Current < min)
                {
                    min = iterator.Current;
                }
            }

            return min;
        }
    }
}