namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The descriptive information test.
/// </summary>
[TestFixture]
public class DescriptiveInformationTests : FullCalculatorsTests<DescriptiveInformation>
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
    [TestCase(0, Link.None, 2.37956557896877)]
    [TestCase(0, Link.Start, 2.58645791024)]
    [TestCase(0, Link.End, 2.383831871)]
    [TestCase(0, Link.Both, 2.52382717296366)]
    [TestCase(0, Link.Cycle, 2.971)]

    [TestCase(2, Link.None, 2.314622766)]
    [TestCase(2, Link.Start, 2.9611915354687)]
    [TestCase(2, Link.End, 2.56417770797363)]
    [TestCase(2, Link.Both, 2.8867851948)]
    [TestCase(2, Link.Cycle, 3.389245277)]

    [TestCase(30, Link.Start, 1.71450693)]
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
    [TestCase(3, Link.None, 1)]
    [TestCase(5, Link.None, 1)]
    [TestCase(7, Link.None, 1)]
    public void NoIntervalsTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }
}
