namespace Libiada.MarkovChains.MarkovChain.Matrices.Probability;

using Libiada.Core.Core;

using MarkovChains.MarkovChain.Matrices.Absolute;

/// <summary>
/// Interface of probability matrix.
/// </summary>
public interface IProbabilityMatrix
{
    /// <summary>
    /// Fills probability matrix from another matrix.
    /// </summary>
    /// <param name="matrix">
    /// Source matrix for probability recalculation.
    /// </param>
    void Fill(IOpenMatrix matrix);

    /// <summary>
    /// Get probabilities vector at specified address.
    /// </summary>
    /// <param name="alphabet">
    /// The alphabet.
    /// </param>
    /// <param name="previous">
    /// The Address.
    /// </param>
    /// <returns>
    /// List of pairs "element - probability".
    /// </returns>
    Dictionary<IBaseObject, double> GetProbabilityVector(Alphabet alphabet, int[] previous);
}
