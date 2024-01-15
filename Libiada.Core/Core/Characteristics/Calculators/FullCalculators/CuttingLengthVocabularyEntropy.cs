namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// Sadovsky entropy of dictionary.
/// </summary>
public class CuttingLengthVocabularyEntropy : NonLinkableFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// Cut length vocabulary entropy as <see cref="double"/>.
    /// </returns>
    public override double Calculate(Chain chain)
    {
        var cutLength = new CuttingLength();
        return Math.Log(chain.Length - cutLength.Calculate(chain) + 1, 2);
    }
}
