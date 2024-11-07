namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The depth test.
/// </summary>
[TestFixture]
public class RYSkewTests : FullCalculatorsTests<RYSkew>
{
    /// <summary>
    /// The calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(1, 0)]
    [TestCase(2, -0.4)]
    [TestCase(3, 0)]
    [TestCase(4, -1)]
    [TestCase(5, 0)]
    [TestCase(6, 0.42857142857)]
    [TestCase(7, 0)]
    [TestCase(8, -1)]
    public void CalculationTest(int index, double value)
    {
        ChainCharacteristicTest(index, Link.NotApplied, value);
    }
}
