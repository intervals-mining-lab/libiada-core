namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The regularity test.
/// </summary>
[TestFixture]
public class RegularityTests : FullCalculatorsTests<Regularity>
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
    [TestCase(0, Link.None, 0.8547)]
    [TestCase(0, Link.Start, 0.8332)]
    [TestCase(0, Link.End, 0.8489)]
    [TestCase(0, Link.Both, 0.8393)]
    [TestCase(0, Link.Cycle, 0.7917)]

    [TestCase(2, Link.None, 0.924481699264)]
    [TestCase(2, Link.Start, 0.848944998)]
    [TestCase(2, Link.End, 0.88086479457968535)]
    [TestCase(2, Link.Both, 0.86439343863)]
    [TestCase(2, Link.Cycle, 0.838985343)]

    [TestCase(4, Link.None, 1)]
    [TestCase(4, Link.Start, 1)]
    [TestCase(4, Link.End, 1)]
    [TestCase(4, Link.Both, 1)]
    [TestCase(4, Link.Cycle, 1)]

    [TestCase(30, Link.Start, 0.9587)]
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
