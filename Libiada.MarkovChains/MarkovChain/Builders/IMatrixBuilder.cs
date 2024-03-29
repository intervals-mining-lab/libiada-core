namespace Libiada.MarkovChains.MarkovChain.Builders;

/// <summary>
/// Interface of matrix creation rule.
/// </summary>
public interface IMatrixBuilder
{
    /// <summary>
    /// Creates element of matrix.
    /// </summary>
    /// <param name="alphabetCardinality">
    /// Alphabet cardinality.
    /// </param>
    /// <param name="i">
    /// The dimensionality of the created element.
    /// </param>
    /// <returns>
    /// Element of matrix.
    /// </returns>
    object Create(int alphabetCardinality, int i);
}
