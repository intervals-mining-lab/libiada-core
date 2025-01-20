namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness asymmetry coefficient test.
/// </summary>
[TestFixture]
public class AverageRemotenessSkewnessCoefficientTests : FullCalculatorsTests<AverageRemotenessSkewnessCoefficient>
{
    /// <summary>
    /// The average remoteness asymmetry coefficient test.
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
    [TestCase(0, Link.None, 0.2887)]
    [TestCase(0, Link.Start, 0.7691)]
    [TestCase(0, Link.End, 0.2583)]
    [TestCase(0, Link.Both, -0.4341)]
    [TestCase(0, Link.Cycle, -0.4082)]

    [TestCase(2, Link.None, 0.7496522433)]
    [TestCase(2, Link.Start, 0.5195114814)]
    [TestCase(2, Link.End, 1.2615505633)]
    [TestCase(2, Link.Both, 0.4029308102)]
    [TestCase(2, Link.Cycle, 0.8748926874)]

    [TestCase(4, Link.None, 0)]
    [TestCase(4, Link.Start, 0)]
    [TestCase(4, Link.End, 0)]
    [TestCase(4, Link.Both, 0)]
    [TestCase(4, Link.Cycle, 0)]

    [TestCase(30, Link.None, 0.7071067812)]
    [TestCase(30, Link.Start, 0.4082482905)]
    [TestCase(30, Link.End, 0.4082482905)]
    [TestCase(30, Link.Both, 0.2886751346)]
    [TestCase(30, Link.Cycle, 0.4082482905)]
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
