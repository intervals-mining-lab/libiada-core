namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;

/// <summary>
/// The space reorganizer.
/// </summary>
public abstract class SpaceReorganizer
{
    /// <summary>
    /// Reorganizes <see cref="AbstractChain"/> into <see cref="AbstractChain"/>.
    /// </summary>
    /// <param name="source">
    /// Source chain.
    /// </param>
    /// <returns>
    /// The <see cref="AbstractChain"/>.
    /// </returns>
    public abstract AbstractChain Reorganize(AbstractChain source);
}
