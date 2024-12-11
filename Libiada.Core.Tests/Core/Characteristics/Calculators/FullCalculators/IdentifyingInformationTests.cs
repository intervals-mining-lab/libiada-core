namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The identifying informations test.
/// </summary>
[TestFixture(TestOf = typeof(IdentifyingInformation))]
public class IdentifyingInformationTests : FullCalculatorsTests<IdentifyingInformation>
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
    [TestCase(0, Link.None, 1.25069821459)]
    [TestCase(0, Link.Start, 1.3709777)]
    [TestCase(0, Link.End, 1.2532824857)]
    [TestCase(0, Link.Both, 1.335618955)]
    [TestCase(0, Link.Cycle, 1.571)]

    [TestCase(1, Link.None, 1.7906654768)]
    [TestCase(1, Link.Start, 1.6895995955)]
    [TestCase(1, Link.End, 1.6965784285)]
    [TestCase(1, Link.Both, 1.6373048326)]
    [TestCase(1, Link.Cycle, 1.9709505945)]

    [TestCase(2, Link.None, 1.210777084415)]
    [TestCase(2, Link.Start, 1.5661778097771987)]
    [TestCase(2, Link.End, 1.35849625)]
    [TestCase(2, Link.Both, 1.5294637608763)]
    [TestCase(2, Link.Cycle, 1.76096404744368)]

    [TestCase(3, Link.Start, 0.5)]
    [TestCase(3, Link.End, 0.5)]
    [TestCase(3, Link.Both, 0.5849625007)]
    [TestCase(3, Link.Cycle, 1)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 1.1462406252)]
    [TestCase(5, Link.End, 1.1462406252)]
    [TestCase(5, Link.Both, 1.3219280949)]
    [TestCase(5, Link.Cycle, 2)]

    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 1.102035074)]
    [TestCase(6, Link.End, 0.830626027)]
    [TestCase(6, Link.Both, 1.3991235932)]
    [TestCase(6, Link.Cycle, 1.6644977792)]

    [TestCase(30, Link.None, 0.9182958341)]
    [TestCase(30, Link.Start, 0.7777937375)]
    [TestCase(30, Link.End, 0.8421793565)]
    [TestCase(30, Link.Both, 0.7628357147)]
    [TestCase(30, Link.Cycle, 0.9709505945)]
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
