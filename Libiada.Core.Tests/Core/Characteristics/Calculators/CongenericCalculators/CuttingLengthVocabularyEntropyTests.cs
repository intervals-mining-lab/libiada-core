namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The cut length vocabulary entropy test.
    /// </summary>
    [TestFixture]
    public class CuttingLengthVocabularyEntropyTests : CongenericCalculatorsTests<CuttingLengthVocabularyEntropy>
    {
        /// <summary>
        /// The congeneric calculation test.
        /// </summary>
        /// <param name="index">
        /// The congeneric sequence index in <see cref="ChainsStorage"/>.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, 2.8074)]
        public void CongenericCalculationTest(int index, double value)
        {
            CongenericChainCharacteristicTest(index, Link.NotApplied, value);
        }
    }
}
