namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Periodicity.
    /// Makes sense only for congeneric sequences.
    /// </summary>
    public class Periodicity : IFullCalculator
    {
        /// <summary>
        /// Average geometric interval calculator.
        /// </summary>
        private readonly IFullCalculator geometricMeanCalculator = new GeometricMean();

        /// <summary>
        /// Average arithmetic interval calculator.
        /// </summary>
        private readonly IFullCalculator arithmeticMeanCalculator = new ArithmeticMean();

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
        /// Periodicity as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            var geometricMean = geometricMeanCalculator.Calculate(chain, link);
            var arithmeticMean = arithmeticMeanCalculator.Calculate(chain, link);
            return arithmeticMean == 0 ? 0 : geometricMean / arithmeticMean;
        }
    }
}
