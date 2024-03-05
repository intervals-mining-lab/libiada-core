namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The cut length vocabulary entropy test.
/// </summary>
[TestFixture]
public class CuttingLengthVocabularyEntropyTests : CongenericCalculatorsTests<CuttingLengthVocabularyEntropy>
{
    /// <summary>
    /// The congeneric calculation test.
    /// </summary>
    /// <param name="index">
    /// The congeneric sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, 2.8074)]
    public void CongenericCalculationTest(int index, double value)
    {
        CongenericChainCharacteristicTest(index, Link.NotApplied, value);
    }
}
