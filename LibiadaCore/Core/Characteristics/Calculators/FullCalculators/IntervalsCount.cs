namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Intervals count depending on link.
    /// </summary>
    public class IntervalsCount : IFullCalculator
    {
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
        /// Intervals count in chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            double sum = 0;
            var calculator = new CongenericCalculators.IntervalsCount();

            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                sum += calculator.Calculate(chain.CongenericChain(i), link);
            }

            return (int)sum;
        }
    }
}
