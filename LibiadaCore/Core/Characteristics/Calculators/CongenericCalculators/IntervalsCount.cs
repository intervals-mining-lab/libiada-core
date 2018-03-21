namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// Intervals count depending on link.
    /// </summary>
    public class IntervalsCount : ICongenericCalculator
    {
        /// <summary>
        /// If link is to start, to end or cycle then intervals count equals elements count.
        /// If link is to start and end then intervals count equals elements count + 1.
        /// If link is none then intervals count equals elements count - 1.
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
        public double Calculate(CongenericChain chain, Link link)
        {
            return chain.GetArrangement(link).Length;
        }
    }
}
