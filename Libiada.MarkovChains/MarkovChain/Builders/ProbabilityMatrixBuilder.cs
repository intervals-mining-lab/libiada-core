namespace Libiada.MarkovChains.MarkovChain.Builders;

using MarkovChains.MarkovChain.Matrices.Probability;

/// <summary>
/// Probabilities matrix creation rule.
/// </summary>
public class ProbabilityMatrixBuilder : IMatrixBuilder
{
    /// <summary>
    /// The create.
    /// </summary>
    /// <param name="alphabetCardinality">
    /// The alphabet cardinality.
    /// </param>
    /// <param name="i">
    /// The dimensionality of the matrix.
    /// </param>
    /// <returns>
    /// The <see cref="object"/>.
    /// </returns>
    public object Create(int alphabetCardinality, int i)
    {
        return i switch
        {
            0 => (double)0,
            1 => new ProbabilityMatrixRow(alphabetCardinality, i),
            _ => new ProbabilityMatrix(alphabetCardinality, i),
        };
    }
}
