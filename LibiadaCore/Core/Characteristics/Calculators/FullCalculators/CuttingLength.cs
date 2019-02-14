namespace LibiadaCore.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Misc.Iterators;

    /// <summary>
    /// Sadovsky cut length.
    /// </summary>
    public class CuttingLength : NonLinkableFullCalculator
    {
        /// <summary>
        /// Calculation method.
        /// </summary>
        /// <param name="chain">
        /// Source sequence.
        /// </param>
        /// <returns>
        /// Cut length as <see cref="double"/>.
        /// </returns>
        public override double Calculate(Chain chain)
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
            for (int length = 1; length <= chain.Length; length++)
            {
                if (IsRecoveryPossible(chain, length))
                {
                    return length;
                }
            }

            return chain.Length;
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
        private bool IsRecoveryPossible(AbstractChain chain, int length)
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
