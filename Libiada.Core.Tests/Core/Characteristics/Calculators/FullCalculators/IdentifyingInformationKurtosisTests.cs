namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The identifying informations (entropy) kurtosis tests.
/// </summary>
[TestFixture]
public class IdentifyingInformationKurtosisTests : FullCalculatorsTests<IdentifyingInformationKurtosis>
{
    /// <summary>
    /// The identifying informations (entropy) kurtosis test.
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
    [TestCase(0, Link.None, 0.0076075452)]
    [TestCase(0, Link.Start, 0.0007775444)]
    [TestCase(0, Link.End, 0.0014489037)]
    [TestCase(0, Link.Both, 0.000737086)]
    [TestCase(0, Link.Cycle, 0.00199397)]

    [TestCase(1, Link.None, 0.3216228368)]
    [TestCase(1, Link.Start, 0.0586189698)]
    [TestCase(1, Link.End, 0.0119570411)]
    [TestCase(1, Link.Both, 0.001927888)]
    [TestCase(1, Link.Cycle, 0.0078683085)]

    [TestCase(2, Link.None, 0.9525186474)]
    [TestCase(2, Link.Start, 0.117658279)]
    [TestCase(2, Link.End, 0.2717006183)]
    [TestCase(2, Link.Both, 0.1918030542)]
    [TestCase(2, Link.Cycle, 0.8009746706)]

    [TestCase(3, Link.Start, 0.0625)]
    [TestCase(3, Link.End, 0.0625)]
    [TestCase(3, Link.Both, 0)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 0.5737638301)]
    [TestCase(5, Link.End, 0.5737638301)]
    [TestCase(5, Link.Both, 0)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 3.0582113959)]
    [TestCase(6, Link.End, 0.1143755081)]
    [TestCase(6, Link.Both, 0.1939740077)]
    [TestCase(6, Link.Cycle, 1.0395668471)]

    [TestCase(30, Link.None, 0.0740740741)]
    [TestCase(30, Link.Start, 0.045455754)]
    [TestCase(30, Link.End, 0.0003216766)]
    [TestCase(30, Link.Both, 0.001927888)]
    [TestCase(30, Link.Cycle, 0.0078683085)]
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
