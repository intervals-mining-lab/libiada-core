namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Space phantom reorganizer.
/// </summary>
public class SpacePhantomReorganizer : SpaceReorganizer
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
    public override AbstractSequence Reorganize(AbstractSequence source)
    {
        List<IBaseObject> elements = [];

        for (int i = 0; i < source.Length; i++)
        {
            elements.Add(source[i] as ValuePhantom ?? [source[i]]);
        }

        return new Sequence(elements);
    }
}
