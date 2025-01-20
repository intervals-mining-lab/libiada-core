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
    /// The binary sequences.
    /// </summary>
    private readonly List<ComposedSequence> binarySequences = SequencesStorage.BinarySequences;

    /// <summary>
    /// The congeneric sequences.
    /// </summary>
    private readonly List<CongenericSequence> congenericSequences = SequencesStorage.CongenericSequences;

    /// <summary>
    /// The elements.
    /// </summary>
    private readonly Dictionary<string, IBaseObject> elements = SequencesStorage.Elements;

    /// <summary>
    /// Gets or sets the calculator.
    /// </summary>
    private readonly T calculator = new();

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
        CongenericSequence firstSequence = binarySequences[index].CongenericSequence(elements["A"]);
        CongenericSequence secondSequence = binarySequences[index].CongenericSequence(elements["B"]);
        double result1 = calculator.Calculate(firstSequence, secondSequence, Link.End);
        double result2 = calculator.Calculate(secondSequence, firstSequence, Link.End);
        Assert.Multiple(() =>
        {
            Assert.That(result1, Is.EqualTo(firstValue).Within(0.0001d));
            Assert.That(result2, Is.EqualTo(secondValue).Within(0.0001d));
        });
    }

    /// <summary>
    /// The calculation test.
    /// </summary>
    /// <param name="firstIndex">
    /// First congeneric sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="secondIndex">
    /// Second congeneric sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="firstValue">
    /// The first value.
    /// </param>
    protected void CalculationTest(int firstIndex, int secondIndex, double firstValue)
    {
        double result = calculator.Calculate(congenericSequences[firstIndex], congenericSequences[secondIndex], Link.End);
        Assert.That(result, Is.EqualTo(firstValue).Within(0.0001d));
    }
}
