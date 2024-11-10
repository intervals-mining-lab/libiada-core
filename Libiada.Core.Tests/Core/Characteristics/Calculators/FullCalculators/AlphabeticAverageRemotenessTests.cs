namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The alphabetic average remoteness test.
/// </summary>
[TestFixture]
public class AlphabeticAverageRemotenessTests : FullCalculatorsTests<AlphabeticAverageRemoteness>
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
    [TestCase(0, Link.None, 0.6462)]
    [TestCase(0, Link.Start, 0.6989)]
    [TestCase(0, Link.End, 0.6417)]
    [TestCase(0, Link.Both, 0.6832)]
    [TestCase(0, Link.Cycle, 0.7786)]

    [TestCase(2, Link.None, 0.548746875)]
    [TestCase(2, Link.Start, 0.6649604)]
    [TestCase(2, Link.End, 0.5877443751)]
    [TestCase(2, Link.Both, 0.65961189)]
    [TestCase(2, Link.Cycle, 0.75384077985)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(30, Link.Start, 0.7169925)]
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
