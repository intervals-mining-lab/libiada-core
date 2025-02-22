namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Standard Deviation test.
/// </summary>
[TestFixture]
public class IdentifyingInformationStandardDeviationTests : FullCalculatorsTests<IdentifyingInformationStandardDeviation>
{
    /// <summary>
    /// Standard Deviation test.
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
    [TestCase(0, Link.None, 0.2894813634)]
    [TestCase(0, Link.Start, 0.1460221541)]
    [TestCase(0, Link.End, 0.1702348333)]
    [TestCase(0, Link.Both, 0.1566193881)]
    [TestCase(0, Link.Cycle, 0.2033260195)]

    [TestCase(1, Link.None, 0.6540588996)]
    [TestCase(1, Link.Start, 0.4628287284)]
    [TestCase(1, Link.End, 0.2675293331)]
    [TestCase(1, Link.Both, 0.2053902959)]
    [TestCase(1, Link.Cycle, 0.2865719291)]

    [TestCase(2, Link.None, 0.7484475352)]
    [TestCase(2, Link.Start, 0.5726578196)]
    [TestCase(2, Link.End, 0.5680590212)]
    [TestCase(2, Link.Both, 0.598686688)]
    [TestCase(2, Link.Cycle, 0.8118289731)]

    [TestCase(3, Link.Start, 0.5)]
    [TestCase(3, Link.End, 0.5)]
    [TestCase(3, Link.Both, 0)]
    [TestCase(3, Link.Cycle, 0)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(5, Link.Start, 0.75110516)]
    [TestCase(5, Link.End, 0.75110516)]
    [TestCase(5, Link.Both, 0)]
    [TestCase(5, Link.Cycle, 0)]


    [TestCase(6, Link.None, 0)]
    [TestCase(6, Link.Start, 1.2791321688)]
    [TestCase(6, Link.End, 0.4292546418)]
    [TestCase(6, Link.Both, 0.6582271245)]
    [TestCase(6, Link.Cycle, 0.9897433186)]

    [TestCase(30, Link.None, 0.4714045208)]
    [TestCase(30, Link.Start, 0.4442838424)]
    [TestCase(30, Link.End, 0.1288600158)]
    [TestCase(30, Link.Both, 0.2053902959)]
    [TestCase(30, Link.Cycle, 0.2865719291)]
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
