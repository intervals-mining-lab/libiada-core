namespace Libiada.MarkovChains.MarkovChain;

/// <summary>
/// Chain preprocessing method.
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
    /// Loopback (usinginformation about order of the chain).
    /// </summary>
    CycleBuilding
}
