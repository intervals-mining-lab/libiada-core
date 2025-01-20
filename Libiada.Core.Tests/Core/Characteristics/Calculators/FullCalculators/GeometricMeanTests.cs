namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The geometric mean test.
/// </summary>
[TestFixture]
public class GeometricMeanTests : FullCalculatorsTests<GeometricMean>
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
    [TestCase(0, Link.None, 2.0339)]
    [TestCase(0, Link.Start, 2.155)]
    [TestCase(0, Link.End, 2.0237)]
    [TestCase(0, Link.Both, 2.1182)]
    [TestCase(0, Link.Cycle, 2.3522)]

    [TestCase(2, Link.None, 2.139826387867)]
    [TestCase(2, Link.Start, 2.513888742864)]
    [TestCase(2, Link.End, 2.25869387)]
    [TestCase(2, Link.Both, 2.4953181811241978)]
    [TestCase(2, Link.Cycle, 2.843527111557)]

    [TestCase(4, Link.None, 1)]
    [TestCase(4, Link.Start, 1)]
    [TestCase(4, Link.End, 1)]
    [TestCase(4, Link.Both, 1)]
    [TestCase(4, Link.Cycle, 1)]

    [TestCase(30, Link.Start, 1.6437518295)]
    public void CalculationTest(int index, Link link, double value)
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
