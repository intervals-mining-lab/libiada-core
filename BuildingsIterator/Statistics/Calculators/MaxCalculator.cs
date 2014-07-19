namespace BuildingsIterator.Statistics.Calculators
{
    using System.Collections.Generic;

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
            List<double>.Enumerator iterator = values.GetEnumerator();
            double max = double.MinValue;
            while (iterator.MoveNext())
            {
                if (iterator.Current > max)
                {
                    max = iterator.Current;
                }
            }

            return max;
        }
    }
}