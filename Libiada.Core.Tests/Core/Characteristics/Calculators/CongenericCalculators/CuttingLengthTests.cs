namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The cut length test.
/// </summary>
[TestFixture]
public class CuttingLengthTests : CongenericCalculatorsTests<CuttingLength>
{
    /// <summary>
    /// The congeneric calculation test.
    /// </summary>
    /// <param name="index">
    /// The congeneric sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, 4)]
    public void CongenericCalculationTest(int index, double value)
    {
        CongenericSequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
