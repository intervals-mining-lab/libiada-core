namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class GCSkewTests : FullCalculatorsTests<GCSkew>
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
    [TestCase(2, -0.666666666667)]
    [TestCase(3, 0)]
    [TestCase(4, -1)]
    [TestCase(5, 0)]
    [TestCase(6, 0)]
    public void CalculationTest(int index, double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }

    /// <summary>
    /// Sequence without Guanine or Cytozine calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(7, 0)]
    [TestCase(8, 0)]
    public void SequenceWithoutGCTest(int index, double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
