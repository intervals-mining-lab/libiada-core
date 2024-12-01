namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The entropy kurtosis coefficient tests.
/// </summary>
[TestFixture]
public class EntropyKurtosisCoefficientTests : FullCalculatorsTests<EntropyKurtosisCoefficient>
{
    /// <summary>
    /// The entropy kurtosis coefficient test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, Link.None, 1.0833333333)]
    [TestCase(0, Link.Start, 1.7102130594)]
    [TestCase(0, Link.End, 1.7252251832)]
    [TestCase(0, Link.Both, 1.225)]
    [TestCase(0, Link.Cycle, 1.1666666667)]

    [TestCase(1, Link.None, 1.7574356855)]
    [TestCase(1, Link.Start, 1.2774883489)]
    [TestCase(1, Link.End, 2.3342001534)]
    [TestCase(1, Link.Both, 1.0833333333)]
    [TestCase(1, Link.Cycle, 1.1666666667)]

    [TestCase(2, Link.None, 3.0354846197)]
    [TestCase(2, Link.Start, 1.0940614369)]
    [TestCase(2, Link.End, 2.6092565493)]
    [TestCase(2, Link.Both, 1.4929907332)]
    [TestCase(2, Link.Cycle, 1.8439986382)]

    [TestCase(3, Link.Start, 1)]
    [TestCase(3, Link.End, 1)]
    [TestCase(3, Link.Both, 0)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 1.8027279195)]
    [TestCase(5, Link.End, 1.8027279195)]
    [TestCase(5, Link.Both, 0)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 1.1423674442)]
    [TestCase(6, Link.End, 3.3687829924)]
    [TestCase(6, Link.Both, 1.0333333333)]
    [TestCase(6, Link.Cycle, 1.0833333333)]

    [TestCase(30, Link.None, 1.5)]
    [TestCase(30, Link.Start, 1.1666666667)]
    [TestCase(30, Link.End, 1.1666666667)]
    [TestCase(30, Link.Both, 1.0833333333)]
    [TestCase(30, Link.Cycle, 1.1666666667)]
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
