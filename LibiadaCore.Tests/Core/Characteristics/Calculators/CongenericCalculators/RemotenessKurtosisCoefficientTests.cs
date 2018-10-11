namespace LibiadaCore.Tests.Core.Characteristics.Calculators.CongenericCalculators
{
    using LibiadaCore.Core;
    using LibiadaCore.Core.Characteristics.Calculators.CongenericCalculators;

    using NUnit.Framework;

    /// <summary>
    /// The remoteness kurtosis coefficient tests.
    /// </summary>
    [TestFixture]
    public class RemotenessKurtosisCoefficientTests : CongenericCalculatorsTests<RemotenessKurtosisCoefficient>
    {
        /// <summary>
        /// The average remoteness dispersion test.
        /// </summary>
        /// <param name="index">
        /// The congeneric sequence index in <see cref="ChainsStorage"/>.
        /// </param>
        /// <param name="link">
        /// Redundant parameter, not used in calculations.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        [TestCase(0, Link.Start, 5.000000378)]
        public void CongenericCalculationTest(int index, Link link, double value)
        {
            CongenericChainCharacteristicTest(index, link, value);
        }
    }
}
