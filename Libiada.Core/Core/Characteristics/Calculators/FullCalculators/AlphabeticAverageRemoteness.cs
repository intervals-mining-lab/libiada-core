namespace Libiada.Core.Core.Characteristics.Calculators.FullCalculators;

/// <summary>
/// The average remoteness with logarithm base equals cardinality of alphabet.
/// </summary>
public class AlphabeticAverageRemoteness : IFullCalculator
{
    /// <summary>
    /// Calculation method.
    /// </summary>
    /// <param name="sequence">
    /// Source sequence.
    /// </param>
    /// <param name="link">
    /// Binding of the intervals in the sequence.
    /// </param>
    /// <returns>
    /// <see cref="double"/>
    /// Value of alphabetic average remoteness.
    /// </returns>
    public double Calculate(ComposedSequence sequence, Link link)
    {
        double geometricMean = new GeometricMean().Calculate(sequence, link);
        if (geometricMean == 0) return 0;

        int alphabetCardinality = sequence.Alphabet.Cardinality;
        if (alphabetCardinality <= 1) return 0;

        return Math.Log(geometricMean, alphabetCardinality);
    }
}
