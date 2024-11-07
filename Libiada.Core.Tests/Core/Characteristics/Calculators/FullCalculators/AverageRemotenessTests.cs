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

    [TestCase(2, Link.None, 1.09749375)]
    [TestCase(2, Link.Start, 1.3299208)]
    [TestCase(2, Link.End, 1.17548874963)]
    [TestCase(2, Link.Both, 1.31922378713)]
    [TestCase(2, Link.Cycle, 1.5076815597)]

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
