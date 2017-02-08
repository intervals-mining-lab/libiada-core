namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The elements count test.
    /// </summary>
    [TestFixture]
    public class ElementsCountTests : FullCalculatorsTests
    {
        /// <summary>
        /// The chain calculation test.
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
        [TestCase(0, Link.None, 10)]
        [TestCase(0, Link.Start, 10)]
        [TestCase(0, Link.End, 10)]
        [TestCase(0, Link.Both, 10)]
        [TestCase(0, Link.Cycle, 10)]
        public void ChainCalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
