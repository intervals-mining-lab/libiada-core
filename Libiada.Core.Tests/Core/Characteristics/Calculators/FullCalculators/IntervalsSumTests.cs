namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The intervals sum test.
/// </summary>
[TestFixture]
public class IntervalsSumTests : FullCalculatorsTests<IntervalsSum>
{
    /// <summary>
    /// The sequence calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 17)]
    [TestCase(0, Link.Start, 26)]
    [TestCase(0, Link.End, 24)]
    [TestCase(0, Link.Both, 33)]
    [TestCase(0, Link.Cycle, 30)]

    [TestCase(2, Link.None, 16)]
    [TestCase(2, Link.Start, 32)]
    [TestCase(2, Link.End, 28)]
    [TestCase(2, Link.Both, 44)]
    [TestCase(2, Link.Cycle, 40)]

    [TestCase(4, Link.None, 3)]
    [TestCase(4, Link.Start, 4)]
    [TestCase(4, Link.End, 4)]
    [TestCase(4, Link.Both, 5)]
    [TestCase(4, Link.Cycle, 4)]
    public void SequenceCalculationTest(int index, Link link, double value)
    {
        SequenceCharacteristicTest(index, link, value);
    }

    /// <summary>
    /// No intervals test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
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
        SequenceCharacteristicTest(index, link, value);
    }
}
