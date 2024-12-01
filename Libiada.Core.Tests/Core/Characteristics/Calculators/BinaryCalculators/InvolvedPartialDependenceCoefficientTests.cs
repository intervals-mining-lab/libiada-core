namespace Libiada.Core.Tests.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

/// <summary>
/// The involved partial dependence coefficient test.
/// </summary>
[TestFixture]
public class InvolvedPartialDependenceCoefficientTests : BinaryCalculatorsTests<InvolvedPartialDependenceCoefficient>
{
    /// <summary>
    /// The k 2 test.
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
    [TestCase(0, 0.285714286, 0.338143834)]
    [TestCase(1, 0, 0)]
    [TestCase(2, 0, 0)]
    [TestCase(3, 0, 0.5461)]
    [TestCase(4, 0.75, 0)]
    [TestCase(5, 0.9091, 0)]
    [TestCase(6, -11, 0)]
    [TestCase(7, -0.1997, 0.1697)]
    [TestCase(8, 0.2138, 0.1046)]
    [TestCase(9, 0.0152, 0.4098)]
    [TestCase(10, 0.6139, 0.4019)]
    [TestCase(11, 0.6898, 0.0592)]
    [TestCase(12, 0.2929, 0.25)]
    [TestCase(13, 0.5347, 0.4955)]
    [TestCase(14, 0.7741, 0.2092)]
    [TestCase(15, 0.3429, 0.35)]
    [TestCase(16, 0.3745, 0.3965)]
    [TestCase(17, 0.6072, 0.3757)]
    [TestCase(19, 0.759718859, -0.162330299)]
    public void K2Test(int index, double firstValue, double secondValue)
    {
        CalculationTest(index, firstValue, secondValue);
    }

    /// <summary>
    /// The get k 2 test.
    /// </summary>
    [Test]
    public void GetK2Test()
    {
        List<List<double>> result = Calculator.CalculateAll(Chains[1], Link.End);

        Assert.That(result[0][0], Is.Zero);
        Assert.That(result[0][1], Is.Zero);
        Assert.That(result[1][0], Is.Zero);
        Assert.That(result[1][1], Is.Zero);

        result = Calculator.CalculateAll(Chains[10], Link.End);

        Assert.That(result[0][0], Is.Zero);
        Assert.That(Math.Round(result[0][1], 3), Is.EqualTo(0.614));
        Assert.That(Math.Round(result[1][0], 3), Is.EqualTo(0.402));
        Assert.That(result[1][1], Is.Zero);

        result = Calculator.CalculateAll(Chains[18], Link.End);

        Assert.That(result[0][0], Is.Zero);
        Assert.That(Math.Round(result[0][1], 4), Is.EqualTo(0.5407));
        Assert.That(Math.Round(result[0][2], 3), Is.EqualTo(0.296));
        Assert.That(Math.Round(result[1][0], 3), Is.EqualTo(0.292));
        Assert.That(result[1][1], Is.Zero);
        Assert.That(Math.Round(result[1][2], 3), Is.EqualTo(0.418));
        Assert.That(Math.Round(result[2][0], 4), Is.EqualTo(0.1875));
        Assert.That(Math.Round(result[2][1], 3), Is.EqualTo(0.311));
        Assert.That(result[2][2], Is.Zero);
    }
}
