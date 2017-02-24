namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The length test.
    /// </summary>
    [TestFixture]
    public class LengthTests : CongenericCalculatorsTests
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
        [TestCase(0, 10)]
        [TestCase(1, 15)]
        [TestCase(2, 1)]
        [TestCase(3, 8)]
        [TestCase(4, 1000000)]
        [TestCase(5, 5)]
        public void CongenericCalculationTest(int index, double value)
        {
            CongenericChainCharacteristicTest(index, Link.NotApplied, value);
        }
    }
}