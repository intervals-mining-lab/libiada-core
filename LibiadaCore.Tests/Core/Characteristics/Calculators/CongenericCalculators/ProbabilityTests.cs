namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;

    using NUnit.Framework;

    /// <summary>
    /// The probability test.
    /// </summary>
    [TestFixture]
    public class ProbabilityTests : CongenericCalculatorsTests
    {
        /// <summary>
        /// The congeneric calculation test.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, 0.3)]
        public void CongenericCalculationTest(int index, double value)
        {
            CongenericChainCharacteristicTest(index, Link.NotApplied, value);
        }
    }
}
