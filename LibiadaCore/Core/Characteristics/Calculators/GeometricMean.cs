namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Среднегеометрический интервал.
    /// </summary>
    public class GeometricMean : ICalculator
    {
        /// <summary>
        /// Depth characteristic calculator.
        /// </summary>
        private readonly ICalculator depthCalculator = new Depth();

        /// <summary>
        /// Intervals count calculator.
        /// </summary>
        private readonly ICalculator intervalsCount = new IntervalsCount();

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Average geometric of intervals lengths as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            // Считаем в логарифмическом масштабе, чтобы избежать переполнения
            double depth = depthCalculator.Calculate(chain, link);
            double nj = intervalsCount.Calculate(chain, link);

            // возвращаемое значение делогарифмируем
            return Math.Pow(2, depth / nj);
        }

        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Average geometric of intervals lengths as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            // Считаем в логарифмическом масштабе, чтобы избежать переполнения
            double depth = depthCalculator.Calculate(chain, link);
            double nj = intervalsCount.Calculate(chain, link);

            // возвращаемое значение делогарифмируем
            return Math.Pow(2, depth / nj);
        }
    }
}