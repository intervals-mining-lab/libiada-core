namespace LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators
{
    /// <summary>
    /// Probability (frequency).
    /// </summary>
    public class Probability : ICongenericCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// Frequency of element in congeneric chain as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            var count = new ElementsCount();
            var length = new Length();

            return count.Calculate(chain, link) / length.Calculate(chain, link);
        }
    }
}
