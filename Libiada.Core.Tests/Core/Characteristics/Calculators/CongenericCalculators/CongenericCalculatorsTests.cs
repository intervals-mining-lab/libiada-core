namespace Libiada.Core.Tests.Core.Characteristics.Calculators.CongenericCalculators;

using Libiada.Core.Core;
using Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// The calculators tests.
/// </summary>
/// <typeparam name="T">
/// Characteristic calculator type.
/// </typeparam>
public abstract class CongenericCalculatorsTests<T> where T : ICongenericCalculator, new()
{
    /// <summary>
    /// The congeneric sequences.
    /// </summary>
    private readonly List<CongenericSequence> congenericSequences = SequencesStorage.CongenericSequences;

    /// <summary>
    /// Gets or sets the calculator.
    /// </summary>
    private readonly T calculator = new();

    /// <summary>
    /// The congeneric sequence characteristic test.
    /// </summary>
    /// <param name="index">
    /// The congeneric sequence index in <see cref="SequencesStorage"/>.
    /// </param>
    /// <param name="link">
    /// The link.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    protected void CongenericSequenceCharacteristicTest(int index, Link link, double value)
    {
        Assert.That(calculator.Calculate(congenericSequences[index], link), Is.EqualTo(value).Within(0.0001d));
    }
}
