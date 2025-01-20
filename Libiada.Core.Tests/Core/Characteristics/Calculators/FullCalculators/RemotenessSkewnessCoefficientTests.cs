namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness skewness coefficient tests.
/// </summary>
[TestFixture]
public class RemotenessSkewnessCoefficientTests : FullCalculatorsTests<RemotenessSkewnessCoefficient>
{
    /// <summary>
    /// The remoteness skewness coefficient test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, -0.1980597)]
    [TestCase(0, Link.Start, -0.2357032)]
    [TestCase(0, Link.End, -0.147245)]
    [TestCase(0, Link.Both, -0.1808623)]
    [TestCase(0, Link.Cycle, -0.1356234)]

    [TestCase(1, Link.None, -0.5829668669)]
    [TestCase(1, Link.Start, -0.3603013061)]
    [TestCase(1, Link.End, -0.3410360811)]
    [TestCase(1, Link.Both, -0.2812871936)]
    [TestCase(1, Link.Cycle, -0.8964505469)]

    [TestCase(2, Link.None, 0.2654111534)]
    [TestCase(2, Link.Start, -0.0565556889)]
    [TestCase(2, Link.End, 0.1554671169)]
    [TestCase(2, Link.Both, -0.0393792325)]
    [TestCase(2, Link.Cycle, 0.0819247356)]

    [TestCase(3, Link.Start, 0)]
    [TestCase(3, Link.End, 0)]
    [TestCase(3, Link.Both, 0)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, -0.4733901994)]
    [TestCase(5, Link.End, -0.4733901994)]
    [TestCase(5, Link.Both, -0.4733901994)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 0.3195924049)]
    [TestCase(6, Link.End, 0.5953546977)]
    [TestCase(6, Link.Both, 0.2297164906)]
    [TestCase(6, Link.Cycle, -0.1811558496)]

    [TestCase(30, Link.None, -0.307659401)]
    [TestCase(30, Link.Start, -0.0313566973)]
    [TestCase(30, Link.End, -0.0313566973)]
    [TestCase(30, Link.Both, 0.0562260608)]
    [TestCase(30, Link.Cycle, -0.704736147)]
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
