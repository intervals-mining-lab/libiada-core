namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness kurtosis coefficient tests.
/// </summary>
[TestFixture]
public class RemotenessKurtosisCoefficientTests : FullCalculatorsTests<RemotenessKurtosisCoefficient>
{
    /// <summary>
    /// The average remoteness dispersion test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// Redundant parameter, not used in calculations.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 1.15256002)]
    [TestCase(0, Link.Start, 1.2832018)]
    [TestCase(0, Link.End, 1.2351903)]
    [TestCase(0, Link.Both, 1.3146229)]
    [TestCase(0, Link.Cycle, 1.337076)]
    public void ChainCalculationTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(0, link, value);
    }

    /// <summary>
    /// No intervals test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(3, Link.None, 0)]
    [TestCase(5, Link.None, 0)]
    [TestCase(7, Link.None, 0)]
    public void NoIntervalsTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }
}
