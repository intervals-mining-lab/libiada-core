namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Misc.Iterators;

    /// <summary>
    /// Sadovsky cut length.
    /// </summary>
    public class CuttingLength : IFullCalculator
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
        /// Cut length as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return CutCommon(chain);
        }

        /// <summary>
        /// The cut common.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// <see cref="double"/>.
        /// </returns>
        private double CutCommon(AbstractChain chain)
        {
            for (int length = 1; length <= chain.GetLength(); length++)
            {
                if (CheckRecoveryAvailable(chain, length))
                {
                    return length;
                }
            }

            return chain.GetLength();
        }

        /// <summary>
        /// The check recovery available.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <param name="length">
        /// Length of L-gram.
        /// </param>
        /// <returns>
        /// true if chain is recoverable form L-grams.
        /// </returns>
        private bool CheckRecoveryAvailable(AbstractChain chain, int length)
        {
            var iterator = new IteratorStart(chain, length, 1);
            var alphabet = new Alphabet();

            while (iterator.Next())
            {
                if (alphabet.Contains(iterator.Current()))
                {
                    return false;
                }

                alphabet.Add(iterator.Current());
            }

            return true;
        }
    }
}
