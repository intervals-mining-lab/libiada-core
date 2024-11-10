namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness test.
/// </summary>
[TestFixture]
public class AverageRemotenessTests : FullCalculatorsTests<AverageRemoteness>
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
    [TestCase(0, Link.None, 1.0242)]
    [TestCase(0, Link.Start, 1.1077)]
    [TestCase(0, Link.End, 1.017)]
    [TestCase(0, Link.Both, 1.0828)]
    [TestCase(0, Link.Cycle, 1.234)]

    [TestCase(1, Link.None, 1.6726956021)]
    [TestCase(1, Link.Start, 1.4943064208)]
    [TestCase(1, Link.End, 1.4621136113)]
    [TestCase(1, Link.Both, 1.3948590506)]
    [TestCase(1, Link.Cycle, 1.8112989210)]

    [TestCase(2, Link.None, 1.09749375)]
    [TestCase(2, Link.Start, 1.3299208)]
    [TestCase(2, Link.End, 1.17548874963)]
    [TestCase(2, Link.Both, 1.31922378713)]
    [TestCase(2, Link.Cycle, 1.5076815597)]

    [TestCase(3, Link.Start, 0.5)]
    [TestCase(3, Link.End, 0.5)]
    [TestCase(3, Link.Both, 0.5)]
    [TestCase(3, Link.Cycle, 1)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 1.1462406252)]
    [TestCase(5, Link.End, 1.1462406252)]
    [TestCase(5, Link.Both, 1.1462406252)]
    [TestCase(5, Link.Cycle, 2)]

    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 1.102035074)]
    [TestCase(6, Link.End, 0.654994643)]
    [TestCase(6, Link.Both, 1.1181098199)]
    [TestCase(6, Link.Cycle, 1.4888663952)]

    [TestCase(30, Link.None, 0.8616541669)]
    [TestCase(30, Link.Start, 0.7169925001)]
    [TestCase(30, Link.End, 0.7169925001)]
    [TestCase(30, Link.Both, 0.654994643)]
    [TestCase(30, Link.Cycle, 0.9169925001)]
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
