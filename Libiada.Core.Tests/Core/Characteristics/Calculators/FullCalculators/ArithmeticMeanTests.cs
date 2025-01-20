namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The arithmetic mean test.
/// </summary>
[TestFixture]
public class ArithmeticMeanTests : FullCalculatorsTests<ArithmeticMean>
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
    [TestCase(0, Link.None, 2.4286)]
    [TestCase(0, Link.Start, 2.6)]
    [TestCase(0, Link.End, 2.4)]
    [TestCase(0, Link.Both, 2.5385)]
    [TestCase(0, Link.Cycle, 3)]

    [TestCase(2, Link.None, 2.666666666666667)]
    [TestCase(2, Link.Start, 3.2)]
    [TestCase(2, Link.End, 2.8)]
    [TestCase(2, Link.Both, 3.142857142857)]
    [TestCase(2, Link.Cycle, 4)]

    [TestCase(4, Link.None, 1)]
    [TestCase(4, Link.Start, 1)]
    [TestCase(4, Link.End, 1)]
    [TestCase(4, Link.Both, 1)]
    [TestCase(4, Link.Cycle, 1)]

    [TestCase(30, Link.Start, 1.8)]
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
