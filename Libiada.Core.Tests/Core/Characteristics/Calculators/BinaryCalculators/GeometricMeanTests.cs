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
    /// Binary sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="firstValue">
    /// The first value.
    /// </param>
    /// <param name="secondValue">
    /// The second value.
    /// </param>
    [TestCase(0, 1.7321, 1)]
    [TestCase(1, 1, 0)]
    [TestCase(2, 3, 0)]
    [TestCase(3, 4.527019056, 2.080083823)]
    [TestCase(4, 1, 0)]
    [TestCase(5, 1, 0)]
    [TestCase(6, 12, 0)]
    [TestCase(7, 6.92820323, 1)]
    [TestCase(8, 2.289428485, 3.464101615)]
    [TestCase(9, 5.360108411, 1)]
    [TestCase(10, 2, 2.5198421)]
    [TestCase(11, 1.861209718, 5.59344471)]
    [TestCase(12, 4, 4)]
    [TestCase(13, 3, 2.466212074)]
    [TestCase(14, 1, 3.556893304)]
    [TestCase(15, 1, 1)]
    [TestCase(16, 4.30886938, 3)]
    [TestCase(17, 3.036588972, 4)]
    [TestCase(19, 1, 5.646216173)]
    public void SpatialDependenceTest(int index, double firstValue, double secondValue)
    {
        CalculationTest(index, firstValue, secondValue);
    }
}
