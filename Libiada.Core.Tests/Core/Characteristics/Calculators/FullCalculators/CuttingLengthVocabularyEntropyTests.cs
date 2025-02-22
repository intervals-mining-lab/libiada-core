namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The cut length vocabulary entropy test.
/// </summary>
[TestFixture]
public class CuttingLengthVocabularyEntropyTests : FullCalculatorsTests<CuttingLengthVocabularyEntropy>
{
    /// <summary>
    /// The calculation test.
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
    [TestCase(0, 3)]
    public void CalculationTest(int index, double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
