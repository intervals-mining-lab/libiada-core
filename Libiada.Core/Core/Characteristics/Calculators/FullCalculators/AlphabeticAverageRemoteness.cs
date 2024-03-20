namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness with logarithm base equals cardinality of alphabet.
/// </summary>
public class AlphabeticAverageRemoteness : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="chain">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Link of intervals in sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/>
    /// Value of alphabetic average remoteness.
    /// </returns>
    public double Calculate(Chain chain, Link link)
    {
        GeometricMean geometricMean = new();
        int alphabetCardinality = chain.Alphabet.Cardinality;
        return Math.Log(geometricMean.Calculate(chain, link), alphabetCardinality);
    }
}
