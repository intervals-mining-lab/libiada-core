namespace Libiada.Core.SpaceReorganizers;

using Libiada.Core.Core;
using Libiada.Core.Core.SimpleTypes;

/// <summary>
/// Not phantom reorganizer.
/// </summary>
public class SpaceNotPhantomReorganizer : SpaceReorganizer
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
            IBaseObject element = (source[i] as ValuePhantom)?[0] ?? source[i];
            elements.Add(element);
        }

        return new Sequence(elements);
    }
}
