namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The geometric mean test.
    /// </summary>
    [TestFixture]
    public class GeometricMeanTests : CongenericCalculatorsTests<GeometricMean>
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
        [TestCase(0, Link.None, 1.7321)]
        [TestCase(0, Link.Start, 2.2894)]
        [TestCase(0, Link.End, 2.0801)]
        [TestCase(0, Link.Both, 2.4495)]
        [TestCase(0, Link.Cycle, 2.6207)]

        [TestCase(1, Link.None, 2.1544)]
        [TestCase(1, Link.Start, 2.5149)]
        [TestCase(1, Link.End, 2.5149)]
        [TestCase(1, Link.Both, 2.7595)]
        [TestCase(1, Link.Cycle, 2.8925)]

        [TestCase(2, Link.None, 1)]
        [TestCase(2, Link.Start, 1)]
        [TestCase(2, Link.End, 1)]
        [TestCase(2, Link.Both, 1)]
        [TestCase(2, Link.Cycle, 1)]

        [TestCase(3, Link.None, 1)]
        [TestCase(3, Link.Start, 8)]
        [TestCase(3, Link.End, 1)]
        [TestCase(3, Link.Both, 2.8284)]
        [TestCase(3, Link.Cycle, 8)]

        [TestCase(5, Link.None, 1)]
        [TestCase(5, Link.Start, 1)]
        [TestCase(5, Link.End, 1)]
        [TestCase(5, Link.Both, 1)]
        [TestCase(5, Link.Cycle, 1)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
    }
}
