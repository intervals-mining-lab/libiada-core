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
    /// The sequences.
    /// </summary>
    protected readonly List<ComposedSequence> Sequences = SequencesStorage.BinarySequences;

    /// <summary>
    /// Gets or sets the calculator.
    /// </summary>
    protected readonly T Calculator = new();

    /// <summary>
    /// The elements.
    /// </summary>
    private readonly Dictionary<string, IBaseObject> elements = SequencesStorage.Elements;

    /// <summary>
    /// The calculation test.
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
    protected void CalculationTest(int index, double firstValue, double secondValue)
    {
        double result1 = Calculator.Calculate(Sequences[index].GetRelationIntervalsManager(elements["A"], elements["B"]), Link.End);
        double result2 = Calculator.Calculate(Sequences[index].GetRelationIntervalsManager(elements["B"], elements["A"]), Link.End);
        Assert.Multiple(() =>
        {
            Assert.That(result1, Is.EqualTo(firstValue).Within(0.0001));
            Assert.That(result2, Is.EqualTo(secondValue).Within(0.0001));
        });
    }
}
