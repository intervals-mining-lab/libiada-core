namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The length test.
    /// </summary>
    [TestFixture]
    public class LengthTests : FullCalculatorsTests
    {
        /// <summary>
        /// The chain calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, 10)]
        public void ChainCalculationTest(int index,  double value)
        {
            ChainCharacteristicTest(index, Link.NotApplied, value);
        }
    }
}
