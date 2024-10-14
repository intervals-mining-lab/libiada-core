namespace Libiada.MarkovChains.MarkovChain.Matrices.Absolute;

/// <summary>
/// Interface for accessing inner data of matrix.
/// </summary>
public interface IOpenMatrix
{

    // TODO: update type
    /// <summary>
    /// Gets elements list of matrix.
    /// </summary>
    List<object> ValueList { get; }

    /// <summary>
    /// Gets rank of matrix.
    /// </summary>
    int Rank { get; }

    /// <summary>
    /// Gets value of the matrix.
    /// </summary>
    double Value { get; }
}
