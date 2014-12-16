namespace BuildingsIterator.Statistics.Calculators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Вычисляет начальный i-й момент выбоки
    /// </summary>
    public class StartingPointCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// Порядок момента
        /// </summary>
        private readonly int s = 1;

        /// <summary>
        /// Конструктор калькулятора вычисляющего начальный момент выборки
        /// </summary>
        /// <param name="i">Порядок момента</param>
        public StartingPointCalculator(int i)
        {
            s = i;
        }

        /// <summary>
        /// Метод вычисления начального момента выборки
        /// </summary>
        /// <param name="values">Выборка</param>
        /// <returns>Начальный момент</returns>
        public double Calculate(List<double> values)
        {
            double sum = 0;
            for (int i = 0; i < values.Count; i++)
            {
                sum += Math.Pow(values[i], s);
            }

            sum /= values.Count;
            return sum;
        }
    }
}