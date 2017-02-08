namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// Elements count.
    /// </summary>
    public class ElementsCount : ICongenericCalculator
    {
        /// <summary>
        /// Amount of not empty positions,
        /// in other words elements count.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// Elements count in chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return chain.OccurrencesCount;
        }
    }
}
