namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The regularity test.
    /// </summary>
    [TestFixture]
    public class RegularityTests : CongenericCalculatorsTests
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
        [TestCase(0, Link.None, 1.2248)]
        [TestCase(0, Link.Start, 1.5849)]
        [TestCase(0, Link.End, 1.4467)]
        [TestCase(0, Link.Both, 1.6956)]
        [TestCase(0, Link.Cycle, 1.8263)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
    }
}
