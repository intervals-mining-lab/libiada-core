namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Average arithmetic value of lengths of congeneric intervals in sequence.
    /// </summary>
    public class ArithmeticMean : IFullCalculator
    {
        /// <summary>
        /// Calculates multiplication of all intervals
        /// between nearest similar elements in sequence
        /// divided by number of intervals.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in sequence.
        /// </param>
        /// <returns>
        /// <see cref="double"/> value of average arithmetic of intervals lengths.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            var adder = new IntervalsSum();
            var counter = new IntervalsCount();

            double intervalsSum = adder.Calculate(chain, link);
            var intervalsCount = (int)counter.Calculate(chain, link);
            return intervalsCount == 0 ? 0 : intervalsSum / intervalsCount;
        }
    }
}
