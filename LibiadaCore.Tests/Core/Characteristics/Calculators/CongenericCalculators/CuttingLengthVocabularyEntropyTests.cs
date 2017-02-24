namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The cut length vocabulary entropy test.
    /// </summary>
    [TestFixture]
    public class CuttingLengthVocabularyEntropyTests : CongenericCalculatorsTests
    {
        /// <summary>
        /// The congeneric calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
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
