namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness asymmetry test.
/// </summary>
[TestFixture]
public class AverageRemotenessSkewnessTests : FullCalculatorsTests<AverageRemotenessSkewness>
{
    /// <summary>
    /// The average remoteness asymmetry test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 0.0055)]
    [TestCase(0, Link.Start, 0.0016)]
    [TestCase(0, Link.End, 0.0006)]
    [TestCase(0, Link.Both, -0.0049)]
    [TestCase(0, Link.Cycle, -0.0028)]

    [TestCase(2, Link.None, 0.3275814984)]
    [TestCase(2, Link.Start, 0.1093844261)]
    [TestCase(2, Link.End, 0.2892762012)]
    [TestCase(2, Link.Both, 0.1041464096)]
    [TestCase(2, Link.Cycle, 0.5167149843)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(30, Link.None, 0.0946041996)]
    [TestCase(30, Link.Start, 0.0423543481)]
    [TestCase(30, Link.End, 0.0000955948)]
    [TestCase(30, Link.Both, 0.001654884)]
    [TestCase(30, Link.Cycle, 0.0117646301)]
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
