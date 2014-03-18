namespace LibiadaCore.Core.Characteristics.Calculators
{
    using LibiadaCore.Misc.Iterators;

    /// <summary>
    /// Длина обрезания по Садовскому.
    /// </summary>
    public class CutLength : ICalculator
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
        public double Calculate(CongenericChain chain, Link link)
        {
            return this.CutCommon(chain);
        }

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
            return this.CutCommon(chain);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.CutLength;
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
        private double CutCommon(BaseChain chain)
        {
            for (int length = 1; length <= chain.Length; length++)
            {
                if (this.CheckRecoveryAvailable(chain, length))
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
        /// Length of L-gramm.
        /// </param>
        /// <returns>
        /// true if chain is recoverable form L-gramms.
        /// </returns>
        private bool CheckRecoveryAvailable(BaseChain chain, int length)
        {
            var iterator = new IteratorStart<BaseChain, BaseChain>(chain, length, 1);
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