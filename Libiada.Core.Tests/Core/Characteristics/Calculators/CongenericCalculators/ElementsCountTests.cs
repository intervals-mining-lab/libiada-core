namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The elements count test.
/// </summary>
[TestFixture]
public class ElementsCountTests : CongenericCalculatorsTests<ElementsCount>
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
    [TestCase(0, 3)]
    [TestCase(1, 4)]
    [TestCase(2, 1)]
    [TestCase(3, 1)]
    [TestCase(4, 3)]
    [TestCase(5, 5)]
    public void CongenericCalculationTest(int index, double value)
    {
        CongenericSequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
