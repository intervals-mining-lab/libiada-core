namespace Libiada.Core.Tests.Core.Characteristics.Calculators.BinaryCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.BinaryCalculators;

/// <summary>
/// The abstract binary calculator test.
/// </summary>
/// <typeparam name="T">
/// Characteristic calculator type.
/// </typeparam>
public abstract class BinaryCalculatorsTests<T> where T : IBinaryCalculator, new()
{
    /// <summary>
    /// The chains.
    /// </summary>
    protected readonly List<Chain> Chains = ChainsStorage.BinaryChains;

    /// <summary>
    /// Gets or sets the calculator.
    /// </summary>
    protected readonly T Calculator = new T();

    /// <summary>
    /// The elements.
    /// </summary>
    private readonly Dictionary<string, IBaseObject> elements = ChainsStorage.Elements;

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
        double result1 = Calculator.Calculate(Chains[index].GetRelationIntervalsManager(elements["A"], elements["B"]), Link.End);
        double result2 = Calculator.Calculate(Chains[index].GetRelationIntervalsManager(elements["B"], elements["A"]), Link.End);
        Assert.AreEqual(firstValue, result1, 0.0001);
        Assert.AreEqual(secondValue, result2, 0.0001);
    }
}
