namespace LibiadaCore.Core.Characteristics.Calculators
{
    /// <summary>
    /// Average arithmetic value of lengths of congeneric intervals in sequence.
    /// </summary>
    public class ArithmeticMean : ICalculator
    {
        /// <summary>
        /// Intervals length sum calculator.
        /// </summary>
        private readonly ICalculator adder = new IntervalsSum();

        /// <summary>
        /// Intervals count calculator.
        /// </summary>
        private readonly ICalculator counter = new IntervalsCount();

        /// <summary>
        /// Calculates multiplication of all intervals 
        /// between nearest elements in congeneric sequence
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
        public double Calculate(CongenericChain chain, Link link)
        {
            double sum = adder.Calculate(chain, link);
            int intervalsCount = (int)counter.Calculate(chain, link);
            return intervalsCount == 0 ? 0 : sum / intervalsCount;
        }

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
            double sum = adder.Calculate(chain, link);
            int intervalsCount = (int)counter.Calculate(chain, link);
            return intervalsCount == 0 ? 0 : sum / intervalsCount;
        }
    }
}
