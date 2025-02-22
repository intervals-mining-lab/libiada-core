namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The length test.
/// </summary>
[TestFixture]
public class LengthTests : FullCalculatorsTests<Length>
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
    [TestCase(0, 10)]
    [TestCase(1, 10)]
    [TestCase(2, 10)]
    [TestCase(3, 2)]
    [TestCase(4, 4)]
    [TestCase(5, 4)]
    [TestCase(6, 7)]
    [TestCase(7, 2)]
    [TestCase(8, 4)]
    [TestCase(9, 9)]
    [TestCase(10, 9)]
    [TestCase(11, 9)]
    [TestCase(12, 9)]
    [TestCase(13, 9)]
    [TestCase(14, 9)]
    [TestCase(15, 9)]
    [TestCase(16, 9)]
    [TestCase(17, 9)]
    [TestCase(18, 10)]
    [TestCase(19, 10)]
    public void SequenceCalculationTest(int index,  double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
