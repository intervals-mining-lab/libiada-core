namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The alphabetic depth test.
/// </summary>
[TestFixture]
public class AlphabeticDepthTests : FullCalculatorsTests<AlphabeticDepth>
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
    [TestCase(0, Link.None, 4.5237)]
    [TestCase(0, Link.Start, 6.9887)]
    [TestCase(0, Link.End, 6.4165)]
    [TestCase(0, Link.Both, 8.8815)]
    [TestCase(0, Link.Cycle, 7.7856)]

    [TestCase(2, Link.None, 3.29248125)]
    [TestCase(2, Link.Start, 6.649604)]
    [TestCase(2, Link.End, 5.877443751)]
    [TestCase(2, Link.Both, 9.2345665)]
    [TestCase(2, Link.Cycle, 7.5384077985)]

    [TestCase(30, Link.Start, 3.5849625)]
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
