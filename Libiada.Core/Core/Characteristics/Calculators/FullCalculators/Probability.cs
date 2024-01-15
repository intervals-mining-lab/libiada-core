namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// Probability (frequency).
    /// </summary>
    public class Probability : NonLinkableFullCalculator
    {
        /// <summary>
        /// For complete (full) sequence always equals 1.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// if chain is full then 1, otherwise percent of filled positions as <see cref="double"/>.
        /// </returns>
        public override double Calculate(Chain chain)
        {
            var calculator = new CongenericCalculators.Probability();

            double result = 0;
            Alphabet alphabet = chain.Alphabet;
            for (int i = 0; i < alphabet.Cardinality; i++)
            {
                result += calculator.Calculate(chain.CongenericChain(i));
            }

            return result > 1 ? 1 : result;
        }
    }
}
