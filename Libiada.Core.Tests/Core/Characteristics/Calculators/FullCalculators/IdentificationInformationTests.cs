namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The identification information test.
/// </summary>
[TestFixture]
public class IdentificationInformationTests : FullCalculatorsTests<IdentificationInformation>
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

    [TestCase(2, Link.None, 1.210777084415)]
    [TestCase(2, Link.Start, 1.5661778097771987)]
    [TestCase(2, Link.End, 1.35849625)]
    [TestCase(2, Link.Both, 1.5294637608763)]
    [TestCase(2, Link.Cycle, 1.76096404744368)]

    [TestCase(30, Link.Start, 0.77779373752225)]
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
