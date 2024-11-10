namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness kurtosis tests.
/// </summary>
[TestFixture]
public class AverageRemotenessKurtosisTests : FullCalculatorsTests<AverageRemotenessKurtosis>
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
    [TestCase(0, Link.None, 0.0056)]
    [TestCase(0, Link.Start, 0.0004)]
    [TestCase(0, Link.End, 0.0005)]
    [TestCase(0, Link.Both, 0.0032)]
    [TestCase(0, Link.Cycle, 0.0016)]

    [TestCase(2, Link.None, 1.057766653)]
    [TestCase(2, Link.Start, 0.2012758125)]
    [TestCase(2, Link.End, 0.4378910419)]
    [TestCase(2, Link.Both, 0.3199463542)]
    [TestCase(2, Link.Cycle, 1.2846741865)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(30, Link.None, 0.102642009)]
    [TestCase(30, Link.Start, 0.0568737186)]
    [TestCase(30, Link.End, 0.0000168381)]
    [TestCase(30, Link.Both, 0.001111492)]
    [TestCase(30, Link.Cycle, 0.0103074679)]
    public void ChainCalculationTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
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
