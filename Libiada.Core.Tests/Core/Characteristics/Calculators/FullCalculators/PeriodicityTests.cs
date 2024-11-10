namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The periodicity test.
/// </summary>
[TestFixture]
public class PeriodicityTests : FullCalculatorsTests<Periodicity>
{
    /// <summary>
    /// The chain calculation test.
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
    [TestCase(0, Link.None, 0.8375)]
    [TestCase(0, Link.Start, 0.8288)]
    [TestCase(0, Link.End, 0.8432)]
    [TestCase(0, Link.Both, 0.8344)]
    [TestCase(0, Link.Cycle, 0.7841)]

    [TestCase(2, Link.None, 0.80243489545)]
    [TestCase(2, Link.Start, 0.785590232145)]
    [TestCase(2, Link.End, 0.806676382)]
    [TestCase(2, Link.Both, 0.7939648758)]
    [TestCase(2, Link.Cycle, 0.71088177788925)]

    [TestCase(4, Link.None, 1)]
    [TestCase(4, Link.Start, 1)]
    [TestCase(4, Link.End, 1)]
    [TestCase(4, Link.Both, 1)]
    [TestCase(4, Link.Cycle, 1)]

    [TestCase(30, Link.Start, 0.91319546)]
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
