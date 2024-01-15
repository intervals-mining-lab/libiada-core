namespace Libiada.Core.Tests.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

/// <summary>
/// The binary geometric mean test.
/// </summary>
[TestFixture]
public class GeometricMeanTests : BinaryCalculatorsTests<GeometricMean>
{
    /// <summary>
    /// The spatial dependence test.
    /// </summary>
    /// <param name="index">
    /// Binary sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="firstValue">
    /// The first value.
    /// </param>
    /// <param name="secondValue">
    /// The second value.
    /// </param>
    [TestCase(0, 1.7321, 1)]
    public void SpatialDependenceTest(int index, double firstValue, double secondValue)
    {
        CalculationTest(index, firstValue, secondValue);
    }
}
