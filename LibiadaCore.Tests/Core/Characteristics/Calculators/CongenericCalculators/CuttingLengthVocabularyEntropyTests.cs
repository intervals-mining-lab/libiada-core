using LibiadaCore.Core;
using NUnit.Framework;

namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
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
        /// <param name="link">
        /// The link.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, Link.None, 2.8074)]
        [TestCase(0, Link.Start, 2.8074)]
        [TestCase(0, Link.End, 2.8074)]
        [TestCase(0, Link.Both, 2.8074)]
        [TestCase(0, Link.Cycle, 2.8074)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
    }
}
