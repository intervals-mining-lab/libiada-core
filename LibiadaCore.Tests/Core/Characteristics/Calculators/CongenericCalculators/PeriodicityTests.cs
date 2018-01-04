namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The periodicity test.
    /// </summary>
    [TestFixture]
    public class PeriodicityTests : CongenericCalculatorsTests<Periodicity>
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
        [TestCase(0, Link.None, 0.8661)]
        [TestCase(0, Link.Start, 0.8585)]
        [TestCase(0, Link.End, 0.8915)]
        [TestCase(0, Link.Both, 0.8907)]
        [TestCase(0, Link.Cycle, 0.7862)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
    }
}
