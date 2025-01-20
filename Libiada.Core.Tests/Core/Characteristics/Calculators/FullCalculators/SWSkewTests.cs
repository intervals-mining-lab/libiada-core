namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class SWSkewTests : FullCalculatorsTests<SWSkew>
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
    [TestCase(1, -0.2)]
    [TestCase(2, 0.2)]
    [TestCase(3, 1)]
    [TestCase(4, 1)]
    [TestCase(5, 0)]
    [TestCase(6, -0.42857142857)]
    [TestCase(7, -1)]
    [TestCase(8, -1)]
    public void CalculationTest(int index, double value)
    {
        SequenceCharacteristicTest(index, Link.NotApplied, value);
    }
}
