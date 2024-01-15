namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.FullCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class GCToATRatioTests : FullCalculatorsTests<GCToATRatio>
    {
        /// <summary>
        /// The calculation test.
        /// </summary>
        /// <param name="index">
        /// Full sequence index in <see cref="ChainsStorage"/>.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(1, 0.6666)]
        public void CalculationTest(int index, double value)
        {
            ChainCharacteristicTest(index, Link.NotApplied, value);
        }

        /// <summary>
        /// Sequence without Adenin or Timine calculation test.
        /// </summary>
        /// <param name="index">
        /// Full sequence index in <see cref="ChainsStorage"/>.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(3, 0)]
        [TestCase(4, 0)]
        public void SequenceWithoutATTest(int index, double value)
        {
            ChainCharacteristicTest(index, Link.NotApplied, value);
        }
    }
}
