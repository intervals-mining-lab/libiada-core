namespace LibiadaCore.Core.Characteristics.Calculators
{
    using System;

    /// <summary>
    /// Sadovsky entropy of dictionary.
    /// </summary>
    public class CuttingLengthVocabularyEntropy : ICalculator
    {
        /// <summary>
        /// Cut length calculator.
        /// </summary>
        private readonly ICalculator cutLength = new CuttingLength();

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
            return Math.Log(chain.GetLength() - cutLength.Calculate(chain, link) + 1, 2);
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
            return Math.Log(chain.GetLength() - cutLength.Calculate(chain, link) + 1, 2);
        }
    }
}
