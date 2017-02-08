namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Average arithmetic value of lengths of congeneric intervals in sequence.
    /// </summary>
    public class ArithmeticMean : IFullCalculator
    {
        /// <summary>
        /// Intervals length sum calculator.
        /// </summary>
        private readonly IFullCalculator adder = new IntervalsSum();

        /// <summary>
        /// Intervals count calculator.
        /// </summary>
        private readonly IFullCalculator counter = new IntervalsCount();

        /// <summary>
        /// Calculates multiplication of all intervals
        /// between nearest similar elements in sequence
        /// divided by number of intervals.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of average arithmetic of intervals lengths.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double intervalsSum = adder.Calculate(chain, link);
            int intervalsCount = (int)counter.Calculate(chain, link);
            return intervalsCount == 0 ? 0 : intervalsSum / intervalsCount;
        }
    }
}
