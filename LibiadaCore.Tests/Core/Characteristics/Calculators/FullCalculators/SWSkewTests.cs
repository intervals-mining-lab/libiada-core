namespace LibiadaCore.Tests.Core.Characteristics.Calculators.FullCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The depth test.
    /// </summary>
    [TestFixture]
    public class SWSkewTests : FullCalculatorsTests
    {
        /// <summary>
        /// The calculation test.
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
        [TestCase(1, Link.None, -0.2)]
        [TestCase(1, Link.Start, -0.2)]
        [TestCase(1, Link.End, -0.2)]
        [TestCase(1, Link.Both, -0.2)]
        [TestCase(1, Link.Cycle, -0.2)]

        public void CalculationTest(int index, Link link, double value)
        {
            ChainCharacteristicTest(index, link, value);
        }
    }
}
