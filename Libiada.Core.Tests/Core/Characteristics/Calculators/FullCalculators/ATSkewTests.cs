namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class ATSkewTests : FullCalculatorsTests<ATSkew>
{
    /// <summary>
    /// The calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(1, 0)]
    [TestCase(2, 0)]
    [TestCase(5, 0)]
    [TestCase(6, 0.6)]
    [TestCase(7, 0)]
    [TestCase(8, -1)]
    public void CalculationTest(int index, double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }

    /// <summary>
    /// Sequence without Adenin or Timine calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(3, 0)]
    [TestCase(4, 0)]
    public void SequenceWithoutATTest(int index, double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
