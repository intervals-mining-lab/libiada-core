namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The remoteness kurtosis tests.
/// </summary>
[TestFixture]
public class RemotenessKurtosisTests : FullCalculatorsTests<RemotenessKurtosis>
{
    /// <summary>
    /// The remoteness kurtosis test.
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
    [TestCase(0, Link.None, 0.7589278)]
    [TestCase(0, Link.Start, 0.9619193)]
    [TestCase(0, Link.End, 0.7288246)]
    [TestCase(0, Link.Both, 0.888077)]
    [TestCase(0, Link.Cycle, 1.6655934)]

    [TestCase(1, Link.None, 1.674332994)]
    [TestCase(1, Link.Start, 1.4471693596)]
    [TestCase(1, Link.End, 1.3683536511)]
    [TestCase(1, Link.Both, 1.2688567516)]
    [TestCase(1, Link.Cycle, 1.2751326476)]

    [TestCase(2, Link.None, 1.4101100504)]
    [TestCase(2, Link.Start, 1.7828429408)]
    [TestCase(2, Link.End, 1.4114296444)]
    [TestCase(2, Link.Both, 1.6728319397)]
    [TestCase(2, Link.Cycle, 3.55665678)]

    [TestCase(3, Link.Start, 0.0625)]
    [TestCase(3, Link.End, 0.0625)]
    [TestCase(3, Link.Both, 0.0625)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 0.5737638301)]
    [TestCase(5, Link.End, 0.5737638301)]
    [TestCase(5, Link.Both, 0.5737638301)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 3.0582113959)]
    [TestCase(6, Link.End, 0.6815665337)]
    [TestCase(6, Link.Both, 2.1217880591)]
    [TestCase(6, Link.Cycle, 3.4108669694)]

    [TestCase(30, Link.None, 0.2751024121)]
    [TestCase(30, Link.Start, 0.2217903986)]
    [TestCase(30, Link.End, 0.2217903986)]
    [TestCase(30, Link.Both, 0.1918030542)]
    [TestCase(30, Link.Cycle, 0.1812587393)]
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
