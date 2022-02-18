namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Periodicity.
    /// TODO: check if it makes sense only for congeneric sequences.
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
        /// Link of intervals in sequence.
        /// </param>
        /// <returns>
        /// Periodicity as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double geometricMean = geometricMeanCalculator.Calculate(chain, link);
            double arithmeticMean = arithmeticMeanCalculator.Calculate(chain, link);
            return arithmeticMean == 0 ? 0 : geometricMean / arithmeticMean;
        }
    }
}
