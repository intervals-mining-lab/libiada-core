namespace Libiada.Core.Core.Characteristics.Calculators.CongenericCalculators;

/// <summary>
/// Sadovsky entropy of dictionary.
/// </summary>
public class CuttingLengthVocabularyEntropy : NonLinkableCongenericCalculator
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
    public override double Calculate(CongenericChain chain)
    {
        double cuttingLength = new CuttingLength().Calculate(chain);

        return Math.Log(chain.Length - cuttingLength + 1, 2);
    }

}
