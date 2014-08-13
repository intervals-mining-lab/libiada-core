namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Core.SimpleTypes;

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

            for (int index = chainLength; --index >= 0;)
            {
                sum = sum + ((ValueString)chain[index]).Value.Length;
            }

            return sum / (double)chainLength;
        }
    }
}