namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class AverageRemotenessGCToATRatioTests : FullCalculatorsTests<AverageRemotenessGCToATRatio>
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
    [TestCase(1, Link.None, 2.0906)]
    [TestCase(1, Link.Start, 1.9527)]
    [TestCase(1, Link.End, 1.0826)]
    [TestCase(1, Link.Both, 1.2505)]
    [TestCase(1, Link.Cycle, 1.4932)]

    [TestCase(2, Link.None, 0.386852807)]
    [TestCase(2, Link.Start, 0.894883976)]
    [TestCase(2, Link.End, 1.309482246)]
    [TestCase(2, Link.Both, 0.978885023)]
    [TestCase(2, Link.Cycle, 1.06305297)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    public void CalculationTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }

    /// <summary>
    /// Sequence without Adenin or Timine calculation test.
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
    [TestCase(3, Link.Start, 0)]
    [TestCase(3, Link.End, 0)]
    [TestCase(3, Link.Both, 0)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]
    public void SequenceWithoutATTest(int index, Link link, double value)
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
    [TestCase(5, Link.None, 0)]
    [TestCase(7, Link.None, 0)]
    public void NoIntervalsTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }
}
