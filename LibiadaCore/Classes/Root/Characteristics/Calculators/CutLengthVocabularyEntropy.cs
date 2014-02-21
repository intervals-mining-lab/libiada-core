namespace LibiadaCore.Classes.Root.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Энтропия словаря по Садовскому.
    /// </summary>
    public class CutLengthVocabularyEntropy : ICalculator
    {
        /// <summary>
        /// Cut length calculator.
        /// </summary>
        private readonly CutLength cutLength = new CutLength();

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
        /// Cut length vocabulary entropy as <see cref="double"/>.
        /// </returns>
        public double Calculate(CongenericChain chain, Link link)
        {
            return Math.Log(chain.Length - cutLength.Calculate(chain, link) + 1, 2);
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
        /// Cut length vocabulary entropy as <see cref="double"/>.
        /// </returns>
        public double Calculate(Chain chain, Link link)
        {
            return Math.Log(chain.Length - cutLength.Calculate(chain, link) + 1, 2);
        }

        /// <summary>
        /// Returns enum of this characteristic.
        /// </summary>
        /// <returns>
        /// The <see cref="CharacteristicsEnum"/>.
        /// </returns>
        public CharacteristicsEnum GetCharacteristicName()
        {
            return CharacteristicsEnum.CutLengthVocabularyEntropy;
        }
    }
}