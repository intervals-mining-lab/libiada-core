namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The volume test.
/// </summary>
[TestFixture]
public class VolumeTests : FullCalculatorsTests<Volume>
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
    [TestCase(0, Link.None, 144)]
    [TestCase(0, Link.Start, 2160)]
    [TestCase(0, Link.End, 1152)]
    [TestCase(0, Link.Both, 17280)]
    [TestCase(0, Link.Cycle, 5184)]

    [TestCase(2, Link.None, 96)]
    [TestCase(2, Link.Start, 10080)]
    [TestCase(2, Link.End, 3456)]
    [TestCase(2, Link.Both, 362880)]
    [TestCase(2, Link.Cycle, 34560)]

    [TestCase(4, Link.None, 1)]
    [TestCase(4, Link.Start, 1)]
    [TestCase(4, Link.End, 1)]
    [TestCase(4, Link.Both, 1)]
    [TestCase(4, Link.Cycle, 1)]
    public void CalculationTest(int index, Link link, double value)
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
    [TestCase(3, Link.None, 1)]
    [TestCase(5, Link.None, 1)]
    [TestCase(7, Link.None, 1)]
    public void NoIntervalsTest(int index, Link link, double value)
    {
        ChainCharacteristicTest(index, link, value);
    }

    /// <summary>
    /// The series test.
    /// </summary>
    [Test]
    public void SeriesTest()
    {
        SeriesCharacteristicTest(0, Link.NotApplied, 8);
    }
}
