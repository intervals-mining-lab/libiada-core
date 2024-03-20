namespace Libiada.MarkovChains.MarkovChain;

using MarkovChains.MarkovChain.Generators;

/// <summary>
/// Factory of markov chains.
/// </summary>
public class MarkovChainFactory
{
    /// <summary>
    /// Creates markov chain.
    /// </summary>
    /// <param name="method">
    /// Chain type.
    /// </param>
    /// <param name="rank">
    /// Chain's rank.
    /// </param>
    /// <param name="heterogeneityRank">
    /// Heterogeneity rank of the sequence.
    /// </param>
    /// <param name="generator">
    /// Random numbers generator.
    /// </param>
    /// <returns>
    /// Markov chain as <see cref="MarkovChainBase"/>.
    /// </returns>
    /// <exception cref="Exception">
    /// Thrown if chain type is unknown.
    /// </exception>
    public MarkovChainBase Create(GeneratingMethod method, int rank, int heterogeneityRank, IGenerator generator)
    {
        return method switch
        {
            GeneratingMethod.DynamicNotCongeneric => null,
            GeneratingMethod.StaticNotCongeneric => new MarkovChainNotCongenericStatic(rank, heterogeneityRank, generator),
            GeneratingMethod.DynamicCongeneric => null,
            GeneratingMethod.StaticCongeneric => new MarkovChainCongenericStatic(rank, generator),
            GeneratingMethod.Random => new MarkovChainRandom(rank, generator),
            _ => throw new ArgumentException("This type of markov chain does not registered in system", "method"),
        };
    }
}
