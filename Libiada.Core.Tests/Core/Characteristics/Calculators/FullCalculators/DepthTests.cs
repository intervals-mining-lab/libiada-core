namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class DepthTests : FullCalculatorsTests<Depth>
{
    /// <summary>
    /// The calculation test.
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
    [TestCase(0, Link.None, 7.1699)]
    [TestCase(0, Link.Start, 11.0768)]
    [TestCase(0, Link.End, 10.1699)]
    [TestCase(0, Link.Both, 14.0768)]
    [TestCase(0, Link.Cycle, 12.3399)]

    [TestCase(2, Link.None, 6.5849625)]
    [TestCase(2, Link.Start, 13.299208)]
    [TestCase(2, Link.End, 11.7548875)]
    [TestCase(2, Link.Both, 18.469133)]
    [TestCase(2, Link.Cycle, 15.076815597)]

    [TestCase(30, Link.Start, 3.5849625)]
    public void CalculationTest(int index, Link link, double value)
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
