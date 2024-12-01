namespace Libiada.Core.Tests.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

/// <summary>
/// The normalized partial dependence coefficient test.
/// </summary>
[TestFixture]
public class NormalizedPartialDependenceCoefficientTests : BinaryCalculatorsTests<NormalizedPartialDependenceCoefficient>
{
    /// <summary>
    /// The normalized k 1 test.
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
    [TestCase(0, 0.2, 0.094680274)]
    [TestCase(1, 0, 0)]
    [TestCase(2, 0, 0)]
    [TestCase(3, 0, 0.1214)]
    [TestCase(4, 0.3, 0)]
    [TestCase(5, 0.1515, 0)]
    [TestCase(6, -1.6923, 0)]
    [TestCase(7, -0.0303, 0.0107)]
    [TestCase(8, 0.0855, 0.012)]
    [TestCase(9, 0.0047, 0.0424)]
    [TestCase(10, 0.1754, 0.0861)]
    [TestCase(11, 0.1971, 0.0127)]
    [TestCase(12, 0.0732, 0.0312)]
    [TestCase(13, 0.1426, 0.0991)]
    [TestCase(14, 0.2693, 0.0546)]
    [TestCase(15, 0.0357, 0.1458)]
    [TestCase(16, 0.0904, 0.0478)]
    [TestCase(17, 0.1401, 0.0578)]
    [TestCase(19, 0.264250038, -0.042347035)]
    public void NormalizedK1Test(int index, double firstValue, double secondValue)
    {
        CalculationTest(index, firstValue, secondValue);
    }

    /// <summary>
    /// The get normalized k 1 test.
    /// </summary>
    [Test]
    public void GetNormalizedK1Test()
    {
        List<List<double>> result = Calculator.CalculateAll(Chains[1], Link.End);

        Assert.Multiple(() =>
        {
            Assert.That(result[0][0], Is.Zero);
            Assert.That(result[0][1], Is.Zero);
            Assert.That(result[1][0], Is.Zero);
            Assert.That(result[1][1], Is.Zero);
        });

        result = Calculator.CalculateAll(Chains[10], Link.End);

        Assert.Multiple(() =>
        {
            Assert.That(result[0][0], Is.Zero);
            Assert.That(result[0][1], Is.EqualTo(0.175).Within(0.001d));
            Assert.That(result[1][0], Is.EqualTo(0.086).Within(0.001d));
            Assert.That(result[1][1], Is.Zero);
        });

        result = Calculator.CalculateAll(Chains[18], Link.End);

        Assert.Multiple(() =>
        {
            Assert.That(result[0][0], Is.Zero);
            Assert.That(result[0][1], Is.EqualTo(0.1352).Within(0.0001d));
            Assert.That(result[0][2], Is.EqualTo(0.066).Within(0.001d));
            Assert.That(result[1][0], Is.EqualTo(0.0729).Within(0.0001d));
            Assert.That(result[1][1], Is.Zero);
            Assert.That(result[1][2], Is.EqualTo(0.174).Within(0.001d));
            Assert.That(result[2][0], Is.EqualTo(0.062).Within(0.001d));
            Assert.That(result[2][1], Is.EqualTo(0.129).Within(0.001d));
            Assert.That(result[2][2], Is.Zero);
        });
    }
}
