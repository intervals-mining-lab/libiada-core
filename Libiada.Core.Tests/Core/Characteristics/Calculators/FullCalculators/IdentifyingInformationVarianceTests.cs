namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The identifying informations (entropy) variance test.
/// </summary>
[TestFixture]
public class IdentifyingInformationVarianceTests : FullCalculatorsTests<IdentifyingInformationVariance>
{
    /// <summary>
    /// The identifying informations (entropy) variance test.
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
    [TestCase(0, Link.None, 0.0837994597)]
    [TestCase(0, Link.Start, 0.0213224695)]
    [TestCase(0, Link.End, 0.0289798985)]
    [TestCase(0, Link.Both, 0.0245296327)]
    [TestCase(0, Link.Cycle, 0.0413414702)]

    [TestCase(1, Link.None, 0.4277930442)]
    [TestCase(1, Link.Start, 0.2142104318)]
    [TestCase(1, Link.End, 0.0715719441)]
    [TestCase(1, Link.Both, 0.0421851737)]
    [TestCase(1, Link.Cycle, 0.0821234705)]

    [TestCase(2, Link.None, 0.5601737129)]
    [TestCase(2, Link.Start, 0.3279369783)]
    [TestCase(2, Link.End, 0.3226910516)]
    [TestCase(2, Link.Both, 0.3584257504)]
    [TestCase(2, Link.Cycle, 0.6590662815)]

    [TestCase(3, Link.Start, 0.25)]
    [TestCase(3, Link.End, 0.25)]
    [TestCase(3, Link.Both, 0)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 0.5641589614)]
    [TestCase(5, Link.End, 0.5641589614)]
    [TestCase(5, Link.Both, 0)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 1.6361791053)]
    [TestCase(6, Link.End, 0.1842595475)]
    [TestCase(6, Link.Both, 0.4332629475)]
    [TestCase(6, Link.Cycle, 0.9795918367)]

    [TestCase(30, Link.None, 0.2222222222)]
    [TestCase(30, Link.Start, 0.1973881326)]
    [TestCase(30, Link.End, 0.0166049037)]
    [TestCase(30, Link.Both, 0.0421851737)]
    [TestCase(30, Link.Cycle, 0.0821234705)]
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
