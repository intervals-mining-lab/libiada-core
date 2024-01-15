namespace Libiada.MarkovChains.MarkovChain.Matrices.Absolute;

using System.Collections;

/// <summary>
/// Interface for accessing inner data of matrix.
/// </summary>
public interface IOpenMatrix
{
    /// <summary>
    /// Gets elements list of matrix.
    /// </summary>
    ArrayList ValueList { get; }

    /// <summary>
    /// Gets rank of matrix.
    /// </summary>
    int Rank { get; }

    /// <summary>
    /// Gets value of the matrix.
    /// </summary>
    double Value { get; }
}
