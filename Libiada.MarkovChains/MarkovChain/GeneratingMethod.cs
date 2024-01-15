namespace Libiada.MarkovChains.MarkovChain;

/// <summary>
/// Enumeration of markov chain types.
/// </summary>
[Serializable]
public enum GeneratingMethod
{
    /// <summary>
    /// Congeneric markov chain.
    /// Probabilities does not depend on the step.
    /// </summary>
    StaticCongeneric,

    /// <summary>
    /// Not congeneric (dissimilar) markov chain.
    /// Probabilities does not depend on the step.
    /// </summary>
    StaticNotCongeneric,

    /// <summary>
    /// Congeneric markov chain.
    /// Probabilities depends on the step.
    /// </summary>
    DynamicCongeneric,

    /// <summary>
    /// Not congeneric (dissimilar) markov chain.
    /// Probabilities depends on the step.
    /// </summary>
    DynamicNotCongeneric,

    /// <summary>
    /// The random.
    /// </summary>
    Random
}
