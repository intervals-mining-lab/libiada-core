﻿namespace Libiada.Core.Tests.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

/// <summary>
/// The partial dependence coefficient test.
/// </summary>
[TestFixture]
public class PartialDependenceCoefficientTests : BinaryCalculatorsTests<PartialDependenceCoefficient>
{
    /// <summary>
    /// The k 1 test.
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
    [TestCase(0, 0.5, 0.236700684)]
    [TestCase(1, 0, 0)]
    [TestCase(2, 0, 0)]
    [TestCase(3, 0, 0.5461)]
    [TestCase(4, 0.75, 0)]
    [TestCase(5, 0.9091, 0)]
    [TestCase(6, -11, 0)]
    [TestCase(7, -0.2197, 0.1556)]
    [TestCase(8, 0.3563, 0.0747)]
    [TestCase(9, 0.0227, 0.3074)]
    [TestCase(10, 0.6139, 0.4019)]
    [TestCase(11, 0.6898, 0.0592)]
    [TestCase(12, 0.2929, 0.25)]
    [TestCase(13, 0.5347, 0.4955)]
    [TestCase(14, 0.7741, 0.2092)]
    [TestCase(15, 0.2143, 0.875)]
    [TestCase(16, 0.4369, 0.3469)]
    [TestCase(17, 0.6072, 0.3757)]
    [TestCase(19, 0.759718859, -0.162330299)]
    public void K1Test(int index, double firstValue, double secondValue)
    {
        CalculationTest(index, firstValue, secondValue);
    }

    /// <summary>
    /// The get k 1 test.
    /// </summary>
    [Test]
    public void GetK1Test()
    {
        List<List<double>> result = Calculator.CalculateAll(Sequences[1], Link.End);

        Assert.Multiple(() =>
        {
            Assert.That(result[0][0], Is.Zero);
            Assert.That(result[0][1], Is.Zero);
            Assert.That(result[1][0], Is.Zero);
            Assert.That(result[1][1], Is.Zero);
        });

        result = Calculator.CalculateAll(Sequences[10], Link.End);

        Assert.Multiple(() =>
        {
            Assert.That(result[0][0], Is.Zero);
            Assert.That(result[0][1], Is.EqualTo(0.614).Within(0.001d));
            Assert.That(result[1][0], Is.EqualTo(0.402).Within(0.001d));
            Assert.That(result[1][1], Is.Zero);
        });

        result = Calculator.CalculateAll(Sequences[18], Link.End);

        Assert.Multiple(() =>
        {
            Assert.That(result[0][0], Is.Zero);
            Assert.That(result[0][1], Is.EqualTo(0.4055).Within(0.0001d));
            Assert.That(result[0][2], Is.EqualTo(0.197).Within(0.001d));
            Assert.That(result[1][0], Is.EqualTo(0.4375).Within(0.0001d));
            Assert.That(result[1][1], Is.Zero);
            Assert.That(result[1][2], Is.EqualTo(0.349).Within(0.001d));
            Assert.That(result[2][0], Is.EqualTo(0.375).Within(0.001d));
            Assert.That(result[2][1], Is.EqualTo(0.388).Within(0.001d));
            Assert.That(result[2][2], Is.Zero);
        });
    }
}
