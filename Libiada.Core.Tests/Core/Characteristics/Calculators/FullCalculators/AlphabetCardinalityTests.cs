namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The alphabet cardinality test.
/// </summary>
[TestFixture]
public class AlphabetCardinalityTests : FullCalculatorsTests<AlphabetCardinality>
{
    /// <summary>
    /// The sequence calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, 3)]
    [TestCase(1, 4)]
    [TestCase(2, 4)]
    [TestCase(3, 2)]
    [TestCase(4, 1)]
    [TestCase(5, 4)]
    [TestCase(6, 4)]
    [TestCase(7, 2)]
    [TestCase(8, 1)]
    [TestCase(9, 3)]
    [TestCase(10, 3)]
    [TestCase(11, 3)]
    [TestCase(12, 3)]
    [TestCase(13, 3)]
    [TestCase(14, 3)]
    [TestCase(15, 3)]
    [TestCase(16, 3)]
    [TestCase(17, 3)]
    [TestCase(18, 0)]
    [TestCase(19, 1)]
    public void SequenceCalculationTest(int index, double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
