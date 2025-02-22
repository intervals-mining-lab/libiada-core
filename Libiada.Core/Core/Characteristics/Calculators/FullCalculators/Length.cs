namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Sequence length.
/// </summary>
public class Length : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Sequence length as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        return sequence.Length;
    }
}
