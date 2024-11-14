namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness kurtosis coefficient tests.
/// </summary>
[TestFixture]
public class AverageRemotenessKurtosisCoefficientTests : FullCalculatorsTests<AverageRemotenessKurtosisCoefficient>
{
    /// <summary>
    /// The average remoteness kurtosis coefficient test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 1.0833)]
    [TestCase(0, Link.Start, 1.7262)]
    [TestCase(0, Link.End, 1.6741)]
    [TestCase(0, Link.Both, 1.2419)]
    [TestCase(0, Link.Cycle, 1.1666)]

    [TestCase(2, Link.None, 3.1899008031)]
    [TestCase(2, Link.Start, 1.6068591076)]
    [TestCase(2, Link.End, 3.1200053283)]
    [TestCase(2, Link.Both, 1.943235334)]
    [TestCase(2, Link.Cycle, 2.5925748595)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(30, Link.None, 1.5)]
    [TestCase(30, Link.Start, 1.1666666667)]
    [TestCase(30, Link.End, 1.1666666667)]
    [TestCase(30, Link.Both, 1.0833333333)]
    [TestCase(30, Link.Cycle, 1.1666666667)]
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
