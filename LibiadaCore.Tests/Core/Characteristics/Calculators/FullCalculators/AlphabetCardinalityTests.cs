namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The alphabet cardinality test.
    /// </summary>
    [TestFixture]
    public class AlphabetCardinalityTests : FullCalculatorsTests<AlphabetCardinality>
    {
        /// <summary>
        /// The chain calculation test.
        /// </summary>
        /// <param name="index">
        /// Full sequence index in <see cref="ChainsStorage"/>.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, 3)]
        [TestCase(1, 4)]
        [TestCase(2, 4)]
        [TestCase(3, 2)]
        [TestCase(4, 1)]
        [TestCase(5, 4)]
        public void ChainCalculationTest(int index, double value)
        {
            ChainCharacteristicTest(index, Link.NotApplied, value);
        }
    }
}
