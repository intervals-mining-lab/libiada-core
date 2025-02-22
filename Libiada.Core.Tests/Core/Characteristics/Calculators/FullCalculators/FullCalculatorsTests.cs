namespace Libiada.Core.Tests.Core.Characteristics.Calculators.FullCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.ArrangementManagers;
using Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The abstract calculator test.
/// </summary>
/// <typeparam name="T">
/// Calculator type.
/// </typeparam>
public abstract class FullCalculatorsTests<T> where T : IFullCalculator, new ()
{
    /// <summary>
    /// The sequences.
    /// </summary>
    private readonly List<ComposedSequence> sequences = SequencesStorage.CompusedSequences;

    /// <summary>
    /// Gets or sets the calculator.
    /// </summary>
    protected readonly T Calculator = new();

    /// <summary>
    /// The sequence characteristic test.
    /// </summary>
    /// <param name="index">
    /// The sequence index.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The expected value.
    /// </param>
    protected void SequenceCharacteristicTest(int index, Link link, double value)
    {
        Assert.That(Calculator.Calculate(sequences[index], link), Is.EqualTo(value).Within(0.0001d));
    }

    /// <summary>
    /// The series characteristic test.
    /// </summary>
    /// <param name="index">
    /// The sequence index.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The expected value.
    /// </param>
    protected void SeriesCharacteristicTest(int index, Link link, double value)
    {
        sequences[index].SetArrangementManagers(ArrangementType.Series);
        Assert.That(Calculator.Calculate(sequences[index], link), Is.EqualTo(value).Within(0.0001d));
    }
}
