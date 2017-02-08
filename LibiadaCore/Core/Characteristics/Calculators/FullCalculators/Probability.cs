namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Probability (frequency).
    /// </summary>
    public class Probability : IFullCalculator
    {
        /// <summary>
        /// For complete (full) sequence always equals 1.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <returns>
        /// if chain is full then 1, otherwise percent of filled positions as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            var calculator = new CongenericCalculators.Probability();

            double result = 0;
            for (int i = 0; i < chain.Alphabet.Cardinality; i++)
            {
                result += calculator.Calculate(chain.CongenericChain(i), link);
            }

            return result > 1 ? 1 : result;
        }
    }
}
