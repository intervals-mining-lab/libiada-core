namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Standard Deviation test.
/// </summary>
[TestFixture]
public class AverageRemotenessStandardDeviationTests : FullCalculatorsTests<AverageRemotenessStandardDeviation>
{
    /// <summary>
    /// Standard Deviation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// Redundant parameter, not used in calculations.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 0.2677)]
    [TestCase(0, Link.Start, 0.1296)]
    [TestCase(0, Link.End, 0.1298)]
    [TestCase(0, Link.Both, 0.225)]
    [TestCase(0, Link.Cycle, 0.191)]

    [TestCase(2, Link.None, 0.7588451685)]
    [TestCase(2, Link.Start, 0.5949129839)]
    [TestCase(2, Link.End, 0.6120722377)]
    [TestCase(2, Link.Both, 0.6369978137)]
    [TestCase(2, Link.Cycle, 0.8390066887)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(30, Link.None, 0.5114562277)]
    [TestCase(30, Link.Start, 0.4698845969)]
    [TestCase(30, Link.End, 0.0616363065)]
    [TestCase(30, Link.Both, 0.1789723977)]
    [TestCase(30, Link.Cycle, 0.3065852807)]
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
