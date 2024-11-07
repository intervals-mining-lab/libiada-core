namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The uniformity calculator tests.
/// </summary>
[TestFixture]
public class UniformityTests : FullCalculatorsTests<Uniformity>
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
    [TestCase(0, Link.None, 0.22649821459)]
    [TestCase(0, Link.Start, 0.2632777)]
    [TestCase(0, Link.End, 0.2362824857)]
    [TestCase(0, Link.Both, 0.252818955)]
    [TestCase(0, Link.Cycle, 0.337)]

    [TestCase(2, Link.None, 0.113283334415)]
    [TestCase(2, Link.Start, 0.2362570097771987)]
    [TestCase(2, Link.End, 0.18300750037)]
    [TestCase(2, Link.Both, 0.2102399737463)]
    [TestCase(2, Link.Cycle, 0.25328248774368)]

    [TestCase(30, Link.Start, 0.06080123752225)]
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
