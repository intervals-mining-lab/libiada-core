namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class GCRatioTests : FullCalculatorsTests
    {
        /// <summary>
        /// The calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(1, 40)]
        public void CalculationTest(int index, double value)
        {
            ChainCharacteristicTest(index, Link.NotApplied, value);
        }

        /// <summary>
        /// Sequence without Guanine or Cytozine calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(7, 0)]
        [TestCase(8, 0)]
        public void SequenceWithoutGCTest(int index, double value)
        {
            ChainCharacteristicTest(index, Link.NotApplied, value);
        }
    }
}
