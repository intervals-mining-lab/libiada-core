using LibiadaCore.Core.SimpleTypes;

namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    /// <summary>
    /// The average length of word (element) in sequence.
    /// </summary>
    public class AverageWordLength : IFullCalculator
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
        /// Average word length in <see cref="double"/> value.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            int chainLength = chain.GetLength();

            int sum = 0;

            for (int i = 0; i < chainLength; i++)
            {
                sum += ((ValueString)chain[i]).Value.Length;
            }

            return sum / (double)chainLength;
        }
    }
}
