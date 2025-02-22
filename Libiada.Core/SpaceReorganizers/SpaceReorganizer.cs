namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;

/// <summary>
/// The space reorganizer.
/// </summary>
public abstract class SpaceReorganizer
{
    /// <summary>
    /// Reorganizes <see cref="AbstractSequence"/> into <see cref="AbstractSequence"/>.
    /// </summary>
    /// <param name="source">
    /// Source sequence.
    /// </param>
    /// <returns>
    /// The <see cref="AbstractSequence"/>.
    /// </returns>
    public abstract AbstractSequence Reorganize(AbstractSequence source);
}
