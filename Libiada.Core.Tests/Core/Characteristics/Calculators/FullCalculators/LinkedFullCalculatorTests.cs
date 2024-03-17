namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The linked full characteristic calculator tests.
/// </summary>
[TestFixture(TestOf = typeof(LinkedFullCalculator))]
public class LinkedFullCalculatorTests
{
    /// <summary>
    /// The test sequences.
    /// </summary>
    private readonly List<Chain> sequences = ChainsStorage.Chains;

    /// <summary>
    /// Linked full characteristic calculator tests.
    /// </summary>
    /// <param name="sequenceIndex">
    /// The sequence index in sequence storage.
    /// </param>
    /// <param name="type">
    /// The full characteristic type.
    /// </param>
    /// <param name="link">
    /// The characteristic link.
    /// </param>
    /// <param name="expected">
    /// The expected characteristic value.
    /// </param>
    [TestCase(0, FullCharacteristic.AverageRemoteness, Link.None, 1.0242)]
    [TestCase(0, FullCharacteristic.AverageRemoteness, Link.Start, 1.1077)]
    [TestCase(0, FullCharacteristic.AverageRemoteness, Link.End, 1.017)]
    [TestCase(0, FullCharacteristic.AverageRemoteness, Link.Both, 1.0828)]
    [TestCase(0, FullCharacteristic.AverageRemoteness, Link.Cycle, 1.234)]
    [TestCase(3, FullCharacteristic.AverageRemoteness, Link.None, 0)]
    [TestCase(1, FullCharacteristic.GCRatio, Link.NotApplied, 40)]

    public void CalculationTest(int sequenceIndex, FullCharacteristic type, Link link, double expected)
    {
        var calculator = new LinkedFullCalculator(type, link);
        double actual = calculator.Calculate(sequences[sequenceIndex]);
        Assert.That(actual, Is.EqualTo(expected).Within(0.0001d));
    }
}