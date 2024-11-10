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
        double geometricMean = new GeometricMean().Calculate(chain, link);
        if (geometricMean == 0) return 0;

        int alphabetCardinality = chain.Alphabet.Cardinality;
        if (alphabetCardinality <= 1) return 0;

        return Math.Log(geometricMean, alphabetCardinality);
    }
}
