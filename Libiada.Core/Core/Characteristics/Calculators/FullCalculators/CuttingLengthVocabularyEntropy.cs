namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Sadovsky entropy of dictionary.
/// </summary>
public class CuttingLengthVocabularyEntropy : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Cut length vocabulary entropy as <see cref="double"/>.
    /// </returns>
    public override double Calculate(ComposedSequence sequence)
    {
        double cutLength = new CuttingLength().Calculate(sequence);
        return Math.Log2(sequence.Length - cutLength + 1);
    }
}
