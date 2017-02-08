namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Sum of intervals lengths depending on link.
    /// </summary>
    public class IntervalsSum : IFullCalculator
    {
        /// <summary>
        /// Sum of intervals lengths in all congeneric sequences of complete sequence.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Link of intervals in chain.
        /// </param>
        /// <returns>
        /// Intervals sum as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double sum = 0;
            var calculator = new CongenericCalculators.IntervalsSum();

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                sum += calculator.Calculate(chain.CongenericChain(i), link);
            }

            return sum;
        }
    }
}
