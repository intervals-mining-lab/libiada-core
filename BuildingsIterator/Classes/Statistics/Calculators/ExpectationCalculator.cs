namespace BuildingsIterator.Classes.Statistics.Calculators
{
    using System.Collections.Generic;

    /// <summary>
    /// Класс-калюкулятор для вычисления математического ожидания выборки
    /// </summary>
    public class ExpectationCalculator : IOnePicksCalculator
    {
        /// <summary>
        /// Вычисление математического ожидания
        /// </summary>
        /// <param name="values">
        /// Статистическая выборка
        /// </param>
        /// <returns>
        /// Математическое ожидание
        /// </returns>
        public double Calculate(List<double> values)
        {
            return (new StartingPointCalculator(1)).Calculate(values);
        }
    }
}