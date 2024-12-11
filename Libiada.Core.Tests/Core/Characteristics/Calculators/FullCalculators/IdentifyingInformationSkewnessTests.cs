namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The identifying informations (entropy) asymmetry test.
/// </summary>
[TestFixture]
public class IdentifyingInformationSkewnessTests : FullCalculatorsTests<IdentifyingInformationSkewness>
{
    /// <summary>
    /// The identifying informations (entropy) asymmetry test.
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
    [TestCase(0, Link.None, 0.0070027916)]
    [TestCase(0, Link.Start, 0.0019081519)]
    [TestCase(0, Link.End, -0.003475505)]
    [TestCase(0, Link.Both, -0.0018223334)]
    [TestCase(0, Link.Cycle, -0.0034316521)]

    [TestCase(1, Link.None, 0.0353815658)]
    [TestCase(1, Link.Start, 0.0359251193)]
    [TestCase(1, Link.End, 0.0142580512)]
    [TestCase(1, Link.Both, 0.0025012041)]
    [TestCase(1, Link.Cycle, 0.0096078301)]

    [TestCase(2, Link.None, 0.1366238006)]
    [TestCase(2, Link.Start, 0.0127627739)]
    [TestCase(2, Link.End, 0.2050350246)]
    [TestCase(2, Link.Both, 0.0120652538)]
    [TestCase(2, Link.Cycle, 0.2306313714)]

    [TestCase(3, Link.Start, 0)]
    [TestCase(3, Link.End, 0)]
    [TestCase(3, Link.Both, 0)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, -0.2005956445)]
    [TestCase(5, Link.End, -0.2005956445)]
    [TestCase(5, Link.Both, 0)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 0.6688715333)]
    [TestCase(6, Link.End, -0.0198625829)]
    [TestCase(6, Link.Both, -0.0520674966)]
    [TestCase(6, Link.Cycle, 0.2798833819)]

    [TestCase(30, Link.None, 0.0740740741)]
    [TestCase(30, Link.Start, 0.0358018882)]
    [TestCase(30, Link.End, 0.0008735322)]
    [TestCase(30, Link.Both, 0.0025012041)]
    [TestCase(30, Link.Cycle, 0.0096078301)]
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
