namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// The average word length tests.
/// </summary>
[TestFixture]
public class AverageWordLengthTests : FullCalculatorsTests<AverageWordLength>
{
    /// <summary>
    /// The chain calculation test.
    /// </summary>
    /// <param name="index">
    /// Full sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    [TestCase(0, 1)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 1)]
    [TestCase(4, 1)]
    [TestCase(5, 1)]
    public void ChainCalculationTest(int index, double value)
    {
        ChainCharacteristicTest(index, Link.NotApplied, value);
    }

    /// <summary>
    /// The calculation test.
    /// </summary>
    [Test]
    public void CalculationTest()
    {
        var sequence = new Chain(5)
        {
            [0] = new ValueString("bla"),
            [1] = new ValueString("blablab"),
            [2] = new ValueString("blablabla"),
            [3] = new ValueString("bla"),
            [4] = new ValueString("bla")
        };
        double actual = Calculator.Calculate(sequence, Link.NotApplied);
        Assert.That(actual, Is.EqualTo(5).Within(0.0001d));

        sequence = new Chain(10)
        {
            [0] = new ValueString("qwer"),
            [1] = new ValueString("kfjvu"),
            [2] = new ValueString("osmejbh"),
            [3] = new ValueString("sbwhjvuynr"),
            [4] = new ValueString("yuekxogh"),
            [5] = new ValueString("zxcbv"),
            [6] = new ValueString("vngjm,m"),
            [7] = new ValueString("e"),
            [8] = new ValueString("hh"),
            [9] = new ValueString("poiygtr")
        };
        actual = Calculator.Calculate(sequence, Link.NotApplied);
        Assert.That(actual, Is.EqualTo(5.6).Within(0.0001d));

        sequence = new Chain(8)
        {
            [0] = new ValueString("1234567"),
            [1] = new ValueString("890"),
            [2] = new ValueString("12"),
            [3] = new ValueString("3456"),
            [4] = new ValueString("7890123"),
            [5] = new ValueString("4567890123"),
            [6] = new ValueString("456789012"),
            [7] = new ValueString("3456789012345")
        };
        actual = Calculator.Calculate(sequence, Link.NotApplied);
        Assert.That(actual, Is.EqualTo(6.875).Within(0.0001d));
    }
}
