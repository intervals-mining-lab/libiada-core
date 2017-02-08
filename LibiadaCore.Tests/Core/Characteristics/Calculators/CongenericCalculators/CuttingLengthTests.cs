namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The cut length test.
    /// </summary>
    [TestFixture]
    public class CuttingLengthTests : CongenericCalculatorsTests
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
        [TestCase(0, Link.None, 4)]
        [TestCase(0, Link.Start, 4)]
        [TestCase(0, Link.End, 4)]
        [TestCase(0, Link.Both, 4)]
        [TestCase(0, Link.Cycle, 4)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
    }
}
