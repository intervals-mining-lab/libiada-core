namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The probability test.
/// </summary>
[TestFixture]
public class ProbabilityTests : FullCalculatorsTests<Probability>
{
    /// <summary>
    /// The sequence calculation test.
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
    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(18, 0)]
    [TestCase(19, 0.1)]
    [TestCase(20, 0.1)]
    [TestCase(21, 0.2)]
    [TestCase(22, 0.2)]
    [TestCase(24, 0.2)]
    [TestCase(26, 0.3)]
    [TestCase(29, 0.1)]
    public void SequenceCalculationTest(int index, double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }

    /// <summary>
    /// No intervals test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(3, 1)]
    [TestCase(5, 1)]
    [TestCase(7, 1)]
    public void NoIntervalsTest(int index, double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
