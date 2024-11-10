namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness dispersion tests.
/// </summary>
[TestFixture]
public class RemotenessDispersionTests : FullCalculatorsTests<RemotenessDispersion>
{
    /// <summary>
    /// The average remoteness dispersion test.
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
    [TestCase(0, Link.None, 0.8114)]
    [TestCase(0, Link.Start, 0.8658)]
    [TestCase(0, Link.End, 0.7681)]
    [TestCase(0, Link.Both, 0.8219)]
    [TestCase(0, Link.Cycle, 1.1161)]

    [TestCase(1, Link.None, 0.8980974132)]
    [TestCase(1, Link.Start, 0.8749987356)]
    [TestCase(1, Link.End, 0.8310391947)]
    [TestCase(1, Link.Both, 0.8109118201)]
    [TestCase(1, Link.Cycle, 0.6465603597)]

    [TestCase(2, Link.None, 0.9091793235)]
    [TestCase(2, Link.Start, 1.0779835603)]
    [TestCase(2, Link.End, 0.905843037)]
    [TestCase(2, Link.Both, 1.0211390462)]
    [TestCase(2, Link.Cycle, 1.5034625058)]

    [TestCase(3, Link.Start, 0.25)]
    [TestCase(3, Link.End, 0.25)]
    [TestCase(3, Link.Both, 0.25)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 0.5641589614)]
    [TestCase(5, Link.End, 0.5641589614)]
    [TestCase(5, Link.Both, 0.5641589614)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 1.6361791053)]
    [TestCase(6, Link.End, 0.6441400361)]
    [TestCase(6, Link.Both, 1.2468057939)]
    [TestCase(6, Link.Cycle, 1.7323804252)]

    [TestCase(30, Link.None, 0.4282541395)]
    [TestCase(30, Link.Start, 0.3883429805)]
    [TestCase(30, Link.End, 0.3883429805)]
    [TestCase(30, Link.Both, 0.3584257504)]
    [TestCase(30, Link.Cycle, 0.2615459804)]
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
