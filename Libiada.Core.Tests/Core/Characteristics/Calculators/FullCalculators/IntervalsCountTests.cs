namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The intervals count test.
/// </summary>
[TestFixture]
public class IntervalsCountTests : FullCalculatorsTests<IntervalsCount>
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
    [TestCase(0, Link.None, 7)]
    [TestCase(0, Link.Start, 10)]
    [TestCase(0, Link.End, 10)]
    [TestCase(0, Link.Both, 13)]
    [TestCase(0, Link.Cycle, 10)]

    [TestCase(2, Link.None, 6)]
    [TestCase(2, Link.Start, 10)]
    [TestCase(2, Link.End, 10)]
    [TestCase(2, Link.Both, 14)]
    [TestCase(2, Link.Cycle, 10)]

    [TestCase(4, Link.None, 3)]
    [TestCase(4, Link.Start, 4)]
    [TestCase(4, Link.End, 4)]
    [TestCase(4, Link.Both, 5)]
    [TestCase(4, Link.Cycle, 4)]
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
