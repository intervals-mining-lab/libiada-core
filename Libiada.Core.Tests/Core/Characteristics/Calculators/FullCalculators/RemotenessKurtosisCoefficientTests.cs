namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness kurtosis coefficient tests.
/// </summary>
[TestFixture]
public class RemotenessKurtosisCoefficientTests : FullCalculatorsTests<RemotenessKurtosisCoefficient>
{
    /// <summary>
    /// The remoteness kurtosis coefficient test.
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
    [TestCase(0, Link.None, 1.15256002)]
    [TestCase(0, Link.Start, 1.2832018)]
    [TestCase(0, Link.End, 1.2351903)]
    [TestCase(0, Link.Both, 1.3146229)]
    [TestCase(0, Link.Cycle, 1.337076)]

    [TestCase(1, Link.None, 2.0758451057)]
    [TestCase(1, Link.Start, 1.8901858506)]
    [TestCase(1, Link.End, 1.981323274)]
    [TestCase(1, Link.Both, 1.9295913034)]
    [TestCase(1, Link.Cycle, 3.0502625018)]

    [TestCase(2, Link.None, 1.7059013272)]
    [TestCase(2, Link.Start, 1.5342241347)]
    [TestCase(2, Link.End, 1.7200985668)]
    [TestCase(2, Link.Both, 1.6042887793)]
    [TestCase(2, Link.Cycle, 1.5734637926)]

    [TestCase(3, Link.Start, 1)]
    [TestCase(3, Link.End, 1)]
    [TestCase(3, Link.Both, 1)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 1.8027279195)]
    [TestCase(5, Link.End, 1.8027279195)]
    [TestCase(5, Link.Both, 1.8027279195)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 1.1423674442)]
    [TestCase(6, Link.End, 1.6426599588)]
    [TestCase(6, Link.Both, 1.364911137)]
    [TestCase(6, Link.Cycle, 1.1365230436)]

    [TestCase(30, Link.None, 1.5)]
    [TestCase(30, Link.Start, 1.4706584498)]
    [TestCase(30, Link.End, 1.4706584498)]
    [TestCase(30, Link.Both, 1.4929907332)]
    [TestCase(30, Link.Cycle, 2.6497375191)]
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
