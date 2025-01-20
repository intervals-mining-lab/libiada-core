namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Sadovsky entropy of dictionary.
/// </summary>
public class CuttingLengthVocabularyEntropy : NonLinkableCongenericCalculator
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
    public override double Calculate(CongenericSequence sequence)
    {
        double cuttingLength = new CuttingLength().Calculate(sequence);

        return Math.Log(sequence.Length - cuttingLength + 1, 2);
    }

}
