namespace Libiada.Core.Tests.Core.Characteristics.Calculators.AccordanceCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.AccordanceCalculators;

/// <summary>
/// The accordance calculators tests.
/// </summary>
/// <typeparam name="T">
/// Characteristic calculator type
/// </typeparam>
public abstract class AccordanceCalculatorsTests<T> where T : IAccordanceCalculator, new()
{
    /// <summary>
    /// The binary chains.
    /// </summary>
    private readonly List<Chain> binaryChains = ChainsStorage.BinaryChains;

    /// <summary>
    /// The congeneric chains.
    /// </summary>
    private readonly List<CongenericChain> congenericChains = ChainsStorage.CongenericChains;

    /// <summary>
    /// The elements.
    /// </summary>
    private readonly Dictionary<string, IBaseObject> elements = ChainsStorage.Elements;

    /// <summary>
    /// Gets or sets the calculator.
    /// </summary>
    private readonly T calculator = new();

    /// <summary>
    /// The calculation test.
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
    protected void CalculationTest(int index, double firstValue, double secondValue)
    {
        CongenericChain firstChain = binaryChains[index].CongenericChain(elements["A"]);
        CongenericChain secondChain = binaryChains[index].CongenericChain(elements["B"]);
        double result1 = calculator.Calculate(firstChain, secondChain, Link.End);
        double result2 = calculator.Calculate(secondChain, firstChain, Link.End);
        Assert.That(result1, Is.EqualTo(firstValue).Within(0.0001d));
        Assert.That(result2, Is.EqualTo(secondValue).Within(0.0001d));
    }

    /// <summary>
    /// The calculation test.
    /// </summary>
    /// <param name="firstIndex">
    /// First congeneric sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="secondIndex">
    /// Second congeneric sequence index in <see cref="ChainsStorage"/>.
    /// </param>
    /// <param name="firstValue">
    /// The first value.
    /// </param>
    protected void CalculationTest(int firstIndex, int secondIndex, double firstValue)
    {
        double result = calculator.Calculate(congenericChains[firstIndex], congenericChains[secondIndex], Link.End);
        Assert.That(result, Is.EqualTo(firstValue).Within(0.0001d));
    }
}
