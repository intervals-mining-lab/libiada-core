namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class AverageRemotenessGCSkewTests : FullCalculatorsTests<AverageRemotenessGCSkew>
{
    /// <summary>
    /// The calculation test.
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
    [TestCase(1, Link.None, -0.0946)]
    [TestCase(1, Link.Start, 0.0989)]
    [TestCase(1, Link.End, -0.2423)]
    [TestCase(1, Link.Both, -0.0172)]
    [TestCase(1, Link.Cycle, 0.0278)]

    [TestCase(2, Link.None, -1)]
    [TestCase(2, Link.Start, 0.487496188)]
    [TestCase(2, Link.End, 0.527321204)]
    [TestCase(2, Link.Both, 0.572664908)]
    [TestCase(2, Link.Cycle, 0.611832142)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    public void CalculationTest(int index, Link link, double value)
    {
        SequenceCharacteristicTest(index, link, value);
    }

    /// <summary>
    /// Sequence without Guanine or Cytozine calculation test.
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
    [TestCase(7, Link.None, 0)]
    [TestCase(7, Link.Start, 0)]
    [TestCase(7, Link.End, 0)]
    [TestCase(7, Link.Both, 0)]
    [TestCase(7, Link.Cycle, 0)]

    [TestCase(8, Link.None, 0)]
    [TestCase(8, Link.Start, 0)]
    [TestCase(8, Link.End, 0)]
    [TestCase(8, Link.Both, 0)]
    [TestCase(8, Link.Cycle, 0)]
    public void SequenceWithoutGCTest(int index, Link link, double value)
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
    public void NoIntervalsTest(int index, Link link, double value)
    {
        SequenceCharacteristicTest(index, link, value);
    }
}
