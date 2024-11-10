namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness standard deviation tests.
/// </summary>
[TestFixture]
public class RemotenessStandardDeviationTests : FullCalculatorsTests<RemotenessStandardDeviation>
{
    /// <summary>
    /// Standard Deviation test.
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
    [TestCase(0, Link.None, 0.9008121)]
    [TestCase(0, Link.Start, 0.9304883)]
    [TestCase(0, Link.End, 0.87644402)]
    [TestCase(0, Link.Both, 0.906593)]
    [TestCase(0, Link.Cycle, 1.0564604)]

    [TestCase(1, Link.None, 0.9476800162)]
    [TestCase(1, Link.Start, 0.9354136709)]
    [TestCase(1, Link.End, 0.9116135117)]
    [TestCase(1, Link.Both, 0.9005064243)]
    [TestCase(1, Link.Cycle, 0.8040897709)]

    [TestCase(2, Link.None, 0.953508953)]
    [TestCase(2, Link.Start, 1.0382598713)]
    [TestCase(2, Link.End, 0.9517578668)]
    [TestCase(2, Link.Both, 1.0105142484)]
    [TestCase(2, Link.Cycle, 1.2261576187)]

    [TestCase(3, Link.Start, 0.5)]
    [TestCase(3, Link.End, 0.5)]
    [TestCase(3, Link.Both, 0.5)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 0.75110516)]
    [TestCase(5, Link.End, 0.75110516)]
    [TestCase(5, Link.Both, 0.75110516)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 1.2791321688)]
    [TestCase(6, Link.End, 0.8025833515)]
    [TestCase(6, Link.Both, 1.1166045826)]
    [TestCase(6, Link.Cycle, 1.3161992346)]

    [TestCase(30, Link.None, 0.6544112923)]
    [TestCase(30, Link.Start, 0.6231717103)]
    [TestCase(30, Link.End, 0.6231717103)]
    [TestCase(30, Link.Both, 0.598686688)]
    [TestCase(30, Link.Cycle, 0.5114156631)]
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
