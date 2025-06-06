namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The probability test.
/// </summary>
[TestFixture]
public class ProbabilityTests : CongenericCalculatorsTests<Probability>
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
    [TestCase(0, 0.3)]
    public void CongenericCalculationTest(int index, double value)
    {
        CongenericSequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
