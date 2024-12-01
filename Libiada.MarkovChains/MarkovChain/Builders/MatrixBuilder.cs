namespace Libiada.MarkovChains.MarkovChain.Builders;

using MarkovChains.MarkovChain.Matrices.Absolute;

/// <summary>
/// Matrix of absolute (numeric) values creation rule.
/// </summary>
public class MatrixBuilder : IMatrixBuilder
{
    /// <summary>
    /// Creates matrix.
    /// </summary>
    /// <param name="alphabetCardinality">
    /// Alphabet cardinality.
    /// </param>
    /// <param name="i">
    /// The dimensionality of the matrix.
    /// </param>
    /// <returns>
    /// Element of matrix as <see cref="object"/>.
    /// </returns>
    public object Create(int alphabetCardinality, int i)
    {
        return i switch
        {
            0 => (double)0,
            1 => new MatrixRow(alphabetCardinality, i),
            _ => new Matrix(alphabetCardinality, i),
        };
    }
}
