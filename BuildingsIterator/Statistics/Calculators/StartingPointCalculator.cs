namespace BuildingsIterator.Statistics.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Вычисляет начальный i-й момент выбоки.
    /// </summary>
    public class StartingPointCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// Порядок момента.
        /// </summary>
        private readonly int s = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartingPointCalculator" /> class.
        /// </summary>
        /// <param name="i">
        /// Порядок момента.
        /// </param>
        public StartingPointCalculator(int i)
        {
            s = i;
        }

        /// <summary>
        /// Метод вычисления начального момента выборки.
        /// </summary>
        /// <param name="sample">
        /// Выборка.
        /// </param>
        /// <returns>
        /// Начальный момент.
        /// </returns>
        public double Calculate(List<double> sample)
        {
            double sum = 0;
            for (int i = 0; i < sample.Count; i++)
            {
                sum += Math.Pow(sample[i], s);
            }

            sum /= sample.Count;
            return sum;
        }
    }
}
