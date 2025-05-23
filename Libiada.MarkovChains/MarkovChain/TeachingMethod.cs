namespace Libiada.MarkovChains.MarkovChain;

/// <summary>
/// Sequence preprocessing method.
/// </summary>
public enum TeachingMethod
{
    /// <summary>
    /// No preprocessing.
    /// </summary>
    None,

    /// <summary>
    /// Loopback (using statistical data).
    /// </summary>
    Cycle,

    /// <summary>
    /// Loopback (using information about order of the sequence).
    /// </summary>
    CycleOrder
}
