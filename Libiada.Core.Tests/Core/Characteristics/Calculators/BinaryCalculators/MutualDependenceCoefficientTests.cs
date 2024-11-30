namespace Libiada.Core.Tests.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

/// <summary>
/// The mutual dependence coefficient test.
/// </summary>
[TestFixture]
public class MutualDependenceCoefficientTests : BinaryCalculatorsTests<MutualDependenceCoefficient>
{
    /// <summary>
    /// The k 3 test.
    /// </summary>
    /// <param name="index">
    /// Binary sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, 0.310825552)]
    [TestCase(1, 0)]
    [TestCase(2, 0)]
    [TestCase(3, 0)]
    [TestCase(4, 0)]
    [TestCase(5, 0)]
    [TestCase(6, 0)]
    [TestCase(7, 0)]
    [TestCase(8, 0.1495)]
    [TestCase(9, 0.0788)]
    [TestCase(10, 0.4967)]
    [TestCase(11, 0.2022)]
    [TestCase(12, 0.2706)]
    [TestCase(13, 0.5147)]
    [TestCase(14, 0.4024)]
    [TestCase(15, 0.3464)]
    [TestCase(16, 0.3853)]
    [TestCase(17, 0.4776)]
    [TestCase(19, 0)]
    public void K3Test(int index, double value)
    {
        CalculationTest(index, value, value);
    }

    /// <summary>
    /// The get k 3 test.
    /// </summary>
    [Test]
    public void GetK3Test()
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
            Assert.That(result[0][1], Is.EqualTo(0.497).Within(0.001d));
            Assert.That(result[1][0], Is.EqualTo(0.497).Within(0.001d));
            Assert.That(result[1][1], Is.Zero);
        });

        result = Calculator.CalculateAll(Chains[18], Link.End);

        Assert.Multiple(() =>
        {
            Assert.That(result[0][0], Is.Zero);
            Assert.That(result[0][1], Is.EqualTo(0.397).Within(0.001d));
            Assert.That(result[0][2], Is.EqualTo(0.236).Within(0.001d));
            Assert.That(result[1][0], Is.EqualTo(0.397).Within(0.001d));
            Assert.That(result[1][1], Is.Zero);
            Assert.That(result[1][2], Is.EqualTo(0.360).Within(0.001d));
            Assert.That(result[2][0], Is.EqualTo(0.236).Within(0.001d));
            Assert.That(result[2][1], Is.EqualTo(0.360).Within(0.001d));
            Assert.That(result[2][2], Is.Zero);
        });
    }
}
