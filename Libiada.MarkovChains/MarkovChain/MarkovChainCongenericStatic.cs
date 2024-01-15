namespace Libiada.MarkovChains.MarkovChain;

using MarkovChains.MarkovChain.Generators;

/// <summary>
/// Static congeneric markov chain class.
/// </summary>
public class MarkovChainCongenericStatic : MarkovChainNotCongenericStatic
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarkovChainCongenericStatic"/> class.
    /// </summary>
    /// <param name="rank">
    /// Rank of markov chain.
    /// </param>
    /// <param name="generator">
    /// Random numbers generator.
    /// </param>
    public MarkovChainCongenericStatic(int rank, IGenerator generator) : base(rank, 0, generator)
    {
    }
}
