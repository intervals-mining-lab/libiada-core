namespace Libiada.MarkovChains.MarkovChain.Generators;

/// <summary>
/// Interface of random numbers generator.
/// </summary>
public interface IGenerator
{
    /// <summary>
    /// Reset to initial state.
    /// </summary>
    void Reset();

    /// <summary>
    /// Gets next value of pseudorandom generator.
    /// </summary>
    /// <returns>
    /// Value in [0..1] interval.
    /// </returns>
    double Next();
}
